using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Episodeum.MainForm;

namespace Episodeum.view {
	public abstract partial class ContentPanel : UserControl {

		protected MainForm mainForm;

		protected PanelId panelId;
		public PanelId PanelId {
			get {
				return panelId;
			}
		}

		public ContentPanel(MainForm mainForm) {
			this.mainForm = mainForm;
		}

		internal abstract void UpdateView();
	}
}
