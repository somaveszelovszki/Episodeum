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
			this.menuPanel = new Episodeum.view.MenuPanel();
			this.panelContainer = new System.Windows.Forms.Panel();
			this.mainTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.ColumnCount = 2;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Controls.Add(this.menuPanel, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.panelContainer, 1, 0);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 1;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(752, 403);
			this.mainTableLayoutPanel.TabIndex = 1;
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
			// panelContainer
			// 
			this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContainer.Location = new System.Drawing.Point(203, 3);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(546, 397);
			this.panelContainer.TabIndex = 2;
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(752, 403);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Name = "MainForm";
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion
		private TableLayoutPanel mainTableLayoutPanel;
		private view.MenuPanel menuPanel;
		private Panel panelContainer;
	}
}

