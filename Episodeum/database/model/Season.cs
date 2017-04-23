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
	}
}