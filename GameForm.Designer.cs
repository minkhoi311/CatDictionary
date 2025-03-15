namespace Dictionary
{
    partial class GameForm
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
            this.lbWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAns = new System.Windows.Forms.TextBox();
            this.lbIPA = new System.Windows.Forms.Label();
            this.lbMeaning = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbAnnouce = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbWord
            // 
            this.lbWord.Font = new System.Drawing.Font("MS Reference Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWord.Location = new System.Drawing.Point(107, -2);
            this.lbWord.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new System.Drawing.Size(583, 81);
            this.lbWord.TabIndex = 6;
            this.lbWord.Text = "Trò Chơi Đoán Từ";
            this.lbWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "IPA:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 51);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ý nghĩa: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nhập từ bạn đoán: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAns
            // 
            this.txtAns.Location = new System.Drawing.Point(367, 327);
            this.txtAns.Name = "txtAns";
            this.txtAns.Size = new System.Drawing.Size(362, 35);
            this.txtAns.TabIndex = 7;
            // 
            // lbIPA
            // 
            this.lbIPA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbIPA.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIPA.Location = new System.Drawing.Point(352, 100);
            this.lbIPA.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbIPA.Name = "lbIPA";
            this.lbIPA.Size = new System.Drawing.Size(362, 51);
            this.lbIPA.TabIndex = 6;
            this.lbIPA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMeaning
            // 
            this.lbMeaning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbMeaning.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMeaning.Location = new System.Drawing.Point(352, 170);
            this.lbMeaning.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbMeaning.Name = "lbMeaning";
            this.lbMeaning.Size = new System.Drawing.Size(362, 51);
            this.lbMeaning.TabIndex = 6;
            this.lbMeaning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(308, 397);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(153, 51);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbAnnouce
            // 
            this.lbAnnouce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbAnnouce.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnnouce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbAnnouce.Location = new System.Drawing.Point(187, 241);
            this.lbAnnouce.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAnnouce.Name = "lbAnnouce";
            this.lbAnnouce.Size = new System.Drawing.Size(426, 65);
            this.lbAnnouce.TabIndex = 6;
            this.lbAnnouce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(308, 397);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(153, 51);
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "Tiếp Tục";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Visible = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 494);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtAns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAnnouce);
            this.Controls.Add(this.lbMeaning);
            this.Controls.Add(this.lbIPA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbWord);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAns;
        private System.Windows.Forms.Label lbIPA;
        private System.Windows.Forms.Label lbMeaning;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbAnnouce;
        private System.Windows.Forms.Button btnContinue;
    }
}