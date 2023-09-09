namespace WorkAc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWord = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitProg = new System.Windows.Forms.ToolStripMenuItem();
            this.guideMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оформлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрСправкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProg = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.selectTable = new System.Windows.Forms.ComboBox();
            this.selectCategory = new System.Windows.Forms.ComboBox();
            this.closeSearch = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDgv = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.guideMenu,
            this.SearchMenu,
            this.видToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.ExitMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(475, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRecord,
            this.экспортToolStripMenuItem,
            this.ExitProg});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 31);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // AddRecord
            // 
            this.AddRecord.Name = "AddRecord";
            this.AddRecord.Size = new System.Drawing.Size(178, 22);
            this.AddRecord.Text = "Добавить запись";
            this.AddRecord.Click += new System.EventHandler(this.AddRecord_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportExcel,
            this.exportWord,
            this.exportPDF});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // exportExcel
            // 
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(108, 22);
            this.exportExcel.Text = "Excel";
            this.exportExcel.Click += new System.EventHandler(this.exportExcel_Click);
            // 
            // exportWord
            // 
            this.exportWord.Name = "exportWord";
            this.exportWord.Size = new System.Drawing.Size(108, 22);
            this.exportWord.Text = "Word";
            this.exportWord.Click += new System.EventHandler(this.exportWord_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(108, 22);
            this.exportPDF.Text = "PDF";
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // ExitProg
            // 
            this.ExitProg.Name = "ExitProg";
            this.ExitProg.Size = new System.Drawing.Size(178, 22);
            this.ExitProg.Text = "Выход";
            this.ExitProg.Click += new System.EventHandler(this.ExitProg_Click);
            // 
            // guideMenu
            // 
            this.guideMenu.Name = "guideMenu";
            this.guideMenu.Size = new System.Drawing.Size(92, 31);
            this.guideMenu.Text = "Справочник";
            this.guideMenu.Click += new System.EventHandler(this.guideMenu_Click);
            // 
            // SearchMenu
            // 
            this.SearchMenu.Name = "SearchMenu";
            this.SearchMenu.Size = new System.Drawing.Size(56, 31);
            this.SearchMenu.Text = "Поиск";
            this.SearchMenu.Click += new System.EventHandler(this.SearchMenu_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оформлениеToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(41, 31);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // оформлениеToolStripMenuItem
            // 
            this.оформлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LightMenuItem,
            this.DarkMenuItem});
            this.оформлениеToolStripMenuItem.Name = "оформлениеToolStripMenuItem";
            this.оформлениеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.оформлениеToolStripMenuItem.Text = "Оформление";
            // 
            // LightMenuItem
            // 
            this.LightMenuItem.Name = "LightMenuItem";
            this.LightMenuItem.Size = new System.Drawing.Size(126, 22);
            this.LightMenuItem.Text = "Светлый";
            this.LightMenuItem.Click += new System.EventHandler(this.LightMenuItem_Click);
            // 
            // DarkMenuItem
            // 
            this.DarkMenuItem.Name = "DarkMenuItem";
            this.DarkMenuItem.Size = new System.Drawing.Size(126, 22);
            this.DarkMenuItem.Text = "Темный";
            this.DarkMenuItem.Click += new System.EventHandler(this.DarkMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрСправкиToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.aboutProg});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(70, 31);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // просмотрСправкиToolStripMenuItem
            // 
            this.просмотрСправкиToolStripMenuItem.Name = "просмотрСправкиToolStripMenuItem";
            this.просмотрСправкиToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.просмотрСправкиToolStripMenuItem.Text = "Просмотр справки";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // aboutProg
            // 
            this.aboutProg.Name = "aboutProg";
            this.aboutProg.Size = new System.Drawing.Size(189, 22);
            this.aboutProg.Text = "О программе";
            this.aboutProg.Click += new System.EventHandler(this.aboutProg_Click);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(157, 31);
            this.ExitMenu.Text = "Сменить пользователя";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // SearchPanel
            // 
            this.SearchPanel.AutoSize = true;
            this.SearchPanel.Controls.Add(this.selectCategory);
            this.SearchPanel.Controls.Add(this.closeSearch);
            this.SearchPanel.Controls.Add(this.SearchBox);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1178, 34);
            this.SearchPanel.TabIndex = 6;
            this.SearchPanel.Visible = false;
            // 
            // selectTable
            // 
            this.selectTable.FormattingEnabled = true;
            this.selectTable.Items.AddRange(new object[] {
            "Персональные данные",
            "Служебные данные",
            "Паспортные данные"});
            this.selectTable.Location = new System.Drawing.Point(3, 3);
            this.selectTable.Name = "selectTable";
            this.selectTable.Size = new System.Drawing.Size(151, 23);
            this.selectTable.TabIndex = 11;
            this.selectTable.Text = "Выберите таблицу";
            this.selectTable.SelectedIndexChanged += new System.EventHandler(this.selectTable_SelectedIndexChanged);
            // 
            // selectCategory
            // 
            this.selectCategory.FormattingEnabled = true;
            this.selectCategory.Location = new System.Drawing.Point(3, 5);
            this.selectCategory.Name = "selectCategory";
            this.selectCategory.Size = new System.Drawing.Size(167, 24);
            this.selectCategory.TabIndex = 10;
            // 
            // closeSearch
            // 
            this.closeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeSearch.FlatAppearance.BorderSize = 0;
            this.closeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeSearch.Location = new System.Drawing.Point(1152, 5);
            this.closeSearch.Name = "closeSearch";
            this.closeSearch.Size = new System.Drawing.Size(23, 23);
            this.closeSearch.TabIndex = 9;
            this.closeSearch.Text = "X";
            this.closeSearch.UseVisualStyleBackColor = true;
            this.closeSearch.Click += new System.EventHandler(this.closeSearch_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.AccessibleName = "";
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBox.Location = new System.Drawing.Point(176, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(970, 22);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.SearchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.2027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.7973F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 561);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView, 2);
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 78);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(1178, 480);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.DoubleClick += new System.EventHandler(this.DataGridView_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.SearchPanel);
            this.panel1.Controls.Add(this.labelDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 34);
            this.panel1.TabIndex = 14;
            // 
            // labelDgv
            // 
            this.labelDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDgv.AutoSize = true;
            this.labelDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDgv.Location = new System.Drawing.Point(9, 9);
            this.labelDgv.Name = "labelDgv";
            this.labelDgv.Size = new System.Drawing.Size(245, 16);
            this.labelDgv.TabIndex = 15;
            this.labelDgv.Text = "Персональные данные сотрудников";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(478, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 29);
            this.panel2.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование личных дел сотрудников организации";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem SearchMenu;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitProg;
        private System.Windows.Forms.ToolStripMenuItem оформлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DarkMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProg;
        private System.Windows.Forms.ToolStripMenuItem exportExcel;
        private System.Windows.Forms.ToolStripMenuItem exportWord;
        private System.Windows.Forms.ToolStripMenuItem exportPDF;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ToolStripMenuItem AddRecord;
        private System.Windows.Forms.Button closeSearch;
        private DataSet dataSet;
        private System.Windows.Forms.ToolStripMenuItem guideMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDgv;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem просмотрСправкиToolStripMenuItem;
        private System.Windows.Forms.ComboBox selectCategory;
        private System.Windows.Forms.ComboBox selectTable;
        private System.Windows.Forms.Panel panel2;
    }
}