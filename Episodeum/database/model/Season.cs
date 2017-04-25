using System;
using SQLite;

namespace Episodeum.database.model {
    [Table("season")]
    public class Season : Filmography {

		[Column("series_id"), NotNull]
		public int SeriesId { get; set; }

		[Column("season_number"), NotNull]
        public int SeasonNumber { get; set; }

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("SeriesId:\t\t" + SeriesId);
			Console.WriteLine("SeasonNumber:\t" + SeasonNumber);
		}

		[Ignore]
		public Series Series {
			get {
				return App.Instance.DbManager.Connection.Get<Series>(SeriesId);
			}
			set {
				SeriesId = value.getId();
			}
		}

		[Ignore]
		public override FilmographyToUser ToUser {
			get {
				return App.Instance.DbManager.GetJoin<FilmographyToUser, Season>(
					ftu => ftu.FilmographyId,
					s => s.Id,
					"A.user_id=" + App.Instance.User.getId()
					+ " and A.filmography_type_id=" + (int) FilmographyType.Value.SEASON
					+ " and A.filmography_id=" + Id)[0];
			}
		}
	}
}