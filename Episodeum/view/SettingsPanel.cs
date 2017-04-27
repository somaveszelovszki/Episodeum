using System.Collections.Generic;
using Episodeum.Properties;
using Episodeum.util;
using static Episodeum.MainForm;

namespace Episodeum.view {
	public partial class SettingsPanel : ContentPanel {

		public SettingsPanel(MainForm mainForm) : base(mainForm) {
			InitializeComponent();
			panelId = PanelId.Settings;

			preferenceList.Add(new CheckboxListItemUserControl(
				new Preference<bool>("OpenMediaInApp", "Open media in app")));

			preferenceList.Add(new StringPreferenceListItemUserControl(
				new Preference<string>("ExternalMediaPlayerPath", "External media player executable file")));

			preferenceList.ItemClick += PreferenceList_ItemClick;
		}

		private void PreferenceList_ItemClick(object sender, System.EventArgs e) {
			// do nothing
		}

		internal override void UpdateView() {

			for(int i = 0; i < preferenceList.Count; i++)
				((ListItemUserControl) preferenceList[i]).UpdateView();

			Invalidate();
		}
	}
}
