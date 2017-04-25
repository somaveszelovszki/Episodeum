using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Episodeum.database.model;
using Episodeum.util;
using static Episodeum.util.SystemUtils;

namespace Episodeum.communication {

	/// <summary>
	/// Gets data from the given movie data provider.
	/// 
	/// This is a Singleton class.
	/// </summary>
	class MovieDataClient {

		/// <summary>
		/// Callback delegate for series search.
		/// </summary>
		/// <param name="seriesList"></param>
		public delegate void OnSeriesSearchResponseDelegate(List<Series> seriesList);

		/// <summary>
		/// Callback method for series saving.
		/// </summary>
		/// <param name="series"></param>
		public delegate void OnSeriesSavedResponseDelegate(Series series);

		private static readonly string API_BASE_URL = "https://api.themoviedb.org/3/";
		private static readonly string TMDB_BASE_URL = "http://themoviedb.org/";
		private static readonly string IMDb_BASE_URL = "http://imdb.com/title/";
		private static readonly string BASE_URL_POSTER = "https://image.tmdb.org/t/p/w185/";

		private static readonly string API_KEY = "4dc6e38a1e9ab3ed2788ad1f933e35a2";

		private HttpClient client = new HttpClient();

		private static MovieDataClient instance;
		public static MovieDataClient Instance {
			get {
				if (instance == null) {
					instance = new MovieDataClient();
				}
				return instance;
			}
		}

		public enum KEY {

			// parameters to check response success
			ERRORS,
			STATUS_CODE,
			STATUS_MESSAGE,
			RESULTS,
			SUCCESS,

			// result parameters
			TITLE,
			NAME,
			RELEASE_DATE,
			FIRST_AIR_DATE,
			AIR_DATE,
			EXTERNAL_IDS,
			IMDB_ID,
			TMDB_ID,
			OVERVIEW,
			VOTE_AVERAGE,
			POSTER_PATH,
			SEASON_NUMBER,
			EPISODE_NUMBER,
			NUMBER_OF_SEASONS,
			NUMBER_OF_EPISODES,
			STATUS,
			EPISODE_RUN_TIME,
			SEASONS,
			SEASON_X,
			EPISODES,
			SERIES_ENDED,
			SERIES_RETURNING,

			// URL paths
			SEARCH,
			MOVIE,
			TV,
			SEASON,
			EPISODE,

			// IMDb path
			IMDb_PATH_TITLE,

			// GET parameters
			API_KEY,
			QUERY,
			LANGUAGE,
			APPEND_TO_RESPONSE,
		}

		public static Dictionary<KEY, string> KEY_Strings = new Dictionary<KEY, string>() {
			{ KEY.ERRORS, "errors" },
			{ KEY.STATUS_CODE, "status_code" },
			{ KEY.STATUS_MESSAGE, "status_message" },
			{ KEY.SUCCESS, "success" },
			{ KEY.RESULTS, "results" },

			{ KEY.TITLE, "title" },
			{ KEY.NAME, "name" },
			{ KEY.RELEASE_DATE, "release_date" },
			{ KEY.FIRST_AIR_DATE, "first_air_date" },
			{ KEY.AIR_DATE, "air_date" },
			{ KEY.EXTERNAL_IDS, "external_ids" },
			{ KEY.IMDB_ID, "imdb_id" },
			{ KEY.TMDB_ID, "id" },
			{ KEY.OVERVIEW, "overview" },
			{ KEY.VOTE_AVERAGE, "vote_average" },
			{ KEY.POSTER_PATH, "poster_path" },
			{ KEY.SEASON_NUMBER, "season_number" },
			{ KEY.EPISODE_NUMBER, "episode_number" },
			{ KEY.NUMBER_OF_SEASONS, "number_of_seasons" },
			{ KEY.NUMBER_OF_EPISODES, "number_of_episodes" },
			{ KEY.STATUS, "status" },
			{ KEY.EPISODE_RUN_TIME, "episode_run_time" },
			{ KEY.SEASONS, "seasons" },
			{ KEY.SEASON_X, "season/{0}" },
			{ KEY.EPISODES, "episodes" },
			{ KEY.SERIES_ENDED, "Ended" },
			{ KEY.SERIES_RETURNING, "Returning Series" },

			{ KEY.SEARCH, "search" },
			{ KEY.MOVIE, "movie" },
			{ KEY.TV, "tv" },
			{ KEY.SEASON, "season" },
			{ KEY.EPISODE, "episode" },

			{ KEY.IMDb_PATH_TITLE, "title" },

			{ KEY.API_KEY, "api_key" },
			{ KEY.QUERY, "query" },
			{ KEY.LANGUAGE, "language" },
			{ KEY.APPEND_TO_RESPONSE, "append_to_response" }
		};

