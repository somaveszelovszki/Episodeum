using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.communication;
using Episodeum.database;
using Episodeum.database.model;
using Episodeum.Properties;
using Episodeum.view;
using SQLite;
using static Episodeum.communication.MovieDataClient;
using static Episodeum.MainForm;

namespace Episodeum {

	/// <summary>
	/// Responsible for application logic.
	/// 
	/// This is a Singleton class.
	/// </summary>
	public class App {

		public DatabaseManager DbManager { get; }

		private MainForm mainForm;

		private User user;
		public User User {
			get {
				return user;
			}
		}

		private static App instance;
		public static App Instance {
			get { return instance; }
		}

		private void Init(MainForm mainForm) {

			this.mainForm = mainForm;

			// TODO not here
			int userId = 1;
			user = DbManager.Connection.Get<User>(userId);

			List<Series> savedShows = DbManager.GetSavedShows();

			foreach(Series s in savedShows) {
				Console.WriteLine(s.Id + " " + s.Title);
			}

			mainForm.UpdatePanel(PanelId.SavedShows, savedShows, true);
		}

		public static void Initialize(MainForm mainForm) {
			instance = new App();
			instance.Init(mainForm);
		}

		public void printFilmographyTypes() {
			foreach(Rating r in DbManager.Connection.Table<Rating>()) {
				Console.WriteLine(r.Name);
			}
		}

		private App() {
			DbManager = new DatabaseManager();
		}

		public void SearchSeries(string query) {
			// TODO do this in a separate thread
			new Thread(SearchSeriesThread).Start(query);
		}

		private void SearchSeriesThread(object query) {
			MovieDataClient.Instance.SearchAsync((string) query, ShowSearchedSeriesList, ShowErrorMessage);
		}

		public void OpenSeriesDataForSaving(Series series) {
			SaveSeriesForm saveSaveSeriesForm = new SaveSeriesForm();
			saveSaveSeriesForm.UpdateView(series);

			if (saveSaveSeriesForm.ShowDialog() == DialogResult.Yes) {
				new Thread(SaveSeriesThread).Start(series);
			}
		}

		internal void WatchEpisode(Episode episode) {
			if(Settings.Default.OpenMediaInApp) {
				MediaPlayerForm mediaPLayerForm = new MediaPlayerForm();
				mediaPLayerForm.Show();
				mediaPLayerForm.UpdateView(episode);
			} else {

				string mediaPlayer = Settings.Default.ExternalMediaPlayerPath;

				if(mediaPlayer != null) {
					Process.Start(mediaPlayer, "\"" + Files.GetEpisodeFile(episode) + "\"");

					Thread.Sleep(1000);

					switch(MessageBox.Show("Have you finished the episode?", "", MessageBoxButtons.YesNo)) {
						case DialogResult.Yes:

							// marks episode finished and sets seconds watched (not punctual)
							FilmographyToUser toUser = episode.ToUser;
							toUser.Finished = true;
							toUser.SecondsWatched = episode.Season.Series.EpisodeRunTime * 60;	// in seconds
							DbManager.Connection.Update(toUser);

							// if episode is last ine is season, marks season finished
							if (DbManager.IsLastEpisodeInSeason(episode)) {
								FilmographyToUser sToUser = episode.Season.ToUser;
								sToUser.Finished = true;
								DbManager.Connection.Update(sToUser);
							}

							// updates user statistics
							string date = DateTime.Today.ToShortDateString();
							TableQuery<UserStatistics> query = DbManager.Connection.Table<UserStatistics>()
								.Where(us => us.UserId == User.Id && us.Date == date);
							UserStatistics stat = query != null && query.Count() > 0 ? query.First() : null;

							if(stat == null) {
								stat = new UserStatistics();
								stat.UserId = User.GetId();
								stat.SetDate(DateTime.Today);
								stat.TimeWatching = 0;
							}

							stat.TimeWatching += toUser.SecondsWatched;
							DbManager.Connection.InsertOrReplace(stat);

							// udpates series panel (new next episode)
							mainForm.UpdatePanel(PanelId.Series, episode.Season.Series, true);
							break;
					}
				} else
					MessageBox.Show("Please select external media player in Settings page.");

			}
		}

		private void SaveSeriesThread(object series) {
			MovieDataClient.Instance.SaveSeries(((Series)series).TmdbId, OnSeriesSaved, ShowErrorMessage);
		}

		private void ShowSearchedSeriesList(List<Series> seriesList) {
			mainForm.UpdatePanel(PanelId.SearchSeries, seriesList, true);
		}

		private void OnSeriesSaved(Series series) {
			if(mainForm.IsDisposed) return;

			if (mainForm.InvokeRequired) {
				mainForm.Invoke(new OnSeriesSavedResponseDelegate(OnSeriesSaved), series);
			} else {
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.Description = "Please select series folder.";
				if(folderBrowserDialog.ShowDialog() == DialogResult.OK) {
					string rootFolder = folderBrowserDialog.SelectedPath;

					Console.WriteLine(rootFolder);

					FilmographyToUser seriesToUser = series.ToUser;
					seriesToUser.Path = rootFolder;
					
					DbManager.Connection.Update(seriesToUser);

					Console.WriteLine("path: " + series.ToUser.Path);
				}
				mainForm.UpdatePanel(PanelId.SavedShows, DbManager.GetSavedShows(), true);
				MessageBox.Show("Series saved: " + series.Title);
			}
		}

		private void ShowErrorMessage(object sender, ErrorEventArgs e) {
			Console.WriteLine(e.GetException().StackTrace);
			MessageBox.Show("An error has occurred.");
		}
	}
}
