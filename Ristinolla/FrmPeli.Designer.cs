namespace Ristinolla
{
    partial class FrmPeli
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
            this.components = new System.ComponentModel.Container();
            this.pnlRistikko = new System.Windows.Forms.Panel();
            this.lblPeliaikaO = new System.Windows.Forms.Label();
            this.lblPeliaikaX = new System.Windows.Forms.Label();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.lblPelaajaO = new System.Windows.Forms.Label();
            this.lblPelaajaX = new System.Windows.Forms.Label();
            this.tmrPelaajaX = new System.Windows.Forms.Timer(this.components);
            this.tmrPelaajaO = new System.Windows.Forms.Timer(this.components);
            this.tmrTietokoneMiettii = new System.Windows.Forms.Timer(this.components);
            this.pnlRistikko.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRistikko
            // 
            this.pnlRistikko.Controls.Add(this.lblPeliaikaO);
            this.pnlRistikko.Controls.Add(this.lblPeliaikaX);
            this.pnlRistikko.Controls.Add(this.btn7);
            this.pnlRistikko.Controls.Add(this.btn9);
            this.pnlRistikko.Controls.Add(this.btn8);
            this.pnlRistikko.Controls.Add(this.btn4);
            this.pnlRistikko.Controls.Add(this.btn6);
            this.pnlRistikko.Controls.Add(this.btn5);
            this.pnlRistikko.Controls.Add(this.btn1);
            this.pnlRistikko.Controls.Add(this.btn3);
            this.pnlRistikko.Controls.Add(this.btn2);
            this.pnlRistikko.Controls.Add(this.lblPelaajaO);
            this.pnlRistikko.Controls.Add(this.lblPelaajaX);
            this.pnlRistikko.Location = new System.Drawing.Point(0, 1);
            this.pnlRistikko.Name = "pnlRistikko";
            this.pnlRistikko.Size = new System.Drawing.Size(650, 520);
            this.pnlRistikko.TabIndex = 0;
            this.pnlRistikko.Paint += new System.Windows.Forms.PaintEventHandler(this.RistikkopaneeliPiirros);
            // 
            // lblPeliaikaO
            // 
            this.lblPeliaikaO.AutoSize = true;
            this.lblPeliaikaO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeliaikaO.Location = new System.Drawing.Point(214, 440);
            this.lblPeliaikaO.Name = "lblPeliaikaO";
            this.lblPeliaikaO.Size = new System.Drawing.Size(56, 24);
            this.lblPeliaikaO.TabIndex = 14;
            this.lblPeliaikaO.Text = "Aika:";
            // 
            // lblPeliaikaX
            // 
            this.lblPeliaikaX.AutoSize = true;
            this.lblPeliaikaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeliaikaX.Location = new System.Drawing.Point(214, 391);
            this.lblPeliaikaX.Name = "lblPeliaikaX";
            this.lblPeliaikaX.Size = new System.Drawing.Size(56, 24);
            this.lblPeliaikaX.TabIndex = 13;
            this.lblPeliaikaX.Text = "Aika:";
            // 
            // btn7
            // 
            this.btn7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn7.BackColor = System.Drawing.Color.White;
            this.btn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(124, 252);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(123, 108);
            this.btn7.TabIndex = 12;
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn9
            // 
            this.btn9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn9.BackColor = System.Drawing.Color.White;
            this.btn9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(378, 252);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(121, 108);
            this.btn9.TabIndex = 11;
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn8
            // 
            this.btn8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn8.BackColor = System.Drawing.Color.White;
            this.btn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(253, 252);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(119, 108);
            this.btn8.TabIndex = 10;
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.White;
            this.btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(124, 128);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(123, 118);
            this.btn4.TabIndex = 9;
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.White;
            this.btn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(378, 128);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(121, 118);
            this.btn6.TabIndex = 8;
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.White;
            this.btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(253, 128);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(119, 118);
            this.btn5.TabIndex = 7;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.White;
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(124, 21);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(123, 101);
            this.btn1.TabIndex = 6;
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.White;
            this.btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(378, 21);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(121, 101);
            this.btn3.TabIndex = 5;
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btnKlikki);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.White;
            this.btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(253, 21);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(119, 101);
            this.btn2.TabIndex = 4;
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btnKlikki);
            // 
            // lblPelaajaO
            // 
            this.lblPelaajaO.AutoSize = true;
            this.lblPelaajaO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaajaO.Location = new System.Drawing.Point(35, 440);
            this.lblPelaajaO.Name = "lblPelaajaO";
            this.lblPelaajaO.Size = new System.Drawing.Size(76, 25);
            this.lblPelaajaO.TabIndex = 1;
            this.lblPelaajaO.Text = "label2";
            // 
            // lblPelaajaX
            // 
            this.lblPelaajaX.AutoSize = true;
            this.lblPelaajaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaajaX.Location = new System.Drawing.Point(35, 391);
            this.lblPelaajaX.Name = "lblPelaajaX";
            this.lblPelaajaX.Size = new System.Drawing.Size(76, 25);
            this.lblPelaajaX.TabIndex = 0;
            this.lblPelaajaX.Text = "label1";
            // 
            // tmrPelaajaX
            // 
            this.tmrPelaajaX.Interval = 1000;
            this.tmrPelaajaX.Tick += new System.EventHandler(this.tmrPelaajaX_Tick);
            // 
            // tmrPelaajaO
            // 
            this.tmrPelaajaO.Interval = 1000;
            this.tmrPelaajaO.Tick += new System.EventHandler(this.tmrPelaajaO_Tick);
            // 
            // tmrTietokoneMiettii
            // 
            this.tmrTietokoneMiettii.Interval = 500;
            this.tmrTietokoneMiettii.Tick += new System.EventHandler(this.tmrTietokoneMiettii_Tick);
            // 
            // FrmPeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(654, 518);
            this.Controls.Add(this.pnlRistikko);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPeli";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ristinolla";
            this.Load += new System.EventHandler(this.FrmPeli_Load);
            this.pnlRistikko.ResumeLayout(false);
            this.pnlRistikko.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRistikko;
        private System.Windows.Forms.Timer tmrPelaajaX;
        private System.Windows.Forms.Timer tmrPelaajaO;
        private System.Windows.Forms.Label lblPelaajaO;
        private System.Windows.Forms.Label lblPelaajaX;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Label lblPeliaikaO;
        private System.Windows.Forms.Label lblPeliaikaX;
        public System.Windows.Forms.Timer tmrTietokoneMiettii;
    }
}