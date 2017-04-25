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
using static Episodeum.MainForm;
using Episodeum.util;

namespace Episodeum.view {
	public partial class SeriesPanel : ContentPanel {

		public delegate void WatchEpisodeClickDelegate(Episode episode);

		public event WatchEpisodeClickDelegate WatchEpisodeButtonClick;

		public SeriesPanel(MainForm mainForm) : base(mainForm) {
			InitializeComponent();

			watchEpisodeButton.Click += WatchEpisodeButton_Click;

			panelId = PanelId.Series;
		}

		private void WatchEpisodeButton_Click(object sender, EventArgs e) {
			WatchEpisodeButtonClick((Episode) ((Control) sender).Tag);
		}

		internal override void UpdateView() {
			Series series = (Series) mainForm.GetPanelData(this);
			Episode nextEpisode = App.Instance.DbManager.GetNextEpisode(series);
			FilmographyToUser episodeToUser = nextEpisode.ToUser;

			headerPanel.UpdateView(series);

			overviewLabel.Text = series.Overview;

			nextEpisodeNumberLabel.Text =
				"S" + nextEpisode.Season.SeasonNumber + " E" + nextEpisode.EpisodeNumber
				+ (!string.IsNullOrEmpty(nextEpisode.Title) ? ": " + nextEpisode.Title : "");

			watchEpisodeButton.Tag = nextEpisode;
			watchEpisodeButton.Text = episodeToUser.SecondsWatched == 0 ?
				"Watch now" : "Continue from " + SystemUtils.GetTime(new TimeSpan(episodeToUser.SecondsWatched));

			Invalidate();
		}
	}
}
