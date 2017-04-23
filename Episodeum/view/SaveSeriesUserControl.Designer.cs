namespace Episodeum {
	partial class SaveSeriesUserControl {
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
			this.overviewLabel = new System.Windows.Forms.Label();
			this.linksPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.tmdbButton = new System.Windows.Forms.PictureBox();
			this.imdbButton = new System.Windows.Forms.PictureBox();
			this.footerPanel = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.addButton = new Episodeum.view.RoundButton();
			this.headerPanel = new Episodeum.SeriesListItemUserControl();
			this.linksPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tmdbButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imdbButton)).BeginInit();
			this.footerPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// overviewLabel
			// 
			this.overviewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.overviewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.overviewLabel.Location = new System.Drawing.Point(0, 53);
			this.overviewLabel.Margin = new System.Windows.Forms.Padding(0);
			this.overviewLabel.Name = "overviewLabel";
			this.overviewLabel.Padding = new System.Windows.Forms.Padding(20);
			this.overviewLabel.Size = new System.Drawing.Size(604, 256);
			this.overviewLabel.TabIndex = 3;
			this.overviewLabel.Text = "overview";
			this.overviewLabel.Click += new System.EventHandler(this.imdbButton_Click);
			// 
			// linksPanel
			// 
			this.linksPanel.BackColor = System.Drawing.SystemColors.Control;
			this.linksPanel.Controls.Add(this.tmdbButton);
			this.linksPanel.Controls.Add(this.imdbButton);
			this.linksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.linksPanel.Location = new System.Drawing.Point(0, 0);
			this.linksPanel.Margin = new System.Windows.Forms.Padding(0);
			this.linksPanel.Name = "linksPanel";
			this.linksPanel.Size = new System.Drawing.Size(302, 66);
			this.linksPanel.TabIndex = 5;
			// 
			// tmdbButton
			// 
			this.tmdbButton.BackgroundImage = global::Episodeum.Properties.Resources._312x276_tmdb_primary_blue;
			this.tmdbButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.tmdbButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tmdbButton.Location = new System.Drawing.Point(3, 3);
			this.tmdbButton.Name = "tmdbButton";
			this.tmdbButton.Size = new System.Drawing.Size(60, 60);
			this.tmdbButton.TabIndex = 2;
			this.tmdbButton.TabStop = false;
			this.tmdbButton.Click += new System.EventHandler(this.tmdbButton_Click);
			// 
			// imdbButton
			// 
			this.imdbButton.BackgroundImage = global::Episodeum.Properties.Resources.IMDb_square_yellow;
			this.imdbButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.imdbButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imdbButton.Location = new System.Drawing.Point(69, 3);
			this.imdbButton.Name = "imdbButton";
			this.imdbButton.Size = new System.Drawing.Size(60, 60);
			this.imdbButton.TabIndex = 3;
			this.imdbButton.TabStop = false;
			this.imdbButton.Click += new System.EventHandler(this.imdbButton_Click);
			// 
			// footerPanel
			// 
			this.footerPanel.ColumnCount = 2;
			this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.footerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.footerPanel.Controls.Add(this.linksPanel, 0, 0);
			this.footerPanel.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footerPanel.Location = new System.Drawing.Point(0, 307);
			this.footerPanel.Name = "footerPanel";
			this.footerPanel.RowCount = 1;
			this.footerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.footerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.footerPanel.Size = new System.Drawing.Size(604, 66);
			this.footerPanel.TabIndex = 7;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.addButton);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(305, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 60);
			this.flowLayoutPanel1.TabIndex = 6;
			// 
			// addButton
			// 
			this.addButton.BackColor = System.Drawing.SystemColors.Control;
			this.addButton.BackgroundImage = global::Episodeum.Properties.Resources.ic_add_circle_outline;
			this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.addButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addButton.Location = new System.Drawing.Point(238, 3);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(55, 55);
			this.addButton.TabIndex = 0;
			this.addButton.UseVisualStyleBackColor = false;
			// 
			// headerPanel
			// 
			this.headerPanel.BackColor = System.Drawing.Color.DarkKhaki;
			this.headerPanel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(604, 50);
			this.headerPanel.TabIndex = 4;
			// 
			// SaveSeriesUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.footerPanel);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.overviewLabel);
			this.Name = "SaveSeriesUserControl";
			this.Size = new System.Drawing.Size(604, 373);
			this.linksPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tmdbButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imdbButton)).EndInit();
			this.footerPanel.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label overviewLabel;
		private SeriesListItemUserControl headerPanel;
		private System.Windows.Forms.FlowLayoutPanel linksPanel;
		private System.Windows.Forms.TableLayoutPanel footerPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private view.RoundButton addButton;
		private System.Windows.Forms.PictureBox tmdbButton;
		private System.Windows.Forms.PictureBox imdbButton;
	}
}
