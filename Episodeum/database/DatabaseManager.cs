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

		internal bool SaveFilmography(Filmography entity) {

			Filmography existing = null;
			
			if (entity is Series)
				existing = Connection.Table<Series>().Where(f => f.TmdbId == entity.TmdbId).First();

			if(entity is Season)
				existing = Connection.Table<Season>().Where(f => f.TmdbId == entity.TmdbId).First();

			if(entity is Episode)
				existing = Connection.Table<Episode>().Where(f => f.TmdbId == entity.TmdbId).First();

			if (existing == null)
				return Connection.Insert(entity) > 0;
			else {
				entity.Id = existing.Id;
				return Connection.Update(entity) > 0;
			}
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
			Expression<Func<B, bool>> whereB)
			
			where A : Model, new()
			where B : Model, new() {

			string tableA = GetTableName<A>();
			string tableB = GetTableName<B>();

			string query = string.Format("select * from {0} join {1} on {0}.{2} = {1}.{3} where {4}",
				tableA,
				tableB,
				GetPropColumn(propertyA),
				GetPropColumn(propertyB),
				GetSqlText(whereB));

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
		private string GetTableName(Type classType) {

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
		private string GetColumnName(Type classType, string propName) {
			return ((ColumnAttribute) classType.GetProperty(propName)
				.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault()).Name;
		}

		/// <summary>
		/// Parses SQL text from expression. (Substitutes class type with table name and properties with column names.)
		/// </summary>
		/// <typeparam name="C"></typeparam>
		/// <param name="exp"></param>
		/// <returns></returns>
		private string GetSqlText<C>(Expression<Func<C, bool>> exp) where C : Model {
			string expBody = exp.Body.ToString();

			string className = exp.Parameters[0].Name;
			string tableName = GetTableName(exp.Parameters[0].Type);

			// gets property column names with their indexes in the string where they need to replace property name
			Dictionary<int, string> propColumns = GetPropColumns<C>(expBody, className);

			int indexDiff = 0;

			// iterates through all matched properties and replaces property names with column names
			foreach(int index in propColumns.Keys) {

				// indexDiff stores the difference between the indexes of the old and the new string
				// replacing a property name with a longer/shorter column name increases/decreases it
				int newIndex = index + indexDiff;

				int nextSpaceIndex = expBody.IndexOf(" ", newIndex);
				int propertyNameLength = nextSpaceIndex - newIndex;
				int columnNameLength = propColumns[index].Length;

				// replacing a property name with a longer/shorter column name increases/decreases indexDiff
				indexDiff += columnNameLength - propertyNameLength;

				// replaces property name at given index with column name
				expBody = expBody.Substring(0, newIndex)
					+ propColumns[index]
					+ expBody.Substring(newIndex + propertyNameLength);
			}

			// replaces class name with table name
			return expBody.Replace(className + ".", tableName + ".")
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
