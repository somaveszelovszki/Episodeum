namespace Episodeum.view {
	partial class SaveSeriesForm {
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
			this.saveSeriesUserControl = new Episodeum.SaveSeriesUserControl();
			this.SuspendLayout();
			// 
			// saveSeriesUserControl
			// 
			this.saveSeriesUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.saveSeriesUserControl.Location = new System.Drawing.Point(0, 0);
			this.saveSeriesUserControl.Name = "saveSeriesUserControl";
			this.saveSeriesUserControl.Size = new System.Drawing.Size(748, 500);
			this.saveSeriesUserControl.TabIndex = 0;
			// 
			// SaveSeriesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 500);
			this.Controls.Add(this.saveSeriesUserControl);
			this.Name = "SaveSeriesForm";
			this.Text = "Series data";
			this.ResumeLayout(false);

		}

		#endregion

		private SaveSeriesUserControl saveSeriesUserControl;
	}
}