namespace Episodeum.view {
	partial class SeriesPanel {
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
			this.headerPanel = new Episodeum.SeriesListItemUserControl();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.overviewTabPage = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.overviewLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.staticNextEpisodeLabel = new System.Windows.Forms.Label();
			this.watchNowButton = new System.Windows.Forms.Button();
			this.nextEpisodeNumberLabel = new System.Windows.Forms.Label();
			this.seasonsTabPage = new System.Windows.Forms.TabPage();
			this.tabControl.SuspendLayout();
			this.overviewTabPage.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerPanel
			// 
			this.headerPanel.BackColor = System.Drawing.Color.DarkKhaki;
			this.headerPanel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(530, 50);
			this.headerPanel.TabIndex = 0;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.overviewTabPage);
			this.tabControl.Controls.Add(this.seasonsTabPage);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 50);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(20, 5);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(530, 325);
			this.tabControl.TabIndex = 1;
			// 
			// overviewTabPage
			// 
			this.overviewTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.overviewTabPage.Controls.Add(this.tableLayoutPanel);
			this.overviewTabPage.Location = new System.Drawing.Point(4, 26);
			this.overviewTabPage.Name = "overviewTabPage";
			this.overviewTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.overviewTabPage.Size = new System.Drawing.Size(522, 295);
			this.overviewTabPage.TabIndex = 0;
			this.overviewTabPage.Text = "Overview";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.overviewLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(516, 289);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// overviewLabel
			// 
			this.overviewLabel.AutoSize = true;
			this.overviewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.overviewLabel.Location = new System.Drawing.Point(20, 20);
			this.overviewLabel.Margin = new System.Windows.Forms.Padding(20);
			this.overviewLabel.Name = "overviewLabel";
			this.overviewLabel.Size = new System.Drawing.Size(476, 13);
			this.overviewLabel.TabIndex = 0;
			this.overviewLabel.Text = "overview";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightCoral;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.staticNextEpisodeLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.watchNowButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.nextEpisodeNumberLabel, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 53);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 40);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// staticNextEpisodeLabel
			// 
			this.staticNextEpisodeLabel.AutoSize = true;
			this.staticNextEpisodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.staticNextEpisodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.staticNextEpisodeLabel.Location = new System.Drawing.Point(3, 0);
			this.staticNextEpisodeLabel.Name = "staticNextEpisodeLabel";
			this.staticNextEpisodeLabel.Size = new System.Drawing.Size(114, 40);
			this.staticNextEpisodeLabel.TabIndex = 0;
			this.staticNextEpisodeLabel.Text = "Next episode:";
			this.staticNextEpisodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// watchNowButton
			// 
			this.watchNowButton.AutoSize = true;
			this.watchNowButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.watchNowButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.watchNowButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.watchNowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.watchNowButton.Location = new System.Drawing.Point(308, 5);
			this.watchNowButton.Margin = new System.Windows.Forms.Padding(5);
			this.watchNowButton.Name = "watchNowButton";
			this.watchNowButton.Size = new System.Drawing.Size(107, 30);
			this.watchNowButton.TabIndex = 2;
			this.watchNowButton.Text = "Watch now!";
			this.watchNowButton.UseVisualStyleBackColor = false;
			// 
			// nextEpisodeNumberLabel
			// 
			this.nextEpisodeNumberLabel.AutoSize = true;
			this.nextEpisodeNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nextEpisodeNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nextEpisodeNumberLabel.Location = new System.Drawing.Point(123, 0);
			this.nextEpisodeNumberLabel.Name = "nextEpisodeNumberLabel";
			this.nextEpisodeNumberLabel.Size = new System.Drawing.Size(177, 40);
			this.nextEpisodeNumberLabel.TabIndex = 3;
			this.nextEpisodeNumberLabel.Text = "Season 1 Episode 1";
			this.nextEpisodeNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// seasonsTabPage
			// 
			this.seasonsTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.seasonsTabPage.Location = new System.Drawing.Point(4, 26);
			this.seasonsTabPage.Name = "seasonsTabPage";
			this.seasonsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.seasonsTabPage.Size = new System.Drawing.Size(522, 295);
			this.seasonsTabPage.TabIndex = 1;
			this.seasonsTabPage.Text = "Seasons";
			// 
			// SeriesPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.headerPanel);
			this.Name = "SeriesPanel";
			this.Size = new System.Drawing.Size(530, 375);
			this.tabControl.ResumeLayout(false);
			this.overviewTabPage.ResumeLayout(false);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private SeriesListItemUserControl headerPanel;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage overviewTabPage;
		private System.Windows.Forms.TabPage seasonsTabPage;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label overviewLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label staticNextEpisodeLabel;
		private System.Windows.Forms.Button watchNowButton;
		private System.Windows.Forms.Label nextEpisodeNumberLabel;
	}
}