		private enum DATA_PROVIDER {
			TMDB, IMDb
		};

		/// <summary>
		/// Builder class for movie data provider URLs.
		/// </summary>
		private class URLBuilder {

			public class ParameterList<T> : List<T> {

				public override string ToString() {
					return string.Join(",", this.ToArray());
				}
			}

			private static readonly char PATH_SEP = '/';

			protected StringBuilder builder;
			private int paramNum = 0;

			public URLBuilder(string baseUrl) {
				builder = new StringBuilder(baseUrl);
			}

			public void AppendPath(KEY pathKey) {
				AppendPath(KEY_Strings[pathKey]);
			}

			public void AppendPath(int num) {
				AppendPath(num.ToString());
			}

			public void AppendPath(string path) {
				builder.Append(path);
				builder.Append(PATH_SEP);
			}

			public void Append(string path) {
				builder.Append(path);
			}

			private void AppendApiKey() {
				AppendParam(KEY.API_KEY, API_KEY);
			}

			public void AppendParams(Dictionary<KEY, object> parameters) {
				AppendApiKey();

				if(parameters != null) {

					foreach(KEY key in parameters.Keys) {
						AppendParam(key, parameters[key]);
					}
				}
			}

			private void AppendParam(KEY key, object value) {
				if (value != null) {

					if (paramNum == 0) {

						// removes last path separator before first parameter
						if (builder[builder.Length - 1] == PATH_SEP) {
							builder.Length--;
						}
						builder.Append("?");
					} else {
						builder.Append("&");
					}

					builder.Append(KEY_Strings[key]);
					builder.Append("=");
					builder.Append(PrepareParam(value.ToString()));

					++paramNum;
				}
			}

			private string PrepareParam(string param) {
				return param.Replace(" ", "+");
			}

			public override string ToString() {
				return builder.ToString();
			}
		}

		private class PosterURLBuilder : URLBuilder {

			public PosterURLBuilder() : base(BASE_URL_POSTER) {}

			public string PrepareURL(string posterPath) {
				return builder.Append(posterPath).ToString();
			}
		}

		private class ViewURL_TMDB_Builder : URLBuilder {

			public ViewURL_TMDB_Builder() : base(TMDB_BASE_URL) { }

			public string PrepareURL(FilmographyType.Value type, int tmdbId) {

				switch (type) {
					case FilmographyType.Value.MOVIE:
						AppendPath(KEY.MOVIE);
						break;
					case FilmographyType.Value.SERIES:
						AppendPath(KEY.TV);
						break;
					default:
						// TODO
						throw new NotImplementedException();
				}
				AppendPath(tmdbId);

				return ToString();
			}
		}

		private class ViewURL_IMDb_Builder : URLBuilder {

			public ViewURL_IMDb_Builder() : base(IMDb_BASE_URL) { }

			public string PrepareURL(string imdbId) {

				AppendPath(KEY.IMDb_PATH_TITLE);
				AppendPath(imdbId);

				return ToString();
			}
		}

		private class SearchURLBuilder : URLBuilder {

			public SearchURLBuilder() : base(API_BASE_URL) { }

			public string PrepareURL(FilmographyType.Value type, Dictionary<KEY, object> parameters) {

				AppendPath(KEY.SEARCH);

				switch (type) {
					case FilmographyType.Value.MOVIE:
						throw new NotSupportedException();

					case FilmographyType.Value.SERIES:
					case FilmographyType.Value.SEASON:
					case FilmographyType.Value.EPISODE:

						// TODO
						AppendPath(KEY.TV);
						break;
				}

				AppendParams(parameters);

				return ToString();
			}
		}

