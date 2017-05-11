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
	public partial class ListPanel : UserControl {

		public enum ORIENTATION {
			HORIZONTAL, VERTICAL
		};

		public event EventHandler ItemClick;

		public ORIENTATION Orientation { get; set; }

		public int ColumnWidth { get; set; }

		public int RowHeight { get; set; }

		public int DividerSize { get; set; }

		public int Count {
			get {
				return Controls.Count;
			}
		}

		public ListItemUserControl this[int index] {
			get {
				return (ListItemUserControl) Controls[index];
			}
		}

		public ListPanel() {
			InitializeComponent();
		}

		public void Clear() {
			Controls.Clear();
		}

		public void AddRange(List<ListItemUserControl> controls) {
			AddRange(controls.ToArray());
		}

		public void AddRange(ListItemUserControl[] controls) {
			foreach(ListItemUserControl control in controls)
				Add(control);
		}

		public void Update(List<ListItemUserControl> controls) {
			Update(controls.ToArray());
		}

		public void Update(ListItemUserControl[] controls) {
			Clear();
			AddRange(controls);
		}

		private delegate void AddControlDelegate(ListItemUserControl control);

		public void Add(ListItemUserControl control) {

			if(IsDisposed) return;

			if(InvokeRequired)
				Invoke(new AddControlDelegate(Add), control);
			else {
				Controls.Add(control);

				// registers list item's children's click event handlers
				// so that they will all call the same callback method
				control.ItemClick += Control_ItemClick;

				OnDataSetChanged();
			}
		}

		private void Control_ItemClick(object sender, EventArgs e) {
			ItemClick(sender, e);
		}

		public void Remove(ListItemUserControl control) {
			Controls.Remove(control);
			OnDataSetChanged();
		}

		private void OnDataSetChanged() {
			UpdatePositions();

			UpdateView();
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

		internal void UpdateView() {
			Invalidate();
		}
	}
}
