using System;
using Episodeum.util;
using SQLite;

namespace Episodeum.database.model {
    [Table("season")]
    public class Season : Filmography {

		[Column("series_id")]
		public int SeriesId { get; set; }

		[Column("season_number")]
        public int SeasonNumber { get; set; }

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("SeriesId:\t\t" + SeriesId);
			Console.WriteLine("SeasonNumber:\t" + SeasonNumber);
		}
	}
}