		private class GetURLBuilder : URLBuilder {

			public GetURLBuilder() : base(API_BASE_URL) { }

			public string PrepareURL(FilmographyType.Value type, Dictionary<KEY, object> parameters) {

				switch(type) {
					case FilmographyType.Value.MOVIE:
						// TODO
						throw new NotImplementedException();

					case FilmographyType.Value.SERIES:
						AppendPath(KEY.TV);
						AppendPath((int) parameters[KEY.TMDB_ID]);
						break;

					case FilmographyType.Value.SEASON:
						AppendPath(KEY.TV);
						AppendPath((int) parameters[KEY.TMDB_ID]);
						AppendPath(KEY.SEASON);
						AppendPath((int) parameters[KEY.SEASON_NUMBER]);
						break;

					case FilmographyType.Value.EPISODE:
						AppendPath(KEY.TV);
						AppendPath((int) parameters[KEY.TMDB_ID]);
						AppendPath(KEY.SEASON);
						AppendPath((int) parameters[KEY.SEASON_NUMBER]);
						AppendPath(KEY.EPISODE);
						AppendPath((int) parameters[KEY.EPISODE_NUMBER]);
						break;
				}

				parameters.Remove(KEY.TMDB_ID);
				parameters.Remove(KEY.SEASON_NUMBER);
				parameters.Remove(KEY.EPISODE_NUMBER);

				ParameterList<string> appendToResponse = new ParameterList<string>();
				appendToResponse.Add(KEY_Strings[KEY.EXTERNAL_IDS]);
				parameters.Add(KEY.APPEND_TO_RESPONSE, appendToResponse);

				AppendParams(parameters);

				return ToString();
			}
		}

		private class GetSeriesWithSeasonsURLBuilder : URLBuilder {

			public GetSeriesWithSeasonsURLBuilder() : base(API_BASE_URL) { }

			public string PrepareURL(Dictionary<KEY, object> parameters, List<int> seasonNumbers) {

				AppendPath(KEY.TV);
				AppendPath((int) parameters[KEY.TMDB_ID]);

				parameters.Remove(KEY.TMDB_ID);

				ParameterList<string> appendToResponse = new ParameterList<string>();

				foreach(int seasonNumber in seasonNumbers)
					appendToResponse.Add(KEY_Strings[KEY.SEASON] + "/" + seasonNumber);

				appendToResponse.Add(KEY_Strings[KEY.EXTERNAL_IDS]);

				parameters.Add(KEY.APPEND_TO_RESPONSE, appendToResponse);

				AppendParams(parameters);

				return ToString();
			}
		}

		public async void DownloadPosterPicture(string posterPath) {

			string url = new PosterURLBuilder().PrepareURL(posterPath);

			HttpResponseMessage response = await client.GetAsync(url);

			// Check that response was successful or throw exception
			if(response.IsSuccessStatusCode) {
				// Read response asynchronously and save asynchronously to file
				using(FileStream fileStream = Files.Create(Files.DIR.CommonApplicationData, Files.SUB_DIR.IMAGES, posterPath)) {
					//copy the content from response to filestream
					await response.Content.CopyToAsync(fileStream);

					// TODO update icon
				}
			}
		}

		/// <summary>
		/// Searches movie data provider with a search query.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="OnSeriesSearchResponse"></param>
		public async void SearchAsync(string query, OnSeriesSearchResponseDelegate OnSeriesSearchResponse,
			ErrorEventHandler OnError) {

			string language = "en-US";

			Dictionary<KEY, object> parameters = new Dictionary<KEY, object>();

			parameters.Add(KEY.QUERY, query);
			parameters.Add(KEY.LANGUAGE, language);

			string url = new SearchURLBuilder().PrepareURL(FilmographyType.Value.SERIES, parameters);

			Console.WriteLine("url: " + url);

			try {
				HttpResponseMessage response = await client.GetAsync(url);

				response.EnsureSuccessStatusCode();       // throws Exception if HTTP response code is not SUCCESS

				string responseJson = await response.Content.ReadAsStringAsync();

				JSONParser parser = new JSONParser(responseJson);

				if(!parser.isSuccessful()) throw new UnsuccessfulGetException();

				OnSeriesSearchResponse(parser.ParseSeriesList());
				
			} catch (Exception e) {
				OnError(this, new ErrorEventArgs(e));
			}
		}

