using System;
using System.Collections.Generic;
using SQLite;

namespace Episodeum.database.model {
    [Table("series_status")]
    public class SeriesStatus : Type {

		/// <summary>
		/// Series statuses and their ids match values in DB.
		/// </summary>
		public enum Value {
			CONTINUING = 1,
			ENDED = 2
		}

		/// <summary>
		/// Series status names match values in DB.
		/// </summary>
		public static Dictionary<Value, string> SERIES_STATUS_Strings = new Dictionary<Value, string>() {
			{ Value.CONTINUING, "Returning Series" },
			{ Value.ENDED, "Ended" }
		};

		public static Value GetByName(string name) {

			Console.WriteLine("status: " + name);

			foreach(Value status in SERIES_STATUS_Strings.Keys) {
				if(SERIES_STATUS_Strings[status] == name) {
					return status;
				}
			}

			throw new ArgumentException();
		}

	}
}
