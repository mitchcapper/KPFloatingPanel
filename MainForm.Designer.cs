namespace KPFloatingPanel
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lbClock = new System.Windows.Forms.Label();
			this.pmMainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miHide = new System.Windows.Forms.ToolStripMenuItem();
			this.miSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuExitKeePass = new System.Windows.Forms.ToolStripMenuItem();
			this.pmPasswords = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miNoPasswords = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuSaveDatabase = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextSearch = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.LastOne = new System.Windows.Forms.ToolStripMenuItem();
			this.tmClock = new System.Windows.Forms.Timer(this.components);
			this.ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.timer_search = new System.Windows.Forms.Timer(this.components);
			this.pmMainMenu.SuspendLayout();
			this.pmPasswords.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbClock
			// 
			resources.ApplyResources(this.lbClock, "lbClock");
			this.lbClock.ContextMenuStrip = this.pmMainMenu;
			this.lbClock.ForeColor = System.Drawing.SystemColors.InfoText;
			this.lbClock.Name = "lbClock";
			this.lbClock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbClock_MouseMove);
			this.lbClock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbClock_MouseDown);
			this.lbClock.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbClock_MouseUp);
			// 
			// pmMainMenu
			// 
			this.pmMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHide,
            this.miSetup,
            this.toolStripSeparator2,
            this.miAbout,
            this.toolStripSeparator1,
            this.ToolStripMenuExitKeePass});
			this.pmMainMenu.Name = "pmMainMenu";
			this.pmMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.pmMainMenu.ShowImageMargin = false;
			resources.ApplyResources(this.pmMainMenu, "pmMainMenu");
			// 
			// miHide
			// 
			this.miHide.AutoToolTip = true;
			this.miHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.miHide.Name = "miHide";
			resources.ApplyResources(this.miHide, "miHide");
			this.miHide.Click += new System.EventHandler(this.miHide_Click);
			// 
			// miSetup
			// 
			this.miSetup.AutoToolTip = true;
			this.miSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.miSetup.Name = "miSetup";
			resources.ApplyResources(this.miSetup, "miSetup");
			this.miSetup.Click += new System.EventHandler(this.miSetup_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// miAbout
			// 
			this.miAbout.Name = "miAbout";
			resources.ApplyResources(this.miAbout, "miAbout");
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// ToolStripMenuExitKeePass
			// 
			this.ToolStripMenuExitKeePass.Name = "ToolStripMenuExitKeePass";
			resources.ApplyResources(this.ToolStripMenuExitKeePass, "ToolStripMenuExitKeePass");
			this.ToolStripMenuExitKeePass.Click += new System.EventHandler(this.ToolStripMenuExitKeePass_Click);
			// 
			// pmPasswords
			// 
			this.pmPasswords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNoPasswords,
            this.toolStripMenuSaveDatabase,
			this.LastOne,
            this.toolStripTextSearch,
            this.toolStripSeparator3
            
            });
			this.pmPasswords.Name = "pmPasswords";
			this.pmPasswords.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			resources.ApplyResources(this.pmPasswords, "pmPasswords");
			this.pmPasswords.Click += new System.EventHandler(this.pmPasswords_Click);
			// 
			// miNoPasswords
			// 
			resources.ApplyResources(this.miNoPasswords, "miNoPasswords");
			this.miNoPasswords.Name = "miNoPasswords";
			this.miNoPasswords.Click += new System.EventHandler(this.miNoPasswords_Click);
			// 
			// toolStripMenuSaveDatabase
			// 
			this.toolStripMenuSaveDatabase.Image = global::KPFloatingPanel.Properties.Resources.B16x16_FileSave;
			this.toolStripMenuSaveDatabase.Name = "toolStripMenuSaveDatabase";
			resources.ApplyResources(this.toolStripMenuSaveDatabase, "toolStripMenuSaveDatabase");
			this.toolStripMenuSaveDatabase.Click += new System.EventHandler(this.toolStripMenuSaveDatabase_Click);
			// 
			// toolStripTextSearch
			// 
			this.toolStripTextSearch.AcceptsReturn = true;
			resources.ApplyResources(this.toolStripTextSearch, "toolStripTextSearch");
			this.toolStripTextSearch.Name = "toolStripTextSearch";
			this.toolStripTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextSearch_KeyDown);
			this.toolStripTextSearch.GotFocus += new System.EventHandler(this.toolStripTextSearch_GotFocus);
			this.toolStripTextSearch.TextChanged += new System.EventHandler(this.toolStripTextSearch_TextChanged);
			this.toolStripTextSearch.Click += new System.EventHandler(this.toolStripTextSearch_GotFocus);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			// 
			// LastOne
			// 
			this.LastOne.Name = "LastOne";
			resources.ApplyResources(this.LastOne, "LastOne");
			// 
			// tmClock
			// 
			this.tmClock.Enabled = true;
			this.tmClock.Interval = 1000;
			this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
			// 
			// ilIcons
			// 
			this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
			this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilIcons.Images.SetKeyName(0, "0.ico");
			this.ilIcons.Images.SetKeyName(1, "1.ico");
			this.ilIcons.Images.SetKeyName(2, "2.ico");
			this.ilIcons.Images.SetKeyName(3, "3.ico");
			this.ilIcons.Images.SetKeyName(4, "4.ico");
			this.ilIcons.Images.SetKeyName(5, "5.ico");
			this.ilIcons.Images.SetKeyName(6, "B16x16_LockWorkspace.png");
			this.ilIcons.Images.SetKeyName(7, "x.png");
			this.ilIcons.Images.SetKeyName(8, "3.png");
			this.ilIcons.Images.SetKeyName(9, "2.png");
			this.ilIcons.Images.SetKeyName(10, "4.png");
			this.ilIcons.Images.SetKeyName(11, "5.png");
			this.ilIcons.Images.SetKeyName(12, "1.png");
			// 
			// timer_search
			// 
			this.timer_search.Interval = 100;
			this.timer_search.Tick += new System.EventHandler(this.timer_search_Tick);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ContextMenuStrip = this.pmMainMenu;
			this.Controls.Add(this.lbClock);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TopMost = true;
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbClock_MouseUp);
			this.pmMainMenu.ResumeLayout(false);
			this.pmPasswords.ResumeLayout(false);
			this.pmPasswords.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbClock;
		private System.Windows.Forms.ContextMenuStrip pmPasswords;
		private System.Windows.Forms.Timer tmClock;
		private System.Windows.Forms.ContextMenuStrip pmMainMenu;
		private System.Windows.Forms.ToolStripMenuItem miHide;
		private System.Windows.Forms.ToolStripMenuItem miSetup;
		private System.Windows.Forms.ToolStripMenuItem miNoPasswords;
		internal System.Windows.Forms.ImageList ilIcons;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuSaveDatabase;
		private System.Windows.Forms.ToolStripTextBox toolStripTextSearch;
		private System.Windows.Forms.Timer timer_search;
		private System.Windows.Forms.ToolStripMenuItem miAbout;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuExitKeePass;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem LastOne;
	}
}