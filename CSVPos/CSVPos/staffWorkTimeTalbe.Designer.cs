namespace CSVPos
{
    partial class staffWorkTimeTalbe
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
            this.dgvWorkTable = new System.Windows.Forms.DataGridView();
            this.empNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRreleaseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empWorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtViewEmpNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewEmpNum = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkTable
            // 
            this.dgvWorkTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empNum,
            this.empName,
            this.employform,
            this.LRtime,
            this.LRreleaseTime,
            this.empWorkTime});
            this.dgvWorkTable.EnableHeadersVisualStyles = false;
            this.dgvWorkTable.Location = new System.Drawing.Point(1, 219);
            this.dgvWorkTable.Name = "dgvWorkTable";
            this.dgvWorkTable.RowHeadersWidth = 10;
            this.dgvWorkTable.RowTemplate.Height = 23;
            this.dgvWorkTable.Size = new System.Drawing.Size(773, 374);
            this.dgvWorkTable.TabIndex = 0;
            // 
            // empNum
            // 
            this.empNum.HeaderText = "사번";
            this.empNum.Name = "empNum";
            this.empNum.Width = 140;
            // 
            // empName
            // 
            this.empName.HeaderText = "이름";
            this.empName.Name = "empName";
            // 
            // employform
            // 
            this.employform.HeaderText = "고용형태";
            this.employform.Name = "employform";
            // 
            // LRtime
            // 
            this.LRtime.HeaderText = "출근시간";
            this.LRtime.Name = "LRtime";
            this.LRtime.Width = 140;
            // 
            // LRreleaseTime
            // 
            this.LRreleaseTime.HeaderText = "퇴근시간";
            this.LRreleaseTime.Name = "LRreleaseTime";
            this.LRreleaseTime.Width = 140;
            // 
            // empWorkTime
            // 
            this.empWorkTime.HeaderText = "근무시간";
            this.empWorkTime.Name = "empWorkTime";
            this.empWorkTime.Width = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "전체직원근무현황";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(624, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 37);
            this.label5.TabIndex = 23;
            this.label5.Text = "Ver. 0.1";
            // 
            // txtViewEmpNum
            // 
            this.txtViewEmpNum.Location = new System.Drawing.Point(12, 192);
            this.txtViewEmpNum.Name = "txtViewEmpNum";
            this.txtViewEmpNum.Size = new System.Drawing.Size(133, 21);
            this.txtViewEmpNum.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(491, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "특정 사원 한명의 근무현황 보기를 원하시면, 사번을 검색하세요.";
            // 
            // btnViewEmpNum
            // 
            this.btnViewEmpNum.Location = new System.Drawing.Point(151, 190);
            this.btnViewEmpNum.Name = "btnViewEmpNum";
            this.btnViewEmpNum.Size = new System.Drawing.Size(75, 23);
            this.btnViewEmpNum.TabIndex = 28;
            this.btnViewEmpNum.Text = "검색";
            this.btnViewEmpNum.UseVisualStyleBackColor = true;
            this.btnViewEmpNum.Click += new System.EventHandler(this.btnViewEmpNum_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSVPos.Properties.Resources.poweroff;
            this.pictureBox1.Location = new System.Drawing.Point(643, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // staffWorkTimeTalbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(777, 594);
            this.Controls.Add(this.btnViewEmpNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtViewEmpNum);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvWorkTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "staffWorkTimeTalbe";
            this.Text = "staffWorkTimeTalbe";
            this.Load += new System.EventHandler(this.staffWorkTimeTalbe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employform;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRreleaseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn empWorkTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewEmpNum;
        internal System.Windows.Forms.TextBox txtViewEmpNum;
        internal System.Windows.Forms.DataGridView dgvWorkTable;
    }
}