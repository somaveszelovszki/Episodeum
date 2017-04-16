
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Episodeum.util;

namespace Episodeum.view {
	public partial class MenuPanel : UserControl {

		public event EventHandler MenuListItemClick {
			add { menuListPanel.ItemClick += value; }
			remove { menuListPanel.ItemClick -= value; }
		}

		public MenuPanel() {
			InitializeComponent();
		}

		internal void UpdateView(List<MenuListItem> menuItems) {

			menuListPanel.Clear();

			foreach(MenuListItem menuItem in menuItems) {
				MenuListItemPanel listItemPanel = new MenuListItemPanel();
				listItemPanel.UpdateView(menuItem);
				menuListPanel.Add(listItemPanel);
			}

			Invalidate();
		}
	}
}
