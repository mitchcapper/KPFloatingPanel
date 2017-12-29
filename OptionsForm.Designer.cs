namespace KPFloatingPanel
{
    partial class OptionsForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.pcOptions = new System.Windows.Forms.TabControl();
            this.tsBehavior = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxShortcutWinQuick = new System.Windows.Forms.CheckBox();
            this.cbxShortcutAltQuick = new System.Windows.Forms.CheckBox();
            this.cbxShortcutShiftQuick = new System.Windows.Forms.CheckBox();
            this.cbxShortcutCntrlQuick = new System.Windows.Forms.CheckBox();
            this.txtShortcutKeyQuick = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxShowLastOne = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxShortcutWin = new System.Windows.Forms.CheckBox();
            this.cbxShortcutAlt = new System.Windows.Forms.CheckBox();
            this.cbxShortcutShift = new System.Windows.Forms.CheckBox();
            this.cbxShortcutCntrl = new System.Windows.Forms.CheckBox();
            this.txtShortcutKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxShowFoldersBeforeEntries = new System.Windows.Forms.CheckBox();
            this.cbxShowSearch = new System.Windows.Forms.CheckBox();
            this.cbxShowClock = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStartGroup = new System.Windows.Forms.ComboBox();
            this.cbxSortAlphabetical = new System.Windows.Forms.CheckBox();
            this.cbURLAction = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsView = new System.Windows.Forms.TabPage();
            this.pnFontColor = new System.Windows.Forms.Panel();
            this.pnPanelColor = new System.Windows.Forms.Panel();
            this.edPercent = new System.Windows.Forms.NumericUpDown();
            this.btChangeFontColor = new System.Windows.Forms.Button();
            this.btChangePanelColor = new System.Windows.Forms.Button();
            this.lbPercent = new System.Windows.Forms.Label();
            this.lbFontColor = new System.Windows.Forms.Label();
            this.lbPanelColor = new System.Windows.Forms.Label();
            this.lbTransp = new System.Windows.Forms.Label();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.cbxLockPosition = new System.Windows.Forms.CheckBox();
            this.pnButtons.SuspendLayout();
            this.pcOptions.SuspendLayout();
            this.tsBehavior.SuspendLayout();
            this.tsView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnButtons
            // 
            this.pnButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnButtons.Controls.Add(this.btCancel);
            this.pnButtons.Controls.Add(this.btOk);
            this.pnButtons.Location = new System.Drawing.Point(0, 355);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(268, 41);
            this.pnButtons.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(180, 8);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(77, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(92, 8);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(77, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // pcOptions
            // 
            this.pcOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcOptions.Controls.Add(this.tsBehavior);
            this.pcOptions.Controls.Add(this.tsView);
            this.pcOptions.Location = new System.Drawing.Point(0, 0);
            this.pcOptions.Name = "pcOptions";
            this.pcOptions.SelectedIndex = 0;
            this.pcOptions.Size = new System.Drawing.Size(268, 353);
            this.pcOptions.TabIndex = 1;
            // 
            // tsBehavior
            // 
            this.tsBehavior.Controls.Add(this.cbxLockPosition);
            this.tsBehavior.Controls.Add(this.label5);
            this.tsBehavior.Controls.Add(this.cbxShortcutWinQuick);
            this.tsBehavior.Controls.Add(this.cbxShortcutAltQuick);
            this.tsBehavior.Controls.Add(this.cbxShortcutShiftQuick);
            this.tsBehavior.Controls.Add(this.cbxShortcutCntrlQuick);
            this.tsBehavior.Controls.Add(this.txtShortcutKeyQuick);
            this.tsBehavior.Controls.Add(this.label6);
            this.tsBehavior.Controls.Add(this.cbxShowLastOne);
            this.tsBehavior.Controls.Add(this.label4);
            this.tsBehavior.Controls.Add(this.cbxShortcutWin);
            this.tsBehavior.Controls.Add(this.cbxShortcutAlt);
            this.tsBehavior.Controls.Add(this.cbxShortcutShift);
            this.tsBehavior.Controls.Add(this.cbxShortcutCntrl);
            this.tsBehavior.Controls.Add(this.txtShortcutKey);
            this.tsBehavior.Controls.Add(this.label3);
            this.tsBehavior.Controls.Add(this.cbxShowFoldersBeforeEntries);
            this.tsBehavior.Controls.Add(this.cbxShowSearch);
            this.tsBehavior.Controls.Add(this.cbxShowClock);
            this.tsBehavior.Controls.Add(this.label2);
            this.tsBehavior.Controls.Add(this.cbStartGroup);
            this.tsBehavior.Controls.Add(this.cbxSortAlphabetical);
            this.tsBehavior.Controls.Add(this.cbURLAction);
            this.tsBehavior.Controls.Add(this.label1);
            this.tsBehavior.Location = new System.Drawing.Point(4, 22);
            this.tsBehavior.Name = "tsBehavior";
            this.tsBehavior.Padding = new System.Windows.Forms.Padding(3);
            this.tsBehavior.Size = new System.Drawing.Size(260, 327);
            this.tsBehavior.TabIndex = 1;
            this.tsBehavior.Text = "Behavior";
            this.tsBehavior.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "+";
            // 
            // cbxShortcutWinQuick
            // 
            this.cbxShortcutWinQuick.AutoSize = true;
            this.cbxShortcutWinQuick.Location = new System.Drawing.Point(153, 303);
            this.cbxShortcutWinQuick.Name = "cbxShortcutWinQuick";
            this.cbxShortcutWinQuick.Size = new System.Drawing.Size(45, 17);
            this.cbxShortcutWinQuick.TabIndex = 22;
            this.cbxShortcutWinQuick.Text = "Win";
            this.cbxShortcutWinQuick.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutAltQuick
            // 
            this.cbxShortcutAltQuick.AutoSize = true;
            this.cbxShortcutAltQuick.Location = new System.Drawing.Point(115, 303);
            this.cbxShortcutAltQuick.Name = "cbxShortcutAltQuick";
            this.cbxShortcutAltQuick.Size = new System.Drawing.Size(38, 17);
            this.cbxShortcutAltQuick.TabIndex = 21;
            this.cbxShortcutAltQuick.Text = "Alt";
            this.cbxShortcutAltQuick.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutShiftQuick
            // 
            this.cbxShortcutShiftQuick.AutoSize = true;
            this.cbxShortcutShiftQuick.Location = new System.Drawing.Point(67, 303);
            this.cbxShortcutShiftQuick.Name = "cbxShortcutShiftQuick";
            this.cbxShortcutShiftQuick.Size = new System.Drawing.Size(47, 17);
            this.cbxShortcutShiftQuick.TabIndex = 20;
            this.cbxShortcutShiftQuick.Text = "Shift";
            this.cbxShortcutShiftQuick.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutCntrlQuick
            // 
            this.cbxShortcutCntrlQuick.AutoSize = true;
            this.cbxShortcutCntrlQuick.Location = new System.Drawing.Point(21, 303);
            this.cbxShortcutCntrlQuick.Name = "cbxShortcutCntrlQuick";
            this.cbxShortcutCntrlQuick.Size = new System.Drawing.Size(47, 17);
            this.cbxShortcutCntrlQuick.TabIndex = 19;
            this.cbxShortcutCntrlQuick.Text = "Cntrl";
            this.cbxShortcutCntrlQuick.UseVisualStyleBackColor = true;
            // 
            // txtShortcutKeyQuick
            // 
            this.txtShortcutKeyQuick.Location = new System.Drawing.Point(217, 301);
            this.txtShortcutKeyQuick.MaxLength = 1;
            this.txtShortcutKeyQuick.Name = "txtShortcutKeyQuick";
            this.txtShortcutKeyQuick.Size = new System.Drawing.Size(24, 20);
            this.txtShortcutKeyQuick.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "QuickPass Hot Key (leave blank to disable):";
            // 
            // cbxShowLastOne
            // 
            this.cbxShowLastOne.Location = new System.Drawing.Point(20, 257);
            this.cbxShowLastOne.Name = "cbxShowLastOne";
            this.cbxShowLastOne.Size = new System.Drawing.Size(220, 24);
            this.cbxShowLastOne.TabIndex = 16;
            this.cbxShowLastOne.Text = "Show Last Entry";
            this.cbxShowLastOne.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "+";
            // 
            // cbxShortcutWin
            // 
            this.cbxShortcutWin.AutoSize = true;
            this.cbxShortcutWin.Location = new System.Drawing.Point(150, 115);
            this.cbxShortcutWin.Name = "cbxShortcutWin";
            this.cbxShortcutWin.Size = new System.Drawing.Size(45, 17);
            this.cbxShortcutWin.TabIndex = 14;
            this.cbxShortcutWin.Text = "Win";
            this.cbxShortcutWin.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutAlt
            // 
            this.cbxShortcutAlt.AutoSize = true;
            this.cbxShortcutAlt.Location = new System.Drawing.Point(112, 115);
            this.cbxShortcutAlt.Name = "cbxShortcutAlt";
            this.cbxShortcutAlt.Size = new System.Drawing.Size(38, 17);
            this.cbxShortcutAlt.TabIndex = 13;
            this.cbxShortcutAlt.Text = "Alt";
            this.cbxShortcutAlt.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutShift
            // 
            this.cbxShortcutShift.AutoSize = true;
            this.cbxShortcutShift.Location = new System.Drawing.Point(64, 115);
            this.cbxShortcutShift.Name = "cbxShortcutShift";
            this.cbxShortcutShift.Size = new System.Drawing.Size(47, 17);
            this.cbxShortcutShift.TabIndex = 12;
            this.cbxShortcutShift.Text = "Shift";
            this.cbxShortcutShift.UseVisualStyleBackColor = true;
            // 
            // cbxShortcutCntrl
            // 
            this.cbxShortcutCntrl.AutoSize = true;
            this.cbxShortcutCntrl.Location = new System.Drawing.Point(18, 115);
            this.cbxShortcutCntrl.Name = "cbxShortcutCntrl";
            this.cbxShortcutCntrl.Size = new System.Drawing.Size(47, 17);
            this.cbxShortcutCntrl.TabIndex = 11;
            this.cbxShortcutCntrl.Text = "Cntrl";
            this.cbxShortcutCntrl.UseVisualStyleBackColor = true;
            // 
            // txtShortcutKey
            // 
            this.txtShortcutKey.Location = new System.Drawing.Point(214, 113);
            this.txtShortcutKey.MaxLength = 1;
            this.txtShortcutKey.Name = "txtShortcutKey";
            this.txtShortcutKey.Size = new System.Drawing.Size(24, 20);
            this.txtShortcutKey.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Global Hot Key (leave blank to disable):";
            // 
            // cbxShowFoldersBeforeEntries
            // 
            this.cbxShowFoldersBeforeEntries.Location = new System.Drawing.Point(19, 161);
            this.cbxShowFoldersBeforeEntries.Name = "cbxShowFoldersBeforeEntries";
            this.cbxShowFoldersBeforeEntries.Size = new System.Drawing.Size(220, 24);
            this.cbxShowFoldersBeforeEntries.TabIndex = 7;
            this.cbxShowFoldersBeforeEntries.Text = "Show Folders Before Entries";
            this.cbxShowFoldersBeforeEntries.UseVisualStyleBackColor = true;
            // 
            // cbxShowSearch
            // 
            this.cbxShowSearch.Location = new System.Drawing.Point(19, 209);
            this.cbxShowSearch.Name = "cbxShowSearch";
            this.cbxShowSearch.Size = new System.Drawing.Size(220, 24);
            this.cbxShowSearch.TabIndex = 6;
            this.cbxShowSearch.Text = "Show Search";
            this.cbxShowSearch.UseVisualStyleBackColor = true;
            // 
            // cbxShowClock
            // 
            this.cbxShowClock.Location = new System.Drawing.Point(19, 185);
            this.cbxShowClock.Name = "cbxShowClock";
            this.cbxShowClock.Size = new System.Drawing.Size(220, 24);
            this.cbxShowClock.TabIndex = 5;
            this.cbxShowClock.Text = "Show Clock";
            this.cbxShowClock.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Starting Group:";
            // 
            // cbStartGroup
            // 
            this.cbStartGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbStartGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStartGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartGroup.FormattingEnabled = true;
            this.cbStartGroup.Location = new System.Drawing.Point(19, 71);
            this.cbStartGroup.Name = "cbStartGroup";
            this.cbStartGroup.Size = new System.Drawing.Size(220, 21);
            this.cbStartGroup.TabIndex = 3;
            // 
            // cbxSortAlphabetical
            // 
            this.cbxSortAlphabetical.Location = new System.Drawing.Point(19, 137);
            this.cbxSortAlphabetical.Name = "cbxSortAlphabetical";
            this.cbxSortAlphabetical.Size = new System.Drawing.Size(220, 24);
            this.cbxSortAlphabetical.TabIndex = 2;
            this.cbxSortAlphabetical.Text = "Sort Entries by Name";
            this.cbxSortAlphabetical.UseVisualStyleBackColor = true;
            // 
            // cbURLAction
            // 
            this.cbURLAction.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbURLAction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbURLAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbURLAction.FormattingEnabled = true;
            this.cbURLAction.Items.AddRange(new object[] {
            "Open in browser (default)",
            "Copy to clipboard"});
            this.cbURLAction.Location = new System.Drawing.Point(19, 27);
            this.cbURLAction.Name = "cbURLAction";
            this.cbURLAction.Size = new System.Drawing.Size(220, 21);
            this.cbURLAction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL item action:";
            // 
            // tsView
            // 
            this.tsView.Controls.Add(this.pnFontColor);
            this.tsView.Controls.Add(this.pnPanelColor);
            this.tsView.Controls.Add(this.edPercent);
            this.tsView.Controls.Add(this.btChangeFontColor);
            this.tsView.Controls.Add(this.btChangePanelColor);
            this.tsView.Controls.Add(this.lbPercent);
            this.tsView.Controls.Add(this.lbFontColor);
            this.tsView.Controls.Add(this.lbPanelColor);
            this.tsView.Controls.Add(this.lbTransp);
            this.tsView.Location = new System.Drawing.Point(4, 22);
            this.tsView.Name = "tsView";
            this.tsView.Padding = new System.Windows.Forms.Padding(3);
            this.tsView.Size = new System.Drawing.Size(258, 286);
            this.tsView.TabIndex = 0;
            this.tsView.Text = "View";
            this.tsView.UseVisualStyleBackColor = true;
            // 
            // pnFontColor
            // 
            this.pnFontColor.BackColor = System.Drawing.SystemColors.InfoText;
            this.pnFontColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnFontColor.Location = new System.Drawing.Point(19, 176);
            this.pnFontColor.Name = "pnFontColor";
            this.pnFontColor.Size = new System.Drawing.Size(121, 25);
            this.pnFontColor.TabIndex = 11;
            this.pnFontColor.DoubleClick += new System.EventHandler(this.pnFontColor_DoubleClick);
            // 
            // pnPanelColor
            // 
            this.pnPanelColor.BackColor = System.Drawing.SystemColors.Info;
            this.pnPanelColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnPanelColor.Location = new System.Drawing.Point(19, 104);
            this.pnPanelColor.Name = "pnPanelColor";
            this.pnPanelColor.Size = new System.Drawing.Size(121, 25);
            this.pnPanelColor.TabIndex = 10;
            this.pnPanelColor.DoubleClick += new System.EventHandler(this.pnPanelColor_DoubleClick);
            // 
            // edPercent
            // 
            this.edPercent.Location = new System.Drawing.Point(19, 41);
            this.edPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edPercent.Name = "edPercent";
            this.edPercent.Size = new System.Drawing.Size(120, 20);
            this.edPercent.TabIndex = 9;
            this.edPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btChangeFontColor
            // 
            this.btChangeFontColor.Location = new System.Drawing.Point(164, 176);
            this.btChangeFontColor.Name = "btChangeFontColor";
            this.btChangeFontColor.Size = new System.Drawing.Size(75, 23);
            this.btChangeFontColor.TabIndex = 8;
            this.btChangeFontColor.Text = "Change...";
            this.btChangeFontColor.UseVisualStyleBackColor = true;
            this.btChangeFontColor.Click += new System.EventHandler(this.btChangeFontColor_Click);
            // 
            // btChangePanelColor
            // 
            this.btChangePanelColor.Location = new System.Drawing.Point(164, 104);
            this.btChangePanelColor.Name = "btChangePanelColor";
            this.btChangePanelColor.Size = new System.Drawing.Size(75, 23);
            this.btChangePanelColor.TabIndex = 7;
            this.btChangePanelColor.Text = "Change...";
            this.btChangePanelColor.UseVisualStyleBackColor = true;
            this.btChangePanelColor.Click += new System.EventHandler(this.btChangePanelColor_Click);
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Location = new System.Drawing.Point(153, 43);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(15, 13);
            this.lbPercent.TabIndex = 4;
            this.lbPercent.Text = "%";
            // 
            // lbFontColor
            // 
            this.lbFontColor.AutoSize = true;
            this.lbFontColor.Location = new System.Drawing.Point(16, 152);
            this.lbFontColor.Name = "lbFontColor";
            this.lbFontColor.Size = new System.Drawing.Size(57, 13);
            this.lbFontColor.TabIndex = 2;
            this.lbFontColor.Text = "Font color:";
            // 
            // lbPanelColor
            // 
            this.lbPanelColor.AutoSize = true;
            this.lbPanelColor.Location = new System.Drawing.Point(16, 80);
            this.lbPanelColor.Name = "lbPanelColor";
            this.lbPanelColor.Size = new System.Drawing.Size(103, 13);
            this.lbPanelColor.TabIndex = 1;
            this.lbPanelColor.Text = "Floating Panel color:";
            // 
            // lbTransp
            // 
            this.lbTransp.AutoSize = true;
            this.lbTransp.Location = new System.Drawing.Point(16, 16);
            this.lbTransp.Name = "lbTransp";
            this.lbTransp.Size = new System.Drawing.Size(75, 13);
            this.lbTransp.TabIndex = 0;
            this.lbTransp.Text = "Transparency:";
            // 
            // ColorDialog
            // 
            this.ColorDialog.AnyColor = true;
            this.ColorDialog.FullOpen = true;
            // 
            // cbxLockPosition
            // 
            this.cbxLockPosition.Location = new System.Drawing.Point(20, 233);
            this.cbxLockPosition.Name = "cbxLockPosition";
            this.cbxLockPosition.Size = new System.Drawing.Size(220, 24);
            this.cbxLockPosition.TabIndex = 24;
            this.cbxLockPosition.Text = "Lock Panel Position";
            this.cbxLockPosition.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 394);
            this.Controls.Add(this.pcOptions);
            this.Controls.Add(this.pnButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.pnButtons.ResumeLayout(false);
            this.pcOptions.ResumeLayout(false);
            this.tsBehavior.ResumeLayout(false);
            this.tsBehavior.PerformLayout();
            this.tsView.ResumeLayout(false);
            this.tsView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edPercent)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.CheckBox cbxSortAlphabetical;

        #endregion

        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.TabControl pcOptions;
        private System.Windows.Forms.TabPage tsView;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label lbFontColor;
        private System.Windows.Forms.Label lbPanelColor;
        private System.Windows.Forms.Label lbTransp;
        private System.Windows.Forms.Button btChangeFontColor;
        private System.Windows.Forms.Button btChangePanelColor;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Panel pnFontColor;
        private System.Windows.Forms.Panel pnPanelColor;
        private System.Windows.Forms.NumericUpDown edPercent;
        private System.Windows.Forms.TabPage tsBehavior;
        private System.Windows.Forms.ComboBox cbURLAction;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbStartGroup;
		private System.Windows.Forms.CheckBox cbxShowClock;
		private System.Windows.Forms.CheckBox cbxShowSearch;
		private System.Windows.Forms.TextBox txtShortcutKey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox cbxShowFoldersBeforeEntries;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox cbxShortcutWin;
		private System.Windows.Forms.CheckBox cbxShortcutAlt;
		private System.Windows.Forms.CheckBox cbxShortcutShift;
		private System.Windows.Forms.CheckBox cbxShortcutCntrl;
		private System.Windows.Forms.CheckBox cbxShowLastOne;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxShortcutWinQuick;
        private System.Windows.Forms.CheckBox cbxShortcutAltQuick;
        private System.Windows.Forms.CheckBox cbxShortcutShiftQuick;
        private System.Windows.Forms.CheckBox cbxShortcutCntrlQuick;
        private System.Windows.Forms.TextBox txtShortcutKeyQuick;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxLockPosition;
    }
}