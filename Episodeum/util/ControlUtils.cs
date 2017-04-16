using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.view;

namespace Episodeum.util {
	public class ControlUtils {

		public class PanelData {
			public ContentPanel Panel { get; set; }
			public object Data { get; set; }

			public PanelData(ContentPanel panel, object data) {
				this.Panel = panel;
				this.Data = data;
			}
		}

		public static void RegisterAllClickEventListeners(Control control, EventHandler eventHandler) {
			foreach(Control childControl in control.Controls) {
				childControl.Click += eventHandler;
				if(childControl.HasChildren) {
					RegisterAllClickEventListeners(childControl, eventHandler);
				}
			}
		}

		public static Color OnHoverColor (Color color, bool nightMode) {
			if(color.R < 50 && color.G < 50 && color.B < 50)
				nightMode = true;

			if(color.R > 205 && color.G > 205 && color.B > 205)
				nightMode = false;

			if(nightMode)
				return Color.FromArgb(color.A, color.R + 50, color.G + 50, color.B + 50);
			else
				return Color.FromArgb(color.A, color.R - 50, color.G - 50, color.B - 50);
		}
	}
}
