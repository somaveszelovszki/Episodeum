using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Episodeum.database.model;
using Episodeum.Properties;

namespace Episodeum.view {
	public partial class MediaPlayerForm : Form {
		public MediaPlayerForm() {
			InitializeComponent();
		}

		public void UpdateView(Episode episode) {

			string filePath = Files.GetEpisodeFile(episode);

			axVLCPlugin2.playlist.add("file:///" + filePath);
			axVLCPlugin2.playlist.play();
		}
	}
}
