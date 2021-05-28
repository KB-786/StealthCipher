
namespace StealthCipher
{
    partial class decrypt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(decrypt));
            this.btn_finish = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_addFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radiobtn_no = new System.Windows.Forms.RadioButton();
            this.radiobtn_yes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_finish
            // 
            this.btn_finish.Location = new System.Drawing.Point(12, 394);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(150, 45);
            this.btn_finish.TabIndex = 2;
            this.btn_finish.Text = "Decrypt";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(201, 406);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(67, 20);
            this.Message.TabIndex = 11;
            this.Message.Text = "Message";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Message.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_addFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 264);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Decryption";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(689, 27);
            this.textBox1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "File path:";
            // 
            // btn_addFile
            // 
            this.btn_addFile.Location = new System.Drawing.Point(278, 26);
            this.btn_addFile.Name = "btn_addFile";
            this.btn_addFile.Size = new System.Drawing.Size(203, 45);
            this.btn_addFile.TabIndex = 13;
            this.btn_addFile.Text = "Select file to decrypt";
            this.btn_addFile.UseVisualStyleBackColor = true;
            this.btn_addFile.Click += new System.EventHandler(this.btn_addFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radiobtn_no);
            this.groupBox2.Controls.Add(this.radiobtn_yes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 106);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Q:";
            // 
            // radiobtn_no
            // 
            this.radiobtn_no.AutoSize = true;
            this.radiobtn_no.Location = new System.Drawing.Point(6, 76);
            this.radiobtn_no.Name = "radiobtn_no";
            this.radiobtn_no.Size = new System.Drawing.Size(50, 24);
            this.radiobtn_no.TabIndex = 28;
            this.radiobtn_no.TabStop = true;
            this.radiobtn_no.Text = "No";
            this.radiobtn_no.UseVisualStyleBackColor = true;
            this.radiobtn_no.CheckedChanged += new System.EventHandler(this.radiobtn_no_CheckedChanged);
            // 
            // radiobtn_yes
            // 
            this.radiobtn_yes.AutoSize = true;
            this.radiobtn_yes.Location = new System.Drawing.Point(6, 46);
            this.radiobtn_yes.Name = "radiobtn_yes";
            this.radiobtn_yes.Size = new System.Drawing.Size(51, 24);
            this.radiobtn_yes.TabIndex = 27;
            this.radiobtn_yes.TabStop = true;
            this.radiobtn_yes.Text = "Yes";
            this.radiobtn_yes.UseVisualStyleBackColor = true;
            this.radiobtn_yes.CheckedChanged += new System.EventHandler(this.radiobtn_yes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Have you applied Steganography ?";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-179, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 24);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "No";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(-179, -9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 24);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Yes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-179, -32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Have you applied Steganography ?";
            // 
            // decrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.btn_finish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "decrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decrypt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radiobtn_no;
        private System.Windows.Forms.RadioButton radiobtn_yes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
    }
}