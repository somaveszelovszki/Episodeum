using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.communication;
using Episodeum.database;
using Episodeum.database.model;
using Episodeum.view;

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

			List<Series> savedShows = DbManager.GetJoin<Series, FilmographyToUser>(
				s => s.Id,
				ftu => ftu.FilmographyId,
				ftu => ftu.UserId == 1 && ftu.FilmographyTypeId == (int) FilmographyType.Value.SERIES);


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

		private void SaveSeriesThread(object series) {
			MovieDataClient.Instance.SaveSeries(((Series)series).TmdbId, OnSeriesSaved, ShowErrorMessage);
		}

		private void ShowSearchedSeriesList(List<Series> seriesList) {
			mainForm.UpdatePanel(PanelId.SearchSeries, seriesList, true);
		}

		private void OnSeriesSaved(Series series) {
			mainForm.UpdatePanel(PanelId.SavedShows, series, false);
			MessageBox.Show("Series saved: " + series.Title);
		}

		private void ShowErrorMessage(object sender, ErrorEventArgs e) {
			Console.WriteLine(e.GetException().StackTrace);
			MessageBox.Show("An error has occurred.");
		}
	}
}
