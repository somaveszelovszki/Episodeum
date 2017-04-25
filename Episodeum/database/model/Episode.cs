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

		[Ignore]
		public override FilmographyToUser ToUser {
			get {
				return App.Instance.DbManager.GetJoin<FilmographyToUser, Episode>(
					ftu => ftu.FilmographyId,
					e => e.Id,
					"A.user_id=" + App.Instance.User.getId()
					+ " and A.filmography_type_id=" + (int) FilmographyType.Value.EPISODE
					+ " and A.filmography_id=" + Id)[0];
			}
		}
	}
}