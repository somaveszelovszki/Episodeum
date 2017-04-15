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

namespace Episodeum {
	public partial class SeriesListItemUserControl : UserControl {

		public void Update(Series series) {
			Tag = series;
			titleLabel.Text = series.Title;
			ratingLabel.Text = series.VoteAverage != 0 ? series.VoteAverage.ToString() : "N/A";
		}

		public SeriesListItemUserControl() {
			InitializeComponent();

			this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		}
	}
}
