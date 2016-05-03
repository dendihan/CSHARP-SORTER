namespace yprfj
{
    partial class Formproperedit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(40, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(450, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "特征码";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 25);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 25);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "特征码描述：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "特征码代码：";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(324, 240);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(94, 31);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(96, 240);
            this.btnsure.Margin = new System.Windows.Forms.Padding(4);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(94, 31);
            this.btnsure.TabIndex = 3;
            this.btnsure.Text = "保存";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // Formproperedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 285);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Formproperedit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特征码添加/修改";
            this.Load += new System.EventHandler(this.Formproperedit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
    }
}