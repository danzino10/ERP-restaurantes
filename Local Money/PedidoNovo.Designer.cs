
namespace Local_Money
{
    partial class PedidoNovo
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
            this.p_pedido = new System.Windows.Forms.Panel();
            this.p_lista_produtos = new System.Windows.Forms.Panel();
            this.p_total = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_total_valor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_codpromo_valor = new System.Windows.Forms.Label();
            this.lbl_promodia_valor = new System.Windows.Forms.Label();
            this.lbl_subtotal_valor = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.cb_codpromo = new System.Windows.Forms.CheckBox();
            this.cb_promodia = new System.Windows.Forms.CheckBox();
            this.lbl_iva = new System.Windows.Forms.Label();
            this.lbl_subtotal = new System.Windows.Forms.Label();
            this.p_botoes_pedido = new System.Windows.Forms.Panel();
            this.pb_pagar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.p_cabecalho_pedido = new System.Windows.Forms.Panel();
            this.p_numero_pedido = new System.Windows.Forms.Panel();
            this.lbl_pedido = new System.Windows.Forms.Label();
            this.p_mesa_cabecalho = new System.Windows.Forms.Panel();
            this.lbl_mesa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p_navegador = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flp_cardapio = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            this.btn_salvar = new ePOSOne.btnProduct.Button_WOC();
            this.p_pedido.SuspendLayout();
            this.p_total.SuspendLayout();
            this.p_botoes_pedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.p_cabecalho_pedido.SuspendLayout();
            this.p_numero_pedido.SuspendLayout();
            this.p_mesa_cabecalho.SuspendLayout();
            this.p_navegador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_pedido
            // 
            this.p_pedido.Controls.Add(this.p_lista_produtos);
            this.p_pedido.Controls.Add(this.p_total);
            this.p_pedido.Controls.Add(this.p_cabecalho_pedido);
            this.p_pedido.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_pedido.Location = new System.Drawing.Point(424, 0);
            this.p_pedido.Name = "p_pedido";
            this.p_pedido.Size = new System.Drawing.Size(320, 501);
            this.p_pedido.TabIndex = 0;
            // 
            // p_lista_produtos
            // 
            this.p_lista_produtos.AutoScroll = true;
            this.p_lista_produtos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_lista_produtos.Location = new System.Drawing.Point(0, 84);
            this.p_lista_produtos.Name = "p_lista_produtos";
            this.p_lista_produtos.Size = new System.Drawing.Size(320, 245);
            this.p_lista_produtos.TabIndex = 2;
            // 
            // p_total
            // 
            this.p_total.Controls.Add(this.panel2);
            this.p_total.Controls.Add(this.lbl_total_valor);
            this.p_total.Controls.Add(this.label3);
            this.p_total.Controls.Add(this.lbl_codpromo_valor);
            this.p_total.Controls.Add(this.lbl_promodia_valor);
            this.p_total.Controls.Add(this.lbl_subtotal_valor);
            this.p_total.Controls.Add(this.lbl_total);
            this.p_total.Controls.Add(this.cb_codpromo);
            this.p_total.Controls.Add(this.cb_promodia);
            this.p_total.Controls.Add(this.lbl_iva);
            this.p_total.Controls.Add(this.lbl_subtotal);
            this.p_total.Controls.Add(this.p_botoes_pedido);
            this.p_total.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_total.Location = new System.Drawing.Point(0, 329);
            this.p_total.Name = "p_total";
            this.p_total.Size = new System.Drawing.Size(320, 172);
            this.p_total.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 2);
            this.panel2.TabIndex = 12;
            // 
            // lbl_total_valor
            // 
            this.lbl_total_valor.AutoSize = true;
            this.lbl_total_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_valor.Location = new System.Drawing.Point(180, 87);
            this.lbl_total_valor.Name = "lbl_total_valor";
            this.lbl_total_valor.Size = new System.Drawing.Size(42, 20);
            this.lbl_total_valor.TabIndex = 11;
            this.lbl_total_valor.Text = "kz 0";
            this.lbl_total_valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(238, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "14%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_codpromo_valor
            // 
            this.lbl_codpromo_valor.AutoSize = true;
            this.lbl_codpromo_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codpromo_valor.Location = new System.Drawing.Point(238, 47);
            this.lbl_codpromo_valor.Name = "lbl_codpromo_valor";
            this.lbl_codpromo_valor.Size = new System.Drawing.Size(31, 16);
            this.lbl_codpromo_valor.TabIndex = 9;
            this.lbl_codpromo_valor.Text = "kz 0";
            this.lbl_codpromo_valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_promodia_valor
            // 
            this.lbl_promodia_valor.AutoSize = true;
            this.lbl_promodia_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_promodia_valor.Location = new System.Drawing.Point(238, 27);
            this.lbl_promodia_valor.Name = "lbl_promodia_valor";
            this.lbl_promodia_valor.Size = new System.Drawing.Size(31, 16);
            this.lbl_promodia_valor.TabIndex = 8;
            this.lbl_promodia_valor.Text = "kz 0";
            this.lbl_promodia_valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_subtotal_valor
            // 
            this.lbl_subtotal_valor.AutoSize = true;
            this.lbl_subtotal_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subtotal_valor.Location = new System.Drawing.Point(238, 5);
            this.lbl_subtotal_valor.Name = "lbl_subtotal_valor";
            this.lbl_subtotal_valor.Size = new System.Drawing.Size(35, 16);
            this.lbl_subtotal_valor.TabIndex = 7;
            this.lbl_subtotal_valor.Text = "kz 0";
            this.lbl_subtotal_valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_subtotal_valor.TextChanged += new System.EventHandler(this.lbl_subtotal_valor_TextChanged);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(32, 87);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(49, 20);
            this.lbl_total.TabIndex = 6;
            this.lbl_total.Text = "Total";
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_codpromo
            // 
            this.cb_codpromo.AutoSize = true;
            this.cb_codpromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_codpromo.Location = new System.Drawing.Point(16, 46);
            this.cb_codpromo.Name = "cb_codpromo";
            this.cb_codpromo.Size = new System.Drawing.Size(149, 20);
            this.cb_codpromo.TabIndex = 5;
            this.cb_codpromo.Text = "Código promocional";
            this.cb_codpromo.UseVisualStyleBackColor = true;
            // 
            // cb_promodia
            // 
            this.cb_promodia.AutoSize = true;
            this.cb_promodia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_promodia.Location = new System.Drawing.Point(16, 23);
            this.cb_promodia.Name = "cb_promodia";
            this.cb_promodia.Size = new System.Drawing.Size(131, 20);
            this.cb_promodia.TabIndex = 4;
            this.cb_promodia.Text = "Promoção do dia";
            this.cb_promodia.UseVisualStyleBackColor = true;
            // 
            // lbl_iva
            // 
            this.lbl_iva.AutoSize = true;
            this.lbl_iva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iva.Location = new System.Drawing.Point(33, 68);
            this.lbl_iva.Name = "lbl_iva";
            this.lbl_iva.Size = new System.Drawing.Size(91, 16);
            this.lbl_iva.TabIndex = 3;
            this.lbl_iva.Text = "Imposto  (IVA)";
            this.lbl_iva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_subtotal
            // 
            this.lbl_subtotal.AutoSize = true;
            this.lbl_subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_subtotal.Location = new System.Drawing.Point(33, 5);
            this.lbl_subtotal.Name = "lbl_subtotal";
            this.lbl_subtotal.Size = new System.Drawing.Size(65, 16);
            this.lbl_subtotal.TabIndex = 1;
            this.lbl_subtotal.Text = "Subtotal";
            this.lbl_subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_botoes_pedido
            // 
            this.p_botoes_pedido.BackColor = System.Drawing.Color.DarkSlateGray;
            this.p_botoes_pedido.Controls.Add(this.pb_pagar);
            this.p_botoes_pedido.Controls.Add(this.button_WOC1);
            this.p_botoes_pedido.Controls.Add(this.pictureBox1);
            this.p_botoes_pedido.Controls.Add(this.btn_salvar);
            this.p_botoes_pedido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_botoes_pedido.Location = new System.Drawing.Point(0, 113);
            this.p_botoes_pedido.Name = "p_botoes_pedido";
            this.p_botoes_pedido.Size = new System.Drawing.Size(320, 59);
            this.p_botoes_pedido.TabIndex = 0;
            // 
            // pb_pagar
            // 
            this.pb_pagar.Image = global::Local_Money.Properties.Resources.credit_card;
            this.pb_pagar.Location = new System.Drawing.Point(166, 15);
            this.pb_pagar.Name = "pb_pagar";
            this.pb_pagar.Size = new System.Drawing.Size(32, 32);
            this.pb_pagar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_pagar.TabIndex = 3;
            this.pb_pagar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Local_Money.Properties.Resources.floppy_disk;
            this.pictureBox1.Location = new System.Drawing.Point(36, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // p_cabecalho_pedido
            // 
            this.p_cabecalho_pedido.BackColor = System.Drawing.Color.DarkSlateGray;
            this.p_cabecalho_pedido.Controls.Add(this.p_numero_pedido);
            this.p_cabecalho_pedido.Controls.Add(this.p_mesa_cabecalho);
            this.p_cabecalho_pedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_cabecalho_pedido.Location = new System.Drawing.Point(0, 0);
            this.p_cabecalho_pedido.Name = "p_cabecalho_pedido";
            this.p_cabecalho_pedido.Size = new System.Drawing.Size(320, 84);
            this.p_cabecalho_pedido.TabIndex = 0;
            // 
            // p_numero_pedido
            // 
            this.p_numero_pedido.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.p_numero_pedido.Controls.Add(this.lbl_pedido);
            this.p_numero_pedido.Location = new System.Drawing.Point(114, 45);
            this.p_numero_pedido.Name = "p_numero_pedido";
            this.p_numero_pedido.Size = new System.Drawing.Size(206, 27);
            this.p_numero_pedido.TabIndex = 1;
            // 
            // lbl_pedido
            // 
            this.lbl_pedido.AutoSize = true;
            this.lbl_pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_pedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pedido.Location = new System.Drawing.Point(0, 0);
            this.lbl_pedido.Name = "lbl_pedido";
            this.lbl_pedido.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbl_pedido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_pedido.Size = new System.Drawing.Size(107, 29);
            this.lbl_pedido.TabIndex = 0;
            this.lbl_pedido.Text = "Pedido nº";
            this.lbl_pedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_mesa_cabecalho
            // 
            this.p_mesa_cabecalho.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.p_mesa_cabecalho.Controls.Add(this.lbl_mesa);
            this.p_mesa_cabecalho.Location = new System.Drawing.Point(0, 12);
            this.p_mesa_cabecalho.Name = "p_mesa_cabecalho";
            this.p_mesa_cabecalho.Size = new System.Drawing.Size(206, 27);
            this.p_mesa_cabecalho.TabIndex = 0;
            // 
            // lbl_mesa
            // 
            this.lbl_mesa.AutoSize = true;
            this.lbl_mesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_mesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mesa.Location = new System.Drawing.Point(0, 0);
            this.lbl_mesa.Name = "lbl_mesa";
            this.lbl_mesa.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbl_mesa.Size = new System.Drawing.Size(86, 29);
            this.lbl_mesa.TabIndex = 0;
            this.lbl_mesa.Text = "Mesa X";
            this.lbl_mesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(422, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 501);
            this.panel1.TabIndex = 1;
            // 
            // p_navegador
            // 
            this.p_navegador.Controls.Add(this.textBox1);
            this.p_navegador.Controls.Add(this.panel4);
            this.p_navegador.Controls.Add(this.button1);
            this.p_navegador.Controls.Add(this.btn_voltar);
            this.p_navegador.Controls.Add(this.panel3);
            this.p_navegador.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_navegador.Location = new System.Drawing.Point(0, 0);
            this.p_navegador.Name = "p_navegador";
            this.p_navegador.Size = new System.Drawing.Size(422, 50);
            this.p_navegador.TabIndex = 2;
            this.p_navegador.Paint += new System.Windows.Forms.PaintEventHandler(this.p_navegador_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Local_Money.Properties.Resources.arrow_2;
            this.button1.Location = new System.Drawing.Point(372, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 48);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn_voltar
            // 
            this.btn_voltar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_voltar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_voltar.Enabled = false;
            this.btn_voltar.FlatAppearance.BorderSize = 0;
            this.btn_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_voltar.Image = global::Local_Money.Properties.Resources.arrow_1;
            this.btn_voltar.Location = new System.Drawing.Point(0, 0);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(50, 48);
            this.btn_voltar.TabIndex = 1;
            this.btn_voltar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 2);
            this.panel3.TabIndex = 0;
            // 
            // flp_cardapio
            // 
            this.flp_cardapio.AutoScroll = true;
            this.flp_cardapio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_cardapio.Location = new System.Drawing.Point(0, 50);
            this.flp_cardapio.Name = "flp_cardapio";
            this.flp_cardapio.Size = new System.Drawing.Size(422, 451);
            this.flp_cardapio.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(56, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 2);
            this.panel4.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(99, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 33);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_WOC1
            // 
            this.button_WOC1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button_WOC1.BorderColor = System.Drawing.Color.Black;
            this.button_WOC1.ButtonColor = System.Drawing.Color.DarkSlateGray;
            this.button_WOC1.FlatAppearance.BorderSize = 0;
            this.button_WOC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC1.Location = new System.Drawing.Point(143, 3);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_WOC1.OnHoverTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_WOC1.Size = new System.Drawing.Size(143, 53);
            this.button_WOC1.TabIndex = 6;
            this.button_WOC1.Text = "             Pagar agora";
            this.button_WOC1.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_WOC1.UseVisualStyleBackColor = false;
            // 
            // btn_salvar
            // 
            this.btn_salvar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_salvar.BorderColor = System.Drawing.Color.Black;
            this.btn_salvar.ButtonColor = System.Drawing.Color.DarkSlateGray;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar.Location = new System.Drawing.Point(16, 3);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.OnHoverBorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_salvar.OnHoverButtonColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_salvar.OnHoverTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_salvar.Size = new System.Drawing.Size(117, 53);
            this.btn_salvar.TabIndex = 4;
            this.btn_salvar.Text = "          Salvar";
            this.btn_salvar.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_salvar.UseVisualStyleBackColor = false;
            // 
            // PedidoNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 501);
            this.Controls.Add(this.flp_cardapio);
            this.Controls.Add(this.p_navegador);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p_pedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(744, 501);
            this.Name = "PedidoNovo";
            this.Text = "02001";
            this.Load += new System.EventHandler(this.PedidoNovo_Load);
            this.p_pedido.ResumeLayout(false);
            this.p_total.ResumeLayout(false);
            this.p_total.PerformLayout();
            this.p_botoes_pedido.ResumeLayout(false);
            this.p_botoes_pedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.p_cabecalho_pedido.ResumeLayout(false);
            this.p_numero_pedido.ResumeLayout(false);
            this.p_numero_pedido.PerformLayout();
            this.p_mesa_cabecalho.ResumeLayout(false);
            this.p_mesa_cabecalho.PerformLayout();
            this.p_navegador.ResumeLayout(false);
            this.p_navegador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_pedido;
        private System.Windows.Forms.Panel p_cabecalho_pedido;
        private System.Windows.Forms.Panel p_mesa_cabecalho;
        private System.Windows.Forms.Panel p_numero_pedido;
        private System.Windows.Forms.Label lbl_pedido;
        private System.Windows.Forms.Label lbl_mesa;
        private System.Windows.Forms.Panel p_total;
        private System.Windows.Forms.Panel p_botoes_pedido;
        
        private System.Windows.Forms.PictureBox pb_pagar;
        private System.Windows.Forms.Label lbl_total_valor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_codpromo_valor;
        private System.Windows.Forms.Label lbl_promodia_valor;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.CheckBox cb_codpromo;
        private System.Windows.Forms.CheckBox cb_promodia;
        private System.Windows.Forms.Label lbl_iva;
        private System.Windows.Forms.Label lbl_subtotal;
        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ePOSOne.btnProduct.Button_WOC btn_salvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel p_navegador;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_voltar;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.Panel p_lista_produtos;
        public System.Windows.Forms.Label lbl_subtotal_valor;
        public System.Windows.Forms.FlowLayoutPanel flp_cardapio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel4;
    }
}