using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using KeePass;
using KeePass.Forms;
using KeePass.Plugins;
using KeePass.Resources;
using KeePass.Util;
using KeePassLib;
using KeePassLib.Collections;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Security;
using KeePassLib.Utility;

using System.Runtime.InteropServices; // for SetWindowsPos

namespace KPFloatingPanel {
	internal partial class MainForm : Form {
		private int FOldX;
		private int FOldY;
		private int FMoving;
		private string FLastName;
		private OptionsClass FOptions;
		internal IPluginHost Host;

		private const int SpaceForButtons = 300;
		private HotKeyboardHook kb_shortcut;
        private HotKeyboardHook kb_shortcut_quick;
		private HotKeyboardHook.ModifierKeys shortcut_last_mod;
		private string shortcut_last_key = "";
        private HotKeyboardHook.ModifierKeys shortcut_last_mod_quick;
        private string shortcut_last_key_quick = "";
	    private int quick_anim = 0;
		public void CleanUp() {
			if (kb_shortcut != null)
				kb_shortcut.Dispose();


		}
		public MainForm() {
			InitializeComponent();
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			FMoving = 0;
			FLastName = "";
			FOptions = new OptionsClass();
			tmClock_Tick(null, null);
			ApplyOptions();

			Program.Translation.ApplyTo(this);
			Program.Translation.ApplyTo("KeePass.Forms.Plugins.PCFloatingPanel.MainForm.MainMenu", pmMainMenu.Items);
		}


		// prevent stealing focus
		protected override bool ShowWithoutActivation { get { return true; } }
        private void update_shortcut_key_quick()
        {
            HotKeyboardHook.ModifierKeys m_keys = 0;
            if (FOptions.shortcutShiftQuick)
                m_keys |= HotKeyboardHook.ModifierKeys.Shift;
            if (FOptions.shortcutAltQuick)
                m_keys |= HotKeyboardHook.ModifierKeys.Alt;
            if (FOptions.shortcutCntrlQuick)
                m_keys |= HotKeyboardHook.ModifierKeys.Control;
            if (FOptions.shortcutWinQuick)
                m_keys |= HotKeyboardHook.ModifierKeys.Win;
            if (kb_shortcut_quick != null && (shortcut_last_mod_quick != m_keys || shortcut_last_key_quick != FOptions.shortcutKeyQuick))
            {
                kb_shortcut_quick.Dispose();
                kb_shortcut_quick = null;
            }
            if (kb_shortcut_quick == null && !string.IsNullOrEmpty(FOptions.shortcutKeyQuick) && m_keys != 0)
            {
                kb_shortcut_quick = new HotKeyboardHook();
                kb_shortcut_quick.KeyPressed += handle_keyboard_shortcut_quick;

                char key = FOptions.shortcutKeyQuick[0];
                try{
                kb_shortcut_quick.RegisterHotKey(m_keys, (Keys)key);
                }catch (Exception e)
                {
                    MessageBox.Show("KPFloatingPanel: Unable to register QuickPass hotkey due to: " + e.Message);
                }
                shortcut_last_key_quick = FOptions.shortcutKeyQuick;
                shortcut_last_mod_quick = m_keys;
            }
        }
        private void update_shortcut_key() {
			HotKeyboardHook.ModifierKeys m_keys = 0;
			if (FOptions.shortcutShift)
				m_keys |= HotKeyboardHook.ModifierKeys.Shift;
			if (FOptions.shortcutAlt)
				m_keys |= HotKeyboardHook.ModifierKeys.Alt;
			if (FOptions.shortcutCntrl)
				m_keys |= HotKeyboardHook.ModifierKeys.Control;
			if (FOptions.shortcutWin)
				m_keys |= HotKeyboardHook.ModifierKeys.Win;
			if (kb_shortcut != null && (shortcut_last_mod != m_keys || shortcut_last_key != FOptions.shortcutKey)) {
				kb_shortcut.Dispose();
				kb_shortcut = null;
			}
			if (kb_shortcut == null && !string.IsNullOrEmpty(FOptions.shortcutKey) && m_keys != 0) {
				kb_shortcut = new HotKeyboardHook();
				kb_shortcut.KeyPressed += handle_keyboard_shortcut;

				char key = FOptions.shortcutKey[0];
                try
                {
                    kb_shortcut.RegisterHotKey(m_keys, (Keys) key);
                }catch (Exception e)
                {
                    MessageBox.Show("KPFloatingPanel: Unable to register QuickPass hotkey due to: " + e.Message);
                }
			    shortcut_last_key = FOptions.shortcutKey;
				shortcut_last_mod = m_keys;
			}
		}
		private void ApplyOptions() {
			update_shortcut_key();
		    update_shortcut_key_quick();
			BackColor = FOptions.PanelColor;
			lbClock.ForeColor = FOptions.FontColor;
			Opacity = (double)FOptions.Transparency / 100;
			toolStripTextSearch.Visible = FOptions.showSearch;
			try {
				pmPasswords_Opening(null, null);
			}
			catch (Exception e) {
				MessageBox.Show(e.Message + " -- " + e.StackTrace);
			}
			TopMost = true;
		}

