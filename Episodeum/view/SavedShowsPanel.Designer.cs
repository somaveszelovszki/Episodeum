namespace Episodeum.view {
	partial class SavedShowsPanel {
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
			this.panelTitleLabel = new System.Windows.Forms.Label();
			this.seriesListPanel = new Episodeum.view.SeriesListPanel();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.panelTitleLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.seriesListPanel, 0, 1);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(669, 364);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// panelTitleLabel
			// 
			this.panelTitleLabel.AutoSize = true;
			this.panelTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panelTitleLabel.ForeColor = System.Drawing.Color.Chocolate;
			this.panelTitleLabel.Location = new System.Drawing.Point(3, 0);
			this.panelTitleLabel.Name = "panelTitleLabel";
			this.panelTitleLabel.Size = new System.Drawing.Size(663, 30);
			this.panelTitleLabel.TabIndex = 0;
			this.panelTitleLabel.Text = "My shows";
			this.panelTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// seriesListPanel
			// 
			this.seriesListPanel.AutoScroll = true;
			this.seriesListPanel.BackColor = System.Drawing.SystemColors.Control;
			this.seriesListPanel.ColumnWidth = 0;
			this.seriesListPanel.DividerSize = 30;
			this.seriesListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seriesListPanel.Location = new System.Drawing.Point(3, 33);
			this.seriesListPanel.Name = "seriesListPanel";
			this.seriesListPanel.Orientation = Episodeum.view.ListPanel.ORIENTATION.VERTICAL;
			this.seriesListPanel.RowHeight = 50;
			this.seriesListPanel.Size = new System.Drawing.Size(663, 328);
			this.seriesListPanel.TabIndex = 1;
			// 
			// SavedShowsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "SavedShowsPanel";
			this.Size = new System.Drawing.Size(669, 364);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label panelTitleLabel;
		private SeriesListPanel seriesListPanel;
	}
}
