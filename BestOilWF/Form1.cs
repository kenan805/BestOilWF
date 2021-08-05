using BestOilWF.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOilWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonVolume.Enabled = true;
            radioButtonPrice.Enabled = true;
            var benzinPrice = (cb_Benzin.SelectedItem as Benzin)?.Price;
            if (benzinPrice != null)
                tb_Price.Text = benzinPrice.ToString();
            else
                MessageBox.Show("Item not Benzin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Benzin dizel = new() { Name = "Dizel", Price = 0.90 };
            Benzin ai92 = new() { Name = "Ai 92", Price = 1.20 };
            Benzin ai95 = new() { Name = "Ai 95", Price = 1.45 };
            Benzin ai98 = new() { Name = "Ai 98", Price = 1.80 };
            cb_Benzin.Items.Add(dizel);
            cb_Benzin.Items.Add(ai92);
            cb_Benzin.Items.Add(ai95);
            cb_Benzin.Items.Add(ai98);
            cb_Benzin.DisplayMember = "Name";

            CafeProduct hotdog = new() { Name = "Hot-dog", Price = 1.2 };
            CafeProduct gamburger = new() { Name = "Gamburger", Price = 4.50 };
            CafeProduct fri = new() { Name = "Fri", Price = 0.80 };
            CafeProduct cocaCola = new() { Name = "Coca-Cola", Price = 1.4 };
            cb_Hotdog.Text = hotdog.ToString();
            cb_Gamburger.Text = gamburger.ToString();
            cb_Fri.Text = fri.ToString();
            cb_cocacola.Text = cocaCola.ToString();
            tb_Item1_Price.Text = hotdog.Price.ToString();
            tb_Item2_Price.Text = gamburger.Price.ToString();
            tb_Item3_Price.Text = fri.Price.ToString();
            tb_Item4_Price.Text = cocaCola.Price.ToString();

        }
        private void Rb_Volume_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVolume.Checked == true)
            {
                tbVolumeRb.Enabled = true;
                tbPriceRb.Text = string.Empty;
            }
            else
            {
                tbVolumeRb.Enabled = false;
                tbVolumeRb.Text = string.Empty;
            }
        }
        private void Rb_Price_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPrice.Checked == true)
            {
                tbPriceRb.Enabled = true;
                tbVolumeRb.Text = string.Empty;
            }
            else
            {
                tbPriceRb.Enabled = false;
                tbPriceRb.Text = string.Empty;
            }
        }

        private void Tb_VolumeRb_TextChanged(object sender, EventArgs e)
        {
            tbVolumeRb.Text = tbVolumeRb.OnlyDecimalNumberTextBox();
            if (tbVolumeRb.Text == string.Empty || tbVolumeRb.Text == "0")
                lbl_Benzin_All_Price.Text = "0,00";
            else
                lbl_Benzin_All_Price.Text = (double.Parse(tbVolumeRb.Text) * double.Parse(tb_Price.Text)).ToString();
        }
        private void Tb_PriceRb_TextChanged(object sender, EventArgs e)
        {
            tbPriceRb.Text = tbPriceRb.OnlyDecimalNumberTextBox();
            if (tbPriceRb.Text == string.Empty || tbPriceRb.Text == "0")
                lbl_Benzin_All_Price.Text = "0,00";
            else
                lbl_Benzin_All_Price.Text = double.Parse(tbPriceRb.Text).ToString();

        }
        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            var listCheckbox = gb_Cafe.Controls.OfType<CheckBox>().ToList();
            var listNumericUpDown = gb_Cafe.Controls.OfType<NumericUpDown>().ToList();
            for (int i = 0; i < listCheckbox.Count; i++)
            {
                if (listCheckbox[i].Checked == true)
                    listNumericUpDown[i].Enabled = true;
                else
                {
                    listNumericUpDown[i].Enabled = false;
                    listNumericUpDown[i].Value = 0;
                }
            }
        }
        private void Nud_ValueChanged(object sender, EventArgs e)
        {
            double CafeAllPrice = 0;
            int productCount = 0;
            var listTextBoxPrice = gb_Cafe.Controls.OfType<TextBox>().ToList();
            var listNumericUpDown = gb_Cafe.Controls.OfType<NumericUpDown>().ToList();

            for (int i = 0; i < listNumericUpDown.Count; i++)
            {
                productCount = int.Parse(listNumericUpDown[i].Value.ToString());
                CafeAllPrice += productCount * double.Parse(listTextBoxPrice[i].Text);
            }
            lbl_Cafe_All_Price.Text = CafeAllPrice.ToString();
        }
        private void Btn_Calculate_Click(object sender, EventArgs e) => lbl_All_Price.Text = (double.Parse(lbl_Benzin_All_Price.Text) + double.Parse(lbl_Cafe_All_Price.Text)).ToString();


        private void Btn_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void Btn_Exit_MouseHover(object sender, EventArgs e) => btn_Exit.BackColor = Color.DarkRed;

        private void Btn_Exit_MouseLeave(object sender, EventArgs e) => btn_Exit.BackColor = Color.Transparent;
    }
}
