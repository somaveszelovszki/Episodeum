using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Episodeum.view.SearchToolsPanel;
using Episodeum.database.model;
using static Episodeum.view.SeriesListPanel;
using static Episodeum.MainForm;

namespace Episodeum.view {
	public partial class SearchSeriesPanel : ContentPanel {

		public event SearchDelegate Search {
			add { searchToolsPanel.Search += value; }
			remove { searchToolsPanel.Search -= value; }
		}

		public event SeriesClickDelegate SeriesClick {
			add { seriesListPanel.SeriesClick += value; }
			remove { seriesListPanel.SeriesClick -= value; }
		}

		public SearchSeriesPanel(MainForm mainForm) : base(mainForm) {
			InitializeComponent();

			panelId = PanelId.SearchSeries;
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