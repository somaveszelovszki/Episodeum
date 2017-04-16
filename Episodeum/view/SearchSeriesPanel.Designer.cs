namespace Episodeum.view {
	partial class SearchSeriesPanel {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.searchToolsPanel = new Episodeum.view.SearchToolsPanel();
			this.seriesListPanel = new Episodeum.view.SeriesListPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.searchToolsPanel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.seriesListPanel, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 440);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// searchToolsPanel
			// 
			this.searchToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchToolsPanel.Location = new System.Drawing.Point(3, 3);
			this.searchToolsPanel.Name = "searchToolsPanel";
			this.searchToolsPanel.Size = new System.Drawing.Size(603, 34);
			this.searchToolsPanel.TabIndex = 0;
			// 
			// seriesListPanel
			// 
			this.seriesListPanel.AutoScroll = true;
			this.seriesListPanel.BackColor = System.Drawing.SystemColors.Control;
			this.seriesListPanel.ColumnWidth = 0;
			this.seriesListPanel.DividerSize = 30;
			this.seriesListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seriesListPanel.Location = new System.Drawing.Point(3, 43);
			this.seriesListPanel.Name = "seriesListPanel";
			this.seriesListPanel.Orientation = Episodeum.view.ListPanel.ORIENTATION.VERTICAL;
			this.seriesListPanel.RowHeight = 50;
			this.seriesListPanel.Size = new System.Drawing.Size(603, 394);
			this.seriesListPanel.TabIndex = 1;
			// 
			// SearchSeriesPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SearchSeriesPanel";
			this.Size = new System.Drawing.Size(609, 440);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private SearchToolsPanel searchToolsPanel;
		private SeriesListPanel seriesListPanel;
	}
}
