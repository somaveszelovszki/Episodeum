
using Episodeum.database;
using Episodeum.database.model;
using SQLite;
using System;

using System.Windows.Forms;
using Episodeum.communication;
using System.Collections.Generic;
using Episodeum.view;
using System.Threading;

namespace Episodeum {

	/// <summary>
	/// Main form of the application.
	/// </summary>
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();

			searchedSeriesListPanel.ItemClick += SearchedSeriesListPanel_ItemClick;

			App.Initialize(this);
		}

		private void SearchedSeriesListPanel_ItemClick(object sender, EventArgs e) {

			// event handler is probably called with a child element,
			// so goes up in hierarchy to the parent that needs to be handled
			while(!(sender is SeriesListItemUserControl))
				sender = ((Control) sender).Parent;

			App.Instance.OpenSeriesDataForSaving((Series)((SeriesListItemUserControl) sender).Tag);
		}

		public void UpdateSearchedSeriesList(List<Series> seriesList) {

			searchedSeriesListPanel.SuspendLayout();

			searchedSeriesListPanel.Clear();

			foreach(Series series in seriesList) {

				SeriesListItemUserControl listItem = new SeriesListItemUserControl();
				listItem.Update(series);

				searchedSeriesListPanel.Add(listItem);
			}

			/*
			foreach(Series series in seriesList) {

				Console.WriteLine(series.Title);

				SeriesListItemUserControl listItem = new SeriesListItemUserControl();
				listItem.Series = series;

				searchedSeriesListPanel.Controls.Add(listItem, 0, searchedSeriesListPanel.RowCount - 1);
			}

			if (searchedSeriesListPanel.RowStyles.Count > 0) {
				int diff = searchedSeriesListPanel.Height
					- (int) searchedSeriesListPanel.RowStyles[0].Height * searchedSeriesListPanel.RowCount;

				searchedSeriesListPanel.AutoSize = diff > 0;
			}
			*/

			this.searchedSeriesListPanel.ResumeLayout();
		}

		private void searchToolsPanel_Search(string query) {
			App.Instance.SearchSeries(query);
		}
	}
}
