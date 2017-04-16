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

		private static App instance;
		public static App Instance {
			get { return instance; }
		}

		public static void Initialize(MainForm mainForm) {
			instance = new App();
			instance.mainForm = mainForm;

			int userId = 1;

			List<Series> savedShows = instance.DbManager.GetJoin<Series, FilmographyToUser>(
				s => s.Id,
				ftu => ftu.FilmographyId,
				ftu => ftu.UserId == 1 && ftu.FilmographyTypeId == (int) util.Tables.Filmography_TYPE.SERIES);


			foreach(Series s in savedShows) {
				Console.WriteLine(s.Title);
			}

			mainForm.UpdatePanel(PanelId.SavedShows, savedShows, true);
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
			MovieDataClient.Instance.SearchAsync(query, ShowSearchedSeriesList, ShowErrorMessage);
		}

		public void OpenSeriesDataForSaving(Series series) {
			Console.WriteLine("opening series data: " + series.Title);

			SeriesDataForm saveSeriesDataForm = new SeriesDataForm();
			saveSeriesDataForm.UpdateView(series);


			if (saveSeriesDataForm.ShowDialog() == DialogResult.Yes) {
				MovieDataClient.Instance.SaveSeries(series.TmdbId, ShowSeriesSavedMessage, ShowErrorMessage);
			}
		}

		private void ShowSearchedSeriesList(List<Series> seriesList) {
			mainForm.UpdatePanel(PanelId.SearchSeries, seriesList, false);
		}

		private void ShowSeriesSavedMessage(Series series) {
			MessageBox.Show("Series saved: " + series.Title);
		}

		private void ShowErrorMessage(object sender, ErrorEventArgs e) {
			Console.WriteLine(e.GetException().StackTrace);
			MessageBox.Show("An error has occurred.");
		}
	}
}
