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
	//[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<ContentPanel, UserControl>))]
	public partial class ContentPanel : UserControl {

		protected MainForm mainForm;

		protected PanelId panelId;
		public PanelId PanelId {
			get {
				return panelId;
			}
		}

		public ContentPanel() {
		}

		public ContentPanel(MainForm mainForm) {
			this.mainForm = mainForm;
			InitializeComponent();
		}

		internal virtual void UpdateView() {
			throw new InvalidOperationException();
		}
	}
}
