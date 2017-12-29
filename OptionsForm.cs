using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeePass.Plugins;
using KeePassLib.Collections;
using KeePassLib;

namespace KPFloatingPanel
{
	public partial class OptionsForm : Form
	{
		internal IPluginHost Host;
		public OptionsForm()
		{
			InitializeComponent();
			KeePass.Program.Translation.ApplyTo(this);
		}

		internal OptionsClass Options;

		private void btChangePanelColor_Click(object sender, EventArgs e)
		{
			ColorDialog.Color = pnPanelColor.BackColor;
			if (ColorDialog.ShowDialog() == DialogResult.OK)
				pnPanelColor.BackColor = ColorDialog.Color;
		}

		private void btChangeFontColor_Click(object sender, EventArgs e)
		{
			ColorDialog.Color = pnFontColor.BackColor;
			if (ColorDialog.ShowDialog() == DialogResult.OK)
				pnFontColor.BackColor = ColorDialog.Color;
		}
		private List<StartGroupDropdown> drop_items;
		private StartGroupDropdown drop_cur_item;
		private void add_sub_groups(PwGroup group, int level, string cur_item_uuid)
		{
			PwObjectList<PwGroup> groups = group.GetGroups(false);
			foreach (PwGroup sub_group in groups)
			{
				StartGroupDropdown item = new StartGroupDropdown(sub_group.Uuid.ToHexString(), sub_group.Name, level + 1);
				if (sub_group.Uuid.ToHexString() == cur_item_uuid)
					drop_cur_item = item;
				drop_items.Add(item);
				add_sub_groups(sub_group, level + 1, cur_item_uuid);
			}
		}
		private void OptionsForm_Load(object sender, EventArgs e)
		{
			pcOptions.TabIndex = 0;

			edPercent.Value = Options.Transparency;
			pnPanelColor.BackColor = Options.PanelColor;
			pnFontColor.BackColor = Options.FontColor;
			cbURLAction.SelectedIndex = Options.URLAction;
			cbxSortAlphabetical.Checked = Options.sortAlphabetical; //s²
			cbxShowClock.Checked = Options.showClock;
			cbxShortcutAlt.Checked = Options.shortcutAlt;
			cbxShortcutCntrl.Checked = Options.shortcutCntrl;
			cbxShortcutShift.Checked = Options.shortcutShift;
			cbxShortcutWin.Checked = Options.shortcutWin;
            cbxShortcutAltQuick.Checked = Options.shortcutAltQuick;
            cbxShortcutCntrlQuick.Checked = Options.shortcutCntrlQuick;
            cbxShortcutShiftQuick.Checked = Options.shortcutShiftQuick;
            cbxShortcutWinQuick.Checked = Options.shortcutWinQuick;
			cbxShowFoldersBeforeEntries.Checked = Options.foldersFirst;
			cbxShowSearch.Checked = Options.showSearch;
            cbxLockPosition.Checked = Options.lockWindowPosition;
			cbxShowLastOne.Checked = Options.showLastOne;
			txtShortcutKey.Text = Options.shortcutKey;
            txtShortcutKeyQuick.Text = Options.shortcutKeyQuick;
			drop_items = new List<StartGroupDropdown>();
			StartGroupDropdown drop = new StartGroupDropdown("", "Root Group", 0);
			drop_cur_item = drop;
			drop_items.Add(drop);
			if (Host.Database != null && Host.Database.IsOpen)
			{
				PwGroup cur_group = Host.Database.RootGroup;
				add_sub_groups(cur_group, 0, Options.startGroupUUID);
			}
			cbStartGroup.Items.Clear();
			cbStartGroup.Items.AddRange(drop_items.ToArray());
			cbStartGroup.SelectedItem = drop_cur_item;
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;

		}

		private void btOk_Click(object sender, EventArgs e)
		{
			Options.Transparency = edPercent.Value;
			Options.PanelColor = pnPanelColor.BackColor;
			Options.FontColor = pnFontColor.BackColor;
			Options.URLAction = cbURLAction.SelectedIndex;
			Options.sortAlphabetical = cbxSortAlphabetical.Checked; //s²
			Options.showClock = cbxShowClock.Checked;
			Options.startGroupUUID = ((StartGroupDropdown)cbStartGroup.SelectedItem).uuid;
			Options.shortcutAlt = cbxShortcutAlt.Checked;
			Options.shortcutCntrl = cbxShortcutCntrl.Checked;
			Options.shortcutShift = cbxShortcutShift.Checked;
			Options.shortcutWin = cbxShortcutWin.Checked;
            Options.shortcutAltQuick = cbxShortcutAltQuick.Checked;
            Options.shortcutCntrlQuick = cbxShortcutCntrlQuick.Checked;
            Options.shortcutShiftQuick = cbxShortcutShiftQuick.Checked;
            Options.shortcutWinQuick = cbxShortcutWinQuick.Checked;
			Options.foldersFirst = cbxShowFoldersBeforeEntries.Checked;
            Options.shortcutKeyQuick = txtShortcutKeyQuick.Text.ToUpper();
            Options.shortcutKey = txtShortcutKey.Text.ToUpper();
			Options.showSearch = cbxShowSearch.Checked;
            Options.lockWindowPosition = cbxLockPosition.Checked;
			Options.showLastOne = cbxShowLastOne.Checked;
			Options.Save();

			DialogResult = DialogResult.OK;
			Hide();
		}

		private void pnPanelColor_DoubleClick(object sender, EventArgs e)
		{
			btChangePanelColor_Click(sender, e);
		}

		private void pnFontColor_DoubleClick(object sender, EventArgs e)
		{
			btChangeFontColor_Click(sender, e);
		}
	}
	class StartGroupDropdown
	{
		public string uuid;
		public string name;
		public int level;
		public StartGroupDropdown(string uuid, string name, int level)
		{
			this.uuid = uuid;
			this.name = name;
			this.level = level;
		}
		public override string ToString()
		{
			string ret = "";
			for (int i = 0; i < level; i++)
				ret += "---";
			ret += name;
			return ret;
		}
	}
}
