namespace Episodeum.view {
	partial class StatisticsPanel {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.graphControl = new Episodeum.view.GraphControl();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.titleLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.graphControl, 0, 1);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(736, 473);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.OrangeRed;
			this.titleLabel.Location = new System.Drawing.Point(3, 0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(730, 50);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Statistics";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// graphControl
			// 
			this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graphControl.Entries = null;
			this.graphControl.Location = new System.Drawing.Point(30, 80);
			this.graphControl.Margin = new System.Windows.Forms.Padding(30);
			this.graphControl.Name = "graphControl";
			this.graphControl.Size = new System.Drawing.Size(676, 363);
			this.graphControl.TabIndex = 1;
			this.graphControl.Text = "graphControl";
			// 
			// StatisticsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "StatisticsPanel";
			this.Size = new System.Drawing.Size(736, 473);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label titleLabel;
		private GraphControl graphControl;
	}
}
