namespace Episodeum.view {
	partial class MenuPanel {
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
			this.menuListPanel = new Episodeum.view.ListPanel();
			this.profilePanel = new System.Windows.Forms.Panel();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.menuListPanel, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.profilePanel, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(292, 494);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// menuListPanel
			// 
			this.menuListPanel.BackColor = System.Drawing.SystemColors.Control;
			this.menuListPanel.ColumnWidth = 0;
			this.menuListPanel.DividerSize = 1;
			this.menuListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuListPanel.Location = new System.Drawing.Point(4, 75);
			this.menuListPanel.Name = "menuListPanel";
			this.menuListPanel.Orientation = Episodeum.view.ListPanel.ORIENTATION.VERTICAL;
			this.menuListPanel.Padding = new System.Windows.Forms.Padding(10);
			this.menuListPanel.RowHeight = 30;
			this.menuListPanel.Size = new System.Drawing.Size(284, 415);
			this.menuListPanel.TabIndex = 0;
			// 
			// profilePanel
			// 
			this.profilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.profilePanel.Location = new System.Drawing.Point(11, 11);
			this.profilePanel.Margin = new System.Windows.Forms.Padding(10);
			this.profilePanel.Name = "profilePanel";
			this.profilePanel.Size = new System.Drawing.Size(270, 50);
			this.profilePanel.TabIndex = 1;
			// 
			// MenuPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "MenuPanel";
			this.Size = new System.Drawing.Size(292, 494);
			this.tableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private ListPanel menuListPanel;
		private System.Windows.Forms.Panel profilePanel;
	}
}
