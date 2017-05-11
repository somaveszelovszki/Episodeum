using System;
using System.Collections.Generic;
using Episodeum.database.model;
using Episodeum.util;

namespace Episodeum.view {
	public partial class StatisticsPanel : ContentPanel {

		public StatisticsPanel(MainForm mainForm) : base(mainForm) {
			this.mainForm = mainForm;
			InitializeComponent();
		}

		internal override void UpdateView() {
			List<UserStatistics> stats = App.Instance.DbManager.GetUserStatistics();

			List<IGraphable> graphEntries = new List<IGraphable>();

			foreach(UserStatistics stat in stats)
				graphEntries.Add(stat);

			/*List<IGraphable> stats = new List<IGraphable>() {
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 10.").ToString(), TimeWatching = 10 } },
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 11.").ToString(), TimeWatching = 0 } },
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 12.").ToString(), TimeWatching = 5 } },
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 13.").ToString(), TimeWatching = 2 } },
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 14.").ToString(), TimeWatching = 5 } },
				{ new UserStatistics() { Date = DateTime.Parse("2017. 04. 15.").ToString(), TimeWatching = 8 } }
			};*/

			graphControl.Entries = graphEntries;
		}
	}
}
