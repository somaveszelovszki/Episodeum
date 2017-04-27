using System;
using System.Windows.Forms;
using Episodeum.util;
using Episodeum.Properties;

namespace Episodeum.view {
	public partial class CheckboxListItemUserControl : ListItemUserControl {

		public CheckboxListItemUserControl() : base() {
			Initialize(null);
		}

		public CheckboxListItemUserControl(Preference<bool> pref) : base() {
			Initialize(pref);
		}

		private void Initialize(Preference<bool> pref) {
			InitializeComponent();

			RegisterEventListeners();

			Anchor = AnchorStyles.Left | AnchorStyles.Right;


			if(pref != null) UpdateView(pref);
		}

		internal override void RegisterEventListeners() {
			base.RegisterEventListeners();

			checkBox.Click -= ListItemUserControl_Click;

			checkBox.CheckedChanged += CheckBox_CheckedChanged;
			ItemClick += CheckboxListItemUserControl_ItemClick;
		}

		private void CheckboxListItemUserControl_ItemClick(object sender, EventArgs e) {
			checkBox.Checked = !checkBox.Checked;
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e) {
			UpdatePreference();
		}

		internal void UpdatePreference() {
			Preference<bool> pref = (Preference<bool>) Tag;
			if(pref == null) return;

			Settings.Default[pref.Key] = checkBox.Checked;
		}

		public void UpdateView(Preference<bool> pref) {
			Tag = pref;
			UpdateView();
		}

		internal override void UpdateView() {
			Preference<bool> pref = (Preference<bool>) Tag;
			if(pref == null) return;

			nameLabel.Text = pref.Name;
			checkBox.Checked = (bool) Settings.Default[pref.Key];

			Invalidate();
		}
	}
}
