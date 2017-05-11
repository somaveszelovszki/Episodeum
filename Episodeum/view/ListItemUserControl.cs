using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.util;

namespace Episodeum.view {
	public partial class ListItemUserControl : UserControl {

		public event EventHandler ItemClick;

		public ListItemUserControl() : base() {
			Cursor = Cursors.Hand;
		}

		internal virtual void RegisterEventListeners() {
			ControlUtils.RegisterAllClickEventListeners(this, ListItemUserControl_Click);
		}

		protected void ListItemUserControl_Click(object sender, EventArgs e) {
			while(!(sender is ListItemUserControl))
				sender = ((Control) sender).Parent;

			ItemClick(sender, e);
		}

		internal virtual void UpdateView() {
			throw new InvalidOperationException();
		}
	}
}
