using System;
using SQLite;

namespace Episodeum.database.model {
    [Table("episode")]
    public class Episode : Filmography {

        [Column("season_id"), NotNull]
        public int SeasonId { get; set; }

		[Column("episode_number"), NotNull]
		public int EpisodeNumber { get; set; }

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("SeasonId:\t\t" + SeasonId);
			Console.WriteLine("EpisodeNumber:\t" + EpisodeNumber);
		}

		[Ignore]
		public Season Season {
			get {
				return App.Instance.DbManager.Connection.Get<Season>(SeasonId);
			}
			set {
				SeasonId = value.getId();
			}
		}
	}
}