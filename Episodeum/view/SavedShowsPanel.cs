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
using static Episodeum.view.SeriesListPanel;

namespace Episodeum.view {
	public partial class SavedShowsPanel : ContentPanel {		

		public event SeriesClickDelegate SeriesClick {
			add { seriesListPanel.SeriesClick += value; }
			remove { seriesListPanel.SeriesClick -= value; }
		}

		public SavedShowsPanel(MainForm mainForm) : base(mainForm) {
			InitializeComponent();

			panelId = PanelId.SavedShows;
		}

		internal override void UpdateView() {
			seriesListPanel.SuspendLayout();

			seriesListPanel.Clear();

			foreach(Series series in (List<Series>) mainForm.GetPanelData(this)) {

				SeriesListItemUserControl listItem = new SeriesListItemUserControl();
				listItem.UpdateView(series);

				seriesListPanel.Add(listItem);
			}

			seriesListPanel.ResumeLayout();
		}
	}
}
