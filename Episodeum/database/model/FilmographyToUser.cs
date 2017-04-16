using SQLite;

namespace Episodeum.database.model {
	[Table("filmography_to_user")]
	public class FilmographyToUser : Model {
		[Column("filmography_id")]
		public int FilmographyId { get; set; }

		[Column("filmography_type_id")]
		public int FilmographyTypeId { get; set; }

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
