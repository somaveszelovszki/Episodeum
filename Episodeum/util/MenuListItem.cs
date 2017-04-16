using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episodeum.util {
	public class MenuListItem {
		public int Id { get; set; }
		public string Name { get; set; }
		public System.Drawing.Bitmap Icon { get; set; }

		public MenuListItem() { }

		public MenuListItem(int id, string name, System.Drawing.Bitmap icon) {
			Id = id;
			Name = name;
			Icon = icon;
		}
	}
}
