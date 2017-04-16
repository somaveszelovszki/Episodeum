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

namespace Episodeum.view {
	public partial class SeriesListPanel : ListPanel {

		public delegate void SeriesClickDelegate(Series series);

		public event SeriesClickDelegate SeriesClick;

		public SeriesListPanel() : base() {
			ItemClick += SeriesListPanel_ItemClick;
		}

		private void SeriesListPanel_ItemClick(object sender, EventArgs e) {
			SeriesClick((Series) ((SeriesListItemUserControl) sender).Tag);
		}
	}
}
