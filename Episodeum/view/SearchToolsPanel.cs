using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Episodeum.view {
	public partial class SearchToolsPanel : UserControl {

		public delegate void SearchDelegate(string query);

		[Description("Fired when user clicks search button or hits ENTER"), Category("Data")]
		public event SearchDelegate Search;

		public IButtonControl AcceptButton { get; set; }

		public SearchToolsPanel() {
			InitializeComponent();

			AcceptButton = searchButton;
		}

		private void searchButton_Click(object sender, EventArgs e) {

			string query = searchTextBox.Text;

			Search(query);
		}
	}
}
