namespace CSVPos
{
    partial class StaffM
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
            this.dgvEmpInfo = new System.Windows.Forms.DataGridView();
            this.NUm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_residentNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_phoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_hiredate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_firedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_employeeForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SM_employeer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnhireStaff = new System.Windows.Forms.Button();
            this.btnFiredate = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbluserName = new System.Windows.Forms.Label();
            this.labelLoginTime = new System.Windows.Forms.Label();
            this.lbluserEmpNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpInfo
            // 
            this.dgvEmpInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmpInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUm,
            this.empNum,
            this.SM_name,
            this.SM_age,
            this.SM_gender,
            this.SM_residentNum,
            this.SM_phoneNum,
            this.SM_address,
            this.SM_hiredate,
            this.SM_firedate,
            this.SM_employeeForm,
            this.SM_employeer});
            this.dgvEmpInfo.EnableHeadersVisualStyles = false;
            this.dgvEmpInfo.Location = new System.Drawing.Point(2, 324);
            this.dgvEmpInfo.Name = "dgvEmpInfo";
            this.dgvEmpInfo.RowHeadersWidth = 5;
            this.dgvEmpInfo.RowTemplate.Height = 23;
            this.dgvEmpInfo.Size = new System.Drawing.Size(1206, 497);
            this.dgvEmpInfo.TabIndex = 0;
            // 
            // NUm
            // 
            this.NUm.HeaderText = "NO";
            this.NUm.Name = "NUm";
            this.NUm.Width = 35;
            // 
            // empNum
            // 
            this.empNum.HeaderText = "사번";
            this.empNum.Name = "empNum";
            this.empNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SM_name
            // 
            this.SM_name.HeaderText = "이름";
            this.SM_name.Name = "SM_name";
            // 
            // SM_age
            // 
            this.SM_age.HeaderText = "나이";
            this.SM_age.Name = "SM_age";
            // 
            // SM_gender
            // 
            this.SM_gender.HeaderText = "성별";
            this.SM_gender.Name = "SM_gender";
            // 
            // SM_residentNum
            // 
            this.SM_residentNum.HeaderText = "주민등록번호";
            this.SM_residentNum.Name = "SM_residentNum";
            this.SM_residentNum.Width = 105;
            // 
            // SM_phoneNum
            // 
            this.SM_phoneNum.HeaderText = "연락처";
            this.SM_phoneNum.Name = "SM_phoneNum";
            // 
            // SM_address
            // 
            this.SM_address.HeaderText = "주소";
            this.SM_address.Name = "SM_address";
            // 
            // SM_hiredate
            // 
            this.SM_hiredate.HeaderText = "입사일";
            this.SM_hiredate.Name = "SM_hiredate";
            // 
            // SM_firedate
            // 
            this.SM_firedate.HeaderText = "퇴사일";
            this.SM_firedate.Name = "SM_firedate";
            // 
            // SM_employeeForm
            // 
            this.SM_employeeForm.HeaderText = "고용형태";
            this.SM_employeeForm.Name = "SM_employeeForm";
            // 
            // SM_employeer
            // 
            this.SM_employeer.HeaderText = "고용인";
            this.SM_employeer.Name = "SM_employeer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(445, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "직원 관리";
            // 
            // btnhireStaff
            // 
            this.btnhireStaff.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnhireStaff.Location = new System.Drawing.Point(6, 38);
            this.btnhireStaff.Name = "btnhireStaff";
            this.btnhireStaff.Size = new System.Drawing.Size(221, 112);
            this.btnhireStaff.TabIndex = 2;
            this.btnhireStaff.Text = "직원 고용";
            this.btnhireStaff.UseVisualStyleBackColor = true;
            this.btnhireStaff.Click += new System.EventHandler(this.btnhireStaff_Click);
            // 
            // btnFiredate
            // 
            this.btnFiredate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFiredate.Location = new System.Drawing.Point(233, 38);
            this.btnFiredate.Name = "btnFiredate";
            this.btnFiredate.Size = new System.Drawing.Size(221, 112);
            this.btnFiredate.TabIndex = 3;
            this.btnFiredate.Text = "직원 해고";
            this.btnFiredate.UseVisualStyleBackColor = true;
            this.btnFiredate.Click += new System.EventHandler(this.btnFiredate_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReturn.Location = new System.Drawing.Point(460, 38);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(221, 112);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "매장 관리";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnhireStaff);
            this.groupBox1.Controls.Add(this.btnFiredate);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(495, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 163);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "선택가능 기능";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(858, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 33);
            this.label2.TabIndex = 19;
            this.label2.Text = "시간 출력 부분 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(713, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 39);
            this.label3.TabIndex = 20;
            this.label3.Text = "현재 시간 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 37);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ver. 0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(12, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 33);
            this.label4.TabIndex = 23;
            this.label4.Text = "현재 사용자 이름 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(12, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 33);
            this.label6.TabIndex = 24;
            this.label6.Text = "접속 시작 시간 :";
            // 
            // lbluserName
            // 
            this.lbluserName.AutoSize = true;
            this.lbluserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbluserName.Location = new System.Drawing.Point(209, 191);
            this.lbluserName.Name = "lbluserName";
            this.lbluserName.Size = new System.Drawing.Size(243, 33);
            this.lbluserName.TabIndex = 25;
            this.lbluserName.Text = "DB에서 사용자명 뽑기";
            // 
            // labelLoginTime
            // 
            this.labelLoginTime.AutoSize = true;
            this.labelLoginTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelLoginTime.Location = new System.Drawing.Point(195, 267);
            this.labelLoginTime.Name = "labelLoginTime";
            this.labelLoginTime.Size = new System.Drawing.Size(219, 33);
            this.labelLoginTime.TabIndex = 26;
            this.labelLoginTime.Text = "접속 시간 뜨는 부분 ";
            // 
            // lbluserEmpNum
            // 
            this.lbluserEmpNum.AutoSize = true;
            this.lbluserEmpNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserEmpNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbluserEmpNum.Location = new System.Drawing.Point(209, 224);
            this.lbluserEmpNum.Name = "lbluserEmpNum";
            this.lbluserEmpNum.Size = new System.Drawing.Size(120, 33);
            this.lbluserEmpNum.TabIndex = 28;
            this.lbluserEmpNum.Text = "임시테스트";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(12, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 33);
            this.label9.TabIndex = 27;
            this.label9.Text = "현재 사용자 사번 :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSVPos.Properties.Resources.poweroff;
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // StaffM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1184, 833);
            this.Controls.Add(this.lbluserEmpNum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelLoginTime);
            this.Controls.Add(this.lbluserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEmpInfo);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StaffM";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffM";
            this.Load += new System.EventHandler(this.StaffM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnhireStaff;
        private System.Windows.Forms.Button btnFiredate;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelLoginTime;
        internal System.Windows.Forms.DataGridView dgvEmpInfo;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label lbluserName;
        internal System.Windows.Forms.Label lbluserEmpNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUm;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_residentNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_phoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_hiredate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_firedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_employeeForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn SM_employeer;
    }
}