namespace Login_IT4A
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnUserEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(245, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "My super application";
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(783, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(59, 25);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "label2";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // btnUserEditor
            // 
            this.btnUserEditor.Location = new System.Drawing.Point(12, 9);
            this.btnUserEditor.Name = "btnUserEditor";
            this.btnUserEditor.Size = new System.Drawing.Size(179, 34);
            this.btnUserEditor.TabIndex = 2;
            this.btnUserEditor.Text = "Správa uživatelů";
            this.btnUserEditor.UseVisualStyleBackColor = true;
            this.btnUserEditor.Click += new System.EventHandler(this.btnUserEditor_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 485);
            this.Controls.Add(this.btnUserEditor);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        internal Label lblLogin;
        private Button btnUserEditor;
    }
}