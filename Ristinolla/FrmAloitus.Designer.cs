namespace Ristinolla
{
    partial class FrmRistinolla
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
            this.pnlAloitus = new System.Windows.Forms.Panel();
            this.lblxTasapelit = new System.Windows.Forms.Label();
            this.lbloTasapelit = new System.Windows.Forms.Label();
            this.lbloPeliaika = new System.Windows.Forms.Label();
            this.lblxPeliaika = new System.Windows.Forms.Label();
            this.lbloVoitot = new System.Windows.Forms.Label();
            this.lbloHaviot = new System.Windows.Forms.Label();
            this.lblxHaviot = new System.Windows.Forms.Label();
            this.lblxVoitot = new System.Windows.Forms.Label();
            this.btnLisaaPelaaja = new System.Windows.Forms.Button();
            this.cbPelaajaNimiX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudVuosi = new System.Windows.Forms.NumericUpDown();
            this.cbPelaajaNimiO = new System.Windows.Forms.ComboBox();
            this.cbTietokonevastus = new System.Windows.Forms.CheckBox();
            this.lblUusiSukunimi = new System.Windows.Forms.Label();
            this.btnAloitaPeli = new System.Windows.Forms.Button();
            this.lblUusiEtunimi = new System.Windows.Forms.Label();
            this.tbUusiSukunimi = new System.Windows.Forms.TextBox();
            this.tbUusiEtunimi = new System.Windows.Forms.TextBox();
            this.lblPelaajaX = new System.Windows.Forms.Label();
            this.lblPelaajaO = new System.Windows.Forms.Label();
            this.lblLisaaPelaaja = new System.Windows.Forms.Label();
            this.msAloitus = new System.Windows.Forms.MenuStrip();
            this.uusiPeliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAloitus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVuosi)).BeginInit();
            this.msAloitus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAloitus
            // 
            this.pnlAloitus.Controls.Add(this.lblxTasapelit);
            this.pnlAloitus.Controls.Add(this.lbloTasapelit);
            this.pnlAloitus.Controls.Add(this.lbloPeliaika);
            this.pnlAloitus.Controls.Add(this.lblxPeliaika);
            this.pnlAloitus.Controls.Add(this.lbloVoitot);
            this.pnlAloitus.Controls.Add(this.lbloHaviot);
            this.pnlAloitus.Controls.Add(this.lblxHaviot);
            this.pnlAloitus.Controls.Add(this.lblxVoitot);
            this.pnlAloitus.Controls.Add(this.btnLisaaPelaaja);
            this.pnlAloitus.Controls.Add(this.cbPelaajaNimiX);
            this.pnlAloitus.Controls.Add(this.label1);
            this.pnlAloitus.Controls.Add(this.nudVuosi);
            this.pnlAloitus.Controls.Add(this.cbPelaajaNimiO);
            this.pnlAloitus.Controls.Add(this.cbTietokonevastus);
            this.pnlAloitus.Controls.Add(this.lblUusiSukunimi);
            this.pnlAloitus.Controls.Add(this.btnAloitaPeli);
            this.pnlAloitus.Controls.Add(this.lblUusiEtunimi);
            this.pnlAloitus.Controls.Add(this.tbUusiSukunimi);
            this.pnlAloitus.Controls.Add(this.tbUusiEtunimi);
            this.pnlAloitus.Controls.Add(this.lblPelaajaX);
            this.pnlAloitus.Controls.Add(this.lblPelaajaO);
            this.pnlAloitus.Controls.Add(this.lblLisaaPelaaja);
            this.pnlAloitus.Controls.Add(this.msAloitus);
            this.pnlAloitus.Location = new System.Drawing.Point(0, 4);
            this.pnlAloitus.Name = "pnlAloitus";
            this.pnlAloitus.Size = new System.Drawing.Size(569, 422);
            this.pnlAloitus.TabIndex = 0;
            // 
            // lblxTasapelit
            // 
            this.lblxTasapelit.AutoSize = true;
            this.lblxTasapelit.Location = new System.Drawing.Point(31, 196);
            this.lblxTasapelit.Name = "lblxTasapelit";
            this.lblxTasapelit.Size = new System.Drawing.Size(53, 13);
            this.lblxTasapelit.TabIndex = 21;
            this.lblxTasapelit.Text = "Tasapelit:";
            // 
            // lbloTasapelit
            // 
            this.lbloTasapelit.AutoSize = true;
            this.lbloTasapelit.Location = new System.Drawing.Point(406, 196);
            this.lbloTasapelit.Name = "lbloTasapelit";
            this.lbloTasapelit.Size = new System.Drawing.Size(53, 13);
            this.lbloTasapelit.TabIndex = 20;
            this.lbloTasapelit.Text = "Tasapelit:";
            // 
            // lbloPeliaika
            // 
            this.lbloPeliaika.AutoSize = true;
            this.lbloPeliaika.Location = new System.Drawing.Point(406, 226);
            this.lbloPeliaika.Name = "lbloPeliaika";
            this.lbloPeliaika.Size = new System.Drawing.Size(47, 13);
            this.lbloPeliaika.TabIndex = 19;
            this.lbloPeliaika.Text = "Peliaika:";
            // 
            // lblxPeliaika
            // 
            this.lblxPeliaika.AutoSize = true;
            this.lblxPeliaika.Location = new System.Drawing.Point(32, 226);
            this.lblxPeliaika.Name = "lblxPeliaika";
            this.lblxPeliaika.Size = new System.Drawing.Size(50, 13);
            this.lblxPeliaika.TabIndex = 18;
            this.lblxPeliaika.Text = "Peliaika: ";
            // 
            // lbloVoitot
            // 
            this.lbloVoitot.AutoSize = true;
            this.lbloVoitot.Location = new System.Drawing.Point(406, 132);
            this.lbloVoitot.Name = "lbloVoitot";
            this.lbloVoitot.Size = new System.Drawing.Size(40, 13);
            this.lbloVoitot.TabIndex = 17;
            this.lbloVoitot.Text = "Voitot: ";
            // 
            // lbloHaviot
            // 
            this.lbloHaviot.AutoSize = true;
            this.lbloHaviot.Location = new System.Drawing.Point(405, 164);
            this.lbloHaviot.Name = "lbloHaviot";
            this.lbloHaviot.Size = new System.Drawing.Size(41, 13);
            this.lbloHaviot.TabIndex = 16;
            this.lbloHaviot.Text = "Häviöt:";
            // 
            // lblxHaviot
            // 
            this.lblxHaviot.AutoSize = true;
            this.lblxHaviot.Location = new System.Drawing.Point(31, 164);
            this.lblxHaviot.Name = "lblxHaviot";
            this.lblxHaviot.Size = new System.Drawing.Size(41, 13);
            this.lblxHaviot.TabIndex = 15;
            this.lblxHaviot.Text = "Häviöt:";
            // 
            // lblxVoitot
            // 
            this.lblxVoitot.AutoSize = true;
            this.lblxVoitot.Location = new System.Drawing.Point(32, 132);
            this.lblxVoitot.Name = "lblxVoitot";
            this.lblxVoitot.Size = new System.Drawing.Size(37, 13);
            this.lblxVoitot.TabIndex = 14;
            this.lblxVoitot.Text = "Voitot:";
            // 
            // btnLisaaPelaaja
            // 
            this.btnLisaaPelaaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLisaaPelaaja.Location = new System.Drawing.Point(309, 347);
            this.btnLisaaPelaaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnLisaaPelaaja.Name = "btnLisaaPelaaja";
            this.btnLisaaPelaaja.Size = new System.Drawing.Size(150, 35);
            this.btnLisaaPelaaja.TabIndex = 8;
            this.btnLisaaPelaaja.Text = "Lisää Pelaaja";
            this.btnLisaaPelaaja.UseVisualStyleBackColor = true;
            this.btnLisaaPelaaja.Click += new System.EventHandler(this.LisaaKlikki);
            // 
            // cbPelaajaNimiX
            // 
            this.cbPelaajaNimiX.FormattingEnabled = true;
            this.cbPelaajaNimiX.Location = new System.Drawing.Point(35, 86);
            this.cbPelaajaNimiX.Name = "cbPelaajaNimiX";
            this.cbPelaajaNimiX.Size = new System.Drawing.Size(121, 21);
            this.cbPelaajaNimiX.TabIndex = 13;
            this.cbPelaajaNimiX.SelectedValueChanged += new System.EventHandler(this.cbPelaajaTiedotPaivittuu);
            this.cbPelaajaNimiX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPelaajaNimiO_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 306);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Syntymävuosi";
            // 
            // nudVuosi
            // 
            this.nudVuosi.Location = new System.Drawing.Point(386, 307);
            this.nudVuosi.Margin = new System.Windows.Forms.Padding(2);
            this.nudVuosi.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nudVuosi.Minimum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.nudVuosi.Name = "nudVuosi";
            this.nudVuosi.Size = new System.Drawing.Size(93, 20);
            this.nudVuosi.TabIndex = 6;
            this.nudVuosi.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // cbPelaajaNimiO
            // 
            this.cbPelaajaNimiO.FormattingEnabled = true;
            this.cbPelaajaNimiO.Location = new System.Drawing.Point(397, 86);
            this.cbPelaajaNimiO.Name = "cbPelaajaNimiO";
            this.cbPelaajaNimiO.Size = new System.Drawing.Size(121, 21);
            this.cbPelaajaNimiO.TabIndex = 12;
            this.cbPelaajaNimiO.SelectedIndexChanged += new System.EventHandler(this.cbPelaajaTiedotPaivittuu);
            this.cbPelaajaNimiO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPelaajaNimiO_KeyPress);
            // 
            // cbTietokonevastus
            // 
            this.cbTietokonevastus.AutoSize = true;
            this.cbTietokonevastus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTietokonevastus.Location = new System.Drawing.Point(200, 168);
            this.cbTietokonevastus.Name = "cbTietokonevastus";
            this.cbTietokonevastus.Size = new System.Drawing.Size(145, 20);
            this.cbTietokonevastus.TabIndex = 11;
            this.cbTietokonevastus.Text = "Tietokone vastus";
            this.cbTietokonevastus.UseVisualStyleBackColor = true;
            this.cbTietokonevastus.Click += new System.EventHandler(this.cbTietokonevastus_Click);
            // 
            // lblUusiSukunimi
            // 
            this.lblUusiSukunimi.AutoSize = true;
            this.lblUusiSukunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUusiSukunimi.Location = new System.Drawing.Point(31, 357);
            this.lblUusiSukunimi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUusiSukunimi.Name = "lblUusiSukunimi";
            this.lblUusiSukunimi.Size = new System.Drawing.Size(73, 17);
            this.lblUusiSukunimi.TabIndex = 5;
            this.lblUusiSukunimi.Text = "Sukunimi";
            // 
            // btnAloitaPeli
            // 
            this.btnAloitaPeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAloitaPeli.Location = new System.Drawing.Point(200, 45);
            this.btnAloitaPeli.Name = "btnAloitaPeli";
            this.btnAloitaPeli.Size = new System.Drawing.Size(157, 100);
            this.btnAloitaPeli.TabIndex = 8;
            this.btnAloitaPeli.Text = "Aloita peli";
            this.btnAloitaPeli.UseVisualStyleBackColor = true;
            this.btnAloitaPeli.Click += new System.EventHandler(this.AloitaPeli);
            // 
            // lblUusiEtunimi
            // 
            this.lblUusiEtunimi.AutoSize = true;
            this.lblUusiEtunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUusiEtunimi.Location = new System.Drawing.Point(31, 307);
            this.lblUusiEtunimi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUusiEtunimi.Name = "lblUusiEtunimi";
            this.lblUusiEtunimi.Size = new System.Drawing.Size(61, 17);
            this.lblUusiEtunimi.TabIndex = 4;
            this.lblUusiEtunimi.Text = "Etunimi";
            // 
            // tbUusiSukunimi
            // 
            this.tbUusiSukunimi.Location = new System.Drawing.Point(116, 356);
            this.tbUusiSukunimi.Margin = new System.Windows.Forms.Padding(2);
            this.tbUusiSukunimi.Name = "tbUusiSukunimi";
            this.tbUusiSukunimi.Size = new System.Drawing.Size(117, 20);
            this.tbUusiSukunimi.TabIndex = 3;
            this.tbUusiSukunimi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KayttajaSyote);
            this.tbUusiSukunimi.Leave += new System.EventHandler(this.tbLeave);
            // 
            // tbUusiEtunimi
            // 
            this.tbUusiEtunimi.Location = new System.Drawing.Point(116, 307);
            this.tbUusiEtunimi.Margin = new System.Windows.Forms.Padding(2);
            this.tbUusiEtunimi.Name = "tbUusiEtunimi";
            this.tbUusiEtunimi.Size = new System.Drawing.Size(117, 20);
            this.tbUusiEtunimi.TabIndex = 2;
            this.tbUusiEtunimi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KayttajaSyote);
            this.tbUusiEtunimi.Leave += new System.EventHandler(this.tbLeave);
            // 
            // lblPelaajaX
            // 
            this.lblPelaajaX.AutoSize = true;
            this.lblPelaajaX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaajaX.Location = new System.Drawing.Point(43, 45);
            this.lblPelaajaX.Name = "lblPelaajaX";
            this.lblPelaajaX.Size = new System.Drawing.Size(113, 25);
            this.lblPelaajaX.TabIndex = 2;
            this.lblPelaajaX.Text = "Pelaaja X";
            // 
            // lblPelaajaO
            // 
            this.lblPelaajaO.AutoSize = true;
            this.lblPelaajaO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaajaO.Location = new System.Drawing.Point(392, 45);
            this.lblPelaajaO.Name = "lblPelaajaO";
            this.lblPelaajaO.Size = new System.Drawing.Size(115, 25);
            this.lblPelaajaO.TabIndex = 1;
            this.lblPelaajaO.Text = "Pelaaja O";
            // 
            // lblLisaaPelaaja
            // 
            this.lblLisaaPelaaja.AutoSize = true;
            this.lblLisaaPelaaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLisaaPelaaja.Location = new System.Drawing.Point(192, 249);
            this.lblLisaaPelaaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLisaaPelaaja.Name = "lblLisaaPelaaja";
            this.lblLisaaPelaaja.Size = new System.Drawing.Size(153, 20);
            this.lblLisaaPelaaja.TabIndex = 1;
            this.lblLisaaPelaaja.Text = "Lisää uusi pelaaja";
            // 
            // msAloitus
            // 
            this.msAloitus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msAloitus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uusiPeliToolStripMenuItem});
            this.msAloitus.Location = new System.Drawing.Point(0, 0);
            this.msAloitus.Name = "msAloitus";
            this.msAloitus.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msAloitus.Size = new System.Drawing.Size(569, 24);
            this.msAloitus.TabIndex = 0;
            this.msAloitus.Text = "menuStrip1";
            // 
            // uusiPeliToolStripMenuItem
            // 
            this.uusiPeliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ohjeetToolStripMenuItem,
            this.ohjeetToolStripMenuItem1,
            this.infoToolStripMenuItem});
            this.uusiPeliToolStripMenuItem.Name = "uusiPeliToolStripMenuItem";
            this.uusiPeliToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.uusiPeliToolStripMenuItem.Text = "Menu";
            // 
            // ohjeetToolStripMenuItem
            // 
            this.ohjeetToolStripMenuItem.Name = "ohjeetToolStripMenuItem";
            this.ohjeetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ohjeetToolStripMenuItem.Text = "Pelin säännöt";
            this.ohjeetToolStripMenuItem.Click += new System.EventHandler(this.SaannotKlikki);
            // 
            // ohjeetToolStripMenuItem1
            // 
            this.ohjeetToolStripMenuItem1.Name = "ohjeetToolStripMenuItem1";
            this.ohjeetToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ohjeetToolStripMenuItem1.Text = "Ohjeet";
            this.ohjeetToolStripMenuItem1.Click += new System.EventHandler(this.ohjeetKlikki);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoKlikki);
            // 
            // FrmRistinolla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 429);
            this.Controls.Add(this.pnlAloitus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msAloitus;
            this.MaximizeBox = false;
            this.Name = "FrmRistinolla";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ristinolla";
            this.Load += new System.EventHandler(this.FrmRistinollaLataus);
            this.pnlAloitus.ResumeLayout(false);
            this.pnlAloitus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVuosi)).EndInit();
            this.msAloitus.ResumeLayout(false);
            this.msAloitus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip msAloitus;
        private System.Windows.Forms.ToolStripMenuItem uusiPeliToolStripMenuItem;
        private System.Windows.Forms.Label lblPelaajaX;
        private System.Windows.Forms.Label lblPelaajaO;
        public System.Windows.Forms.Panel pnlAloitus;
        public System.Windows.Forms.CheckBox cbTietokonevastus;
        public System.Windows.Forms.Button btnAloitaPeli;
        private System.Windows.Forms.Label lblLisaaPelaaja;
        private System.Windows.Forms.TextBox tbUusiEtunimi;
        private System.Windows.Forms.TextBox tbUusiSukunimi;
        private System.Windows.Forms.Label lblUusiEtunimi;
        private System.Windows.Forms.Label lblUusiSukunimi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLisaaPelaaja;
        public System.Windows.Forms.NumericUpDown nudVuosi;
        public System.Windows.Forms.ComboBox cbPelaajaNimiX;
        public System.Windows.Forms.ComboBox cbPelaajaNimiO;
        public System.Windows.Forms.Label lblxVoitot;
        public System.Windows.Forms.Label lbloPeliaika;
        public System.Windows.Forms.Label lblxPeliaika;
        public System.Windows.Forms.Label lbloHaviot;
        public System.Windows.Forms.Label lblxHaviot;
        public System.Windows.Forms.Label lbloVoitot;
        public System.Windows.Forms.Label lblxTasapelit;
        public System.Windows.Forms.Label lbloTasapelit;
        private System.Windows.Forms.ToolStripMenuItem ohjeetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ohjeetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

