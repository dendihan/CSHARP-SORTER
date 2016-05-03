namespace yprfj
{
    partial class Formshowcol
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemColorEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit2,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.gridControl1.Size = new System.Drawing.Size(437, 685);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridView2.OptionsFilter.AllowMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gridView2.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gridView2.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridView2.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.PaintStyleName = "WindowsXP";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID0000";
            this.gridColumn7.FieldName = "ID0000";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "列名称";
            this.gridColumn4.FieldName = "COLCAP";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 230;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "选择";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit3;
            this.gridColumn5.FieldName = "SHOW00";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 140;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Caption = "Check";
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.ValueChecked = 1;
            this.repositoryItemCheckEdit3.ValueUnchecked = 0;
            // 
            // repositoryItemColorEdit2
            // 
            this.repositoryItemColorEdit2.AutoHeight = false;
            this.repositoryItemColorEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit2.Name = "repositoryItemColorEdit2";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(453, 579);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(94, 31);
            this.btncancel.TabIndex = 6;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(453, 508);
            this.btnsure.Margin = new System.Windows.Forms.Padding(4);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(94, 31);
            this.btnsure.TabIndex = 5;
            this.btnsure.Text = "保存";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // Formshowcol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 685);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Formshowcol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义列选着";
            this.Load += new System.EventHandler(this.Formshowcol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
    }
}