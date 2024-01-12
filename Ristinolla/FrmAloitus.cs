using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ristinolla
{
    public partial class FrmRistinolla : Form
    {

        public List<PelaajienTiedot> pelaajatiedot = new List<PelaajienTiedot>();
        public List<TietokoneenTiedot> tietokonetiedot = new List<TietokoneenTiedot>();

        public string pelaajatietofilu = "c:\\temp\\RistinollaTilastot.txt";
        public string tietokonetietofilu = "c:\\temp\\TietokoneenTilastot.txt";

        /* Pelaajien tallennus JSON*/
        public void SerializeJSON(List<PelaajienTiedot> input)
        {

            string json = JsonConvert.SerializeObject(input);
            System.IO.File.WriteAllText(pelaajatietofilu, json);
        }

        public List<PelaajienTiedot> DeserializeJSON()
        {
            if (File.Exists(pelaajatietofilu))
            {
                using (StreamReader r = new StreamReader(pelaajatietofilu))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<PelaajienTiedot>>(json);
                }
            }
            else
                return null;
        }
        public void SerializeJSON2(List<TietokoneenTiedot> input)
        {

            string json = JsonConvert.SerializeObject(input);
            System.IO.File.WriteAllText(tietokonetietofilu, json);
        }
        public List<TietokoneenTiedot> DeserializeJSON2()
        {
            if(File.Exists(tietokonetietofilu))
            {
                using(StreamReader s = new StreamReader(tietokonetietofilu))
                {
                    string json2 = s.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<TietokoneenTiedot>>(json2);
                }
            }
            else
            {
                return null;
            }
        }

        public FrmRistinolla()
        {
            InitializeComponent();

            pelaajatiedot = DeserializeJSON();
            tietokonetiedot = DeserializeJSON2();

            /* Jotta saadaan ComboBoxeihin näkyviin pelaajan nimi tarvitaan BindingContext ja 
             DataSource pelaajatiedot */

            BindingContext bc = new BindingContext();
            cbPelaajaNimiX.BindingContext = bc;
            cbPelaajaNimiX.DataSource = pelaajatiedot;
            cbPelaajaNimiX.DisplayMember = "PelaajaEtunimi";
            cbPelaajaNimiX.ValueMember = "PelaajaEtunimi";
           

            cbPelaajaNimiO.DataSource = pelaajatiedot;
            cbPelaajaNimiO.DisplayMember = "PelaajaEtunimi";
            cbPelaajaNimiX.ValueMember = "PelaajaEtunimi";

            if (cbTietokonevastus.Checked == true)
            {
                cbPelaajaNimiO.DataSource = tietokonetiedot;
                cbPelaajaNimiO.DisplayMember = "tkEtunimi";
                cbPelaajaNimiO.ValueMember = "tkEtunimi";
            }
        }
        /* Kun uusi pelaaja luodaan lisätään listaan uusi pelaaja, mikäli lista on tyhjä
         Lisätään PelaajienTiedot listaan pelaajan tiedot ja tallennetaan ne tiedostoon c\temp\RistinollaTilastot.*/
        private void LisaaKlikki(object sender, EventArgs e)
        {
            if (pelaajatiedot == null)
            {
                pelaajatiedot = new List<PelaajienTiedot>();
            }
            PelaajienTiedot pt = new PelaajienTiedot();
            pt.PelaajaEtunimi = tbUusiEtunimi.Text;
            pt.PelaajaSukunimi = tbUusiSukunimi.Text;
            pt.PelaajaIka = 2022- int.Parse(nudVuosi.Text);
            
            pelaajatiedot.Add(pt);
            SerializeJSON(pelaajatiedot);
            tbUusiEtunimi.Text = "";
            tbUusiSukunimi.Text = "";
            nudVuosi.Value = 2000;
            btnLisaaPelaaja.Enabled = false;

            /* Mikäli tietokonetietotiedosto on tyhjä, luodaan tietokonepelaajan tilastot */
            var f = new FileInfo(tietokonetietofilu);

            if(f.Length==0)
            {
                if (tietokonetiedot == null)
                {
                    tietokonetiedot = new List<TietokoneenTiedot>();
                }

                TietokoneenTiedot tkt = new TietokoneenTiedot();
                
                tkt.tkEtunimi = "Tietokone";
                tkt.tkSukunimi = "Tietoinen";
                tkt.tkIka = 2022 - 1936;
                tietokonetiedot.Add(tkt);
                SerializeJSON2(tietokonetiedot);
            }
            /* Käynnistetään sovellus uudestaan jotta ComboBoxit ja tilastot päivittyvät */
            Application.Restart();
        }

        private void FrmRistinollaLataus(object sender, EventArgs e)
        {
            /*Varmistetaan ettei peli voi alkaa ilman pelaajia */
            if (String.IsNullOrEmpty(cbPelaajaNimiX.Text) || String.IsNullOrEmpty(cbPelaajaNimiO.Text))
            {
                btnAloitaPeli.Enabled = false;
            }

            btnLisaaPelaaja.Enabled = false;

            /* Kun sovellus latautuu luodaan pelaajatilastolle polku mikäli sitä ei ole olemassa.*/
            DirectoryInfo dr = Directory.CreateDirectory("c:\\temp");
            FileStream fs = null;
            if (File.Exists(pelaajatietofilu) == false)
            {
                fs = File.Create(pelaajatietofilu);
            }
            if (fs != null)
            {
                fs.Close();
            }
            /* Luodaan samalla lista johon pelaajat lisätään */
            if (pelaajatiedot == null)
            {
                pelaajatiedot = new List<PelaajienTiedot>();
            }
            if (File.Exists(pelaajatietofilu) == false)
            {
                File.Create(pelaajatietofilu);
                return;
            }
            /*Luodaan tietokoneelle samalla oma tiedostonsa, johon tallennetaan sen arvot */

            FileStream fst = null;
            if(File.Exists(tietokonetietofilu)==false)
            {
                fst = File.Create(tietokonetietofilu);
                
            }
            if(fst!=null)
            {
                fst.Close();
            }
            if(tietokonetiedot==null)
            {
                tietokonetiedot = new List<TietokoneenTiedot>();
            }
            if (File.Exists(tietokonetietofilu) == false)
            {
                File.Create(tietokonetietofilu);
                return;
            }
        }
        private void KayttajaSyote(object sender, KeyPressEventArgs e)
        {
            /* Käyttäjä voi syöttää vain kirjaimia nimeensä */
            if ((e.KeyChar < 'A' || e.KeyChar > 'Z') && (e.KeyChar < 'a' || e.KeyChar > 'z') && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void AloitaPeli(object sender, EventArgs e)
        {
            Form FrmPeli = new FrmPeli(this);
            FrmPeli.Show();
        }
        private void tbLeave(object sender, EventArgs e)
        {
            /* Pelaajan täytyy lisätä etu- ja sukunimi sekä ikä jotta se voidaan tallentaa*/

            if (String.IsNullOrEmpty(tbUusiEtunimi.Text))
            {
                btnLisaaPelaaja.Enabled = false;
            }
            if (String.IsNullOrEmpty(tbUusiSukunimi.Text))
            {
                btnLisaaPelaaja.Enabled = false;
            }
            else
            {
                btnLisaaPelaaja.Enabled = true;
            }
        }
        public void cbTietokonevastus_Click(object sender, EventArgs e)
        {
            /* Päivitetään tietokoneen tilastot näkyviin ja vaihdetaan pelaajaO nimeksi tietokone */

            if (cbTietokonevastus.Checked==true && !String.IsNullOrEmpty(cbPelaajaNimiX.Text))
            {
                cbPelaajaNimiO.Enabled = false;
                cbPelaajaNimiO.Text = "Tietokone";
                //cbPelaajaNimiO.Visible = false;
                btnAloitaPeli.Enabled = true;

                for (int i = 0; i < tietokonetiedot.Count; i++)
                {
                    if (tietokonetiedot[i].tkEtunimi == cbPelaajaNimiO.Text)
                    {
                        lbloHaviot.Text = "Häviöt: " + tietokonetiedot[i].tkHaviot;
                        lbloVoitot.Text = "Voitot: " + tietokonetiedot[i].tkVoitot;
                        lbloTasapelit.Text = "Tasapelit: " + tietokonetiedot[i].tkTasapelit;
                        lbloPeliaika.Text = "Peliaika: " + tietokonetiedot[i].tkPeliaika;
                        SerializeJSON2(tietokonetiedot);
                        break;
                    }
                }
            }
            /* Mikäli käyttäjä ei haluakkaan pelata tietokonetta vastaan, varmistetaan ettei hän voi pelata "Haamua" vastaan. */
            if(cbTietokonevastus.Checked==false)
            {
                cbPelaajaNimiO.Text = "";
                cbPelaajaNimiO.Enabled = true;
                btnAloitaPeli.Enabled = false;
            }
        }
        /* Kun pelaaja valitaan, päivitetään labeleihin suoraan hänen tilastonsa näkyviin*/
        private void cbPelaajaTiedotPaivittuu(object sender, EventArgs e)
        {
            if (pelaajatiedot != null && cbTietokonevastus.Checked == false)
            {
                for (int i = 0; i < pelaajatiedot.Count; i++)
                {
                    if (pelaajatiedot[i].PelaajaEtunimi == cbPelaajaNimiO.Text)
                    {
                        lbloHaviot.Text = "Häviöt: " + pelaajatiedot[i].PelaajaHaviot;
                        lbloVoitot.Text = "Voitot: " + pelaajatiedot[i].PelaajaVoitot;
                        lbloTasapelit.Text = "Tasapelit:" + pelaajatiedot[i].PelaajaTasapelit;
                        lbloPeliaika.Text = "Peliaika: " + pelaajatiedot[i].Peliaika;
                        SerializeJSON(pelaajatiedot);
                    }
                    if (pelaajatiedot[i].PelaajaEtunimi == cbPelaajaNimiX.Text)
                    {
                        lblxHaviot.Text = "Häviöt: " + pelaajatiedot[i].PelaajaHaviot;
                        lblxVoitot.Text = "Voitot: " + pelaajatiedot[i].PelaajaVoitot;
                        lblxTasapelit.Text = "Tasapelit:" + pelaajatiedot[i].PelaajaTasapelit;
                        lblxPeliaika.Text = "Peliaika: " + pelaajatiedot[i].Peliaika;
                        SerializeJSON(pelaajatiedot);
                    }
                }
               
            }
            /* Varmistetaan että pelaaja ei voi pelata itseään vastaan. */
            if (cbPelaajaNimiX.Text == cbPelaajaNimiO.Text)
            {
                btnAloitaPeli.Enabled = false;
            }
            else
            {
                btnAloitaPeli.Enabled = true;
            }
        }
        /* Käyttäjä ei voi tehdä "uusia" pelaajia suoraan ComboBoxeihin */
        private void cbPelaajaNimiO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =true;
        }
        /* Kun menusta valitaan ohjeet, info tai säännöt, näytetään käyttäjälle viestilaatikot */
        private void ohjeetKlikki(object sender, EventArgs e)
        {

            string sOhjeet = "Aloita peli valitsemalla pelaaja X sekä pelaaja O tai tietokonevastus." +
                " Mikäli et ole pelannut aikaisemmin, luo uusi pelaaja syöttämällä etu-ja sukunimesi sekä syntymävuotesi alla oleviin kenttiin." +
                " Mikäli 'Aloita Peli' nappi on harmaa, kannattaa varmistaa ettet pelaa itseäsi vastaan." +
                " Jos pelaat tietokonetta vastaan ja olet jo merkannut X, ole kärsivällinen ja anna tietokoneen pohtia hetken aikaa omaa siirtoaan :)";
            string ohjeOtsikko = "Ristinolla ohjeet";

            MessageBox.Show(sOhjeet, ohjeOtsikko);
        }

        private void SaannotKlikki(object sender, EventArgs e)
        {
            string sSaannot = "Ristinollan säännöt ovat hyvin yksinkertaiset. Voittaaksesi sinun tulee merkitä kolme X tai O merkkiä, riippuen kumpi pelaaja olet," +
                " vaaka- pysty- tai vinosuunnassa pelilaudalle. Mikäli kumpikaan pelaaja ei onnistu saamaan kolmea omaa merkkiä oikein ja pelilauta on täynnä" +
                " peli päättyy tasapeliin.";
            string saannotOtsikko = "Ristinollan säännöt";
            MessageBox.Show(sSaannot, saannotOtsikko);
        }

        private void infoKlikki(object sender, EventArgs e)
        {
            string info = "Tämän sovelluksen on luonut Karri Seppänen ETB22SP vuonna 2022." +
                " Tämä on Karrin ristinollaversio 5.0.1, tämän sekä edeltävien versioiden tekemiseen kului yhteensä noin. 50 tuntia, Version 4.5.2 voit löytää bittiavaruudesta.";
            string infoOtsikko = "Info";
            MessageBox.Show(info, infoOtsikko);
        }
    }  
}
