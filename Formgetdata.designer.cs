namespace yprfj
{
    partial class Formgetdata
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnquery = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnget = new System.Windows.Forms.Button();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnget);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btnquery);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 120);
            this.panel1.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnclose.Location = new System.Drawing.Point(713, 69);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(136, 38);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "页面关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnquery
            // 
            this.btnquery.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnquery.Location = new System.Drawing.Point(546, 69);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(136, 38);
            this.btnquery.TabIndex = 5;
            this.btnquery.Text = "数据查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Location = new System.Drawing.Point(105, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(225, 38);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2016, 4, 19, 11, 17, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(474, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务数据";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridControl1.Location = new System.Drawing.Point(0, 120);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1082, 277);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "WindowsXP";
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // btnget
            // 
            this.btnget.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnget.Location = new System.Drawing.Point(371, 69);
            this.btnget.Name = "btnget";
            this.btnget.Size = new System.Drawing.Size(136, 38);
            this.btnget.TabIndex = 10;
            this.btnget.Text = "数据获取";
            this.btnget.UseVisualStyleBackColor = true;
            this.btnget.Click += new System.EventHandler(this.btnget_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "状态";
            this.gridColumn1.FieldName = "PSTATE2";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "条形码";
            this.gridColumn2.FieldName = "BARCODE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "实际出口";
            this.gridColumn3.FieldName = "POUT2";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "理论出口";
            this.gridColumn4.FieldName = "POUT";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "收件人姓名";
            this.gridColumn5.FieldName = "TONAME";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "收件地址";
            this.gridColumn6.FieldName = "TOADDR";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "收件单位";
            this.gridColumn7.FieldName = "TOCO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 150;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "收件详细地址";
            this.gridColumn8.FieldName = "TODETAIL";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "收件人电话";
            this.gridColumn9.FieldName = "TOTEL";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 150;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "重量";
            this.gridColumn10.FieldName = "PWEIGHT";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 150;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "长";
            this.gridColumn11.FieldName = "PLENGTH";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 150;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "宽";
            this.gridColumn12.FieldName = "PWIDTH";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            this.gridColumn12.Width = 150;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "高";
            this.gridColumn13.FieldName = "PHEIGHT";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 150;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "体积";
            this.gridColumn14.FieldName = "VOLUME";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            this.gridColumn14.Width = 150;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "标签条码";
            this.gridColumn15.FieldName = "LABBARCODE";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            this.gridColumn15.Width = 150;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "入口编号";
            this.gridColumn16.FieldName = "CODEIN";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            this.gridColumn16.Width = 150;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "操作员代码";
            this.gridColumn17.FieldName = "USERCODE";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            this.gridColumn17.Width = 150;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "操作员姓名";
            this.gridColumn18.FieldName = "USERNAME";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 17;
            this.gridColumn18.Width = 150;
            // 
            // Formgetdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 397);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Formgetdata";
            this.Text = "业务数据";
            this.Load += new System.EventHandler(this.Formgetdata_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnget;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}