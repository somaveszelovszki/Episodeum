using SQLite;

namespace Episodeum.database.model {
    [Table("filmography_type")]
    public class FilmographyType : Type {

		/// <summary>
		/// Filmography types and their ids match values in DB.
		/// </summary>
		public enum Value {
			SERIES = 1,
			EPISODE = 2,
			SEASON = 3,
			MOVIE = 4
		}
	}
}
