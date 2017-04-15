using System.Windows.Forms;

namespace Episodeum {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.searchPanel = new System.Windows.Forms.TableLayoutPanel();
			this.searchToolsPanel = new Episodeum.view.SearchToolsPanel();
			this.searchedSeriesListPanel = new Episodeum.view.ListPanel();
			this.menuPanel = new Episodeum.view.MenuPanel();
			this.mainTableLayoutPanel.SuspendLayout();
			this.searchPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.ColumnCount = 2;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Controls.Add(this.searchPanel, 1, 0);
			this.mainTableLayoutPanel.Controls.Add(this.menuPanel, 0, 0);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 1;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(752, 403);
			this.mainTableLayoutPanel.TabIndex = 1;
			// 
			// searchPanel
			// 
			this.searchPanel.ColumnCount = 1;
			this.searchPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.searchPanel.Controls.Add(this.searchToolsPanel, 0, 0);
			this.searchPanel.Controls.Add(this.searchedSeriesListPanel, 0, 1);
			this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchPanel.Location = new System.Drawing.Point(200, 0);
			this.searchPanel.Margin = new System.Windows.Forms.Padding(0);
			this.searchPanel.Name = "searchPanel";
			this.searchPanel.RowCount = 2;
			this.searchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.searchPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.searchPanel.Size = new System.Drawing.Size(552, 403);
			this.searchPanel.TabIndex = 0;
			// 
			// searchToolsPanel
			// 
			this.searchToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchToolsPanel.Location = new System.Drawing.Point(3, 3);
			this.searchToolsPanel.Name = "searchToolsPanel";
			this.searchToolsPanel.Size = new System.Drawing.Size(546, 34);
			this.searchToolsPanel.TabIndex = 0;
			this.searchToolsPanel.Search += new Episodeum.view.SearchToolsPanel.SearchDelegate(this.searchToolsPanel_Search);
			// 
			// searchedSeriesListPanel
			// 
			this.searchedSeriesListPanel.AutoScroll = true;
			this.searchedSeriesListPanel.BackColor = System.Drawing.SystemColors.Control;
			this.searchedSeriesListPanel.ColumnWidth = 0;
			this.searchedSeriesListPanel.DividerSize = 30;
			this.searchedSeriesListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.searchedSeriesListPanel.Location = new System.Drawing.Point(3, 43);
			this.searchedSeriesListPanel.Name = "searchedSeriesListPanel";
			this.searchedSeriesListPanel.Orientation = Episodeum.view.ListPanel.ORIENTATION.VERTICAL;
			this.searchedSeriesListPanel.RowHeight = 50;
			this.searchedSeriesListPanel.Size = new System.Drawing.Size(546, 357);
			this.searchedSeriesListPanel.TabIndex = 1;
			// 
			// menuPanel
			// 
			this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuPanel.Location = new System.Drawing.Point(0, 0);
			this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
			this.menuPanel.Name = "menuPanel";
			this.menuPanel.Size = new System.Drawing.Size(200, 403);
			this.menuPanel.TabIndex = 1;
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(752, 403);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Name = "MainForm";
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.searchPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion
		private TableLayoutPanel mainTableLayoutPanel;
		private TableLayoutPanel searchPanel;
		private view.SearchToolsPanel searchToolsPanel;
		private view.ListPanel searchedSeriesListPanel;
		private view.MenuPanel menuPanel;
	}
}