		public void ViewOnIMDb(string imdbId) {

			if(String.IsNullOrEmpty(imdbId)) return;

			string language = "en-US";

			string url = new ViewURL_IMDb_Builder().PrepareURL(imdbId);

			Console.WriteLine("url: " + url);

			SystemUtils.OpenUrl(url);
		}

		public void ViewOnTMDB(FilmographyType.Value type, int tmdbId) {

			if(tmdbId == 0) return;

			string language = "en-US";

			string url = new ViewURL_TMDB_Builder().PrepareURL(type, tmdbId);

			Console.WriteLine("url: " + url);

			SystemUtils.OpenUrl(url);
		}

		private async Task<Series> SaveSeries(int seriesTmdbId, string language, List<int> seasonNumbers) {

			// prepares URL using season numbers
			Dictionary<KEY, object> parameters = new Dictionary<KEY, object>();
			parameters.Add(KEY.TMDB_ID, seriesTmdbId);
			parameters.Add(KEY.LANGUAGE, language);
			string url = new GetSeriesWithSeasonsURLBuilder().PrepareURL(parameters, seasonNumbers);

			Console.WriteLine("url (with seasons): " + url);

			HttpResponseMessage response = await client.GetAsync(url);

			response.EnsureSuccessStatusCode();     // throws Exception if HTTP response code is not SUCCESS
			string responseJson = await response.Content.ReadAsStringAsync();

			JSONParser parser = new JSONParser(responseJson);

			if(!parser.isSuccessful()) throw new UnsuccessfulGetException();

			Series series = parser.ParseSeries();

			series.PrintValues();

			try {
				App.Instance.DbManager.SaveFilmography(series, true);
				Console.WriteLine("series inserted successfully");

				Console.WriteLine("series id: " + series.getId());

				List<Season> seasons = parser.ParseSeasons(series.getId());

				foreach(Season season in seasons) {
					season.PrintValues();
					App.Instance.DbManager.SaveFilmography(season, true);
					Console.WriteLine("season id: " + season.getId());

				}

				List<Episode> episodes = parser.ParseEpisodes(seasons);

				foreach(Episode episode in episodes) {
					episode.PrintValues();
					App.Instance.DbManager.SaveFilmography(episode, true);
				}
			} catch(Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}

			

			return series;
		}

		/// <summary>
		/// Saves series given by its Tmdb id - gets data from server and saves to database.
		/// When finished, calls callback delegate.
		/// </summary>
		/// <param name="tmdbId"></param>
		/// <param name="OnSeriesSavedResponse"></param>
		public async void SaveSeries(int tmdbId, OnSeriesSavedResponseDelegate OnSeriesSavedResponse,
			ErrorEventHandler OnError) {
			string language = "en-US";

			// prepares URL
			Dictionary<KEY, object> parameters = new Dictionary<KEY, object>();
			parameters.Add(KEY.TMDB_ID, tmdbId);
			parameters.Add(KEY.LANGUAGE, language);
			string url = new GetURLBuilder().PrepareURL(FilmographyType.Value.SERIES, parameters);
			Console.WriteLine("url: " + url);

			// gets answer from server
			HttpResponseMessage response = await client.GetAsync(url);

			response.EnsureSuccessStatusCode();     // throws Exception if HTTP response code is not SUCCESS
			string responseJson = await response.Content.ReadAsStringAsync();

			JSONParser parser = new JSONParser(responseJson);

			if(!parser.isSuccessful()) throw new UnsuccessfulGetException();

			try {
				// parses season numbers from response object
				Series series = await SaveSeries(tmdbId, language, parser.ParseSeasonNumbers());

				OnSeriesSavedResponse(series);

			} catch(Exception e) {
				Console.WriteLine(e.Message);

				Console.WriteLine(e.StackTrace);
			}
			
			try {
				// TODO put code here

			} catch (Exception e) {
				OnError(this, new ErrorEventArgs(e));
			}
		}
	}
}
