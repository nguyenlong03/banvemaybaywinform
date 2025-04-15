namespace banvemaybay
{
    partial class QLbaocao
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
            this.dataGridViewbaocao = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txttongsovebanduoc = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtsotienbanduoc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbaocao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewbaocao
            // 
            this.dataGridViewbaocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewbaocao.Location = new System.Drawing.Point(0, 254);
            this.dataGridViewbaocao.Name = "dataGridViewbaocao";
            this.dataGridViewbaocao.RowHeadersWidth = 62;
            this.dataGridViewbaocao.RowTemplate.Height = 28;
            this.dataGridViewbaocao.Size = new System.Drawing.Size(1134, 380);
            this.dataGridViewbaocao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 4;
            // 
            // txttongsovebanduoc
            // 
            this.txttongsovebanduoc.Location = new System.Drawing.Point(705, 109);
            this.txttongsovebanduoc.Multiline = true;
            this.txttongsovebanduoc.Name = "txttongsovebanduoc";
            this.txttongsovebanduoc.Size = new System.Drawing.Size(122, 36);
            this.txttongsovebanduoc.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(862, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "Thoát";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(862, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 39);
            this.button4.TabIndex = 11;
            this.button4.Text = "Trang chủ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtsotienbanduoc
            // 
            this.txtsotienbanduoc.Location = new System.Drawing.Point(263, 114);
            this.txtsotienbanduoc.Multiline = true;
            this.txtsotienbanduoc.Name = "txtsotienbanduoc";
            this.txtsotienbanduoc.Size = new System.Drawing.Size(175, 31);
            this.txtsotienbanduoc.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 36);
            this.button1.TabIndex = 14;
            this.button1.Text = "Tổng số vé đã bán";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(47, 114);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(210, 31);
            this.button5.TabIndex = 15;
            this.button5.Text = "Tổng số tiền vé đã bán";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtsotienbanduoc);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txttongsovebanduoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(0, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1134, 210);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo ";
            // 
            // QLbaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 637);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewbaocao);
            this.Name = "QLbaocao";
            this.Text = "QLbaocao";
            this.Load += new System.EventHandler(this.QLbaocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbaocao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewbaocao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttongsovebanduoc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtsotienbanduoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}