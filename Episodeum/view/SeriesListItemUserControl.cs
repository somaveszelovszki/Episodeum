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
using Episodeum.view;

namespace Episodeum {
	public partial class SeriesListItemUserControl : ListItemUserControl {

		public SeriesListItemUserControl() {
			Initialize(null);
		}

		public SeriesListItemUserControl(Series series) {
			Initialize(series);
		}

		private void Initialize(Series series) {
			InitializeComponent();

			RegisterEventListeners();

			Anchor = AnchorStyles.Left | AnchorStyles.Right;

			if(series != null) UpdateView(series);
		}

		public void UpdateView(Series series) {
			Tag = series;

			titleLabel.Text = series.Title;
			ratingLabel.Text = series.VoteAverage != 0 ? series.VoteAverage.ToString() : "N/A";

			Invalidate();
		}
	}
}
