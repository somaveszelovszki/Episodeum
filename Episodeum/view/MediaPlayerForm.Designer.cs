namespace Episodeum.view {
	partial class MediaPlayerForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayerForm));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.axVLCPlugin2 = new AxAXVLC.AxVLCPlugin2();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin2)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.axVLCPlugin2, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(756, 446);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// axVLCPlugin2
			// 
			this.axVLCPlugin2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axVLCPlugin2.Enabled = true;
			this.axVLCPlugin2.Location = new System.Drawing.Point(3, 3);
			this.axVLCPlugin2.Name = "axVLCPlugin2";
			this.axVLCPlugin2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin2.OcxState")));
			this.axVLCPlugin2.Size = new System.Drawing.Size(750, 400);
			this.axVLCPlugin2.TabIndex = 0;
			// 
			// MediaPlayerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(756, 446);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "MediaPlayerForm";
			this.Text = "MediaPlayerForm";
			this.tableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private AxAXVLC.AxVLCPlugin2 axVLCPlugin2;
	}
}