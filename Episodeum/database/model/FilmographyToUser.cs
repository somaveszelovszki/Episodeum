using System;
using SQLite;

namespace Episodeum.database.model {
	[Table("filmography_to_user")]
	public class FilmographyToUser : Model {
		[Column("filmography_id"), NotNull]
		public int FilmographyId { get; set; }

		[Column("filmography_type_id"), NotNull]
		public int FilmographyTypeId { get; set; }

		[Column("user_id"), NotNull]
		public int UserId { get; set; }

		[Column("review")]
		public string Review { get; set; }

		[Column("rating_id")]
		public int? RatingId { get; set; }

		[Column("finished"), NotNull]
		public bool Finished { get; set; }

		[Column("seconds_watched"), NotNull]
		public int SecondsWatched { get; set; }

		[Column("path")]
		public string Path { get; set; }

		[Column("last_activity_date")]
		public string LastActivityDate { get; set; }

		public void SetLastActivityDate(DateTime? lastActivityDate) {
			LastActivityDate = lastActivityDate != null ? ((DateTime) lastActivityDate).ToShortDateString() : null;
		}

		public DateTime? GetLastActivityDate() {
			return LastActivityDate != null ? (DateTime?) DateTime.Parse(LastActivityDate) : null;
		}


		public override void PrintValues() {
			base.PrintValues();

			Console.WriteLine("FilmographyId:\t\t" + FilmographyId);
			Console.WriteLine("FilmographyTypeId:\t\t" + FilmographyTypeId);
			Console.WriteLine("UserId:\t\t" + UserId);
			Console.WriteLine("Finished:\t\t" + Finished);
			Console.WriteLine("SecondsWatched:\t\t" + SecondsWatched);
			Console.WriteLine("Path:\t\t" + Path);
		}
	}
}
