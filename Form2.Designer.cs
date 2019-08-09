namespace WindowsForms_practise
{
    partial class Form2
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUpperCase = new System.Windows.Forms.RadioButton();
            this.rbLowerCase = new System.Windows.Forms.RadioButton();
            this.rbProperCase = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(107, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProperCase);
            this.groupBox1.Controls.Add(this.rbLowerCase);
            this.groupBox1.Controls.Add(this.rbUpperCase);
            this.groupBox1.Location = new System.Drawing.Point(107, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Case";
            // 
            // rbUpperCase
            // 
            this.rbUpperCase.AutoSize = true;
            this.rbUpperCase.Location = new System.Drawing.Point(52, 46);
            this.rbUpperCase.Name = "rbUpperCase";
            this.rbUpperCase.Size = new System.Drawing.Size(119, 24);
            this.rbUpperCase.TabIndex = 0;
            this.rbUpperCase.TabStop = true;
            this.rbUpperCase.Text = "Upper Case";
            this.rbUpperCase.UseVisualStyleBackColor = true;
            // 
            // rbLowerCase
            // 
            this.rbLowerCase.AutoSize = true;
            this.rbLowerCase.Location = new System.Drawing.Point(52, 89);
            this.rbLowerCase.Name = "rbLowerCase";
            this.rbLowerCase.Size = new System.Drawing.Size(118, 24);
            this.rbLowerCase.TabIndex = 1;
            this.rbLowerCase.TabStop = true;
            this.rbLowerCase.Text = "Lower Case";
            this.rbLowerCase.UseVisualStyleBackColor = true;
            // 
            // rbProperCase
            // 
            this.rbProperCase.AutoSize = true;
            this.rbProperCase.Location = new System.Drawing.Point(52, 131);
            this.rbProperCase.Name = "rbProperCase";
            this.rbProperCase.Size = new System.Drawing.Size(122, 24);
            this.rbProperCase.TabIndex = 2;
            this.rbProperCase.TabStop = true;
            this.rbProperCase.Text = "Proper Case";
            this.rbProperCase.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProperCase;
        private System.Windows.Forms.RadioButton rbLowerCase;
        private System.Windows.Forms.RadioButton rbUpperCase;
    }
}