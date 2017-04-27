namespace Episodeum.view {
	partial class FileChooser {
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
			this.filePathTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new Episodeum.view.RoundButton();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel.Controls.Add(this.filePathTextBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.browseButton, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(300, 30);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// filePathTextBox
			// 
			this.filePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.filePathTextBox.Location = new System.Drawing.Point(3, 3);
			this.filePathTextBox.Name = "filePathTextBox";
			this.filePathTextBox.Size = new System.Drawing.Size(264, 23);
			this.filePathTextBox.TabIndex = 0;
			this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
			// 
			// browseButton
			// 
			this.browseButton.BackgroundImage = global::Episodeum.Properties.Resources.ic_add_circle_outline;
			this.browseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.browseButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.browseButton.Location = new System.Drawing.Point(273, 3);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(24, 24);
			this.browseButton.TabIndex = 1;
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// FileChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "FileChooser";
			this.Size = new System.Drawing.Size(300, 30);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.TextBox filePathTextBox;
		private RoundButton browseButton;
	}
}
