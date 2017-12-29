using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using KeePass.Plugins;


namespace KPFloatingPanel {
	internal sealed class KPFloatingPanelExt : Plugin {
		private IPluginHost FHost;
		private MainForm FForm;
		private ToolStripMenuItem FMenuItem;
		private ToolStripMenuItem FTrayItem;
		private ToolStripSeparator FMenuSeparator;
		private ToolStripSeparator FTraySeparator;

		private void InitForm() {
			FForm = new MainForm();
			FForm.Host = FHost;
			FForm.RestorePosition();
			FForm.Show();
		}
		public override string UpdateUrl {
			get {
				return "http://mitchcapper.com/keepass_versions.txt?KPFP";
			}
		}
		public override bool Initialize(IPluginHost AHost) {
			Debug.Assert(AHost != null);
			if (AHost == null) return false;

			FHost = AHost;

			InitForm();

			FMenuItem = new ToolStripMenuItem();
			FMenuItem.Text = "Show Floating Panel";
			FMenuItem.ToolTipText = "Shows floating panel with passwords in the top-right corner of screen";
			FMenuItem.Image = FForm.ilIcons.Images[0];
			FMenuItem.Click += OnShowPanelClick;

			FMenuSeparator = null;
			for (int i = 0; i < FHost.MainWindow.ToolsMenu.DropDownItems.Count; ++i) {
				if (FHost.MainWindow.ToolsMenu.DropDownItems[i].Name == "m_menuToolsPlugins") {
					if (i == (FHost.MainWindow.ToolsMenu.DropDownItems.Count - 1)) {
						FMenuSeparator = new ToolStripSeparator();
						FHost.MainWindow.ToolsMenu.DropDownItems.Add(FMenuSeparator);
					}
					break;
				}
			}
			FHost.MainWindow.ToolsMenu.DropDownItems.Add(FMenuItem);

			FTrayItem = new ToolStripMenuItem();
			FTrayItem.Text = "Show Floating Panel";
			FTrayItem.ToolTipText = "Shows floating panel with passwords in the top-right corner of screen";
			FTrayItem.Image = FForm.ilIcons.Images[0];
			FTrayItem.Click += OnShowPanelClick;

			FTraySeparator = null;
			if (FHost.MainWindow.TrayContextMenu.Items.Count < 3)
				FHost.MainWindow.TrayContextMenu.Items.Insert(0, FTrayItem);
			else {
				if (FHost.MainWindow.TrayContextMenu.Items[2].Name == "m_ctxTrayLock") {
					FTraySeparator = new ToolStripSeparator();
					FHost.MainWindow.TrayContextMenu.Items.Insert(1, FTraySeparator);
				}
				FHost.MainWindow.TrayContextMenu.Items.Insert(2, FTrayItem);
			}
			return true;
		}
		private void OnShowPanelClick(object sender, EventArgs e) {
			if (FForm == null || FForm.IsDisposed)
				InitForm();
			FForm.TopMost = false;
			FForm.Hide();
			FForm.TopMost = true;
			FForm.RestorePosition();
			FForm.Show();
			FForm.BringToFront();
			if (FForm.Opacity < 0.2)
				FForm.Opacity = 1.0;
		}
		public override Image SmallIcon {
			get {
				if (FForm == null)
					return null;
				else
					return FForm.ilIcons.Images[0];
			}
		}
		public override void Terminate() {
			FForm.Hide();
			FForm.CleanUp();
			FHost.MainWindow.TrayContextMenu.Items.Remove(FTraySeparator);
			FHost.MainWindow.TrayContextMenu.Items.Remove(FTrayItem);
			FHost.MainWindow.ToolsMenu.DropDownItems.Remove(FMenuSeparator);
			FHost.MainWindow.ToolsMenu.DropDownItems.Remove(FMenuItem);
			FTraySeparator = null;
			FMenuSeparator = null;
			FTrayItem = null;
			FMenuItem = null;
			FForm = null;
			FHost = null;
		}
	}
}
