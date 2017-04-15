using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Episodeum.view {
	public partial class RoundButton : Button {
		protected override void OnResize(EventArgs e) {
			using(GraphicsPath path = new GraphicsPath()) {
				path.AddEllipse(new Rectangle(3, 3, this.Width - 8, this.Height - 8));
				this.Region = new Region(path);
			}
			base.OnResize(e);
		}
	}
}
