namespace CSVPos
{
    partial class FormDiscount
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
            this.gboxTele = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblMembership = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelecom = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAfterDC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBeforeDC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gboxTele.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "통신사 할인";
            // 
            // gboxTele
            // 
            this.gboxTele.Controls.Add(this.label2);
            this.gboxTele.Controls.Add(this.lblDiscount);
            this.gboxTele.Controls.Add(this.lblMembership);
            this.gboxTele.Controls.Add(this.label8);
            this.gboxTele.Controls.Add(this.txtTelecom);
            this.gboxTele.Controls.Add(this.label7);
            this.gboxTele.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gboxTele.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gboxTele.Location = new System.Drawing.Point(22, 107);
            this.gboxTele.Name = "gboxTele";
            this.gboxTele.Size = new System.Drawing.Size(539, 172);
            this.gboxTele.TabIndex = 20;
            this.gboxTele.TabStop = false;
            this.gboxTele.Text = "통신사 할인";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(377, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 33);
            this.label2.TabIndex = 23;
            this.label2.Text = "할인 :";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDiscount.Location = new System.Drawing.Point(449, 98);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(0, 33);
            this.lblDiscount.TabIndex = 22;
            // 
            // lblMembership
            // 
            this.lblMembership.AutoSize = true;
            this.lblMembership.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembership.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMembership.Location = new System.Drawing.Point(177, 98);
            this.lblMembership.Name = "lblMembership";
            this.lblMembership.Size = new System.Drawing.Size(0, 33);
            this.lblMembership.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(15, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 33);
            this.label8.TabIndex = 20;
            this.label8.Text = "적용 멤버십 : ";
            // 
            // txtTelecom
            // 
            this.txtTelecom.Location = new System.Drawing.Point(162, 44);
            this.txtTelecom.MaxLength = 16;
            this.txtTelecom.Name = "txtTelecom";
            this.txtTelecom.Size = new System.Drawing.Size(299, 35);
            this.txtTelecom.TabIndex = 19;
            this.txtTelecom.Click += new System.EventHandler(this.txtTelecom_Click);
            this.txtTelecom.TextChanged += new System.EventHandler(this.txtTelecom_TextChanged);
            this.txtTelecom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelecom_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(15, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 33);
            this.label7.TabIndex = 19;
            this.label7.Text = "멤버십 번호";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAfterDC);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtBeforeDC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(22, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(539, 172);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "할인 여부 미리 보기";
            // 
            // txtAfterDC
            // 
            this.txtAfterDC.Location = new System.Drawing.Point(162, 106);
            this.txtAfterDC.Name = "txtAfterDC";
            this.txtAfterDC.Size = new System.Drawing.Size(299, 35);
            this.txtAfterDC.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 33);
            this.label6.TabIndex = 22;
            this.label6.Text = "할인 후 금액";
            // 
            // txtBeforeDC
            // 
            this.txtBeforeDC.Location = new System.Drawing.Point(163, 48);
            this.txtBeforeDC.Name = "txtBeforeDC";
            this.txtBeforeDC.Size = new System.Drawing.Size(299, 35);
            this.txtBeforeDC.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(7, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 33);
            this.label5.TabIndex = 20;
            this.label5.Text = "할인 전 금액";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnApply.Location = new System.Drawing.Point(304, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(138, 96);
            this.btnApply.TabIndex = 23;
            this.btnApply.TabStop = false;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(444, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 96);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(597, 476);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gboxTele);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "판매 등록 > 할인, 기프티콘 ";
            this.gboxTele.ResumeLayout(false);
            this.gboxTele.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxTele;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMembership;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelecom;
        internal System.Windows.Forms.TextBox txtBeforeDC;
        private System.Windows.Forms.TextBox txtAfterDC;
        private System.Windows.Forms.Button btnApply;
    }
}