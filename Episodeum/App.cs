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
			saveSeriesDataForm.Update(series);


			if (saveSeriesDataForm.ShowDialog() == DialogResult.Yes) {
				MovieDataClient.Instance.SaveSeries(series.TmdbId, ShowSeriesSavedMessage, ShowErrorMessage);
			}
		}

		private void ShowSearchedSeriesList(List<Series> seriesList) {
			mainForm.UpdateSearchedSeriesList(seriesList);
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
