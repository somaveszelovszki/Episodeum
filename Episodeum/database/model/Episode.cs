using System;
using Episodeum.util;
using SQLite;

namespace Episodeum.database.model {
    [Table("episode")]
    public class Episode : Filmography {

        [Column("season_id")]
        public int SeasonId { get; set; }

		[Column("episode_number")]
		public int EpisodeNumber { get; set; }

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("SeasonId:\t\t" + SeasonId);
			Console.WriteLine("EpisodeNumber:\t" + EpisodeNumber);
		}
	}
}