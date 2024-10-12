namespace Lad04
{
    partial class Form2
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
            this.txtMkhoa = new System.Windows.Forms.TextBox();
            this.txtNameKhoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGs = new System.Windows.Forms.TextBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvkhoa = new System.Windows.Forms.DataGridView();
            this.btnBrk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMkhoa
            // 
            this.txtMkhoa.Location = new System.Drawing.Point(191, 152);
            this.txtMkhoa.Name = "txtMkhoa";
            this.txtMkhoa.Size = new System.Drawing.Size(181, 22);
            this.txtMkhoa.TabIndex = 10;
            // 
            // txtNameKhoa
            // 
            this.txtNameKhoa.Location = new System.Drawing.Point(191, 211);
            this.txtNameKhoa.Name = "txtNameKhoa";
            this.txtNameKhoa.Size = new System.Drawing.Size(213, 22);
            this.txtNameKhoa.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên Khoa :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã Khoa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tổng Gs :";
            // 
            // txtGs
            // 
            this.txtGs.Location = new System.Drawing.Point(191, 270);
            this.txtGs.Name = "txtGs";
            this.txtGs.Size = new System.Drawing.Size(181, 22);
            this.txtGs.TabIndex = 10;
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(290, 341);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 29);
            this.btnOut.TabIndex = 12;
            this.btnOut.Text = "Xóa";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 340);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 29);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvkhoa
            // 
            this.dgvkhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhoa.Location = new System.Drawing.Point(444, 79);
            this.dgvkhoa.Name = "dgvkhoa";
            this.dgvkhoa.RowHeadersWidth = 51;
            this.dgvkhoa.RowTemplate.Height = 24;
            this.dgvkhoa.Size = new System.Drawing.Size(526, 324);
            this.dgvkhoa.TabIndex = 14;
            // 
            // btnBrk
            // 
            this.btnBrk.Location = new System.Drawing.Point(895, 437);
            this.btnBrk.Name = "btnBrk";
            this.btnBrk.Size = new System.Drawing.Size(75, 29);
            this.btnBrk.TabIndex = 15;
            this.btnBrk.Text = "Thoát";
            this.btnBrk.UseVisualStyleBackColor = true;
            this.btnBrk.Click += new System.EventHandler(this.btnBrk_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 487);
            this.Controls.Add(this.btnBrk);
            this.Controls.Add(this.dgvkhoa);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtGs);
            this.Controls.Add(this.txtMkhoa);
            this.Controls.Add(this.txtNameKhoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMkhoa;
        private System.Windows.Forms.TextBox txtNameKhoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGs;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvkhoa;
        private System.Windows.Forms.Button btnBrk;
    }
}