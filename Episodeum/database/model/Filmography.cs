using System;
using SQLite;

namespace Episodeum.database.model {
    public abstract class Filmography : Model {
		[Column("title")]
		public string Title { get; set; }

		[Column("tmdb_id"), NotNull]
        public int TmdbId { get; set; }

		[Column("imdb_id")]
		public string ImdbId { get; set; }

		[Column("overview")]
        public string Overview { get; set; }

        [Column("vote_average")]
        public float VoteAverage { get; set; }

		[Column("release_date")]
		public string ReleaseDate { get; set; }

		[Column("poster_path")]
        public string PosterPath { get; set; }

		public void SetReleaseDate(DateTime? releaseDate) {
			ReleaseDate = releaseDate != null ? ((DateTime) releaseDate).ToShortDateString() : null;
		}

		public DateTime? GetReleaseDate() {
			return ReleaseDate != null ? (DateTime?) DateTime.Parse(ReleaseDate) : null;
		}

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("Title:\t\t" + Title);
			Console.WriteLine("TmdbId:\t\t" + TmdbId);
			Console.WriteLine("ImdbId:\t\t" + ImdbId);
			Console.WriteLine("Overview:\t\t" + Overview);
			Console.WriteLine("VoteAverage:\t\t" + VoteAverage);
			Console.WriteLine("ReleaseDate:\t\t" + ReleaseDate);
			Console.WriteLine("PosterPath:\t\t" + PosterPath);
		}

		[Ignore]
		public abstract FilmographyToUser ToUser { get; }

		[Ignore]
		public string Path {
			get {
				return ToUser.Path;
			}
		}
	}
}
