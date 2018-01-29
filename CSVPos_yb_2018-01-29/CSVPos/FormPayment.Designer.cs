namespace CSVPos
{
    partial class FormPayment
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblempName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblempWorkTime = new System.Windows.Forms.Label();
            this.lblempNum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvStaffWork = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empPhoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horlyWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provisionDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStaffWorkTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnPayInitialization = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffWork)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(945, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "시간 출력 부분 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(471, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 69);
            this.label1.TabIndex = 6;
            this.label1.Text = "급여 관리 ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblempName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblempWorkTime);
            this.groupBox2.Controls.Add(this.lblempNum);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblTotalPay);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(14, 106);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1053, 269);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "급여 현재 상황 ";
            // 
            // lblempName
            // 
            this.lblempName.AutoSize = true;
            this.lblempName.Location = new System.Drawing.Point(722, 116);
            this.lblempName.Name = "lblempName";
            this.lblempName.Size = new System.Drawing.Size(65, 36);
            this.lblempName.TabIndex = 49;
            this.lblempName.Text = "이름";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(627, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 36);
            this.label13.TabIndex = 48;
            this.label13.Text = "이름 :";
            // 
            // lblempWorkTime
            // 
            this.lblempWorkTime.AutoSize = true;
            this.lblempWorkTime.Location = new System.Drawing.Point(714, 164);
            this.lblempWorkTime.Name = "lblempWorkTime";
            this.lblempWorkTime.Size = new System.Drawing.Size(115, 36);
            this.lblempWorkTime.TabIndex = 47;
            this.lblempWorkTime.Text = "근무시간";
            // 
            // lblempNum
            // 
            this.lblempNum.AutoSize = true;
            this.lblempNum.Location = new System.Drawing.Point(722, 69);
            this.lblempNum.Name = "lblempNum";
            this.lblempNum.Size = new System.Drawing.Size(74, 36);
            this.lblempNum.TabIndex = 46;
            this.lblempNum.Text = "사번 ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(579, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 36);
            this.label11.TabIndex = 45;
            this.label11.Text = "근무시간 : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(627, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 36);
            this.label10.TabIndex = 44;
            this.label10.Text = "사번 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(341, 36);
            this.label6.TabIndex = 43;
            this.label6.Text = "이번 달 점장(정직원) 월급 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 36);
            this.label5.TabIndex = 42;
            this.label5.Text = "\\ 2,680,000";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Location = new System.Drawing.Point(282, 222);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(562, 36);
            this.lblTotalPay.TabIndex = 40;
            this.lblTotalPay.Text = "DB에서 급여 부분 꺼내와서 다 더하시면 됨니다";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 36);
            this.label4.TabIndex = 39;
            this.label4.Text = "매출 차감 예정 금액 : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 36);
            this.label9.TabIndex = 38;
            this.label9.Text = "\\ 7,530 ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(319, 36);
            this.label8.TabIndex = 37;
            this.label8.Text = "이번 달 아르바이트 시급 : ";
            // 
            // dgvStaffWork
            // 
            this.dgvStaffWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaffWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.empNum,
            this.empName,
            this.employeeForm,
            this.empPhoneNum,
            this.workTime,
            this.horlyWage,
            this.monthPay,
            this.provisionDay});
            this.dgvStaffWork.Location = new System.Drawing.Point(0, 382);
            this.dgvStaffWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvStaffWork.Name = "dgvStaffWork";
            this.dgvStaffWork.RowHeadersWidth = 20;
            this.dgvStaffWork.RowTemplate.Height = 23;
            this.dgvStaffWork.Size = new System.Drawing.Size(1066, 446);
            this.dgvStaffWork.TabIndex = 20;
            this.dgvStaffWork.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffWork_CellClick);
            // 
            // No
            // 
            this.No.FillWeight = 50F;
            this.No.Frozen = true;
            this.No.HeaderText = "NO";
            this.No.Name = "No";
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.No.Width = 55;
            // 
            // empNum
            // 
            this.empNum.HeaderText = "사번";
            this.empNum.Name = "empNum";
            // 
            // empName
            // 
            this.empName.HeaderText = "이름";
            this.empName.Name = "empName";
            // 
            // employeeForm
            // 
            this.employeeForm.HeaderText = "고용형태";
            this.employeeForm.Name = "employeeForm";
            this.employeeForm.Width = 115;
            // 
            // empPhoneNum
            // 
            this.empPhoneNum.HeaderText = "연락처";
            this.empPhoneNum.Name = "empPhoneNum";
            // 
            // workTime
            // 
            this.workTime.HeaderText = "근무시간";
            this.workTime.Name = "workTime";
            this.workTime.Width = 115;
            // 
            // horlyWage
            // 
            this.horlyWage.HeaderText = "시급";
            this.horlyWage.Name = "horlyWage";
            // 
            // monthPay
            // 
            this.monthPay.HeaderText = "급여";
            this.monthPay.Name = "monthPay";
            // 
            // provisionDay
            // 
            this.provisionDay.HeaderText = "급여지급일";
            this.provisionDay.Name = "provisionDay";
            this.provisionDay.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStaffWorkTable);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnEmployee);
            this.groupBox1.Controls.Add(this.btnPayInitialization);
            this.groupBox1.Controls.Add(this.btnPayment);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(1073, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(266, 734);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btnStaffWorkTable
            // 
            this.btnStaffWorkTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStaffWorkTable.Location = new System.Drawing.Point(18, 58);
            this.btnStaffWorkTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStaffWorkTable.Name = "btnStaffWorkTable";
            this.btnStaffWorkTable.Size = new System.Drawing.Size(234, 118);
            this.btnStaffWorkTable.TabIndex = 5;
            this.btnStaffWorkTable.Text = "전체직원 근무표";
            this.btnStaffWorkTable.UseVisualStyleBackColor = true;
            this.btnStaffWorkTable.Click += new System.EventHandler(this.btnStaffWorkTable_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(18, 182);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 118);
            this.button1.TabIndex = 4;
            this.button1.Text = "현재 직원 \r\n근무현황 조회\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEmployee.Location = new System.Drawing.Point(18, 308);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(234, 118);
            this.btnEmployee.TabIndex = 1;
            this.btnEmployee.Text = "급여 입력 ";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click_1);
            // 
            // btnPayInitialization
            // 
            this.btnPayInitialization.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPayInitialization.Location = new System.Drawing.Point(18, 550);
            this.btnPayInitialization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPayInitialization.Name = "btnPayInitialization";
            this.btnPayInitialization.Size = new System.Drawing.Size(234, 118);
            this.btnPayInitialization.TabIndex = 3;
            this.btnPayInitialization.Text = "월별 급여 초기화";
            this.btnPayInitialization.UseVisualStyleBackColor = true;
            this.btnPayInitialization.Click += new System.EventHandler(this.btnPayInitialization_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPayment.Location = new System.Drawing.Point(18, 429);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(234, 118);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "급여 수정";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(1203, 1028);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 46);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ver. 0.1";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CSVPos.Properties.Resources.poweroff;
            this.pictureBox4.Location = new System.Drawing.Point(1210, 891);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 132);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(777, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 42);
            this.label3.TabIndex = 21;
            this.label3.Text = "현재 시간 : ";
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1353, 1041);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvStaffWork);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPayment";
            this.Load += new System.EventHandler(this.FormPayment_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffWork)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnPayInitialization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStaffWorkTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn empPhoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn horlyWage;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn provisionDay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label lblempWorkTime;
        internal System.Windows.Forms.Label lblempNum;
        internal System.Windows.Forms.Label lblempName;
        internal System.Windows.Forms.DataGridView dgvStaffWork;
        internal System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}