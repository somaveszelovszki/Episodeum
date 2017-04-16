using System.Windows.Forms;
using Episodeum.util;

namespace Episodeum.view {
	public partial class MenuListItemPanel : ListItemUserControl {
		public MenuListItemPanel() {
			InitializeComponent();

			RegisterEventListeners();
		}

		public void UpdateView(MenuListItem menuItem) {
			Tag = menuItem.Id;
			label.Text = menuItem.Name;
			icon.Image = menuItem.Icon;
		}
	}
}
