using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money.modelos
{
    class CartaoCategoriaCardapio
    {
        Panel PainelCartao  = new Panel
        {
            Width = 205,
            Height = 160,
           
        };

        Panel PainelInferior = new Panel
        {
            Width = 150,
            Height = 125,
            Location = new System.Drawing.Point(22, 30),
            BackColor = System.Drawing.Color.DarkSlateGray,
        };

        Panel PainelSuperior = new Panel
        {
            Width = 110,
            Height = 110,
            Location = new System.Drawing.Point(39, 13),
            BackColor = System.Drawing.SystemColors.MenuHighlight,
        };

        PictureBox IconeCategoria = new PictureBox
        {
            Width = 64,
            Height = 64,
            Location = new System.Drawing.Point(22,20),
            Image = global::Local_Money.Properties.Resources._004_chef,
    };

        Label NomeCategoria = new Label
        {
            ForeColor = System.Drawing.SystemColors.Control,
            Dock = DockStyle.Bottom,
            Padding = new System.Windows.Forms.Padding(10, 0, 0, 5),
            //Font = ,
            Text = "Categoria"
        };

        public CartaoCategoriaCardapio ()
        {
            PainelSuperior.Controls.Add(IconeCategoria);
            PainelInferior.Controls.Add(NomeCategoria);
            PainelCartao.Controls.Add(PainelSuperior);
            PainelCartao.Controls.Add(PainelInferior);
            
        }

        public Panel Criar ()
        {
            return PainelCartao;
        }
    }
}
