using System;
using System.Drawing;
using Microsoft.Win32;


namespace KPFloatingPanel {
	public class OptionsClass {
		internal decimal Transparency;
		internal Color PanelColor;
		internal Color FontColor;
		internal int URLAction; // 0 - open in browser; 1 - copy to clipboard; these are indexes in combobox in options form
		internal bool sortAlphabetical; //s²
		internal bool showClock;
		internal bool showSearch;
		internal bool showLastOne;
		internal bool foldersFirst;
        internal int lastPositionX;
        internal int lastPositionY;
        internal string startGroupUUID;
		internal string shortcutKey;
		internal bool shortcutShift;
		internal bool shortcutAlt;
		internal bool shortcutCntrl;
		internal bool shortcutWin;

        internal string shortcutKeyQuick;
        internal bool shortcutShiftQuick;
        internal bool shortcutAltQuick;
        internal bool shortcutCntrlQuick;
        internal bool shortcutWinQuick;
		private Color ColorFromVal(string name) {
			if (name != null && name.StartsWith("#"))
				return System.Drawing.ColorTranslator.FromHtml(name);
			return Color.FromName(name);
		}
		public void Load() {
			try {
				RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\KeePassFloatingPanel");
				if (Key == null)
					return;
				Transparency = (int)Key.GetValue("Transparency", (int)Transparency);
				PanelColor = ColorFromVal((string)Key.GetValue("PanelColor", PanelColor.Name));
				FontColor = ColorFromVal((string)Key.GetValue("FontColor", FontColor.Name));
				URLAction = (int)Key.GetValue("URLAction", URLAction);
				sortAlphabetical = Convert.ToBoolean((string)Key.GetValue("SortEntries"));
				startGroupUUID = (string)Key.GetValue("startGroupUUID");
				showClock = Convert.ToBoolean((string)Key.GetValue("ShowClock"));
				showSearch = Convert.ToBoolean((string)Key.GetValue("ShowSearch"));
				showLastOne = Convert.ToBoolean((string)Key.GetValue("ShowLastOne"));
				foldersFirst = Convert.ToBoolean((string)Key.GetValue("foldersFirst"));
                lastPositionX = (int)Key.GetValue("lastPositionX", (int)lastPositionX);
                lastPositionY = (int)Key.GetValue("lastPositionY", (int)lastPositionY);

				shortcutShift = Convert.ToBoolean((string)Key.GetValue("shortcutShift"));
				shortcutAlt = Convert.ToBoolean((string)Key.GetValue("shortcutAlt"));
				shortcutCntrl = Convert.ToBoolean((string)Key.GetValue("shortcutCntrl"));
				shortcutWin = Convert.ToBoolean((string)Key.GetValue("shortcutWin"));
				shortcutKey = (string)Key.GetValue("shortcutKey");

                shortcutShiftQuick = Convert.ToBoolean((string)Key.GetValue("shortcutShiftQuick"));
                shortcutAltQuick = Convert.ToBoolean((string)Key.GetValue("shortcutAltQuick"));
                shortcutCntrlQuick = Convert.ToBoolean((string)Key.GetValue("shortcutCntrlQuick"));
                shortcutWinQuick = Convert.ToBoolean((string)Key.GetValue("shortcutWinQuick"));
                shortcutKeyQuick = (string)Key.GetValue("shortcutKeyQuick");
			}
			catch (System.IO.IOException) {
				// does nothing
			}
			catch (InvalidCastException) {
				// does nothing
			}
		}
		public void Save() {
			try {
				RegistryKey Key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\KeePassFloatingPanel");
				if (Key == null)
					return;
				Key.SetValue("Transparency", (int)Transparency);
				Key.SetValue("PanelColor", PanelColor.IsNamedColor ? PanelColor.Name : "#" + PanelColor.Name);
				Key.SetValue("FontColor", FontColor.IsNamedColor ?  FontColor.Name : "#" + FontColor.Name);
				Key.SetValue("URLAction", URLAction);
				Key.SetValue("SortEntries", sortAlphabetical); //s²
				Key.SetValue("ShowClock", showClock); //s²
				Key.SetValue("ShowSearch", showSearch); //s²
				Key.SetValue("ShowLastOne", showLastOne); //s²
				Key.SetValue("foldersFirst", foldersFirst); //s²
                Key.SetValue("lastPositionX", (int)lastPositionX);
                Key.SetValue("lastPositionY", (int)lastPositionY);
				
                Key.SetValue("startGroupUUID", startGroupUUID);
				Key.SetValue("shortcutKey", shortcutKey);
				Key.SetValue("shortcutAlt", shortcutAlt);
				Key.SetValue("shortcutShift", shortcutShift);
				Key.SetValue("shortcutCntrl", shortcutCntrl);
				Key.SetValue("shortcutWin", shortcutWin);

                Key.SetValue("shortcutKeyQuick", shortcutKeyQuick);
                Key.SetValue("shortcutAltQuick", shortcutAltQuick);
                Key.SetValue("shortcutShiftQuick", shortcutShiftQuick);
                Key.SetValue("shortcutCntrlQuick", shortcutCntrlQuick);
                Key.SetValue("shortcutWinQuick", shortcutWinQuick);

			}
			catch (System.IO.IOException) {
				// does nothing
			}
			catch (UnauthorizedAccessException) {
				// does nothing
			}
		}
		public OptionsClass() {
			Transparency = 80;
			PanelColor = SystemColors.Info;
			FontColor = SystemColors.InfoText;
			URLAction = 0;
			startGroupUUID = "";
			showClock = false;
			showSearch = true;
			showLastOne = true;
			foldersFirst = true;
            shortcutAlt = shortcutCntrl = shortcutShift = shortcutWin = shortcutAltQuick = shortcutCntrlQuick = shortcutShiftQuick = shortcutWinQuick = false;
            shortcutKey = shortcutKeyQuick = "";
			Load();
		}
	}
}
