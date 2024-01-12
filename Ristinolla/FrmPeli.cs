using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class FrmPeli : Form
    {
        FrmRistinolla FrmAloitus;

        /*Luodaan kynät, joilla piirrämme ristit, nollat sekä itse ristikon */

        Pen RistikkoKyna = new Pen(Color.Black, 4);
        Pen NollaKyna = new Pen(Color.BlueViolet, 4);
        Pen RistiKyna = new Pen(Color.Red, 4);

        /* Julkiset muuttujat johon lisäämme peliajan sekä laskemme tehdyt siirrot */
        public int xPeliaika, oPeliaika,siirrot;
        /* Booleanien avulla tutkitaan onko vastassa tietokone ja kumman vuoro on merkata*/
        public bool bTietokone, bPelaajaVuoro;

        public FrmPeli(FrmRistinolla FrmA)
        {
            InitializeComponent();
            this.FrmAloitus = FrmA;
        }
        /*Pelaajien ajastimet ovat käynnissä sekä heidän nimensä näkyy, mikäli on heidän vuoro merkata*/
        public void ajastin()
        {
            if (bPelaajaVuoro == false)
            {
                lblPelaajaX.Visible = true;
                lblPelaajaO.Visible = false;
                tmrPelaajaX.Enabled = true;
                tmrPelaajaO.Enabled = false;
            }
            if (bPelaajaVuoro == true)
            {
                lblPelaajaX.Visible = false;
                lblPelaajaO.Visible = true;
                tmrPelaajaX.Enabled = false;
                tmrPelaajaO.Enabled = true;
            }
        }
        private void FrmPeli_Load(object sender, EventArgs e)
        {
            ajastin();
            /* Asetetaan pelaajien nimet näkyviin kun on heidän vuoro merkata*/
            lblPelaajaO.Text = FrmAloitus.cbPelaajaNimiO.Text + " " + "O";
            lblPelaajaX.Text = FrmAloitus.cbPelaajaNimiX.Text + " " + "X";
            /* Jos tietokone on vastassa bTietokone==true */
            if (FrmAloitus.cbTietokonevastus.Checked == true)
            {
                bTietokone = true;
            }
        }
        /* Pelaajien ajastimet ovat käynnissä mikäli on heidän vuoro. Jokaisella ajastimen lyönnillä lisäämme 1 sekunnin pelaajan peliaikaan*/
        private void tmrPelaajaX_Tick(object sender, EventArgs e)
        {
            xPeliaika += 1;
            lblPeliaikaX.Text = "Aika:" + " " + xPeliaika.ToString();
        }
        private void tmrPelaajaO_Tick(object sender, EventArgs e)
        {
            oPeliaika += 1;
            lblPeliaikaO.Text = "Aika:" + " " + oPeliaika.ToString();

        }

        /* Tämä funktio toteutuu kun tietokoneen "miettimisaika" päättyy. Tällä lyönnillä kutsumme TietokoneSiirtaa funktiota
         jossa teemme siirron. TietokoneSiirtaa funktio toteutuu ainoastaan kun on O:n vuoro merkata */
        private void tmrTietokoneMiettii_Tick(object sender, EventArgs e)
        {
            if (FrmAloitus.cbTietokonevastus.Checked == true && bPelaajaVuoro == true)
            {
                TietokoneSiirtaa();
            }
        }

        /* Kun pelaaja klikkaa jotain ruutua, siihen piilotettu Button_Click tapahtuma suoritetaan.
         Napin painamuksen jälkeen pelaajavuoro vaihtuu ja piirretään X tai O riippuen pelaajavuorosta.*/
        private void btnKlikki(object sender, EventArgs e)
        {
            bPelaajaVuoro = !bPelaajaVuoro;
            siirrot++; // Lisätään siirrot muuttujaan yksi aina kun nappia painetaan, kun siirtoa on yhteensä 9 se tarkoittaa tasapeliä.

            ajastin();

            /* Mikäli pelataan tietokonetta vastaan, jokaisen klikin jälkeen arvomme uuden "miettimisajan" tietokoneelle.
             Kun miettimisaika on ohi, tmrTietokoneMiettii_Tick funktio käy toteen ja tietokone tekee siirron. */

            if (bTietokone == true)
            {
                Random rnd = new Random();
                int num = rnd.Next(500, 2500);
                tmrTietokoneMiettii.Interval = num;
                tmrTietokoneMiettii.Enabled = true;
            }
            /* Mikäli bPelaajavuoro=true, on X vuoro merkata ja klikatessa merkitään Buttonin tekstiksi X*/
            Button btn = (Button)sender;
            if (bPelaajaVuoro == true)
            {
                btn.Text = "X";
            }
            /* Ja sama O vuorolla */

            if (bPelaajaVuoro == false)
            {
                btn.Text = "O";
            }
            /* Napit häviää näkymästä ja niitä ei voi klikata uudelleen */
            btn.Visible = false;
            btn.Enabled = false;

            /* Kutsumme molempia piirra funktioita, jotka piirtävät ristin tai nollan riippuen onko bPelaajavuoro true tai false*/

            pnlRistikko.Paint += new System.Windows.Forms.PaintEventHandler(this.piirraX);

            pnlRistikko.Paint += new System.Windows.Forms.PaintEventHandler(this.piirraO);

            /* Tarkista funktiossa käymme joka klikin jälkeen ja tarkistamme kaikki mahdolliset tilanteet joilla jompikumpi pelaaja voittaa, tai tulee tasapeli*/
            tarkista();
        }

        /* Siirrymme TietokoneSiirtaa funktioon, jos olemme valinneet tietokoneen vastukseksi, ja on sen vuoro
         Tämä funktio tutkii for loopin sisällä kaikki mahdolliset X yhdistelmät, joilla pelaaja X voisi voittaa seuraavalla kierroksella
         jolloin tietokone estää Pelaajaa X. Ensin tutkitaan vaakarivit, X X -  Jolloin tietokone valitsee X X O. Sitten pystyrivi jne..
         Tietokone pyrkii ensisijaisesti estämään pelaajan seuraavan siirron,
         mutta loopin sisällä on myös ehdot jolla tietokone voi itse voittaa kyseisellä kierroksella. */
        public void TietokoneSiirtaa()
        {
            for (int i = 0; i < 1; i++)
            {
                
                // Ensimmäinen vaakarivi
                if (btn1.Text == "X" && btn2.Text == "X" && btn3.Visible == true || btn6.Text == "X" && btn9.Text == "X" && btn3.Visible == true
                   || btn7.Text == "O" && btn5.Text == "O" && btn3.Visible == true || btn1.Text == "O" && btn2.Text == "O" && btn3.Visible == true || btn6.Text == "O" && btn9.Text == "O" && btn3.Visible == true || btn7.Text == "O" && btn5.Text == "O" && btn3.Visible == true)
                {
                    btn3.PerformClick();
                    break;
                }

                if (btn2.Text == "X" && btn3.Text == "X" && btn1.Visible == true || btn4.Text == "X" && btn7.Text == "X" && btn1.Visible == true || btn5.Text == "X" && btn9.Text == "X" && btn1.Visible == true
                    || btn2.Text == "O" && btn3.Text == "O" && btn1.Visible == true || btn4.Text == "O" && btn7.Text == "O" && btn1.Visible == true || btn5.Text == "O" && btn9.Text == "O" && btn1.Visible == true)

                {
                    btn1.PerformClick();
                    break;
                }

                if (btn1.Text == "X" && btn3.Text == "X" && btn2.Visible == true || btn5.Text == "X" && btn8.Text == "X" && btn2.Visible == true
                    || btn1.Text == "O" && btn3.Text == "O" && btn2.Visible == true || btn5.Text == "O" && btn8.Text == "O" && btn2.Visible == true)
                {
                    btn2.PerformClick();
                    break;
                }

                // Toinen vaakarivi 
                if (btn4.Text == "X" && btn5.Text == "X" && btn6.Visible == true || btn3.Text == "X" && btn9.Text == "X" && btn6.Visible == true
                    || btn4.Text == "O" && btn5.Text == "O" && btn6.Visible == true || btn3.Text == "O" && btn9.Text == "O" && btn6.Visible == true)
                {
                    btn6.PerformClick();
                    break;
                }

                if (btn4.Text == "X" && btn6.Text == "X" && btn5.Visible == true || btn2.Text == "X" && btn8.Text == "X" && btn5.Visible == true
                    || btn1.Text == "X" && btn9.Text == "X" && btn5.Visible == true || btn3.Text == "X" && btn7.Text == "X" && btn5.Visible == true
                    || btn4.Text == "O" && btn6.Text == "O" && btn5.Visible == true || btn2.Text == "O" && btn8.Text == "O" && btn5.Visible == true
                    || btn1.Text == "O" && btn9.Text == "O" && btn5.Visible == true || btn3.Text == "O" && btn7.Text == "O" && btn5.Visible == true)

                {
                    btn5.PerformClick();
                    break;
                }

                if (btn6.Text == "X" && btn5.Text == "X" && btn4.Visible == true || btn1.Text == "X" && btn7.Text == "X" && btn4.Visible == true
                    || btn6.Text == "O" && btn5.Text == "O" && btn4.Visible == true || btn1.Text == "O" && btn7.Text == "O" && btn4.Visible == true)
                {
                    btn4.PerformClick();
                    break;
                }

                // Kolmas vaakarivi 
                if (btn8.Text == "X" && btn9.Text == "X" && btn7.Visible == true || btn5.Text == "X" && btn3.Text == "X" && btn7.Visible == true || btn1.Text == "X" && btn4.Text == "X" && btn7.Visible == true
                     || btn8.Text == "O" && btn9.Text == "O" && btn7.Visible == true || btn5.Text == "O" && btn3.Text == "O" && btn7.Visible == true || btn1.Text == "O" && btn4.Text == "O" && btn7.Visible == true)
                {
                    btn7.PerformClick();
                    break;
                }

                if (btn7.Text == "X" && btn8.Text == "X" && btn9.Visible == true || btn6.Text == "X" && btn3.Text == "X" && btn9.Visible == true || btn1.Text == "X" && btn5.Text == "X" && btn9.Visible == true
                    || btn7.Text == "O" && btn8.Text == "O" && btn9.Visible == true || btn6.Text == "O" && btn3.Text == "O" && btn9.Visible == true || btn1.Text == "O" && btn5.Text == "O" && btn9.Visible == true)
                {
                    btn9.PerformClick();
                    break;
                }

                if (btn7.Text == "X" && btn9.Text == "X" && btn8.Visible == true || btn2.Text == "X" && btn5.Text == "X" && btn8.Visible == true
                    || btn7.Text == "O" && btn9.Text == "O" && btn8.Visible == true || btn2.Text == "O" && btn5.Text == "O" && btn8.Visible == true)
                {
                    btn8.PerformClick();
                    break;
                }

                if (btn1.Text == "X" && btn5.Visible == true || btn3.Text == "X" && btn5.Visible == true || btn7.Text == "X" && btn5.Visible == true || btn9.Text == "X" && btn5.Visible == true)
                {
                    btn5.PerformClick();
                    break;
                }

                if (btn2.Text == "X" && btn3.Visible == true || btn4.Text == "X" && btn3.Visible == true || btn5.Text == "X" && btn3.Visible == true || btn6.Text == "X" && btn3.Visible == true || btn8.Text == "X" && btn3.Visible == true)
                {
                    btn3.PerformClick();
                    break;
                }
                /* Mikäli tietokone ei ymmärrä estää eikä voi voittaa, täytyy arpoa joku nappi jota se painaa
                 For silmukassa arvomme numeron ja switch casessa klikataan nappia joka vastaa arvottua numeroa
                mikäli nappi on jo painettu arvomme uuden napin painettavaksi.*/

                for(int j=0;j<1;j++)
                { 
                Random rnd = new Random();
                int random = rnd.Next(1, 10);

                    switch (random)
                    {
                        case 1:
                            if (btn1.Visible == true)
                                btn1.PerformClick();
                            else
                                j--;
                            break;

                        case 2:
                            if (btn2.Visible == true)
                                btn2.PerformClick();
                            else
                                j--;
                            break;
                        case 3:
                            if (btn3.Visible == true)
                                btn3.PerformClick();
                            else
                                j--;
                            break;
                        case 4:
                            if (btn4.Visible == true)
                                btn4.PerformClick();
                            else
                                j--;
                            break;
                        case 5:
                            if (btn5.Visible == true)
                                btn5.PerformClick();
                            else
                                j--;
                            break;
                        case 6:
                            if (btn6.Visible == true)
                                btn6.PerformClick();
                            else
                                j--;
                            break;
                        case 7:
                            if (btn7.Visible == true)
                                btn7.PerformClick();
                            else
                                j--;
                            break;
                        case 8:
                            if (btn8.Visible == true)
                                btn8.PerformClick();
                            else
                                j--;
                            break;
                        case 9:
                            if (btn9.Visible == true)
                                btn9.PerformClick();
                            else
                                j--;
                            break;
                    }
                }
                tarkista();
            }
        }
        /* Täällä tutkitaan kaikki mahdolliset voittokuviot molemmille pelaajille,
         * mikäli joku pelaajista voitaa tai tulee tasapeli hän voi päättää pelaako uudestaan vai sulkeeko pelin. 
         * Jokaiselle pelaajalle lisätään tulokset tiedostoon ylös */
        public void tarkista()
        {
            /* Mikäli siirtoja on tehty 9, eli tuloksena on tasapeli*/

            if (siirrot == 9)
            {
                for (int i = 0; i < FrmAloitus.pelaajatiedot.Count; i++)
                {
                    if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiX.Text)
                    {
                        FrmAloitus.pelaajatiedot[i].PelaajaTasapelit++;
                        FrmAloitus.lblxTasapelit.Text = "Tasapelit: " + FrmAloitus.pelaajatiedot[i].PelaajaTasapelit;
                        FrmAloitus.pelaajatiedot[i].Peliaika += xPeliaika;
                        FrmAloitus.lblxPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                        FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                    }
                    /* Ja vastustajan tiedot päivitetään myös, mikäli ihminen oli vastuksena */

                    if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiO.Text && FrmAloitus.cbTietokonevastus.Checked == false)
                    {
                        FrmAloitus.pelaajatiedot[i].PelaajaTasapelit++;
                        FrmAloitus.lbloTasapelit.Text = "Tasapelit: " + FrmAloitus.pelaajatiedot[i].PelaajaTasapelit;
                        FrmAloitus.pelaajatiedot[i].Peliaika += oPeliaika;
                        FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                        FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                    }
                }
                // Mikäli tietokone oli vastuksena, pitää tallentaa sen tiedostoon tasapeli
                if (FrmAloitus.cbTietokonevastus.Checked == true)
                {
                    for (int i = 0; i < FrmAloitus.tietokonetiedot.Count; i++)
                    {
                        FrmAloitus.tietokonetiedot[i].tkTasapelit++;
                        FrmAloitus.lbloTasapelit.Text = "Tasapelit: " + FrmAloitus.tietokonetiedot[i].tkTasapelit;
                        FrmAloitus.tietokonetiedot[i].tkPeliaika += oPeliaika;
                        FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.tietokonetiedot[i].tkTasapelit;
                        FrmAloitus.SerializeJSON2(FrmAloitus.tietokonetiedot);
                    }
                }
                tmrPelaajaO.Stop();
                tmrPelaajaX.Stop();
                tmrTietokoneMiettii.Stop();

                string tasapeli = "Tasapeli! Haluatko pelata uudestaan?";
                string tasapeliotsikko = "Tasapeli :((";
                MessageBoxButtons Napit = MessageBoxButtons.YesNo;
                DialogResult jatketaanko = MessageBox.Show(tasapeli, tasapeliotsikko, Napit);
                if (jatketaanko == DialogResult.Yes)
                {
                    this.Close();
                    FrmAloitus.btnAloitaPeli.PerformClick();
                }
                else
                {
                    this.Close();
                }
            }
            /* Pelaaja X voittaa */

            if (btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X"
              || btn4.Text == "X" && btn5.Text == "X" && btn6.Text == "X"
              || btn7.Text == "X" && btn9.Text == "X" && btn8.Text == "X"
              || btn1.Text == "X" && btn4.Text == "X" && btn7.Text == "X"
              || btn2.Text == "X" && btn5.Text == "X" && btn8.Text == "X"
              || btn3.Text == "X" && btn6.Text == "X" && btn9.Text == "X"
              || btn1.Text == "X" && btn5.Text == "X" && btn9.Text == "X"
              || btn3.Text == "X" && btn5.Text == "X" && btn7.Text == "X")

            {
                tmrPelaajaO.Stop();
                tmrPelaajaX.Stop();

                /* For loopeissa käydään läpi Aloitus formissa olevat ComboBoxit ja tutkitaan niitä,
                 Kun silmukassa tullaan listassa olevan PelaajaEtunimi kohdalle joka on sama kuin ComboBoxiin valittu pelaaja
                lisätään hänen listan indeksin arvoihin tulokset sekä peliaika ylös.
                */
                for (int i = 0; i < FrmAloitus.pelaajatiedot.Count; i++)
                {
                    if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiX.Text)
                    {
                        FrmAloitus.pelaajatiedot[i].PelaajaVoitot++;
                        FrmAloitus.lblxVoitot.Text = "Voitot: " + FrmAloitus.pelaajatiedot[i].PelaajaVoitot;
                        FrmAloitus.pelaajatiedot[i].Peliaika += xPeliaika;
                        FrmAloitus.lblxPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                        FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                    }
                    /* Ja vastustajan tiedot päivitetään myös, mikäli ihminen oli vastuksena */

                    if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiO.Text && FrmAloitus.cbTietokonevastus.Checked == false)
                    {
                        FrmAloitus.pelaajatiedot[i].PelaajaHaviot++;
                        FrmAloitus.lbloHaviot.Text = "Häviöt: " + FrmAloitus.pelaajatiedot[i].PelaajaHaviot;
                        FrmAloitus.pelaajatiedot[i].Peliaika += oPeliaika;
                        FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                        FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                    }
                }
                // Mikäli tietokone oli vastuksena, pitää tallentaa sen tiedostoon häviö 
                if (FrmAloitus.cbTietokonevastus.Checked == true)
                    {
                        for (int i = 0; i < FrmAloitus.tietokonetiedot.Count; i++)
                        {
                            FrmAloitus.tietokonetiedot[i].tkHaviot++;
                            FrmAloitus.lbloHaviot.Text = "Häviöt: " + FrmAloitus.tietokonetiedot[i].tkHaviot;
                            FrmAloitus.tietokonetiedot[i].tkPeliaika += oPeliaika;
                            FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.tietokonetiedot[i].tkPeliaika;
                            FrmAloitus.SerializeJSON2(FrmAloitus.tietokonetiedot);
                        }
                }
                
                string pelaaja1voitti = FrmAloitus.cbPelaajaNimiX.Text + " " + " voitti!, haluatko pelata uudestaan?";
                string Voittaja1 = "Voittaja!";
                MessageBoxButtons Napit = MessageBoxButtons.YesNo;
                DialogResult jatketaanko = MessageBox.Show(pelaaja1voitti, Voittaja1, Napit);
                if (jatketaanko == DialogResult.Yes)
                {
                    this.Close();
                    FrmAloitus.btnAloitaPeli.PerformClick();
                }
                else
                {
                    this.Close();
                }

            }
            /* Pelaaja O voittaa */
            if (btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O"
              || btn4.Text == "O" && btn5.Text == "O" && btn6.Text == "O"
              || btn7.Text == "O" && btn9.Text == "O" && btn8.Text == "O"
              || btn1.Text == "O" && btn4.Text == "O" && btn7.Text == "O"
              || btn2.Text == "O" && btn5.Text == "O" && btn8.Text == "O"
              || btn3.Text == "O" && btn6.Text == "O" && btn9.Text == "O"
              || btn1.Text == "O" && btn5.Text == "O" && btn9.Text == "O"
              || btn3.Text == "O" && btn5.Text == "O" && btn7.Text == "O")
            {
                tmrPelaajaO.Stop();
                tmrPelaajaX.Stop();

                /* Tutkitaan onko tietokone vastuksena, jos on niin päivitetään X häviö tilastoihin ja tietokoneelle voitto */

                if (FrmAloitus.cbTietokonevastus.Checked == true)
                {
                    for (int i = 0; i < FrmAloitus.tietokonetiedot.Count; i++)
                    {
                        /* Päivitetään tietokoneelle voitto ja pelaajalle häviö*/

                        if (FrmAloitus.tietokonetiedot[i].tkEtunimi == FrmAloitus.cbPelaajaNimiO.Text)
                        {
                            FrmAloitus.tietokonetiedot[i].tkVoitot++;
                            FrmAloitus.lbloVoitot.Text = "Voitot: " + FrmAloitus.tietokonetiedot[i].tkVoitot;
                            FrmAloitus.tietokonetiedot[i].tkPeliaika += oPeliaika;
                            FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.tietokonetiedot[i].tkPeliaika;
                            FrmAloitus.SerializeJSON2(FrmAloitus.tietokonetiedot);
                        }
                    }
                    for (int i = 0; i < FrmAloitus.pelaajatiedot.Count; i++)
                    {
                        if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiX.Text)
                        {
                            FrmAloitus.pelaajatiedot[i].PelaajaHaviot++;
                            FrmAloitus.lblxHaviot.Text = "Häviöt: " + FrmAloitus.pelaajatiedot[i].PelaajaHaviot;
                            FrmAloitus.pelaajatiedot[i].Peliaika += oPeliaika;
                            FrmAloitus.lblxPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                            FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                        }
                    }
                }

                /* Jos vastuksena oli toinen pelaaja ja O voitti, niin päivitetään X häviö ja O voitto */

                if (FrmAloitus.cbTietokonevastus.Checked == false)
                {

                    for (int i = 0; i < FrmAloitus.pelaajatiedot.Count; i++)
                    {
                        if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiO.Text)
                        {
                            FrmAloitus.pelaajatiedot[i].PelaajaVoitot++;
                            FrmAloitus.lbloVoitot.Text = "Voitot: " + FrmAloitus.pelaajatiedot[i].PelaajaVoitot;
                            FrmAloitus.pelaajatiedot[i].Peliaika += oPeliaika;
                            FrmAloitus.lbloPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                            FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                        }
                        if (FrmAloitus.pelaajatiedot[i].PelaajaEtunimi == FrmAloitus.cbPelaajaNimiX.Text)
                        {
                            FrmAloitus.pelaajatiedot[i].PelaajaHaviot++;
                            FrmAloitus.lblxHaviot.Text = "Häviöt: " + FrmAloitus.pelaajatiedot[i].PelaajaHaviot;
                            FrmAloitus.pelaajatiedot[i].Peliaika += oPeliaika;
                            FrmAloitus.lblxPeliaika.Text = "Peliaika: " + FrmAloitus.pelaajatiedot[i].Peliaika;
                            FrmAloitus.SerializeJSON(FrmAloitus.pelaajatiedot);
                        }
                    }
                  
                }
                string pelaaja2voitti = FrmAloitus.cbPelaajaNimiO.Text + " Voitti!, Haluatko pelata uudestaan?";
                string Voittaja2 = "Voittaja!";
                MessageBoxButtons Napit2 = MessageBoxButtons.YesNo;

                DialogResult jatketaanko2 = MessageBox.Show(pelaaja2voitti, Voittaja2, Napit2);
                if (jatketaanko2 == DialogResult.Yes)
                {
                    this.Close();
                    FrmAloitus.btnAloitaPeli.PerformClick();
                }
                else
                {
                    this.Close();
                }
            }
        }

        /* Tässä funktiossa piirrämme ruksin napin määrittämään koordinaattiin mikäli bPelaajavuoro=true */
        public void piirraX(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            float x, y, z, v;

            if (bPelaajaVuoro == true && btn1.Enabled == false)
            {
                x = 130.0F;
                y = 25.0F;
                z = 230.0F;
                v = 100.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);

            }
            if (btn2.Enabled == false && bPelaajaVuoro == true)    // Nappi 2
            {
                x = 260.0F;
                y = 25.0F;
                z = 360.0F;
                v = 100.0F;

                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn3.Enabled == false && bPelaajaVuoro == true)          // Nappi 3
            {
                x = 390.0F;
                y = 25.0F;
                z = 490.0F;
                v = 100.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn4.Enabled == false && bPelaajaVuoro == true)   //Nappi 4
            {
                x = 130.0F;
                y = 140.0F;
                z = 230.0F;
                v = 230.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn5.Enabled == false && bPelaajaVuoro == true)  //Nappi 5
            {
                x = 260.0F;
                y = 140.0F;
                z = 360.0F;
                v = 230.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn6.Enabled == false && bPelaajaVuoro == true)      //Nappi 6
            {
                x = 390.0F;
                y = 140.0F;
                z = 490.0F;
                v = 230.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn7.Enabled == false && bPelaajaVuoro == true)   //Nappi 7
            {
                x = 130.0F;
                y = 265.0F;
                z = 230.0F;
                v = 355.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);


            }
            if (btn8.Enabled == false && bPelaajaVuoro == true)   //Nappi 8
            {
                x = 260.0F;
                y = 265.0F;
                z = 360.0F;
                v = 355.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);

            }
            if (btn9.Enabled == false && bPelaajaVuoro == true)  //Nappi 9
            {
                x = 390.0F;
                y = 265.0F;
                z = 490.0F;
                v = 355.0F;
                PointF pnt1 = new PointF(x, y);
                PointF pnt2 = new PointF(z, v);

                PointF pnt3 = new PointF(z, y);
                PointF pnt4 = new PointF(x, v);
                e.Graphics.DrawLine(RistiKyna, pnt1, pnt2);
                e.Graphics.DrawLine(RistiKyna, pnt3, pnt4);
            }
        }
        /* Tässä Funktiossa piirrämme nollan, bPelaajaVuoro = false */
        public void piirraO(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (btn1.Enabled == false && bPelaajaVuoro == false) // Nappi 1
            {
                g.DrawEllipse(NollaKyna, 150, 30, 75, 75);
                

            }
            if (btn2.Enabled == false && bPelaajaVuoro == false)    // Nappi 2
            {
                g.DrawEllipse(NollaKyna, 275, 30, 75, 75);

            }
            if (btn3.Enabled == false && bPelaajaVuoro == false)          // Nappi 3
            {
                g.DrawEllipse(NollaKyna, 390, 30, 75, 75);

            }
            if (btn4.Enabled == false && bPelaajaVuoro == false)   //Nappi 4
            {
                g.DrawEllipse(NollaKyna, 150, 150, 75, 75);

            }
            if (btn5.Enabled == false && bPelaajaVuoro == false)  //Nappi 5
            {
                g.DrawEllipse(NollaKyna, 275, 150, 75, 75);

            }
            if (btn6.Enabled == false && bPelaajaVuoro == false)      //Nappi 6
            {
                g.DrawEllipse(NollaKyna, 390, 150, 75, 75);


            }
            if (btn7.Enabled == false && bPelaajaVuoro == false)   //Nappi 7
            {
                g.DrawEllipse(NollaKyna, 150, 270, 75, 75);


            }
            if (btn8.Enabled == false && bPelaajaVuoro == false)   //Nappi 8
            {
                g.DrawEllipse(NollaKyna, 275, 270, 75, 75);


            }
            if (btn9.Enabled == false && bPelaajaVuoro == false)  //Nappi 9
            {
                g.DrawEllipse(NollaKyna, 390, 270, 75, 75);

            }
        }
       
        /* Piirretään Ristikko paneeliin */
        private void RistikkopaneeliPiirros(object sender, PaintEventArgs e)
        {
            {

                Graphics g = this.CreateGraphics();
                PointF Pysty1 = new PointF(250.0F, 22.0F);
                PointF Pysty2 = new PointF(250.0F, 359.0F);
                PointF Pysty3 = new PointF(375.0F, 22.0F);
                PointF Pysty4 = new PointF(375.0F, 359.0F);

                e.Graphics.DrawLine(RistikkoKyna, Pysty1, Pysty2);
                e.Graphics.DrawLine(RistikkoKyna, Pysty3, Pysty4);

                PointF Vaaka1 = new PointF(125.0F, 125.0F);
                PointF Vaaka2 = new PointF(500.0F, 125.0F);
                PointF Vaaka3 = new PointF(125.0F, 250.0F);
                PointF Vaaka4 = new PointF(500.0F, 250.0F);

                e.Graphics.DrawLine(RistikkoKyna, Vaaka1, Vaaka2);
                e.Graphics.DrawLine(RistikkoKyna, Vaaka3, Vaaka4);
            }
        }
    }
}

