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

namespace Episodeum.view {
	public partial class SeriesPanel : ContentPanel {
		public SeriesPanel(MainForm mainForm) : base(mainForm) {
			InitializeComponent();

			panelId = PanelId.Series;
		}

		internal override void UpdateView() {
			Series series = (Series) mainForm.GetPanelData(this);
			Episode nextEpisode = App.Instance.DbManager.GetNextEpisode(series);

			headerPanel.UpdateView(series);

			overviewLabel.Text = series.Overview;

			nextEpisodeNumberLabel.Text =
				"S" + nextEpisode.Season.SeasonNumber + " E" + nextEpisode.EpisodeNumber
				+ (!string.IsNullOrEmpty(nextEpisode.Title) ? ": " + nextEpisode.Title : "");

			Invalidate();
		}
	}
}
