namespace Episodeum.view {
	partial class SeriesDataForm {
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
			this.seriesDataUserControl = new Episodeum.SeriesDataUserControl();
			this.SuspendLayout();
			// 
			// seriesDataUserControl
			// 
			this.seriesDataUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.seriesDataUserControl.Location = new System.Drawing.Point(0, 0);
			this.seriesDataUserControl.Name = "seriesDataUserControl";
			this.seriesDataUserControl.Size = new System.Drawing.Size(748, 500);
			this.seriesDataUserControl.TabIndex = 0;
			// 
			// seriesDataForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 500);
			this.Controls.Add(this.seriesDataUserControl);
			this.Name = "seriesDataForm";
			this.Text = "Series data";
			this.ResumeLayout(false);

		}

		#endregion

		private SeriesDataUserControl seriesDataUserControl;
	}
}