		public void ResetPosition() {
			Rectangle R = Screen.GetWorkingArea(Host.MainWindow);
			Top = R.Top;
			Left = R.Left + R.Width - Width - SpaceForButtons;
		}
		private bool last_show_clock;
		private void tmClock_Tick(object sender, EventArgs e) {

			bool update_text = FOptions.showClock;
			if (last_show_clock && !update_text)//when the user changes the options to no longer show the clock we need to know to hide it.
				update_text = true;
			last_show_clock = FOptions.showClock;
			string S = FOptions.showClock ? DateTime.Now + " - " : "";
			string display_name = "";
			if ((Host != null) && (Host.MainWindow != null) && (Host.Database != null)) {
				if (!Host.MainWindow.IsFileLocked(null)) {
					display_name = UrlUtil.StripExtension(UrlUtil.GetFileName(Host.Database.IOConnectionInfo.Path));
					if (Host.Database.Modified) display_name += "*";
				}
				else // Locked
				{
					display_name = UrlUtil.StripExtension(UrlUtil.GetFileName(Host.MainWindow.DocumentManager.ActiveDocument.LockedIoc.Path));
					display_name += " [" + KPRes.Locked + "]";
				}
			}
            if (quick_anim != 0)
            {
                switch (quick_anim)
                {
                    case 3:
                        display_name += " :)";
                        break;
                    case 2:
                        display_name += " :|";
                        break;
                    case 1:
                        display_name += " :O";
                        break;

                }
                quick_anim--;
            }
			if (FLastName != display_name) {
                toolStripMenuSaveDatabase.Enabled = Host != null && Host.Database != null && Host.Database.IsOpen;
				FLastName = display_name;
				TopMost = true;
				update_text = true;
			}
			if (display_name != "")
				S += display_name;
			if (update_text)
				lbClock.Text = S;
		}

		private void miHide_Click(object sender, EventArgs e) {
			Hide();
		}

		private void miSetup_Click(object sender, EventArgs e) {
			using (OptionsForm FForm = new OptionsForm()) {
				FForm.Host = Host;
				FForm.Options = FOptions;
				if (FForm.ShowDialog() == DialogResult.OK)
					ApplyOptions();

			}
		}

		private void lbClock_MouseDown(object sender, MouseEventArgs e) {
			FOldX = Cursor.Position.X;
			FOldY = Cursor.Position.Y;
			FMoving = e.Button == MouseButtons.Left ? 1 : 0;
		}


