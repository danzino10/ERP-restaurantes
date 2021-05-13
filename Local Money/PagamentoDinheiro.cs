using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using NPOI.SS.Util;

namespace Local_Money
{
    public partial class PagamentoDinheiro : Form
    {
        string Montante;
        double ss;
        public PagamentoDinheiro()
        {
            InitializeComponent();
        }

        private void txt_montante_Leave(object sender, EventArgs e)
        {
            
        }

        private void btn_converter_Click(object sender, EventArgs e)
        {
            Montante = txt_montante.Text;
            char[] mon = new char[Montante.Length];
            mon = Montante.ToArray();

            
            
            if(mon[0] == '0')
            {
                txt_montante.Text = "Valor inválido!";
            }
            else
            {
                ss = double.Parse(txt_montante.Text);
                ss = ss * 0.01;
                
                
                if (Montante.Length == 1)
                {
                    Montante = Montante.Insert(0, "0,0");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 2)
                {
                    Montante = Montante.Insert(0, "0,");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 3)
                {
                    Montante = Montante.Insert(1, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 4)
                {
                    Montante = Montante.Insert(2, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 5)
                {
                    Montante = Montante.Insert(3, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 6)
                {
                    Montante = Montante.Insert(1, ".");
                    Montante = Montante.Insert(5, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 7)
                {
                    Montante = Montante.Insert(2, ".");
                    Montante = Montante.Insert(6, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 8)
                {
                    Montante = Montante.Insert(3, ".");
                    Montante = Montante.Insert(7, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 9)
                {
                    Montante = Montante.Insert(1, ".");
                    Montante = Montante.Insert(5, ".");
                    Montante = Montante.Insert(9, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 10)
                {
                    Montante = Montante.Insert(2, ".");
                    Montante = Montante.Insert(6, ".");
                    Montante = Montante.Insert(10, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length == 11)
                {
                    Montante = Montante.Insert(3, ".");
                    Montante = Montante.Insert(7, ".");
                    Montante = Montante.Insert(11, ",");
                    txt_montante.Text = Montante;
                }
                else if (Montante.Length > 11)
                {
                    txt_montante.Clear();
                }
                btn_confirmar.Enabled = true;
            }

            
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_1.Text;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_2.Text;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_3.Text;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_4.Text;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_5.Text;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_6.Text;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_7.Text;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_8.Text;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_9.Text;
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_0.Text;
        }

        private void btn_00_Click(object sender, EventArgs e)
        {
            txt_montante.Text = txt_montante.Text + btn_00.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_montante.Clear();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            
            
            DecimalFormat df = new DecimalFormat("#.##");

            Pagamento p = (Pagamento)Application.OpenForms[3];
            p.Entregue += ss;
            p.lbl_entregue.Text = "Kz " + df.Format(p.Entregue);
                        

            if(p.Total < p.Entregue)
            {
                p.Troco = p.Entregue - p.Total;
                p.lbl_troco.Text = "Kz " + df.Format(p.Troco);

                p.Falta = 0;
                p.lbl_falta.Text = "Kz " + df.Format(p.Falta);

                p.btn_confirmar.Enabled = true;
            }
            else if (p.Total > p.Entregue)
            {
                p.Falta = p.Total - p.Entregue;
                p.lbl_falta.Text = "Kz " + df.Format(p.Falta);

                p.Troco = 0;
                p.lbl_troco.Text = "Kz " + df.Format(p.Troco);
            }
            else
            {
                p.Falta = 0;
                p.lbl_falta.Text = "Kz " + df.Format(p.Falta);

                p.Troco = 0;
                p.lbl_troco.Text = "Kz " + df.Format(p.Troco);

                p.btn_confirmar.Enabled = true;
            }
            this.Close();
        }
    }
}
