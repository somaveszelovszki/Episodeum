using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Episodeum.database.model;

namespace Episodeum {
	public class Files {

		public enum FILE_TYPE {
			FILE, DIRECTORY
		}

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

		public class Format {

			public enum NAME { MP4, AVI, WMV, MOV, FLV, MKV, SUB, SRT, NFO }
			public enum TYPE { VIDEO, SUBTITLE, INFO }

			public TYPE Type { get; set; }
			public string Extension { get; set; }

			private Format (TYPE type, string extension) {
				Type = type;
				Extension = extension;
			}

			public static Dictionary<NAME, Format> Values = new Dictionary<NAME, Format>() {
				{ NAME.MP4, new Format(TYPE.VIDEO, "mp4") },
				{ NAME.AVI, new Format(TYPE.VIDEO, "avi") },
				{ NAME.WMV, new Format(TYPE.VIDEO, "wmv") },
				{ NAME.FLV, new Format(TYPE.VIDEO, "flv") },
				{ NAME.MKV, new Format(TYPE.VIDEO, "mkv") },
				{ NAME.SUB, new Format(TYPE.SUBTITLE, "sub") },
				{ NAME.SRT, new Format(TYPE.SUBTITLE, "srt") },
				{ NAME.NFO, new Format(TYPE.INFO, "nfo") },
			};

			public bool IsFormatOf(string filePath) {
				return Extension == Path.GetExtension(filePath);
			}
		}

		public static string Combine(DIR dir, SUB_DIR subDir, string fileName) {
			return Path.Combine(DIR_Strings[dir], SUB_DIR_Strings[subDir], fileName);
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

		public static string GetSeasonDirectory(Season season) {

			string seriesDir = season.Series.ToUser.Path;

			if (seriesDir == null) return null;

			// selects directory from parent's children that matches the season number
			List<string> results = GetFilesByIndex(Directory.GetDirectories(seriesDir).ToList(),
				FilmographyType.Value.SEASON, season.SeasonNumber);

			return results != null && results.Count > 0 ? results[0] : null;
		}

		public static string GetEpisodeFile(Episode episode) {

			string seasonDir = GetSeasonDirectory(episode.Season);

            if (seasonDir == null) return null;

            // selects directory from parent's children that matches the season number
            List<string> results = GetFilesByIndex(Directory.GetFileSystemEntries(seasonDir).ToList(),
				FilmographyType.Value.EPISODE, episode.EpisodeNumber);

			return results != null && results.Count > 0 ? results[0] : null;
		}


		/// <summary>
		/// Gets files by filmography type and index.
		/// </summary>
		/// <param name="fileNames"></param>
		/// <param name="type"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		private static List<string> GetFilesByIndex(List<string> filePaths, FilmographyType.Value type, int index) {

			if(filePaths == null) return null;

			List<string> results = new List<string>();

			// runs check for every file in list
			foreach(string filePath in filePaths) {

				// checks if file matches index
				if(FileNameMatchesIndex(Path.GetFileName(filePath), index, type)) {

					switch(type) {
						case FilmographyType.Value.SEASON:
							// adds file to results if it is a directory (season directory is always a directory)
							if(GetFileType(filePath) == FILE_TYPE.DIRECTORY)
								results.Add(filePath);
							break;

						case FilmographyType.Value.EPISODE:
							// deep search for episodes
							// -> if we are searching for episodes, and file is a directory,
							//			searches for elements inside directory
							if(GetFileType(filePath) == FILE_TYPE.DIRECTORY) {
								results.AddRange(GetFilesByIndex(
									Directory.GetFiles(filePath).ToList(), FilmographyType.Value.EPISODE, index));
							} else
								results.Add(filePath);

							break;
					}
				}
			}

			return results;
		}

		private static FILE_TYPE GetFileType(string filePath) {
			// gets the file attributes for file or directory
			FileAttributes attr = File.GetAttributes(filePath);

			//detects whether it's a directory or file
			return (attr & FileAttributes.Directory) == FileAttributes.Directory ? FILE_TYPE.DIRECTORY : FILE_TYPE.FILE;
		}

		/**
     * Checks if file name matches given index (EPISODE or SEASON).
     * @param file Subject of check
     * @param index EPISODE or SEASON index to check
     * @param type EPISODE or SEASON
     * @return true if file name matches index
     */
		private static bool FileNameMatchesIndex(string fileName, int index, FilmographyType.Value type) {
			if(fileName == null || index < 0) return false;

			List<Regex> patterns = new List<Regex>();

			switch(type) {
				case FilmographyType.Value.SEASON:
					/* Regexp explanation:
					* [Ss](eason)?  -   character 's' (can be either capital or not)
					*                   or string 'season' (first 's' can be either capital or not)
					* \s*           -    0 or more white-spaces
					* followed by the season index
					* (\D+\d*)?     -   not followed by a digit
					*/
					patterns.Add(new Regex(".*[Ss](eason)?\\s*0?" + index + "(\\D+\\d*)?"));
					break;

				case FilmographyType.Value.EPISODE:
					/* Regexp explanation:
					* [Ee](pisode)?  -   character 'e' (can be either capital or not)
					*                   or string 'episode' (first 'e' can be either capital or not)
					* \s*           -    0 or more white-spaces
					* followed by the episode index
					* \D            -   followed by a non-digit
					*/
					patterns.Add(new Regex(".*[Ee](pisode)?\\s*0?" + index + "\\D"));

					/* Regexp explanation:
					* [Ee](pisode)?  -   character 'e' (can be either capital or not)
					*                   or string 'episode' (first 'e' can be either capital or not)
					* \s*           -    0 or more white-spaces
					* followed by the episode index
					* $            -   end of string
					*/
					patterns.Add(new Regex(".*[Ee](pisode)?\\s*0?" + index + "$"));

					/* Regexp explanation:
					 * X or x
					 * followed by 0 or 1 zeros
					 * followed by the episode index
					 * followed by a non-digit
					 */
					patterns.Add(new Regex(".*[Xx]0?" + index + "\\D+"));

					/* Regexp explanation:
					 * X or x
					 * followed by 0 or 1 zeros
					 * followed by the episode index
					 * $        -   end of string
					 */
					patterns.Add(new Regex(".*[Xx]0?" + index + "$"));

					break;
				default:
					throw new ArgumentException();
			}

			foreach(Regex regex in patterns) {
				Match match = regex.Match(fileName);
				if(match.Success)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Filters out sample files from list of file names.
		/// </summary>
		/// <param name="fileNames"></param>
		private static void FilterOutSampleFiles(List<string> fileNames) {
			if(fileNames != null)
				fileNames = fileNames.Where(f => !(f.Contains("sample") || f.Contains("Sample"))).ToList();
		}

	}
}
