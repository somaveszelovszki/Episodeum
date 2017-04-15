using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episodeum.util {
	public class ControlUtils {

		public static void RegisterAllClickEventListeners(Control control, EventHandler eventHandler) {
			foreach(Control childControl in control.Controls) {
				childControl.Click += eventHandler;
				if(childControl.HasChildren) {
					RegisterAllClickEventListeners(childControl, eventHandler);
				}
			}
		}
	}
}
