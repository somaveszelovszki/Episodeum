using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Episodeum.database.model;
using Episodeum.util;

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
			Console.WriteLine("saving entity...");

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
	}
}
