using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.Properties;

namespace Episodeum.view {
	public partial class FileChooser : UserControl {

		public delegate void OnFilePathChangedDelegate(string filePath);

		public event OnFilePathChangedDelegate FilePathChanged;

		public FileChooser() {
			InitializeComponent();
		}

		private void browseButton_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				UpdateView(openFileDialog.FileName);
			}
		}

		private void filePathTextBox_TextChanged(object sender, EventArgs e) {
			FilePathChanged(filePathTextBox.Text);
		}

		internal void UpdateView(string filePath) {
			filePathTextBox.Text = filePath;
		}
	}
}
