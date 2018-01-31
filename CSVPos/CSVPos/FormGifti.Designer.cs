namespace CSVPos
{
    partial class FormGifti
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGifticonUse = new System.Windows.Forms.Button();
            this.txtUseable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGifti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(153, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 55);
            this.label1.TabIndex = 25;
            this.label1.Text = "기프티콘 결제";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnGifticonUse);
            this.groupBox4.Controls.Add(this.txtUseable);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtProduct);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtGifti);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Location = new System.Drawing.Point(25, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(539, 361);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "기프티콘 기본 정보 입력";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(12, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(521, 33);
            this.label10.TabIndex = 19;
            this.label10.Text = "----------------------------------------------";
            // 
            // btnGifticonUse
            // 
            this.btnGifticonUse.Enabled = false;
            this.btnGifticonUse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGifticonUse.Location = new System.Drawing.Point(138, 275);
            this.btnGifticonUse.Name = "btnGifticonUse";
            this.btnGifticonUse.Size = new System.Drawing.Size(252, 50);
            this.btnGifticonUse.TabIndex = 18;
            this.btnGifticonUse.TabStop = false;
            this.btnGifticonUse.Text = "기프티콘 적용";
            this.btnGifticonUse.UseVisualStyleBackColor = true;
            // 
            // txtUseable
            // 
            this.txtUseable.Location = new System.Drawing.Point(162, 217);
            this.txtUseable.Name = "txtUseable";
            this.txtUseable.Size = new System.Drawing.Size(300, 35);
            this.txtUseable.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "적용 상품";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(162, 99);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(299, 35);
            this.txtProduct.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 33);
            this.label2.TabIndex = 12;
            this.label2.Text = "기프티콘 번호";
            // 
            // txtGifti
            // 
            this.txtGifti.Location = new System.Drawing.Point(162, 49);
            this.txtGifti.MaxLength = 9;
            this.txtGifti.Name = "txtGifti";
            this.txtGifti.Size = new System.Drawing.Size(299, 35);
            this.txtGifti.TabIndex = 11;
            this.txtGifti.Click += new System.EventHandler(this.txtGifti_Click);
            this.txtGifti.TextChanged += new System.EventHandler(this.txtGifti_TextChanged);
            this.txtGifti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGifti_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(6, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 33);
            this.label4.TabIndex = 16;
            this.label4.Text = "사용 가능 여부";
            // 
            // FormGifti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(601, 516);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormGifti";
            this.Text = "FormGifti";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUseable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnGifticonUse;
        internal System.Windows.Forms.TextBox txtProduct;
        internal System.Windows.Forms.TextBox txtGifti;
    }
}