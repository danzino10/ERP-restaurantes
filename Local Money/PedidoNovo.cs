﻿using Local_Money.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money
{
    public partial class PedidoNovo : Form
    {
        public PedidoNovo()
        {
            InitializeComponent();
        }

        private void pb_pagar_Click(object sender, EventArgs e)
        {

        }
        
        private void btn_add_prod_Click(object sender, EventArgs e)
        {
            ProdutoListado produto = new ProdutoListado();

            p_lista_produtos.Controls.Add(produto.CriarProdutoListado());
        }
    }
}
