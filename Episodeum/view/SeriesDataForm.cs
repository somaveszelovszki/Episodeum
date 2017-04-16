using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.database.model;
using Episodeum.util;

namespace Episodeum.view {
	public partial class SeriesDataForm : Form {
		public SeriesDataForm() {
			InitializeComponent();
		}

		public void UpdateView(Series series) {
			seriesDataUserControl.UpdateView(series);
		}

	}
}
