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
		private Panel activePanel;

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
				Process watchProc = new Process();
				watchProc.StartInfo.FileName = Files.GetEpisodeFile(episode);
				watchProc.EnableRaisingEvents = true;
				watchProc.Start();
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
