namespace YouMuEx_convert
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_insertPath = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_confirmMp3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {"None"});
            this.comboBox1.Location = new System.Drawing.Point(88, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(404, 21);
            this.comboBox1.Text = "None";
            this.comboBox1.TabIndex = 1;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(88, 226);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(136, 42);
            this.btn_confirm.TabIndex = 1;
            this.btn_confirm.Text = "confirm[MP4]";
            this.btn_confirm.UseVisualStyleBackColor = true;
            // 
            // btn_insertPath
            // 
            this.btn_insertPath.Location = new System.Drawing.Point(344, 135);
            this.btn_insertPath.Name = "btn_insertPath";
            this.btn_insertPath.Size = new System.Drawing.Size(148, 28);
            this.btn_insertPath.TabIndex = 2;
            this.btn_insertPath.Text = "Insert Path";
            this.btn_insertPath.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 20);
            this.textBox1.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 179);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(464, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(42, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "SavePath";
            // 
            // btn_confirmMp3
            // 
            this.btn_confirmMp3.Location = new System.Drawing.Point(306, 226);
            this.btn_confirmMp3.Name = "btn_confirmMp3";
            this.btn_confirmMp3.Size = new System.Drawing.Size(136, 42);
            this.btn_confirmMp3.TabIndex = 1;
            this.btn_confirmMp3.Text = "confirm[MP3]";
            this.btn_confirmMp3.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 297);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_insertPath);
            this.Controls.Add(this.btn_confirmMp3);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "YouMuEx_convert";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_insertPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_confirmMp3;
        //private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

