namespace yprfj
{
    partial class Formlogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textPWD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsure = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 232);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(216, 229);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 31);
            this.comboBox1.TabIndex = 2;
            // 
            // textPWD
            // 
            this.textPWD.Location = new System.Drawing.Point(216, 290);
            this.textPWD.Margin = new System.Windows.Forms.Padding(4);
            this.textPWD.Name = "textPWD";
            this.textPWD.Size = new System.Drawing.Size(250, 34);
            this.textPWD.TabIndex = 3;
            this.textPWD.UseSystemPasswordChar = true;
            this.textPWD.TextChanged += new System.EventHandler(this.textPWD_TextChanged);
            this.textPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 293);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::yprfj.Properties.Resources._77758PICW2U;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 222);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnsure
            // 
            this.btnsure.Image = global::yprfj.Properties.Resources._202;
            this.btnsure.Location = new System.Drawing.Point(165, 332);
            this.btnsure.Margin = new System.Windows.Forms.Padding(4);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(94, 50);
            this.btnsure.TabIndex = 0;
            this.btnsure.Text = "登入";
            this.btnsure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncancel.Image = global::yprfj.Properties.Resources._168;
            this.btncancel.Location = new System.Drawing.Point(344, 332);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(96, 50);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "取消";
            this.btncancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // Formlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 405);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPWD);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Formlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formlogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Formlogin_FormClosed);
            this.Load += new System.EventHandler(this.Formlogin_Load);
            this.Shown += new System.EventHandler(this.Formlogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textPWD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btncancel;
    }
}