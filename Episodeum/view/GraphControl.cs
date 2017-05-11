using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Episodeum.util;

namespace Episodeum.view {
	public partial class GraphControl : Control {

		public List<IGraphable> Entries { get; set; }

		public GraphControl() {
			Initialize(null);
		}

		public GraphControl(List<IGraphable> entries) {
			Initialize(entries);
		}

		private void Initialize(List<IGraphable> entries) {
			InitializeComponent();
			Entries = entries;
		}

		protected override void OnPaint(PaintEventArgs pe) {
			base.OnPaint(pe);

			const int padding = 30;

			Point origo = new Point(2 * padding, Height - padding);
			int xAxisWidth = Width - 3 * padding;
			int yAxisHeight = Height - 2 * padding;

			// draws axises (x, y)
			pe.Graphics.DrawLine(Pens.Black, origo, new Point(origo.X + xAxisWidth, origo.Y));
			pe.Graphics.DrawLine(Pens.Black, origo, new Point(origo.X, origo.Y - yAxisHeight));

			if(Entries == null || Entries.Count == 0) return;

			double maxValue = Entries.OrderByDescending(v => v.GetValue()).FirstOrDefault().GetValue();
			int xDiff = xAxisWidth / (Entries.Count + 1);

			int lineHeight = 30;

			// Writes text next to y axis
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;

			int displayedAxisValueCount = 5;

			for (int i = 1; i <= displayedAxisValueCount; ++i) {
				double value = maxValue / displayedAxisValueCount * i;

				Rectangle r = new Rectangle(
					origo.X - 2 * padding,
					(int) SystemUtils.Map(value, 0, maxValue, origo.Y, origo.Y - yAxisHeight) + lineHeight / 2,
					2 * padding,
					lineHeight
				);

				pe.Graphics.DrawString(value.ToString(), Font, Brushes.Black, r, sf);
			}

			List<PointF> points = new List<PointF>();

			for(int i = 0; i < Entries.Count; ++i) {
				IGraphable entry = Entries[i];

				PointF p = new PointF(
					origo.X + (i + 1) * xDiff,
					(float) SystemUtils.Map(entry.GetValue(), 0, maxValue, origo.Y, origo.Y - yAxisHeight)
				);

				points.Add(p);

				// Writes text under x axis
				Rectangle r = new Rectangle((int) (origo.X + (i + 0.5) * xDiff), origo.Y, xDiff, lineHeight);
				pe.Graphics.DrawString(entry.GetKey().ToString(), Font, Brushes.Black, r, sf);
			}

			if(points.Count > 1)
				pe.Graphics.DrawLines(new Pen(Color.Red, 3), points.ToArray());
			else if (points.Count == 1) {
				int size = 8;
				PointF p = points[0];
				pe.Graphics.FillEllipse(Brushes.Red,
					p.X - size / 2,
					p.Y + size / 2,
					size,
					size);
			}

		}
	}
}
