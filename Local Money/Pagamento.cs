using Local_Money.modelos;
using NPOI.SS.Util;
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
using System.Data.SqlClient;

namespace Local_Money
{
    public partial class Pagamento : Form
    {

        public double Subtotal, Total, Impostos, Descontos, Entregue, Troco, Falta;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources._004_chef, new Point(380, 10));
            e.Graphics.DrawString("FoodGest LDA.", new Font("Roboto", 20, FontStyle.Bold), Brushes.Black, new Point(320,90));
            e.Graphics.DrawString("NIF: 002869194OE033", new Font("Roboto", 12, FontStyle.Bold), Brushes.Black, new Point(335, 130));
            e.Graphics.DrawString("Rua Samuel Bernardo nº 18, 1º C", new Font("Roboto", 12, FontStyle.Bold), Brushes.Black, new Point(300, 150));

            e.Graphics.DrawString("_________________________________________________________________________________________________________________________________________________________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(5, 155));

            e.Graphics.DrawString("Recibo nº: ", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 180));
            e.Graphics.DrawString("Registado por:", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 200));
            e.Graphics.DrawString("Cliente:", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 220));
            e.Graphics.DrawString("Data: ", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 240));

            e.Graphics.DrawString("00000", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 180));
            e.Graphics.DrawString("Dara Carvalho", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 200));
            e.Graphics.DrawString("", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 220));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString(), new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 240));

            e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(5, 260));

            e.Graphics.DrawString("Produto", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(10, 280));
            e.Graphics.DrawString("Quantidade", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(280, 280));
            e.Graphics.DrawString("Preço un.", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(400, 280));
            e.Graphics.DrawString("Preço tot.", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(600, 280));

            int y = 320;
            PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];
            
            foreach(string item in pn.nomes)
            {
                
                e.Graphics.DrawString(item, new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(10, y));
                y += 40;
            }

            y = 320;
            foreach (int item in pn.quantidades)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(280, y));
                y += 40;

            }

            y = 320;
            foreach (double item in pn.subtotais)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(400, y));
                y += 40;

            }

            y = 320;
            foreach (double item in pn.totais)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(600, y));
                y += 40;

            }

            /*
            foreach (var c in from Control c in pn.p_lista_produtos.Controls
                              where c is Panel
                              select c)
            {
                foreach (var co in from Control co in c.Controls
                                   where co is Label
                                   select co)
                {
                    e.Graphics.DrawString(co.Text, new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    x += 230;
                }

                y += 30;
            }
            */

            e.Graphics.DrawString("Subtotal", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 200));
            e.Graphics.DrawString("Iva (14%)", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 240));
            e.Graphics.DrawString("Descontos", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 280));
            e.Graphics.DrawString("Total", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(30, y + 320));
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            DecimalFormat df = new DecimalFormat("#.##");

            lbl_subtotal.Text = "Kz " + df.Format(Subtotal);
            lbl_total.Text = "Kz " + df.Format(Total);
            lbl_impostos.Text = "Kz " + df.Format((Subtotal * 14 / 100));
            lbl_descontos.Text = "Kz " + df.Format(Descontos);
            lbl_entregue.Text = "Kz " + df.Format(0);
            lbl_troco.Text = "Kz " + df.Format(0);
            lbl_falta.Text = "Kz " + df.Format(Total);
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        public Pagamento()
        {
            InitializeComponent();
             
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dinheiro_Click(object sender, EventArgs e)
        {
            PagamentoDinheiro pd = new PagamentoDinheiro();
            pd.ShowDialog();
        }
    }
}
