namespace banvemaybay
{
    partial class Timkiemve
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
            this.datagridviewtimliem = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txttenhanhkhachtimkiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmachuyenbaytimkiem = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewtimliem)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridviewtimliem
            // 
            this.datagridviewtimliem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewtimliem.Location = new System.Drawing.Point(-6, 244);
            this.datagridviewtimliem.Name = "datagridviewtimliem";
            this.datagridviewtimliem.RowHeadersWidth = 62;
            this.datagridviewtimliem.RowTemplate.Height = 28;
            this.datagridviewtimliem.Size = new System.Drawing.Size(1215, 303);
            this.datagridviewtimliem.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(737, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tìm Kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên hành khách";
            // 
            // txttenhanhkhachtimkiem
            // 
            this.txttenhanhkhachtimkiem.Location = new System.Drawing.Point(376, 53);
            this.txttenhanhkhachtimkiem.Name = "txttenhanhkhachtimkiem";
            this.txttenhanhkhachtimkiem.Size = new System.Drawing.Size(177, 26);
            this.txttenhanhkhachtimkiem.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã chuyến bay";
            // 
            // txtmachuyenbaytimkiem
            // 
            this.txtmachuyenbaytimkiem.Location = new System.Drawing.Point(376, 144);
            this.txtmachuyenbaytimkiem.Name = "txtmachuyenbaytimkiem";
            this.txtmachuyenbaytimkiem.Size = new System.Drawing.Size(177, 26);
            this.txtmachuyenbaytimkiem.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(917, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(897, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 35);
            this.button3.TabIndex = 7;
            this.button3.Text = "Trang chủ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Timkiemve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 559);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtmachuyenbaytimkiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttenhanhkhachtimkiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datagridviewtimliem);
            this.Name = "Timkiemve";
            this.Text = "Timkiemve";
            this.Load += new System.EventHandler(this.Timkiemve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewtimliem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridviewtimliem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttenhanhkhachtimkiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmachuyenbaytimkiem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}