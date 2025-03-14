using System.Windows.Forms;

namespace Dictionary
{
    partial class Form1
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnMyWord = new System.Windows.Forms.Button();
            this.btnGame = new System.Windows.Forms.Button();
            this.lbWord = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lbIPA = new System.Windows.Forms.Label();
            this.lbMeaning = new System.Windows.Forms.Label();
            this.lbEX1 = new System.Windows.Forms.Label();
            this.lbEX2 = new System.Windows.Forms.Label();
            this.lbEX3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(159, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 267);
            this.label1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(36, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 51);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(36, 413);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 51);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnFix
            // 
            this.btnFix.BackColor = System.Drawing.Color.LightGray;
            this.btnFix.FlatAppearance.BorderSize = 0;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFix.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.Location = new System.Drawing.Point(734, 250);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(97, 51);
            this.btnFix.TabIndex = 1;
            this.btnFix.Text = "FixWord";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnMyWord
            // 
            this.btnMyWord.BackColor = System.Drawing.Color.LightGray;
            this.btnMyWord.FlatAppearance.BorderSize = 0;
            this.btnMyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyWord.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyWord.Location = new System.Drawing.Point(734, 332);
            this.btnMyWord.Name = "btnMyWord";
            this.btnMyWord.Size = new System.Drawing.Size(97, 51);
            this.btnMyWord.TabIndex = 2;
            this.btnMyWord.Text = "MyWord";
            this.btnMyWord.UseVisualStyleBackColor = false;
            // 
            // btnGame
            // 
            this.btnGame.BackColor = System.Drawing.Color.LightGray;
            this.btnGame.FlatAppearance.BorderSize = 0;
            this.btnGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGame.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGame.Location = new System.Drawing.Point(734, 413);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(97, 51);
            this.btnGame.TabIndex = 3;
            this.btnGame.Text = "Games";
            this.btnGame.UseVisualStyleBackColor = false;
            // 
            // lbWord
            // 
            this.lbWord.Font = new System.Drawing.Font("MS Reference Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWord.Location = new System.Drawing.Point(145, 95);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new System.Drawing.Size(388, 92);
            this.lbWord.TabIndex = 4;
            this.lbWord.Text = "Hello";
            this.lbWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(162, 25);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(497, 37);
            this.txtSearch.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.LightGray;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(644, 102);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnCopy.Size = new System.Drawing.Size(37, 39);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(628, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.LightGray;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(36, 250);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(97, 51);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lbIPA
            // 
            this.lbIPA.AutoSize = true;
            this.lbIPA.BackColor = System.Drawing.Color.LightGray;
            this.lbIPA.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIPA.Location = new System.Drawing.Point(185, 234);
            this.lbIPA.Name = "lbIPA";
            this.lbIPA.Size = new System.Drawing.Size(72, 20);
            this.lbIPA.TabIndex = 4;
            this.lbIPA.Text = "/heˈləʊ/";
            // 
            // lbMeaning
            // 
            this.lbMeaning.BackColor = System.Drawing.Color.LightGray;
            this.lbMeaning.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMeaning.Location = new System.Drawing.Point(185, 262);
            this.lbMeaning.Name = "lbMeaning";
            this.lbMeaning.Size = new System.Drawing.Size(507, 54);
            this.lbMeaning.TabIndex = 4;
            this.lbMeaning.Text = "used when meeting or greeting someone";
            // 
            // lbEX1
            // 
            this.lbEX1.BackColor = System.Drawing.Color.LightGray;
            this.lbEX1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEX1.Location = new System.Drawing.Point(190, 316);
            this.lbEX1.Name = "lbEX1";
            this.lbEX1.Size = new System.Drawing.Size(502, 52);
            this.lbEX1.TabIndex = 4;
            this.lbEX1.Text = "Hello, Paul. I haven\'t seen you for ages.\r\n";
            // 
            // lbEX2
            // 
            this.lbEX2.BackColor = System.Drawing.Color.LightGray;
            this.lbEX2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEX2.Location = new System.Drawing.Point(190, 368);
            this.lbEX2.Name = "lbEX2";
            this.lbEX2.Size = new System.Drawing.Size(502, 52);
            this.lbEX2.TabIndex = 4;
            this.lbEX2.Text = "I know her vaguely - we\'ve exchanged hellos a few times.";
            // 
            // lbEX3
            // 
            this.lbEX3.BackColor = System.Drawing.Color.LightGray;
            this.lbEX3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEX3.Location = new System.Drawing.Point(190, 420);
            this.lbEX3.Name = "lbEX3";
            this.lbEX3.Size = new System.Drawing.Size(502, 52);
            this.lbEX3.TabIndex = 4;
            this.lbEX3.Text = "say hello I just thought I\'d call by and say hello.";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Dictionary.Properties.Resources.foot;
            this.pictureBox3.Location = new System.Drawing.Point(-9, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(162, 181);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dictionary.Properties.Resources.search;
            this.pictureBox2.Location = new System.Drawing.Point(665, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dictionary.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(717, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 518);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbMeaning);
            this.Controls.Add(this.lbEX3);
            this.Controls.Add(this.lbEX2);
            this.Controls.Add(this.lbEX1);
            this.Controls.Add(this.lbIPA);
            this.Controls.Add(this.lbWord);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnMyWord);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CatDictionary";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnMyWord;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Label lbWord;
        private System.Windows.Forms.TextBox txtSearch;
        private Button btnCopy;
        private Button btnSave;
        private Button btnImport;
        private Label lbIPA;
        private Label lbMeaning;
        private Label lbEX1;
        private Label lbEX2;
        private Label lbEX3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}

