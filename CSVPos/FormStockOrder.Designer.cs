namespace CSVPos
{
    partial class FormStockOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnAddComplete = new System.Windows.Forms.Button();
            this.btnStockAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvOrderState = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvStockState = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStockEa = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockState)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(420, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "수주 관리";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddCancel);
            this.groupBox3.Controls.Add(this.btnAddComplete);
            this.groupBox3.Controls.Add(this.btnStockAdd);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(892, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 360);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "선택가능 기능";
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(107)))), ((int)(((byte)(164)))));
            this.btnAddCancel.ForeColor = System.Drawing.Color.White;
            this.btnAddCancel.Location = new System.Drawing.Point(13, 134);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(205, 94);
            this.btnAddCancel.TabIndex = 3;
            this.btnAddCancel.Text = "수주 목록 삭제";
            this.btnAddCancel.UseVisualStyleBackColor = false;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // btnAddComplete
            // 
            this.btnAddComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(107)))), ((int)(((byte)(164)))));
            this.btnAddComplete.ForeColor = System.Drawing.Color.White;
            this.btnAddComplete.Location = new System.Drawing.Point(13, 234);
            this.btnAddComplete.Name = "btnAddComplete";
            this.btnAddComplete.Size = new System.Drawing.Size(205, 94);
            this.btnAddComplete.TabIndex = 2;
            this.btnAddComplete.Text = "재고 등록";
            this.btnAddComplete.UseVisualStyleBackColor = false;
            this.btnAddComplete.Click += new System.EventHandler(this.btnAddComplete_Click);
            // 
            // btnStockAdd
            // 
            this.btnStockAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(107)))), ((int)(((byte)(164)))));
            this.btnStockAdd.ForeColor = System.Drawing.Color.White;
            this.btnStockAdd.Location = new System.Drawing.Point(13, 34);
            this.btnStockAdd.Name = "btnStockAdd";
            this.btnStockAdd.Size = new System.Drawing.Size(205, 94);
            this.btnStockAdd.TabIndex = 1;
            this.btnStockAdd.Text = "수주 목록 추가";
            this.btnStockAdd.UseVisualStyleBackColor = false;
            this.btnStockAdd.Click += new System.EventHandler(this.btnStockAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(821, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 33);
            this.label2.TabIndex = 18;
            this.label2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(668, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 39);
            this.label3.TabIndex = 19;
            this.label3.Text = "현재 시간 : ";
            // 
            // dgvOrderState
            // 
            this.dgvOrderState.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderState.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderState.Location = new System.Drawing.Point(18, 155);
            this.dgvOrderState.Name = "dgvOrderState";
            this.dgvOrderState.ReadOnly = true;
            this.dgvOrderState.RowTemplate.Height = 23;
            this.dgvOrderState.Size = new System.Drawing.Size(849, 320);
            this.dgvOrderState.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 37);
            this.label4.TabIndex = 48;
            this.label4.Text = "발주 목록";
            // 
            // dgvStockState
            // 
            this.dgvStockState.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStockState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockState.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStockState.Location = new System.Drawing.Point(19, 533);
            this.dgvStockState.Name = "dgvStockState";
            this.dgvStockState.RowTemplate.Height = 23;
            this.dgvStockState.Size = new System.Drawing.Size(849, 320);
            this.dgvStockState.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 37);
            this.label5.TabIndex = 50;
            this.label5.Text = "수주 목록 확인";
            // 
            // cboCate
            // 
            this.cboCate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCate.FormattingEnabled = true;
            this.cboCate.Location = new System.Drawing.Point(535, 493);
            this.cboCate.Name = "cboCate";
            this.cboCate.Size = new System.Drawing.Size(112, 20);
            this.cboCate.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(439, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 53;
            this.label6.Text = "카테고리 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(670, 490);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 25);
            this.label7.TabIndex = 54;
            this.label7.Text = "수주 수량 :";
            // 
            // txtStockEa
            // 
            this.txtStockEa.Location = new System.Drawing.Point(768, 494);
            this.txtStockEa.Name = "txtStockEa";
            this.txtStockEa.Size = new System.Drawing.Size(100, 21);
            this.txtStockEa.TabIndex = 55;
            this.txtStockEa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockEa_KeyPress);
            // 
            // FormStockOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1137, 865);
            this.Controls.Add(this.txtStockEa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvStockState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOrderState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormStockOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStockOrder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStockOrder_FormClosed);
            this.Load += new System.EventHandler(this.FormStockOrder_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStockAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Button btnAddComplete;
        private System.Windows.Forms.DataGridView dgvOrderState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvStockState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStockEa;
    }
}