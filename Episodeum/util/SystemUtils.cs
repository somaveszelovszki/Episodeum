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
	}
}
