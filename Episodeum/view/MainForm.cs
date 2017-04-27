
using Episodeum.database;
using Episodeum.database.model;
using SQLite;
using System;

using System.Windows.Forms;
using Episodeum.communication;
using System.Collections.Generic;
using Episodeum.view;
using System.Threading;
using Episodeum.util;
using static Episodeum.util.ControlUtils;
using Episodeum.Properties;

namespace Episodeum {

	/// <summary>
	/// Main form of the application.
	/// </summary>
    public partial class MainForm : Form {

		public enum PanelId {
			SearchSeries, SavedShows, Series, Settings
		};

		private Dictionary<PanelId, PanelData> panelsMap = new Dictionary<PanelId, PanelData>();

        public MainForm() {

			InitializePanelsMap();
            InitializeComponent();
			InitializeMenuPanel();
			InitializeContentPanels();

			App.Initialize(this);
		}

		private void InitializePanelsMap() {
			panelsMap.Add(PanelId.SearchSeries, new PanelData(new SearchSeriesPanel(this), new List<Series>()));
			panelsMap.Add(PanelId.SavedShows, new PanelData(new SavedShowsPanel(this), new List<Series>()));
			panelsMap.Add(PanelId.Series, new PanelData(new SeriesPanel(this), null));
			panelsMap.Add(PanelId.Settings, new PanelData(new SettingsPanel(this), null));
		}

		private void InitializeContentPanels() {
			foreach(PanelData panelData in panelsMap.Values) {

				ContentPanel panel = panelData.Panel;

				panel.Dock = DockStyle.Fill;
				panel.Visible = false;
				panelContainer.Controls.Add(panel);
			}

			AttachPanelEventListeners();
		}

		private void AttachPanelEventListeners() {

			// attaches event listeners for search series panel
			SearchSeriesPanel searchSeriesPanel = (SearchSeriesPanel) panelsMap[PanelId.SearchSeries].Panel;
			searchSeriesPanel.Search += SearchSeriesPanel_Search;
			searchSeriesPanel.SeriesClick += SearchSeriesPanel_SeriesClick;

			// attaches event listeners for saved shows panel
			SavedShowsPanel savedShowsPanel = (SavedShowsPanel) panelsMap[PanelId.SavedShows].Panel;
			savedShowsPanel.SeriesClick += SavedShowsPanel_SeriesClick;

			// attaches event listeners for series panel
			SeriesPanel seriesPanel = (SeriesPanel) panelsMap[PanelId.Series].Panel;
			seriesPanel.WatchEpisodeButtonClick += SeriesPanel_WatchEpisodeButtonClick;

			// Don't forget to attach event listeners for new panels as well!
		}

		private void SeriesPanel_WatchEpisodeButtonClick(Episode episode) {
			App.Instance.WatchEpisode(episode);
		}

		private void SavedShowsPanel_SeriesClick(Series series) {
			UpdatePanel(PanelId.Series, series, true);
		}

		private void InitializeMenuPanel() {

			menuPanel.MenuListItemClick += MenuPanel_MenuListItemClick;

			List<MenuListItem> menuItems = new List<MenuListItem>();

			// Search series menu item
			menuItems.Add(new MenuListItem((int) PanelId.SearchSeries, "Search",
				Properties.Resources.ic_add_circle_outline));

			// Saved shows menu item
			menuItems.Add(new MenuListItem((int) PanelId.SavedShows, "My shows",
				Properties.Resources.ic_add_circle_outline));

			// Saved shows menu item
			menuItems.Add(new MenuListItem((int) PanelId.Settings, "Settings",
				Properties.Resources.ic_add_circle_outline));

			menuPanel.UpdateView(menuItems);
		}

		internal void UpdatePanel(PanelId panelId, object data, bool loadPanel) {
			panelsMap[panelId].Data = data;

			if(loadPanel) LoadPanel(panelId);
		}

		private void SearchSeriesPanel_Search(string query) {
			App.Instance.SearchSeries(query);
		}

		private void SearchSeriesPanel_SeriesClick(Series series) {
			App.Instance.OpenSeriesDataForSaving(series);
		}

		private void MenuPanel_MenuListItemClick(object sender, EventArgs e) {
			LoadPanel((PanelId) ((MenuListItemPanel) sender).Tag);
		}

		private void HidePanels() {
			LoadPanel(null);
		}


		private delegate void LoadPanelDelegate(PanelId? panelId);

		internal void LoadPanel(PanelId? panelId) {

			if(IsDisposed) return;

			if(InvokeRequired)
				Invoke(new LoadPanelDelegate(LoadPanel), panelId);
			else {
				foreach(PanelId id in panelsMap.Keys) {
					ContentPanel panel = panelsMap[id].Panel;

					if(id == panelId) {
						panel.UpdateView();
						panel.Visible = true;
					} else {
						panel.Visible = false;

					}
				}

				Invalidate();
			}
		}

		internal object GetPanelData(ContentPanel panel) {
			return panelsMap[panel.PanelId].Data;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {

			Settings.Default.Save();

			base.OnClosing(e);
		}
	}
}