		private void lbClock_MouseMove(object sender, MouseEventArgs e) {
			if ((FMoving == 1) && ((Cursor.Position.X != FOldX) || (Cursor.Position.Y != FOldY)))
				FMoving = 2;
			if (FMoving == 2) {
				Location = new Point(Location.X + Cursor.Position.X - FOldX, Location.Y + Cursor.Position.Y - FOldY);
				FOldX = Cursor.Position.X;
				FOldY = Cursor.Position.Y;
			}
		}

		[DllImport("user32")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32")]
		private static extern IntPtr GetForegroundWindow();


		[DllImport("user32")]
		private static extern bool AttachThreadInput(int nThreadId, int nThreadIdTo, bool bAttach);

		[DllImport("user32")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, int unused);

		public bool SetForegroundWindow(Form form, bool force)
		{
			IntPtr window = form.Handle;
			IntPtr windowForeground = GetForegroundWindow();
			if (window == windowForeground || SetForegroundWindow(window))
				return true;

			if (force == false)
				return false;

			if (windowForeground == IntPtr.Zero)
				return false;

			if (!AttachThreadInput(System.Threading.Thread.CurrentThread.ManagedThreadId, GetWindowThreadProcessId(windowForeground, 0), true))
				return false;

			SetForegroundWindow(window);
			AttachThreadInput(System.Threading.Thread.CurrentThread.ManagedThreadId, GetWindowThreadProcessId(windowForeground, 0), false);
			form.BringToFront();
			form.Focus();
			return (GetForegroundWindow() == window);
		}

        public void handle_keyboard_shortcut_quick(object sender, KeyPressedEventArgs e)
        {
            ProtectedString str;
            PwGenerator.Generate(out str, Program.Config.PasswordGenerator.AutoGeneratedPasswordsProfile, null, Program.PwGeneratorPool);
            Clipboard.SetText(str.ReadString());
            quick_anim = 3;
        }
		public void handle_keyboard_shortcut(object sender, KeyPressedEventArgs e) {
			pmPasswords_Opening(null, null);
			pmPasswords.Show(lbClock, new Point(0, Height));
			TopMost = true;
			SetForegroundWindow(this, true);
			pmPasswords.Focus();
			if (FOptions.showSearch && ! Host.MainWindow.IsFileLocked(null))
				toolStripTextSearch.Focus();
		}
		private void lbClock_MouseUp(object sender, MouseEventArgs e) {
			if (FMoving != 2) {
				if (e.Button == MouseButtons.Left) {
					pmPasswords_Opening(null, null);
					pmPasswords.Show(lbClock, e.Location);
					if (FOptions.showSearch)
						toolStripTextSearch.Focus();
				}
			}
			FMoving = 0;
		}

		// This event handler is unassigned
		private void pmPasswords_Opening(object sender, CancelEventArgs e) {
			is_searching = false;
			if (FOptions.showSearch) {
				toolStripTextSearch.Text = "Click To Search";
				toolStripTextSearch.Width = 50;
			}
			if (Host == null)
				return;
			reload_menu();

			if (FOptions.showSearch)
				toolStripTextSearch.Width = pmPasswords.DisplayRectangle.Width;
		}

		private void reload_menu() {
			int i = pmPasswords.Items.Count - 1;
			pmPasswords.SuspendLayout();
			while (i >= 5) {
				pmPasswords.Items.Remove(pmPasswords.Items[i]);
				i--;
			}
			miNoPasswords.Visible = true;
			miNoPasswords.Enabled = false;
			miNoPasswords.Image = null;

			if (Host.MainWindow.IsFileLocked(null)) {
                
				miNoPasswords.Text = KPRes.LockMenuUnlock;
				miNoPasswords.ToolTipText = "The current database is locked.";
				miNoPasswords.Enabled = true;
			    toolStripTextSearch.Visible = false;
				miNoPasswords.Image = ilIcons.Images[6];

				//reset "LastOne"-Entry as soon as database is locked
				LastOne.Visible = false;
				LastOne.Text = "LastOne";
				LastOne.DropDownItems.Clear();
			}
			else
				if ((Host.Database != null) && (Host.Database.IsOpen))
				{
				    toolStripTextSearch.Visible =  FOptions.showSearch;
					LastOne.Visible = FOptions.showLastOne && LastOne.Text != "LastOne";
					PwGroup start_group = Host.Database.RootGroup;
					if (start_group != null && !string.IsNullOrEmpty(FOptions.startGroupUUID)) {
						PwObjectList<PwGroup> all_groups = Host.Database.RootGroup.GetGroups(true);
						foreach (PwGroup group in all_groups) {
							if (group.Uuid.ToHexString() == FOptions.startGroupUUID) {
								start_group = group;
								break;
							}
						}
						if (start_group.Entries.UCount <= 0 && start_group.Groups.UCount <= 0)
							start_group = Host.Database.RootGroup;
					}
					//on default LastOne is visible
					PwEntry last_entry = LastOne.Tag as PwEntry;
					bool last_entry_ok = false;
					if (last_entry != null) {
						PwGroup tmp_grp = last_entry.ParentGroup;
						while (tmp_grp != null) {
							if (tmp_grp == start_group) {
								last_entry_ok = true;
								break;
							}
							if (tmp_grp == Host.Database.RootGroup)
								break;
							tmp_grp = tmp_grp.ParentGroup;
						}
					}
					if (!last_entry_ok)
						LastOne.Visible = false;

					if ((start_group != null) && ((start_group.Entries.UCount > 0) || (start_group.Groups.UCount > 0))) {
						AddGroupToMenu(null, start_group);
						miNoPasswords.Visible = false;
					}
					else {
                        toolStripTextSearch.Visible = LastOne.Visible = false;
						miNoPasswords.Text = "-= No passwords =-";
						miNoPasswords.ToolTipText = "There are no passwords defined.\nOpen KeePass and create some new passwords.";
					}
				}
				else {
                    toolStripTextSearch.Visible = LastOne.Visible = false;
					miNoPasswords.Text = "-= No database open =-";
					miNoPasswords.ToolTipText = "There is no opened database.\nPlease open existing or create new database.";
				}

			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			pmPasswords.ResumeLayout();
		}

		private void miNoPasswords_Click(object sender, EventArgs e) {
			if (Host.MainWindow.IsFileLocked(null)) {
				// Unlock
				Host.MainWindow.TrayContextMenu.Items.Find("m_ctxTrayLock", false)[0].PerformClick();
				// Hide main wnd
				if (!Host.MainWindow.IsTrayed())
					Host.MainWindow.TrayContextMenu.Items.Find("m_ctxTrayTray", false)[0].PerformClick();
			}
		}

		private void AddActionsToItem(ToolStripMenuItem Parent, PwEntry Entry) {
			ToolStripMenuItem Item;

			foreach (KeyValuePair<string, ProtectedString> kvp in Entry.Strings) {
				if (kvp.Key.Equals(PwDefs.UrlField)) {
					if (kvp.Value.Length > 0) {
						Item = new ToolStripMenuItem();
						Item.Tag = Entry;
						ToolStripMenuItem Tmp;
						if (FOptions.URLAction == 0)
							Tmp = (ToolStripMenuItem)Host.MainWindow.EntryContextMenu.Items.Find("m_ctxEntryOpenUrl", true)[0];
						else
							if (FOptions.URLAction == 1)
								Tmp = (ToolStripMenuItem)Host.MainWindow.EntryContextMenu.Items.Find("m_ctxEntryCopyUrl", true)[0];
							else
								throw new Exception("Internal error in AddActionsToItem (FOptions.URLAction)");
						Item.Text = Tmp.Text;
						Item.Image = ilIcons.Images[9];
						Item.Click += miItem_OpenURL;
						Parent.DropDownItems.Add(Item);
					}
					break;
				}
			}

			Item = new ToolStripMenuItem();
			Item.Tag = Entry;
			Item.Text = KPRes.AutoType;
			Item.Image = ilIcons.Images[8];
			Item.Click += miItem_AutoType;
			Parent.DropDownItems.Add(Item);


			foreach (KeyValuePair<string, ProtectedString> kvp in Entry.Strings) {
				if ((!kvp.Key.Equals(PwDefs.TitleField)) && (!kvp.Key.Equals(PwDefs.NotesField)) && (!kvp.Key.Equals(PwDefs.UrlField))) {
					if (kvp.Value.Length > 0) {
						Item = new ToolStripMenuItem();
						Item.Tag = Entry;
						Item.Text = kvp.Key;
						//Item.MouseDown += new MouseEventHandler(miItem_Mousedown);
						Item.Click += miItem_Click;
						//Item.


						if (kvp.Key.Equals(PwDefs.UserNameField)) {
							Item.Image = ilIcons.Images[10];
							Parent.DropDownItems.Insert(Parent.DropDownItems.Count, Item);
						}
						else
							if (kvp.Key.Equals(PwDefs.PasswordField)) {
								Item.Image = ilIcons.Images[11];
								Parent.DropDownItems.Insert(Parent.DropDownItems.Count, Item);
							}
							else {
								Item.Image = ilIcons.Images[5];
								Parent.DropDownItems.Add(Item);
							}
					}
				}
			}

			//Test implementation of Edit Entry s² 2009/07


			bool added = false;
			foreach (KeyValuePair<string, ProtectedString> kvp in Entry.Strings) {
				if ((!kvp.Key.Equals(PwDefs.TitleField)) && (!kvp.Key.Equals(PwDefs.NotesField)) && (!kvp.Key.Equals(PwDefs.UrlField)) && !added) {
					if (kvp.Value.Length > 0) {
						Item = new ToolStripMenuItem();
						Item.Tag = Entry;
						Item.Text = KPRes.EditEntry;
						Item.Image = ilIcons.Images[1];
						//1
						Item.Click += miItem_Edit;
						Parent.DropDownItems.Add(Item);
						added = true;
					}
				}
			}
			//End Test implementation of Edit Entry s² 2009/07
		}







		private void AddItemsToMenu(ToolStripMenuItem Parent, PwGroup RootGroup) {


			//s² - 2009/06/21 - Sorting of PW-Entries in FloatingPanel
			List<PwEntry> myList = RootGroup.GetEntries(is_searching).CloneShallowToList();
            DateTime now = DateTime.Now;
			if (FOptions.sortAlphabetical) {
				myList.Sort((X, Y) => X.Strings.ReadSafe(PwDefs.TitleField).CompareTo(Y.Strings.ReadSafe(PwDefs.TitleField)));
			}
			//End s² - 2009/06/21 - Sorting of PW-Entries in FloatingPanel



			foreach (PwEntry Entry in myList) {
				ToolStripMenuItem Item = new ToolStripMenuItem();
				Item.Tag = Entry;
				Item.Text = Entry.Strings.ReadSafe(PwDefs.TitleField);
				Item.BackColor = Entry.BackgroundColor;
				Item.DropDownOpening += miItem_DropDownOpening;
				Item.DoubleClick += miItem_OpenURL;
				Item.DoubleClickEnabled = true;

				PwIcon IconIndex = Entry.IconId;
				PwUuid CustomIconID = Entry.CustomIconUuid;

				if (CustomIconID != PwUuid.Zero)
					Item.Image = Host.Database.GetCustomIcon(CustomIconID);
				else
					Item.Image = Host.MainWindow.ClientIcons.Images[(int)IconIndex];
				if (Item.Image == null)
					Item.Image = ilIcons.Images[5];

                if (Entry.Expires){
                    if (Entry.ExpiryTime <= now)
                    {
                        Item.Image = ilIcons.Images[7];
                        Item.Font = new Font(Item.Font, Item.Font.Style | FontStyle.Strikeout);
                    }
                    Item.ToolTipText = KPRes.ExpiryTime + ": " + Entry.ExpiryTime;
				}

				if (Parent == null)
					pmPasswords.Items.Add(Item);
				else
					Parent.DropDownItems.Add(Item);

				ToolStripMenuItem Dummy = new ToolStripMenuItem();
				Dummy.Tag = null;
				Dummy.Text = "dummy";
				Dummy.Enabled = false;
				Item.DropDownItems.Add(Dummy);
			}
		}

		private void AddGroupToMenu(ToolStripMenuItem Parent, PwGroup RootGroup) {
			if (!FOptions.foldersFirst)
				AddItemsToMenu(Parent, RootGroup);
			if (!is_searching) {
                DateTime now = DateTime.Now;
				foreach (PwGroup Group in RootGroup.Groups) {
					ToolStripMenuItem Item = new ToolStripMenuItem();
					Item.Tag = Group;
					Item.Text = Group.Name;
					Item.Name = Group.Name;
					Item.DropDownOpening += miGroup_DropDownOpening;

					PwIcon IconIndex = Group.IconId;
					PwUuid CustomIconID = Group.CustomIconUuid;

					if (CustomIconID != PwUuid.Zero)
						Item.Image = Host.Database.GetCustomIcon(CustomIconID);
					else
						Item.Image = Host.MainWindow.ClientIcons.Images[(int)IconIndex];
					if (Item.Image == null)
						Item.Image = ilIcons.Images[4];

                    if (Group.Expires)
                    {
                        if (Group.ExpiryTime <= now)
                        {
                            Item.Image = ilIcons.Images[7];
                            Item.Font = new Font(Item.Font, Item.Font.Style | FontStyle.Strikeout);
                        }
                        Item.ToolTipText = KPRes.ExpiryTime + ": " + Group.ExpiryTime;
					}

					bool bIsRecycleBin = (Host.Database.RecycleBinEnabled && Group.Uuid.EqualsValue(Host.Database.RecycleBinUuid));
					if (!bIsRecycleBin && Group.Entries.UCount + Group.Groups.UCount > 0) {
						if (Parent == null)
							pmPasswords.Items.Add(Item);
						else
							Parent.DropDownItems.Add(Item);
					}

					if ((Group.Groups.UCount > 0) || (Group.Entries.UCount > 0)) {
						ToolStripMenuItem Dummy = new ToolStripMenuItem();
						Dummy.Tag = null;
						Dummy.Text = "dummy";
						Dummy.Enabled = false;
						Item.DropDownItems.Add(Dummy);
					}
				}

				if (RootGroup.Groups.UCount != 0) {
					ToolStripSeparator seperator = new ToolStripSeparator();
					if (Parent == null)
						pmPasswords.Items.Add(seperator);
					else
						Parent.DropDownItems.Add(seperator);
				}
			}
			if (FOptions.foldersFirst)
				AddItemsToMenu(Parent, RootGroup);
		}


		private void miGroup_DropDownOpening(object sender, EventArgs e) { //If its the first time opening we need to add the sub items.
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			if (Item.DropDownItems.Count != 1)
				return;
			ToolStripMenuItem pos_dummy = Item.DropDownItems[0] as ToolStripMenuItem;
			if (pos_dummy == null || pos_dummy.Tag != null)
				return;
			PwGroup Group = (PwGroup)Item.Tag;
			AddGroupToMenu(Item, Group);
			Item.DropDownItems.Remove(pos_dummy);
		}

		private void miItem_DropDownOpening(object sender, EventArgs e) { //If its the first time opening we need to add the sub items.
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			if (Item.DropDownItems.Count != 1)
				return;
			ToolStripMenuItem pos_dummy = Item.DropDownItems[0] as ToolStripMenuItem;
			if (pos_dummy == null || pos_dummy.Tag != null)
				return;
			PwEntry Entry = (PwEntry)Item.Tag;
			AddActionsToItem(Item, Entry);
			Item.DropDownItems.Remove(pos_dummy);
		}

		private void miItem_AutoType(object sender, EventArgs e) {
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			PwEntry Entry = (PwEntry)Item.Tag;

			try {
				AutoType.PerformIntoPreviousWindow(this, Entry,Host.Database);
			}
			catch (Exception ex) {
				MessageService.ShowWarning(ex);
			}
		}
		private void SetLastOne(ToolStripMenuItem item) {
			if (!FOptions.showLastOne)
				return;
			ToolStripMenuItem ParentItem;
			while (item != LastOne && (ParentItem = item.OwnerItem as ToolStripMenuItem) != null && ParentItem.Tag == item.Tag)
				item = ParentItem;

			if (item == LastOne)
				return;

			LastOne.Text = item.Text;
			LastOne.Tag = item.Tag;
			LastOne.DropDownItems.Clear();
			AddActionsToItem(LastOne, item.Tag as PwEntry);
			LastOne.Visible = true;
		}
		private void CustomOpenEntryUrl(PwEntry pe) {
			Debug.Assert(pe != null);
			if (pe == null) throw new ArgumentNullException("pe");
			String open_url;

			if (pe.OverrideUrl.Length > 0)
				open_url = pe.OverrideUrl;
			else {
				string strOverride = Program.Config.Integration.UrlOverride;
				open_url = strOverride.Length > 0 ? strOverride : pe.Strings.ReadSafe(PwDefs.UrlField);
			}
			WinUtil.OpenUrl(open_url, pe);
		}
		private void miItem_OpenURL(object sender, EventArgs e) {
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			PwEntry Entry = Item.Tag as PwEntry;
			if (Entry == null)
				return;

			if (FOptions.URLAction == 0) {
				CustomOpenEntryUrl(Entry);
				SetLastOne(Item);
			}
			else
				if (FOptions.URLAction == 1)
					FieldAction(Item, PwDefs.UrlField, FIELD_ACTION.CLIPBOARD_COPY);
				else
					throw new Exception("Internal error in miItem_OpenURL (FOptions.URLAction)");
		}

		void miItem_Click(object sender, EventArgs e) {
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			FieldAction(Item, Item.Text, FIELD_ACTION.CLIPBOARD_COPY);
		}
		private enum FIELD_ACTION { CLIPBOARD_COPY, DRAG_DROP };
		private void FieldAction(ToolStripMenuItem Item, string FieldName, FIELD_ACTION action) {
			if (Item == null)
				return;

			PwEntry Entry = (PwEntry)Item.Tag;
			if (Entry == null)
				return;
			SetLastOne(Item);
			if (FieldName == PwDefs.PasswordField && PwDefs.IsTanEntry(Entry)) {
				Entry.ExpiryTime = DateTime.Now;
				Entry.Expires = true;
				Host.MainWindow.RefreshEntriesList();
				Host.MainWindow.UpdateUI(false, null, false, null, false, null, true);
			}

			if (action == FIELD_ACTION.CLIPBOARD_COPY) {
				ClipboardUtil.CopyAndMinimize(Entry.Strings.GetSafe(FieldName),
					true, Program.Config.MainWindow.MinimizeAfterClipboardCopy ?
					Host.MainWindow : null, Entry, Host.MainWindow.DocumentManager.ActiveDatabase);
				Host.MainWindow.StartClipboardCountdown();
			}
			else if (action == FIELD_ACTION.DRAG_DROP)
				Item.DoDragDrop(Entry.Strings.ReadSafe(FieldName), DragDropEffects.Copy);

		}




		private void miItem_Edit(object sender, EventArgs e) {
			ToolStripMenuItem Item = (ToolStripMenuItem)sender;
			PwEntry Entry = (PwEntry)Item.Tag;
			PwEntryForm myForm = new PwEntryForm();
			myForm.InitEx(Entry, PwEditMode.EditExistingEntry, Host.MainWindow.DocumentManager.ActiveDatabase, Host.MainWindow.ClientIcons, false, true);

			if ((myForm.ShowDialog() == DialogResult.OK))
				Host.MainWindow.UpdateUI(false, null, Host.MainWindow.DocumentManager.ActiveDatabase.UINeedsIconUpdate, null, true, null, true);
			Host.MainWindow.RefreshEntriesList();
		}



		private void miAbout_Click(object sender, EventArgs e) {

			MessageBox.Show("Floating Panel plugin for KeePass\n" +
							"See KeePass forums or website for distribution\n" + "\n" +

                            "© 2008, Alexeev Alexander, updated 2010 by s², currently by Mitch Capper. All Rights Reserved.",
							"About Floating Panel plugin", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void toolStripMenuSaveDatabase_Click(object sender, EventArgs e) {
			Host.MainWindow.UIFileSave(false);
		}

		private void ToolStripMenuExitKeePass_Click(object sender, EventArgs e) {
			Host.MainWindow.TrayContextMenu.Items.Find("m_ctxTrayFileExit", false)[0].PerformClick();
		}

		private bool is_searching;
		private string search_str = "";

		void toolStripTextSearch_TextChanged(object sender, EventArgs e) {
			timer_search.Enabled = false;
			timer_search.Enabled = true;
		}
		private void timer_search_Tick(object sender, EventArgs e) {
			timer_search.Enabled = false;
			search_str = toolStripTextSearch.Text;
			if (search_str == "Click To Search" || search_str == "") {
				is_searching = false;
				reload_menu();
				return;
			}
			if (!is_searching) {
				is_searching = true;
				reload_menu();
			}
			string[] search_arr = search_str.Split(new char[] { ' ' });
			pmPasswords.SuspendLayout();
			foreach (ToolStripItem item in pmPasswords.Items) {
				if (item.Tag != null) {
					string item_text = item.Text;
					bool show = true;
					foreach (var key in search_arr) {
						if (item_text.IndexOf(key, 0, StringComparison.InvariantCultureIgnoreCase) == -1)
							show = false;
					}
					item.Visible = show;
				}
			}
			pmPasswords.ResumeLayout();
		}

		void toolStripTextSearch_GotFocus(object sender, EventArgs e) {
			if (toolStripTextSearch.Text == "Click To Search") {
				toolStripTextSearch.SelectAll();
			}
		}

		private void toolStripTextSearch_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && e.KeyCode != Keys.Enter)
				return;
			ToolStrip parent = toolStripTextSearch.GetCurrentParent();
			ToolStripItem prev_item = null;
			ToolStripItem next_item = null;
			bool at_item = false;
			foreach (ToolStripItem itm in parent.Items) {
				if (itm == toolStripTextSearch)
					at_item = true;

				if (itm as ToolStripMenuItem == null)
					continue;

				if (!itm.Visible)
					continue;

				if (!at_item && itm != toolStripTextSearch)
					prev_item = itm;

				if (at_item) {
					next_item = itm;
					break;
				}
			}
			if (e.KeyCode == Keys.Enter && next_item != null) {
				miItem_OpenURL(next_item, null);
			}

			if (e.KeyCode == Keys.Down && next_item != null) {
				e.SuppressKeyPress = true;
				e.Handled = true;
				parent.Focus();
				next_item.Select();
			}
			if (e.KeyCode == Keys.Up && prev_item != null) {
				e.SuppressKeyPress = true;
				e.Handled = true;
				parent.Focus();
				prev_item.Select();
			}

		}


		void pmPasswords_Click(object sender, EventArgs e)//remove selection from searchbox
		{
			if (toolStripTextSearch.Focused)
				pmPasswords.Focus();
		}


		protected override CreateParams CreateParams//allow us to be borderless and not show up in alt tab
		{
			get {
				CreateParams cp = base.CreateParams;
				// turn on WS_EX_TOOLWINDOW style bit
				cp.ExStyle |= 0x80;
				return cp;
			}
		}
	}

}
