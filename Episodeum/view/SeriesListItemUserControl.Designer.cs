namespace Episodeum {
	partial class SeriesListItemUserControl {
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
			this.posterPictureBox = new System.Windows.Forms.PictureBox();
			this.seriesBasicInfoPanel = new System.Windows.Forms.TableLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.ratingLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).BeginInit();
			this.seriesBasicInfoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// posterPictureBox
			// 
			this.posterPictureBox.BackColor = System.Drawing.Color.DarkKhaki;
			this.posterPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.posterPictureBox.Location = new System.Drawing.Point(3, 3);
			this.posterPictureBox.Name = "posterPictureBox";
			this.posterPictureBox.Size = new System.Drawing.Size(44, 44);
			this.posterPictureBox.TabIndex = 2;
			this.posterPictureBox.TabStop = false;
			// 
			// seriesBasicInfoPanel
			// 
			this.seriesBasicInfoPanel.ColumnCount = 3;
			this.seriesBasicInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.seriesBasicInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.seriesBasicInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.seriesBasicInfoPanel.Controls.Add(this.posterPictureBox);
			this.seriesBasicInfoPanel.Controls.Add(this.titleLabel);
			this.seriesBasicInfoPanel.Controls.Add(this.ratingLabel);
			this.seriesBasicInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seriesBasicInfoPanel.Location = new System.Drawing.Point(0, 0);
			this.seriesBasicInfoPanel.Name = "seriesBasicInfoPanel";
			this.seriesBasicInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.seriesBasicInfoPanel.Size = new System.Drawing.Size(564, 50);
			this.seriesBasicInfoPanel.TabIndex = 0;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.BackColor = System.Drawing.Color.DarkKhaki;
			this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(53, 0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Padding = new System.Windows.Forms.Padding(30, 0, 5, 0);
			this.titleLabel.Size = new System.Drawing.Size(458, 50);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "title";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ratingLabel
			// 
			this.ratingLabel.AutoSize = true;
			this.ratingLabel.BackColor = System.Drawing.Color.DarkKhaki;
			this.ratingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ratingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ratingLabel.Location = new System.Drawing.Point(517, 0);
			this.ratingLabel.Name = "ratingLabel";
			this.ratingLabel.Size = new System.Drawing.Size(44, 50);
			this.ratingLabel.TabIndex = 2;
			this.ratingLabel.Text = "N/A";
			this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SeriesListItemUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkKhaki;
			this.Controls.Add(this.seriesBasicInfoPanel);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.Name = "SeriesListItemUserControl";
			this.Size = new System.Drawing.Size(564, 50);
			((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).EndInit();
			this.seriesBasicInfoPanel.ResumeLayout(false);
			this.seriesBasicInfoPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox posterPictureBox;
		private System.Windows.Forms.TableLayoutPanel seriesBasicInfoPanel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label ratingLabel;
	}
}
