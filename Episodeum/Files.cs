using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episodeum {
	public class Files {

		public enum DIR {
			CommonApplicationData,
			ApplicationData
		}

		public enum SUB_DIR {
			IMAGES
		}

		private static Dictionary<DIR, string> DIR_Strings = new Dictionary<DIR, string> {
			{ DIR.CommonApplicationData, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) },
			{ DIR.ApplicationData, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) }
		};

		private static Dictionary<SUB_DIR, string> SUB_DIR_Strings = new Dictionary<SUB_DIR, string> {
			{ SUB_DIR.IMAGES, "images" }
		};

		public static string Combine(DIR dir, SUB_DIR subDir, string fileName) {
			return System.IO.Path.Combine(DIR_Strings[dir], SUB_DIR_Strings[subDir], fileName);
		}

		/// <summary>
		/// Creates a file stream at the given path. If directory does not exist, creates it.
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="subDir"></param>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static FileStream Create(DIR dir, SUB_DIR subDir, string fileName) {

			string filePath = Combine(dir, subDir, fileName);

			Directory.CreateDirectory(Path.GetDirectoryName(filePath));

			return File.Create(filePath);
		}

	}
}
