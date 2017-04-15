using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Episodeum.database;
using Episodeum.database.model;
using Episodeum.util;
using Newtonsoft.Json.Linq;

namespace Episodeum.communication {
	class JSONParser {

		private JObject jsonObject;

		public JSONParser(string json) {
			Console.WriteLine(json);

			jsonObject = JObject.Parse(json);
		}

		private JToken get(JObject jsonObj, MovieDataClient.KEY key) {
			return get(jsonObj, MovieDataClient.KEY_Strings[key]);
		}

		private JToken get(JObject jsonObj, string key) {
			return jsonObj[key];
		}

		private JToken get(JToken jToken, MovieDataClient.KEY key) {
			return get(jToken, MovieDataClient.KEY_Strings[key]);
		}

		private JToken get(JToken jToken, string key) {
			return jToken[key];
		}

		public List<Series> ParseSeriesList() {
			List<Series> list = new List<Series>();

			// iterates through result series array,
			// parses them and adds them to the list
			foreach(JObject seriesObj in get(jsonObject, MovieDataClient.KEY.RESULTS)) {
				Series series = new Series();
				list.Add(ParseSeries(seriesObj));
			}

			return list;
		}

		private DateTime? ParseReleaseDate(JObject filmographyObj) {

			JToken releaseDate;

			if(!string.IsNullOrEmpty((string) (releaseDate = get(filmographyObj, MovieDataClient.KEY.FIRST_AIR_DATE))))
				return DateTime.Parse((string) releaseDate);

			if(!string.IsNullOrEmpty((string) (releaseDate = get(filmographyObj, MovieDataClient.KEY.AIR_DATE))))
				return DateTime.Parse((string) releaseDate);

			if(!string.IsNullOrEmpty((string) (releaseDate = get(filmographyObj, MovieDataClient.KEY.RELEASE_DATE))))
				return DateTime.Parse((string) releaseDate);

			return null;
		}

		private string ParseTitle(JObject filmographyObj) {

			JToken title;

			if((title = get(filmographyObj, MovieDataClient.KEY.NAME)) != null)
				return (string) title;

			if((title = get(filmographyObj, MovieDataClient.KEY.TITLE)) != null)
				return (string) title;

			return null;
		}

		private void ParseFilmography(Filmography filmography, Boolean includeExternalIds) {
			ParseFilmography(filmography, jsonObject, includeExternalIds);
		}

		/// <summary>
		/// Parses fields that are common for all Filmography types.
		/// </summary>
		/// <param name="Filmography"></param>
		/// <param name="filmographyObj"></param>
		/// <param name="includeExternalIds"></param>
		private void ParseFilmography(Filmography filmography, JObject filmographyObj, Boolean includeExternalIds) {

			JToken value;

			if((value = get(filmographyObj, MovieDataClient.KEY.TMDB_ID)) != null)
				filmography.TmdbId = (int) value;

			if((value = get(filmographyObj, MovieDataClient.KEY.POSTER_PATH)) != null)
				filmography.PosterPath = (string) value;

			if(!string.IsNullOrEmpty((string)(value = get(filmographyObj, MovieDataClient.KEY.VOTE_AVERAGE))))
				filmography.VoteAverage = float.Parse((string) value);

			if((value = get(filmographyObj, MovieDataClient.KEY.OVERVIEW)) != null)
				filmography.Overview = (string) value;

			// release date can occur under different keys
			filmography.Title = ParseTitle(filmographyObj);
			// release date can occur under different keys
			filmography.SetReleaseDate(ParseReleaseDate(filmographyObj));

			if(includeExternalIds) {
				JToken externalIds = get(filmographyObj, MovieDataClient.KEY.EXTERNAL_IDS);

				if(externalIds != null && (value = get(externalIds, MovieDataClient.KEY.IMDB_ID)) != null)
					filmography.ImdbId = (string) value;
			}
		}

		public Series ParseSeries() {
			return ParseSeries(jsonObject);
		}

