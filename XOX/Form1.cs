using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        int sira, xSkor = 0, oSkor = 0, hamle = 0;
        bool tercih;
        Button[] buttons;
        public Form1()
        {
            InitializeComponent();
            ReAktifButonlar(false);
            rbX.Checked = true;
        }
        private void Butonlar(object sender, EventArgs e)
        {
            //rbX.Checked = rbO.Checked = false;
            Button button = (Button)sender;
            if (cbRakip.Checked == true)
            {
                if (sira % 2 == 0)
                {
                    button.Text = "X";
                    button.BackgroundImage = Properties.Resources.XOX_X;
                    sira++;
                    PCTercih();
                }
                else
                {
                    button.Text = "O";
                    button.BackgroundImage = Properties.Resources.XOX_O;
                    sira++;
                    PCTercih();
                }
                OyunSonu(sira);
            }
            if (cbRakip.Checked == false)
            {
                if (sira % 2 == 0)
                {
                    button.Text = "X";
                    button.BackgroundImage = Properties.Resources.XOX_X;
                    sira++;
                }
                else
                {
                    button.Text = "O";
                    button.BackgroundImage = Properties.Resources.XOX_O;
                    sira++;
                }
                OyunSonu(sira);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = this.Controls.OfType<Button>().ToArray();
        }
        private void PCTercih()
        {
            if (hamle < 4)
            {
                Random rnd = new Random();
                int sayi = rnd.Next(4, 12);
                if ((buttons[sayi].Text == "") && (rbO.Checked == true) && sira != 10)
                {
                    buttons[sayi].BackgroundImage = Properties.Resources.XOX_X;
                    buttons[sayi].Text = "X";
                    buttons[sayi].Enabled = false;
                    sira++;
                    hamle++;
                }
                else if ((buttons[sayi].Text == "") && (rbX.Checked == true) && sira != 9)
                {
                    buttons[sayi].BackgroundImage = Properties.Resources.XOX_O;
                    buttons[sayi].Text = "O";
                    buttons[sayi].Enabled = false;
                    sira++;
                    hamle++;
                }
                else
                {
                    PCTercih();
                }
            }
            else if (hamle == 4)
            {
                OyunSonu(sira);
            }
        }
        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            hamle = 0;
            Temizle();
            ReAktifButonlar(false);
        }
        private void BaslangicTercihi()
        {
            rbX.Enabled = rbO.Enabled = false;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = true;
        }
        private void OyunSonu(int şira)
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "")
            {
                MessageBox.Show("Oyunu " + button1.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "")
            {
                MessageBox.Show("Oyunu " + button1.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "")
            {
                MessageBox.Show("Oyunu " + button7.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
            {
                MessageBox.Show("Oyunu " + button3.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "")
            {
                MessageBox.Show("Oyunu " + button1.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "")
            {
                MessageBox.Show("Oyunu " + button3.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button5.Text == button2.Text && button2.Text == button8.Text && button5.Text != "")
            {
                MessageBox.Show("Oyunu " + button5.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "")
            {
                MessageBox.Show("Oyunu " + button4.Text + " kazandı.");
                ReAktifButonlar(false);
                Tabela();
            }
            else if ((tercih == true && sira == 9) || (tercih == false && sira == 10))
            {
                MessageBox.Show("Oyun Berabere");
                ReAktifButonlar(false);
                Tabela();
            }
        }
        private void btnSifirla_Click(object sender, EventArgs e)
        {
            xSkor = oSkor = 0;
            txtX.Text = xSkor.ToString();
            txtO.Text = oSkor.ToString();
            ReAktifButonlar(false);
            Temizle();
        }
        private void Tabela()
        {
            if ((tercih == true && sira % 2 == 1) || tercih == false && sira % 2 == 1)
            {
                xSkor++;
                txtX.Text = xSkor.ToString();
            }
            else
            {
                oSkor++;
                txtO.Text = oSkor.ToString();
            }
        }
        private void btnKurallar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oyunun başlamasını XOX butonu sağlar \nOyun tamamlanmadan Yeni Oyun butonuna basılırsa skorlarda değişiklik olmaz. \nSıfırla butonu tüm skorları ve oyunu sıfırlar. \nOyuna başladıktan sonra oyun modunudu değiştiremezsiniz. \nOyun Modunu değiştirmek için sıfırlama yapmak zorundasınız.\nBilgisayara Karşı oyun modu seçildiğinde oyuna siz başlarsınız");
        }
        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (rbX.Checked)
            {
                tercih = true;
                sira = 0;
                BaslangicTercihi();
            }
            else if (rbO.Checked)
            {
                tercih = false;
                sira = 1;
                BaslangicTercihi();
            }
            else
            {
                MessageBox.Show("Başlangıç tercihi yapılmadan oyuna başlanmaz.");
            }
        }
        private void Temizle()
        {
            button1.BackgroundImage = button2.BackgroundImage = button3.BackgroundImage = button4.BackgroundImage = button5.BackgroundImage = button6.BackgroundImage = button7.BackgroundImage = button8.BackgroundImage = button9.BackgroundImage = null;
            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = "";
        }
        private void ReAktifButonlar(bool aktif)
        {
            rbX.Enabled = rbO.Enabled = btnBasla.Enabled = true;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = aktif;
        }
    }
}
