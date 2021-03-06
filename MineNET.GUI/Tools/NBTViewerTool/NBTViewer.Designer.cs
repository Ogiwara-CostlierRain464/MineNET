﻿namespace MineNET.GUI.Tools.NBTViewerTool
{
    partial class NBTViewer
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagTypeDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nBTViewerCacheBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cacheData = new MineNET.GUI.Resources.Data.CacheData();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNBTFileLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zLIBZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gZipGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNBTFileSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawNToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zLIBZToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gZipGToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileEndianModeEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.littleEndianLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigEndianBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unLoadNBTFileUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateRowsRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBTViewerCacheBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cacheData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.tagTypeDataGridViewComboBoxColumn});
            this.dataGridView1.DataSource = this.nBTViewerCacheBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(484, 237);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tagTypeDataGridViewComboBoxColumn
            // 
            this.tagTypeDataGridViewComboBoxColumn.DataPropertyName = "TagType";
            this.tagTypeDataGridViewComboBoxColumn.HeaderText = "TagType";
            this.tagTypeDataGridViewComboBoxColumn.Items.AddRange(new object[] {
            "End",
            "Byte",
            "Short",
            "Int",
            "Long",
            "Float",
            "Double",
            "ByteArray",
            "String",
            "List",
            "Compound",
            "IntArray",
            "LongArray"});
            this.tagTypeDataGridViewComboBoxColumn.Name = "tagTypeDataGridViewComboBoxColumn";
            this.tagTypeDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nBTViewerCacheBindingSource
            // 
            this.nBTViewerCacheBindingSource.AllowNew = true;
            this.nBTViewerCacheBindingSource.DataMember = "NBTViewerCache";
            this.nBTViewerCacheBindingSource.DataSource = this.cacheData;
            // 
            // cacheData
            // 
            this.cacheData.DataSetName = "CacheData";
            this.cacheData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.editEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNBTFileLToolStripMenuItem,
            this.saveNBTFileSToolStripMenuItem,
            this.toolStripMenuItem1,
            this.fileEndianModeEToolStripMenuItem,
            this.unLoadNBTFileUToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitEToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // loadNBTFileLToolStripMenuItem
            // 
            this.loadNBTFileLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawNToolStripMenuItem,
            this.zLIBZToolStripMenuItem,
            this.gZipGToolStripMenuItem});
            this.loadNBTFileLToolStripMenuItem.Name = "loadNBTFileLToolStripMenuItem";
            this.loadNBTFileLToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loadNBTFileLToolStripMenuItem.Text = "Load NBT File(&L)";
            // 
            // rawNToolStripMenuItem
            // 
            this.rawNToolStripMenuItem.Name = "rawNToolStripMenuItem";
            this.rawNToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rawNToolStripMenuItem.Text = "Raw(&N)";
            this.rawNToolStripMenuItem.Click += new System.EventHandler(this.rawNToolStripMenuItem_Click);
            // 
            // zLIBZToolStripMenuItem
            // 
            this.zLIBZToolStripMenuItem.Name = "zLIBZToolStripMenuItem";
            this.zLIBZToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zLIBZToolStripMenuItem.Text = "ZLIB(&Z)";
            this.zLIBZToolStripMenuItem.Click += new System.EventHandler(this.zLIBZToolStripMenuItem_Click);
            // 
            // gZipGToolStripMenuItem
            // 
            this.gZipGToolStripMenuItem.Name = "gZipGToolStripMenuItem";
            this.gZipGToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gZipGToolStripMenuItem.Text = "GZip(&G)";
            this.gZipGToolStripMenuItem.Click += new System.EventHandler(this.gZipGToolStripMenuItem_Click);
            // 
            // saveNBTFileSToolStripMenuItem
            // 
            this.saveNBTFileSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawNToolStripMenuItem1,
            this.zLIBZToolStripMenuItem1,
            this.gZipGToolStripMenuItem1});
            this.saveNBTFileSToolStripMenuItem.Name = "saveNBTFileSToolStripMenuItem";
            this.saveNBTFileSToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveNBTFileSToolStripMenuItem.Text = "Save NBT File(&S)";
            // 
            // rawNToolStripMenuItem1
            // 
            this.rawNToolStripMenuItem1.Name = "rawNToolStripMenuItem1";
            this.rawNToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.rawNToolStripMenuItem1.Text = "Raw(&N)";
            this.rawNToolStripMenuItem1.Click += new System.EventHandler(this.rawNToolStripMenuItem1_Click);
            // 
            // zLIBZToolStripMenuItem1
            // 
            this.zLIBZToolStripMenuItem1.Name = "zLIBZToolStripMenuItem1";
            this.zLIBZToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.zLIBZToolStripMenuItem1.Text = "ZLIB(&Z)";
            this.zLIBZToolStripMenuItem1.Click += new System.EventHandler(this.zLIBZToolStripMenuItem1_Click);
            // 
            // gZipGToolStripMenuItem1
            // 
            this.gZipGToolStripMenuItem1.Name = "gZipGToolStripMenuItem1";
            this.gZipGToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.gZipGToolStripMenuItem1.Text = "GZip(&G)";
            this.gZipGToolStripMenuItem1.Click += new System.EventHandler(this.gZipGToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // fileEndianModeEToolStripMenuItem
            // 
            this.fileEndianModeEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.littleEndianLToolStripMenuItem,
            this.bigEndianBToolStripMenuItem});
            this.fileEndianModeEToolStripMenuItem.Name = "fileEndianModeEToolStripMenuItem";
            this.fileEndianModeEToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.fileEndianModeEToolStripMenuItem.Text = "File Endian Mode(&E)";
            // 
            // littleEndianLToolStripMenuItem
            // 
            this.littleEndianLToolStripMenuItem.Checked = true;
            this.littleEndianLToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.littleEndianLToolStripMenuItem.Name = "littleEndianLToolStripMenuItem";
            this.littleEndianLToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.littleEndianLToolStripMenuItem.Text = "LittleEndian(&L)";
            this.littleEndianLToolStripMenuItem.Click += new System.EventHandler(this.littleEndianLToolStripMenuItem_Click);
            // 
            // bigEndianBToolStripMenuItem
            // 
            this.bigEndianBToolStripMenuItem.Name = "bigEndianBToolStripMenuItem";
            this.bigEndianBToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bigEndianBToolStripMenuItem.Text = "BigEndian(&B)";
            this.bigEndianBToolStripMenuItem.Click += new System.EventHandler(this.bigEndianBToolStripMenuItem_Click);
            // 
            // unLoadNBTFileUToolStripMenuItem
            // 
            this.unLoadNBTFileUToolStripMenuItem.Name = "unLoadNBTFileUToolStripMenuItem";
            this.unLoadNBTFileUToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.unLoadNBTFileUToolStripMenuItem.Text = "UnLoad NBT File(&U)";
            this.unLoadNBTFileUToolStripMenuItem.Click += new System.EventHandler(this.unLoadNBTFileUToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // exitEToolStripMenuItem
            // 
            this.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem";
            this.exitEToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitEToolStripMenuItem.Text = "Exit(&E)";
            this.exitEToolStripMenuItem.Click += new System.EventHandler(this.exitEToolStripMenuItem_Click);
            // 
            // editEToolStripMenuItem
            // 
            this.editEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpUToolStripMenuItem,
            this.moveDownDToolStripMenuItem,
            this.updateRowsRToolStripMenuItem});
            this.editEToolStripMenuItem.Name = "editEToolStripMenuItem";
            this.editEToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.editEToolStripMenuItem.Text = "Edit(&E)";
            // 
            // moveUpUToolStripMenuItem
            // 
            this.moveUpUToolStripMenuItem.Name = "moveUpUToolStripMenuItem";
            this.moveUpUToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.moveUpUToolStripMenuItem.Text = "Move Up(&U)";
            this.moveUpUToolStripMenuItem.Click += new System.EventHandler(this.moveUpUToolStripMenuItem_Click);
            // 
            // moveDownDToolStripMenuItem
            // 
            this.moveDownDToolStripMenuItem.Name = "moveDownDToolStripMenuItem";
            this.moveDownDToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.moveDownDToolStripMenuItem.Text = "Move Down(&D)";
            this.moveDownDToolStripMenuItem.Click += new System.EventHandler(this.moveDownDToolStripMenuItem_Click);
            // 
            // updateRowsRToolStripMenuItem
            // 
            this.updateRowsRToolStripMenuItem.Name = "updateRowsRToolStripMenuItem";
            this.updateRowsRToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.updateRowsRToolStripMenuItem.Text = "Update Rows(&R)";
            this.updateRowsRToolStripMenuItem.Click += new System.EventHandler(this.updateRowsRToolStripMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NBTViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "NBTViewer";
            this.Text = "NBTViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBTViewerCacheBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cacheData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownDToolStripMenuItem;
        private System.Windows.Forms.BindingSource nBTViewerCacheBindingSource;
        private Resources.Data.CacheData cacheData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn tagTypeDataGridViewComboBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem updateRowsRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadNBTFileLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zLIBZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gZipGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNBTFileSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawNToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zLIBZToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gZipGToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileEndianModeEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem littleEndianLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bigEndianBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem unLoadNBTFileUToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}