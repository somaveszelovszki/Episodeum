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
	public partial class ListPanel : Panel {

		public enum ORIENTATION {
			HORIZONTAL, VERTICAL
		};

		public event EventHandler ItemClick;

		public ORIENTATION Orientation { get; set; }

		public int ColumnWidth { get; set; }

		public int RowHeight { get; set; }

		public int DividerSize { get; set; }

		public ListPanel() {
			InitializeComponent();
		}

		public void Clear() {
			Controls.Clear();
		}

		public void AddRange(List<Control> controls) {
			AddRange(controls.ToArray());
		}

		public void AddRange(Control[] controls) {
			foreach(Control control in controls)
				Add(control);
		}

		public void Update(List<Control> controls) {
			Update(controls.ToArray());
		}

		public void Update(Control[] controls) {
			Clear();
			AddRange(controls);
		}

		public void Add(Control control) {
			Controls.Add(control);

			// registers list item's children's click event handlers
			// so that they will all call the same callback method
			ControlUtils.RegisterAllClickEventListeners(control, ItemClick);

			OnDataSetChanged();
		}

		public void Remove(Control control) {
			Controls.Remove(control);
			OnDataSetChanged();
		}

		private void OnDataSetChanged() {
			UpdatePositions();

			Invalidate();
		}



		private void UpdatePositions() {
			for(int pos = 0; pos < Controls.Count; ++pos) {

				Control control = Controls[pos];

				switch(Orientation) {
					case ORIENTATION.HORIZONTAL:

						control.Left = pos * (ColumnWidth + DividerSize);
						control.Top = 0;

						control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;

						control.Height = Height;

						break;

					case ORIENTATION.VERTICAL:

						control.Top = pos * (RowHeight + DividerSize);
						control.Left = 0;

						control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

						control.Width = Width;

						break;
				}

			}
		}
	}
}
