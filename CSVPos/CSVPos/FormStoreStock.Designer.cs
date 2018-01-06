namespace CSVPos
{
    partial class FormStoreStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStoreStock));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMoveMain = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnTotalSales = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnStoreManage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(470, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "재고 관리";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMoveMain);
            this.groupBox1.Controls.Add(this.btnEmployee);
            this.groupBox1.Controls.Add(this.btnTotalSales);
            this.groupBox1.Controls.Add(this.btnPayment);
            this.groupBox1.Controls.Add(this.btnStoreManage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(939, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 544);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "선택가능 기능";
            // 
            // btnMoveMain
            // 
            this.btnMoveMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoveMain.Location = new System.Drawing.Point(13, 334);
            this.btnMoveMain.Name = "btnMoveMain";
            this.btnMoveMain.Size = new System.Drawing.Size(205, 94);
            this.btnMoveMain.TabIndex = 13;
            this.btnMoveMain.Text = "상품 재고 수정\r\n(도난,분실)";
            this.btnMoveMain.UseVisualStyleBackColor = true;
            this.btnMoveMain.Click += new System.EventHandler(this.btnMoveMain_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEmployee.Location = new System.Drawing.Point(13, 34);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(205, 94);
            this.btnEmployee.TabIndex = 1;
            this.btnEmployee.Text = "상품 발주";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnTotalSales
            // 
            this.btnTotalSales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTotalSales.Location = new System.Drawing.Point(13, 434);
            this.btnTotalSales.Name = "btnTotalSales";
            this.btnTotalSales.Size = new System.Drawing.Size(205, 94);
            this.btnTotalSales.TabIndex = 12;
            this.btnTotalSales.Text = "매장 내부 \r\n모든 재고 보기";
            this.btnTotalSales.UseVisualStyleBackColor = true;
            this.btnTotalSales.Click += new System.EventHandler(this.btnTotalSales_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPayment.Location = new System.Drawing.Point(13, 134);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(205, 94);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "상품 폐기 등록";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnStoreManage
            // 
            this.btnStoreManage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStoreManage.Location = new System.Drawing.Point(13, 234);
            this.btnStoreManage.Name = "btnStoreManage";
            this.btnStoreManage.Size = new System.Drawing.Size(205, 94);
            this.btnStoreManage.TabIndex = 3;
            this.btnStoreManage.Text = "상품 반납 등록";
            this.btnStoreManage.UseVisualStyleBackColor = true;
            this.btnStoreManage.Click += new System.EventHandler(this.btnStoreManage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(921, 731);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "현 재고 상태 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(870, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "시간 출력 부분 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(717, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 39);
            this.label3.TabIndex = 17;
            this.label3.Text = "현재 시간 : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1063, 713);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(109, 106);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(1057, 822);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ver. 0.1";
            // 
            // FormStoreStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormStoreStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStoreStock";
            this.Load += new System.EventHandler(this.FormStoreStock_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMoveMain;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnTotalSales;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnStoreManage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
    }
}