		public Series ParseSeries(JObject seriesObj) {
			Series series = new Series();
			ParseFilmography(series, seriesObj, true);

			JToken value;

			// parses Series specific fields
			if ((value = get(seriesObj, MovieDataClient.KEY.NUMBER_OF_SEASONS)) != null)
				series.NumberOfSeasons = (int) value;

			if((value = get(seriesObj, MovieDataClient.KEY.NUMBER_OF_EPISODES)) != null)
				series.NumberOfEpisodes = (int) value;

			if((value = get(seriesObj, MovieDataClient.KEY.EPISODE_RUN_TIME)) != null)
				series.EpisodeRunTime = (int) ((JArray) value).First;

			if((value = get(seriesObj, MovieDataClient.KEY.STATUS)) != null)
				series.StatusId = (int) Tables.GetSeriesStatusByName((string) value);

			return series;
		}

		public List<int> ParseSeasonNumbers() {

			List<int> seasonNumbers = new List<int>();

			foreach(JObject seasonObj in get(jsonObject, MovieDataClient.KEY.SEASONS)) {
				seasonNumbers.Add((int) get(seasonObj, MovieDataClient.KEY.SEASON_NUMBER));
			}

			return seasonNumbers;
		}

		public bool isSuccessful() {
			try {

				JToken statusMessage = get(jsonObject, MovieDataClient.KEY.STATUS_MESSAGE);

				if(statusMessage != null) {
					Console.WriteLine("STATUS_MESSAGE: " + (string) statusMessage);
					return false;
				}

				JToken success = get(jsonObject, MovieDataClient.KEY.SUCCESS);

				if(success != null && (bool) success == false) return false;

				if(get(jsonObject, MovieDataClient.KEY.ERRORS) != null) return false;

				if(get(jsonObject, MovieDataClient.KEY.STATUS_CODE) != null) return false;

				return true;

			} catch(Exception e) {
				Console.WriteLine(e.StackTrace);
				return false;
			}
		}

		internal List<Season> ParseSeasons(int seriesId) {

			List<Season> seasons = new List<Season>();

			// parses season data
			foreach(JObject seasonObj in get(jsonObject, MovieDataClient.KEY.SEASONS))
				seasons.Add(ParseSeason(seriesId, seasonObj));

			// not all data is available is the 'seasons' section
			// some of the info can be obtained in the specific section for the given season (e.g. 'season/2' for 2nd season)
			// so searches this object as well for season data
			foreach(Season season in seasons) {
				JToken seasonObj = get(jsonObject, string.Format(MovieDataClient.KEY_Strings[MovieDataClient.KEY.SEASON_X], season.SeasonNumber));
				if(seasonObj != null)
					ParseSeason(season, (JObject) seasonObj);
			}

			return seasons;
		}

		private Season ParseSeason(int seriesId, JObject seasonObj) {
			Season season = new Season();
			season.SeriesId = seriesId;
			ParseSeason(season, seasonObj);
			return season;
		}

		private void ParseSeason(Season season, JObject seasonObj) {
			ParseFilmography(season, seasonObj, false);

			JToken value;

			if((value = get(seasonObj, MovieDataClient.KEY.SEASON_NUMBER)) != null)
				season.SeasonNumber = (int) value;
		}

		internal List<Episode> ParseEpisodes(List<Season> seasons) {

			List<Episode> episodes = new List<Episode>();

			foreach(Season season in seasons) {
				JToken seasonObj = get(jsonObject, string.Format(MovieDataClient.KEY_Strings[MovieDataClient.KEY.SEASON_X], season.SeasonNumber));
				foreach(JObject episodeObj in get(seasonObj, MovieDataClient.KEY.EPISODES))
					episodes.Add(ParseEpisode(season.getId(), episodeObj));
			}

			return episodes;
		}

		private Episode ParseEpisode(int seasonId, JObject episodeObj) {
			Episode episode = new Episode();

			episode.SeasonId = seasonId;

			Console.WriteLine("parsing filmography...");

			ParseFilmography(episode, episodeObj, false);

			Console.WriteLine("parsing episode...");

			JToken value;

			if((value = get(episodeObj, MovieDataClient.KEY.EPISODE_NUMBER)) != null)
				episode.EpisodeNumber = (int) value;

			return episode;
		}
	}
}
