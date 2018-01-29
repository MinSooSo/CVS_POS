namespace CSVPos
{
    partial class FormProductOrder
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
            this.dgv_Supplier = new System.Windows.Forms.DataGridView();
            this.dgv_Order = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProductOrder = new System.Windows.Forms.Button();
            this.btnProAdd = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnProDel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtordernum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Supplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(234, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "상품 발주 관리";
            // 
            // dgv_Supplier
            // 
            this.dgv_Supplier.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Supplier.Location = new System.Drawing.Point(12, 151);
            this.dgv_Supplier.Name = "dgv_Supplier";
            this.dgv_Supplier.ReadOnly = true;
            this.dgv_Supplier.RowTemplate.Height = 23;
            this.dgv_Supplier.Size = new System.Drawing.Size(860, 259);
            this.dgv_Supplier.TabIndex = 45;
            // 
            // dgv_Order
            // 
            this.dgv_Order.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order.Location = new System.Drawing.Point(12, 503);
            this.dgv_Order.Name = "dgv_Order";
            this.dgv_Order.ReadOnly = true;
            this.dgv_Order.RowTemplate.Height = 23;
            this.dgv_Order.Size = new System.Drawing.Size(860, 259);
            this.dgv_Order.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 37);
            this.label2.TabIndex = 47;
            this.label2.Text = "발주 가능 상품";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 37);
            this.label3.TabIndex = 48;
            this.label3.Text = "발주 상품 목록";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProductOrder);
            this.groupBox1.Controls.Add(this.btnProAdd);
            this.groupBox1.Controls.Add(this.btnOutput);
            this.groupBox1.Controls.Add(this.btnProDel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(889, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 444);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "선택가능 기능";
            // 
            // btnProductOrder
            // 
            this.btnProductOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProductOrder.Location = new System.Drawing.Point(13, 334);
            this.btnProductOrder.Name = "btnProductOrder";
            this.btnProductOrder.Size = new System.Drawing.Size(205, 94);
            this.btnProductOrder.TabIndex = 13;
            this.btnProductOrder.Text = "발주 신청";
            this.btnProductOrder.UseVisualStyleBackColor = true;
            this.btnProductOrder.Click += new System.EventHandler(this.btnProductOrder_Click);
            // 
            // btnProAdd
            // 
            this.btnProAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProAdd.Location = new System.Drawing.Point(13, 34);
            this.btnProAdd.Name = "btnProAdd";
            this.btnProAdd.Size = new System.Drawing.Size(205, 94);
            this.btnProAdd.TabIndex = 1;
            this.btnProAdd.Text = "발주 상품 추가";
            this.btnProAdd.UseVisualStyleBackColor = true;
            this.btnProAdd.Click += new System.EventHandler(this.btnProAdd_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOutput.Location = new System.Drawing.Point(13, 234);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(205, 94);
            this.btnOutput.TabIndex = 12;
            this.btnOutput.Text = "현 발주 신청 조회";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnProDel
            // 
            this.btnProDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProDel.Location = new System.Drawing.Point(13, 134);
            this.btnProDel.Name = "btnProDel";
            this.btnProDel.Size = new System.Drawing.Size(205, 94);
            this.btnProDel.TabIndex = 2;
            this.btnProDel.Text = "목록에서 상품 제거";
            this.btnProDel.UseVisualStyleBackColor = true;
            this.btnProDel.Click += new System.EventHandler(this.btnProDel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(642, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 26);
            this.label5.TabIndex = 54;
            this.label5.Text = "주문 수량 :";
            // 
            // txtordernum
            // 
            this.txtordernum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtordernum.Location = new System.Drawing.Point(745, 425);
            this.txtordernum.Name = "txtordernum";
            this.txtordernum.Size = new System.Drawing.Size(106, 21);
            this.txtordernum.TabIndex = 56;
            this.txtordernum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtordernum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtordernum_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(664, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 39);
            this.label8.TabIndex = 60;
            this.label8.Text = "현재 시간 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(817, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 33);
            this.label7.TabIndex = 59;
            // 
            // FormProductOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1134, 773);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtordernum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_Order);
            this.Controls.Add(this.dgv_Supplier);
            this.Controls.Add(this.label1);
            this.Name = "FormProductOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProductOrder";
            this.Load += new System.EventHandler(this.FormProductOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Supplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Supplier;
        private System.Windows.Forms.DataGridView dgv_Order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProAdd;
        private System.Windows.Forms.Button btnProDel;
        private System.Windows.Forms.Button btnProductOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtordernum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOutput;
    }
}