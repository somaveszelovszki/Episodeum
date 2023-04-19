using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.util;
using Episodeum.Properties;

namespace Episodeum.view {
	public partial class StringPreferenceListItemUserControl : ListItemUserControl {

		public StringPreferenceListItemUserControl() : base() {
			Initialize(null);
		}

		public StringPreferenceListItemUserControl(Preference<string> pref) : base() {
			Initialize(pref);
		}

		private void Initialize(Preference<string> pref) {
			InitializeComponent();

			RegisterEventListeners();

			Anchor = AnchorStyles.Left | AnchorStyles.Right;


			if(pref != null) UpdateView(pref);
		}

		internal override void RegisterEventListeners() {
			base.RegisterEventListeners();

			fileChooser.FilePathChanged += FileChooser_FilePathChanged;
		}

		private void FileChooser_FilePathChanged(string filePath) {
			Settings.Default.ExternalMediaPlayerPath = filePath;
		}

		public void UpdateView(Preference<string> pref) {
			Tag = pref;
			UpdateView();
		}

		internal override void UpdateView() {
			Preference<string> pref = (Preference<string>) Tag;
			if(pref == null) return;

			nameLabel.Text = pref.Name;
			fileChooser.UpdateView(pref.Value);

			Invalidate();
		}
	}
}
