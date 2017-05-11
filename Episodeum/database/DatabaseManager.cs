using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Episodeum.database.model;
using Episodeum.util;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace Episodeum.database {

	/// <summary>
	/// Handles a database connection.
	/// </summary>
	public class DatabaseManager {
		private static readonly string DB_PATH = @"D:\Dropbox\C# projects\Episodeum\database\episodeum.sqlite";

		private static readonly int VERSION = 1;

		public SQLiteConnection Connection { get; }

		public DatabaseManager() {
			Connection = new SQLiteConnection(DB_PATH);
		}

		public int LastRowId {
			get {
				return Connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
			}
		}

		internal bool SaveFilmography<T>(T entity, bool newFilmographyToUser) where T : Filmography, new() {

			Filmography existing = null;
			FilmographyType.Value type;

			TableQuery<T> query = Connection.Table<T>().Where(f => f.TmdbId == entity.TmdbId);

			existing = query.Count() > 0 ? query.First() : null;

			if(entity is Series) {
				type = FilmographyType.Value.SERIES;
			} else if(entity is Season) {
				type = FilmographyType.Value.SEASON;
			} else if(entity is Episode) {
				type = FilmographyType.Value.EPISODE;
			} else {
				throw new NotSupportedException();
			}

			if(existing == null) {
				if(Connection.Insert(entity) == 0)
					return false;
			} else {
				entity.Id = existing.Id;
				if(Connection.Update(entity) == 0)
					return false;
			}

			if(newFilmographyToUser) {
				FilmographyToUser ftu = new FilmographyToUser();
				ftu.FilmographyId = entity.GetId();
				ftu.FilmographyTypeId = (int) type;
				ftu.UserId = App.Instance.User.GetId();
				ftu.Finished = false;
				ftu.SecondsWatched = 0;
				ftu.SetLastActivityDate(DateTime.Now);

				ftu.PrintValues();

				TableQuery<FilmographyToUser> ftuQuery = Connection.Table<FilmographyToUser>().Where(
						f => f.UserId == ftu.UserId
						&& f.FilmographyId == ftu.FilmographyId
						&& f.FilmographyTypeId == ftu.FilmographyTypeId);

				FilmographyToUser existingFtu = ftuQuery.Count() > 0 ? ftuQuery.First() : null;

				if(existingFtu == null) {
					if(Connection.Insert(ftu) == 0)
						return false;
				} else {
					ftu.Id = existingFtu.Id;
					if(Connection.Update(ftu) == 0)
						return false;
				}
			}

			return true;
		}

		internal T GetTypeByName<T>(string name) where T : model.Type, new() {
			return Connection.Table<T>().Where(t => t.Name == name).First<T>();
		}

		internal List<UserStatistics> GetUserStatistics() {
			return Connection.Table<UserStatistics>().Where(us => us.UserId == App.Instance.User.Id).ToList();
		}

		internal List<Series> GetSavedShows() {
			return GetJoin<Series, FilmographyToUser>(
				s => s.Id,
				ftu => ftu.FilmographyId,
				"B.user_id=" + App.Instance.User.GetId()
				+ " and B.filmography_type_id=" + (int) FilmographyType.Value.SERIES
				+ " order by B.last_activity_date DESC");
		}

		internal bool IsLastEpisodeInSeason(Episode episode) {
			string query = "select e.* from episode e "
				+ "join (select e._id, max(e.episode_number) from episode e "
					+ "where e.season_id = " + episode.SeasonId
				+ ") e2 "
				+ "where e._id = e2._id;";

			Console.WriteLine("query: " + query);

			List<Episode> tq = Connection.Query<Episode>(query, new object[] { });

			return tq.Count() > 0 ? tq.First().Id == episode.Id : false;
		}

		internal Episode GetNextEpisode(Series series) {
			series.PrintValues();
			string query =
				"select e.* from episode e"
				+ " join (select e._id, min(e.episode_number) from episode e"
					+ " join filmography_to_user ftu on ftu.filmography_id = e._id"
					+ " join (select s._id, min(s.season_number) from season s"
									+ " join filmography_to_user ftu on ftu.filmography_id = s._id"
									+ " where ftu.filmography_type_id = " + (int) FilmographyType.Value.SEASON
									+ " and ftu.finished = 0"
									+ " and ftu.user_id = " + App.Instance.User.GetId()
									+ " and s.series_id = " + series.GetId()
									+ " and s.season_number > 0"
					+ ") s on e.season_id = s._id"
					+ " where ftu.filmography_type_id = " + (int) FilmographyType.Value.EPISODE
					+ " and ftu.finished = 0"
					+ " and ftu.user_id = " + App.Instance.User.GetId()
				+ ") e2 on e._id = e2._id;";

			Console.WriteLine("query: " + query);

			List<Episode> tq = Connection.Query<Episode>(query, new object[] { });

			return tq.Count() > 0 ? tq.First() : null;
		}

		/// <summary>
		/// Gets entities from table joined with another table on their given properties.
		/// </summary>
		/// <typeparam name="A"></typeparam>
		/// <typeparam name="B"></typeparam>
		/// <param name="propertyA"></param>
		/// <param name="propertyB"></param>
		/// <param name="whereB"></param>
		/// <returns></returns>
		internal List<A> GetJoin<A, B>(Expression<Func<A, object>> propertyA, Expression<Func<B, object>> propertyB,
			string where)
			
			where A : Model, new()
			where B : Model, new() {

			string tableA = GetTableName<A>();
			string tableB = GetTableName<B>();

			string query = string.Format("select A.* from {0} A join {1} B on A.{2} = B.{3} where {4}",
				tableA,
				tableB,
				GetPropColumn(propertyA),
				GetPropColumn(propertyB),
				where);

			Console.WriteLine("query: " + query);

			return Connection.Query<A>(query, new object[] { });
		}

		/// <summary>
		/// Gets table name of given Model class (reads attribute value).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private string GetTableName<T>() where T : Model {
			return ((TableAttribute) typeof(T)
				.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault()).Name;
		}

		/// <summary>
		/// Gets table name of given Model class (reads attribute value).
		/// </summary>
		/// <param name="classType"></param>
		/// <returns></returns>
		private string GetTableName(System.Type classType) {

			return ((TableAttribute) classType
				.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault()).Name;
		}

		/// <summary>
		/// Gets column name of given property of a Model class (reads attribute value).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propName"></param>
		/// <returns></returns>
		private string GetColumnName<T>(string propName) where T : Model {
			return ((ColumnAttribute) typeof(T).GetProperty(propName)
				.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault()).Name;
		}

		/// <summary>
		/// Gets column name of given property of a Model class (reads attribute value).
		/// </summary>
		/// <param name="classType"></param>
		/// <param name="propName"></param>
		/// <returns></returns>
		private string GetColumnName(System.Type classType, string propName) {
			return ((ColumnAttribute) classType.GetProperty(propName)
				.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault()).Name;
		}

		/// <summary>
		/// Parses SQL text from expression. (Substitutes class type with table name and properties with column names.)
		/// </summary>
		/// <typeparam name="C"></typeparam>
		/// <param name="exp"></param>
		/// <returns></returns>
		private string GetSqlText<A, B>(Expression<Func<A, B, bool>> exp)
			where A : Model
			where B : Model {
			string expBody = exp.Body.ToString();

			

			string classNameA = exp.Parameters[0].Name;
			string tableNameA = GetTableName(exp.Parameters[0].Type);

			string classNameB = exp.Parameters[1].Name;
			string tableNameB = GetTableName(exp.Parameters[1].Type);

			expBody = ReplacePropertyValues<A>(expBody, classNameA, tableNameA);
			expBody = ReplacePropertyValues<B>(expBody, classNameB, tableNameB);

			return expBody;
		}

		private object GetValue(MemberExpression member) {
			var objectMember = Expression.Convert(member, typeof(object));

			var getterLambda = Expression.Lambda<Func<object>>(objectMember);

			var getter = getterLambda.Compile();

			return getter();
		}

		private string ReplacePropertyValues<T>(string query, string className, string tableName)
			where T : Model {

			// gets property column names with their indexes in the string where they need to replace property name
			Dictionary<int, string> propColumns = GetPropColumns<T>(query, className);

			int indexDiff = 0;

			// iterates through all matched properties and replaces property names with column names
			foreach(int index in propColumns.Keys) {

				// indexDiff stores the difference between the indexes of the old and the new string
				// replacing a property name with a longer/shorter column name increases/decreases it
				int newIndex = index + indexDiff;

				int nextSpaceIndex = query.IndexOf(" ", newIndex);
				int propertyNameLength = nextSpaceIndex - newIndex;
				int columnNameLength = propColumns[index].Length;

				// replacing a property name with a longer/shorter column name increases/decreases indexDiff
				indexDiff += columnNameLength - propertyNameLength;

				// replaces property name at given index with column name
				query = query.Substring(0, newIndex)
					+ propColumns[index]
					+ query.Substring(newIndex + propertyNameLength);
			}

			return query.Replace(className + ".", tableName + ".")
							 .Replace("AndAlso", "and").Replace("==", "=");
		}

		private string GetPropColumn<C>(Expression<Func<C, object>> exp) where C : Model {
			string expBody = exp.Body.ToString();
			
			// replaces class names with table names
			string className = exp.Parameters[0].Name;

			return GetPropColumns<C>(expBody, className).First().Value;
		}

		private Dictionary<int, string> GetPropColumns<C>(string expBody, string className) where C : Model {

			Dictionary<int, string> propColumns = new Dictionary<int, string>();

			Regex regex = new Regex("(?:" + className + "\\.([a-zA-Z0-9_]+))+");

			Console.WriteLine(regex.ToString());

			foreach(Match match in regex.Matches(expBody)) {
				if(match.Success) {
					// adds index of property and column name for property to the dictionary
					propColumns.Add(match.Groups[1].Index, GetColumnName<C>(match.Groups[1].Value));
				}
			}

			return propColumns;
		}
	}
}
