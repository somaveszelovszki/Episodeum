using System;
using SQLite;

namespace Episodeum.database.model {
    [Table("series")]
    public class Series : Filmography {

        [Column("number_of_seasons"), NotNull]
        public int NumberOfSeasons { get; set; }

        [Column("number_of_episodes"), NotNull]
        public int NumberOfEpisodes { get; set; }

        [Column("status_id"), NotNull]
        public int StatusId { get; set; }

        [Column("episode_run_time")]
        public int EpisodeRunTime { get; set; }

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("NumberOfSeasons:\t" + NumberOfSeasons);
			Console.WriteLine("NumberOfEpisodes:\t" + NumberOfEpisodes);
			Console.WriteLine("StatusId:\t\t" + StatusId);
			Console.WriteLine("EpisodeRunTime:\t" + EpisodeRunTime);
		}

		public void setStatus(SeriesStatus.Value? status) {
			StatusId = status != null ? (int) status : 0;
		}
	}
}