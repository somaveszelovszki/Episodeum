using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.database.model;
using Episodeum.util;
using Episodeum.communication;

namespace Episodeum {
	public partial class SaveSeriesUserControl : UserControl {
		public SaveSeriesUserControl() {
			InitializeComponent();
		}


		public void UpdateView(Series series) {
			headerPanel.UpdateView(series);

			overviewLabel.Text = series.Overview;
			imdbButton.Tag = series.ImdbId;
			tmdbButton.Tag = series.TmdbId;

			Tag = series;
		}

		private void imdbButton_Click(object sender, EventArgs e) {
			MovieDataClient.Instance.ViewOnIMDb((string) ((Control) sender).Tag);
		}

		private void tmdbButton_Click(object sender, EventArgs e) {
			MovieDataClient.Instance.ViewOnTMDB(FilmographyType.Value.SERIES,
				(int) ((Control) sender).Tag);
		}
	}
}
