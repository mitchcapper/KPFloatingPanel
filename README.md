KP Floating Panel for KeePass 2.x
=================================

RECENT CHANGES
-----
(MitchCapper unless otherwise noted)
- 7.0 Moved to git(hub), KP 2.3 support, High DPI support


OVERVIEW
-----
KP Floating Panel allows easy access to KeePass entries through a small floating panel on your screen.  Allows quick keyboard access and searching (along with opening, auto type, etc) without opening the KeePass window.  Multiple keyboard shortcut an display options.  Originally written by Alexeev Alexander and improved upon by s² now maintained by Mitch Capper.  Older Changelog has full history.

INSTALLATION
-----
- Download from https://github.com/mitchcapper/KPFloatingPanel/releases
- Place the (KPFloatPanel.plgx) in the KeePass program directory
- Start KeePass and open a database.  Right click on the floating panel near the top of the screen and go to settings, configure as you like.  
- Click on the floating panel to open, or use the global hotkey setup to open it from the keyboard

MAJOR OPTIONS
-----
- You can choose to display at a certain transparency (along with foreground and background colors) by default the display is just the database name
- Show clock in the floating panel
- Only show entries from a specific subgroup in keepass rather than all entries
- Search option (that auto focuses) so you can just type to find an entry
- Global hot key so you can just hit the keyboard combination to open the floating panel
- QuickPass hot key to get a quick random password

OLDER CHANGELOG
-----
6.1 (2012-10-07) changed by MitchCapper
 - Rewrote code dealing with sub-group menus that was very broken (and caused crashes)
 - Enable update notification support.

6.0 (2012-10-06) changed by MitchCapper
 - Added ability to have a shortcut key for copying a random password to the clipboard
 - Fixed expiring entries and how they showed up
 - Don't show search/last entry items when not right
 - Minor other fixes

2.0.12 (2010.08.08) changed by MitchCapper
 -  Made searching so you can type multiple parts of an entry title (seperated by spaces) and it will find the entry even if the parts are not next to each other
 -  Added LastEntry support from Deltamaxx
 -  Dual Monitor Fixes

2.0.9.1(2009.10.19) changed by MitchCapper
 -  Save Database button added to drop down
 -  Ability to set starting group for entries, instead of starting just at the root you can choose to start at a sub-group instead, should safe people from having to constantly go to one subfolder.
 -  Ability to hide the clock
 -  Ability to set a global hot key that will bring it up (IE hitting shift + K will open the floating panel).
 -  Ability to choose if you want folders or entries first
 -  Ability to perform the default action for an entry by just double clicking
 -  Removed the floating panel from showing up in the ALT-Tab list.
 -  Ability to search right from the floating panel.  When search is enabled a textbox will appear as the top of the list, and any time it opens it will have focus by default.  As you type it will search the list and show you as you type the results.  You can then interact with the results or just hit enter and the first ones default action will be taken.  This allows for complete keyboard interaction with the floating panel, hit the global hot key, type part of the entry you want, hit enter, and your done.  When you search it flatens out all the groups, so even if the entry is in a sub-group it will show up in the results

2.0.9 (2009.09.12) changed by s²
 -  implemented a new option to directly jump into the edit-entry dialog from floating panel

1.0.2 (2009.06.20) changed by s²
 -  introduced new feature "sort alphabetical" which can be selected/deselected under settings=>behaviour
 -  compiled for KeePass v2.0.7
 -  Some minor changes due to suggestions of FxCop 
 
1.0.1 (2009.01.11)
 - changed: minimum requirements from .NET v3.5 to .NET v2.0.
 - fixed: passwords' popup menu appear behavior (did not always appear at first click).
 - fixed: better stay on top handling (or I think so).
 - added: "Contacts" ("Send Feedback"/"Go To Forum") menu item.
 - added: ability to copy URL to clipboard instead of open it in the browser.
 - minor fixes (typos, etc).
