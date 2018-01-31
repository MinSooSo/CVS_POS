namespace CSVPos
{
    partial class ViewEmpInfo
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
            this.lblempName = new System.Windows.Forms.Label();
            this.lblempNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvOnePersonWorkTable = new System.Windows.Forms.DataGridView();
            this.empNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRreleaseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empWorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotalWorkTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnePersonWorkTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblempName
            // 
            this.lblempName.AutoSize = true;
            this.lblempName.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblempName.Location = new System.Drawing.Point(12, 87);
            this.lblempName.Name = "lblempName";
            this.lblempName.Size = new System.Drawing.Size(102, 55);
            this.lblempName.TabIndex = 3;
            this.lblempName.Text = "이름";
            // 
            // lblempNum
            // 
            this.lblempNum.AutoSize = true;
            this.lblempNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblempNum.Location = new System.Drawing.Point(145, 8);
            this.lblempNum.Name = "lblempNum";
            this.lblempNum.Size = new System.Drawing.Size(116, 55);
            this.lblempNum.TabIndex = 4;
            this.lblempNum.Text = "사번 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(145, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 55);
            this.label3.TabIndex = 5;
            this.label3.Text = "님의 근무 현황입니다.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSVPos.Properties.Resources.poweroff;
            this.pictureBox1.Location = new System.Drawing.Point(643, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // dgvOnePersonWorkTable
            // 
            this.dgvOnePersonWorkTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnePersonWorkTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empNum,
            this.empName,
            this.employform,
            this.LRtime,
            this.LRreleaseTime,
            this.empWorkTime});
            this.dgvOnePersonWorkTable.EnableHeadersVisualStyles = false;
            this.dgvOnePersonWorkTable.Location = new System.Drawing.Point(1, 218);
            this.dgvOnePersonWorkTable.Name = "dgvOnePersonWorkTable";
            this.dgvOnePersonWorkTable.RowHeadersWidth = 10;
            this.dgvOnePersonWorkTable.RowTemplate.Height = 23;
            this.dgvOnePersonWorkTable.Size = new System.Drawing.Size(773, 374);
            this.dgvOnePersonWorkTable.TabIndex = 26;
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
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 55);
            this.label1.TabIndex = 27;
            this.label1.Text = "사번 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 55);
            this.label2.TabIndex = 28;
            this.label2.Text = "총 근무시간 : ";
            // 
            // lbltotalWorkTime
            // 
            this.lbltotalWorkTime.AutoSize = true;
            this.lbltotalWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalWorkTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltotalWorkTime.Location = new System.Drawing.Point(280, 160);
            this.lbltotalWorkTime.Name = "lbltotalWorkTime";
            this.lbltotalWorkTime.Size = new System.Drawing.Size(180, 55);
            this.lbltotalWorkTime.TabIndex = 29;
            this.lbltotalWorkTime.Text = "근무시간";
            // 
            // ViewEmpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(777, 594);
            this.Controls.Add(this.lbltotalWorkTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOnePersonWorkTable);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblempNum);
            this.Controls.Add(this.lblempName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ViewEmpInfo";
            this.Text = "ViewEmpInfo";
            this.Load += new System.EventHandler(this.ViewEmpInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnePersonWorkTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employform;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRreleaseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn empWorkTime;
        internal System.Windows.Forms.DataGridView dgvOnePersonWorkTable;
        internal System.Windows.Forms.Label lblempName;
        internal System.Windows.Forms.Label lblempNum;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lbltotalWorkTime;
    }
}