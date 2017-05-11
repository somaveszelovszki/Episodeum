using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episodeum.util {
	public class SystemUtils {

		public static void OpenUrl(string url) {
			System.Diagnostics.Process.Start(url);
		}

		public class UnsuccessfulGetException : Exception {}

		public static string GetTime(TimeSpan timeSpan) {
			return string.Format("{0:D2}:{1:D2}:{2:D2}",
						timeSpan.Hours,
						timeSpan.Minutes,
						timeSpan.Seconds);
		}

		public static double Map(double value, double oldMin, double oldMax, double newMin, double newMax) {
			if(value < Math.Min(oldMin, oldMax) || value > Math.Max(oldMin, oldMax))
				throw new ArgumentException();

			return newMin + (value - oldMin) / (oldMax - oldMin) * (newMax - newMin);
		}

		public static string DateToShortString(DateTime date) {
			return string.Format("{0}. {1}.", date.Month, date.Day);
		}
	}
}
