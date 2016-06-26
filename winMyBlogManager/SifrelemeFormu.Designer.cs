namespace winMyBlogManager
{
    partial class SifrelemeFormu
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
            this.btnCoz = new System.Windows.Forms.Button();
            this.btnSifrele = new System.Windows.Forms.Button();
            this.txtSifreli = new System.Windows.Forms.TextBox();
            this.txtSifresiz = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCoz
            // 
            this.btnCoz.Location = new System.Drawing.Point(34, 155);
            this.btnCoz.Name = "btnCoz";
            this.btnCoz.Size = new System.Drawing.Size(75, 23);
            this.btnCoz.TabIndex = 7;
            this.btnCoz.Text = "Çöz";
            this.btnCoz.UseVisualStyleBackColor = true;
            this.btnCoz.Click += new System.EventHandler(this.btnCoz_Click);
            // 
            // btnSifrele
            // 
            this.btnSifrele.Location = new System.Drawing.Point(115, 155);
            this.btnSifrele.Name = "btnSifrele";
            this.btnSifrele.Size = new System.Drawing.Size(75, 23);
            this.btnSifrele.TabIndex = 8;
            this.btnSifrele.Text = "Şifrele";
            this.btnSifrele.UseVisualStyleBackColor = true;
            this.btnSifrele.Click += new System.EventHandler(this.btnSifrele_Click);
            // 
            // txtSifreli
            // 
            this.txtSifreli.Location = new System.Drawing.Point(12, 82);
            this.txtSifreli.Multiline = true;
            this.txtSifreli.Name = "txtSifreli";
            this.txtSifreli.Size = new System.Drawing.Size(178, 67);
            this.txtSifreli.TabIndex = 5;
            // 
            // txtSifresiz
            // 
            this.txtSifresiz.Location = new System.Drawing.Point(12, 12);
            this.txtSifresiz.Multiline = true;
            this.txtSifresiz.Name = "txtSifresiz";
            this.txtSifresiz.Size = new System.Drawing.Size(178, 64);
            this.txtSifresiz.TabIndex = 6;
            // 
            // SifrelemeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 191);
            this.Controls.Add(this.btnCoz);
            this.Controls.Add(this.btnSifrele);
            this.Controls.Add(this.txtSifreli);
            this.Controls.Add(this.txtSifresiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SifrelemeFormu";
            this.Text = "SifrelemeFormu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCoz;
        private System.Windows.Forms.Button btnSifrele;
        private System.Windows.Forms.TextBox txtSifreli;
        private System.Windows.Forms.TextBox txtSifresiz;
    }
}