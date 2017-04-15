using SQLite;

namespace Episodeum.database.model {
	[Table("Filmography_to_user")]
	public class FilmographyToUser : Model {
		[Column("Filmography_id")]
		public int FilmographyId { get; set; }

		[Column("user_id")]
		public int UserId { get; set; }

		[Column("review")]
		public string Review { get; set; }

		[Column("rating_id")]
		public int RatingId { get; set; }

		[Column("finished")]
		public int Finished { get; set; }

		[Column("seconds_watched")]
		public int SecondsWatched { get; set; }
	}
}
