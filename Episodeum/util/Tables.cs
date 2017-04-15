using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episodeum.util {
	public class Tables {

		/// <summary>
		/// Filmography types and their ids match values in DB.
		/// </summary>
		public enum Filmography_TYPE {
			SERIES = 1,
			EPISODE = 2,
			SEASON = 3,
			MOVIE = 4
		}

		/// <summary>
		/// Series statuses and their ids match values in DB.
		/// </summary>
		public enum SERIES_STATUS {
			CONTINUING = 1,
			ENDED = 2
		}

		/// <summary>
		/// Series status names match values in DB.
		/// </summary>
		public static Dictionary<SERIES_STATUS, string> SERIES_STATUS_Strings = new Dictionary<SERIES_STATUS, string>() {
			{ SERIES_STATUS.CONTINUING, "Returning Series" },
			{ SERIES_STATUS.ENDED, "Ended" }
		};

		public static SERIES_STATUS GetSeriesStatusByName(string name) {

			Console.WriteLine("status: " + name);

			foreach(SERIES_STATUS status in SERIES_STATUS_Strings.Keys) {
				if(SERIES_STATUS_Strings[status] == name) {
					return status;
				}
			}

			throw new ArgumentException();
		}
	}
}
