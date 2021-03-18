
namespace Local_Money
{
    partial class AdicionarProduto
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
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.cb_menu = new System.Windows.Forms.ComboBox();
            this.cb_categoria = new System.Windows.Forms.ComboBox();
            this.txt_preco = new System.Windows.Forms.TextBox();
            this.pb_foto = new System.Windows.Forms.PictureBox();
            this.btn_foto = new System.Windows.Forms.Button();
            this.txt_descricao = new System.Windows.Forms.TextBox();
            this.btn_adicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(28, 77);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(223, 20);
            this.txt_nome.TabIndex = 0;
            this.txt_nome.Text = "Nome do produto";
            this.txt_nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_nome.Click += new System.EventHandler(this.txt_nome_Click);
            // 
            // cb_menu
            // 
            this.cb_menu.FormattingEnabled = true;
            this.cb_menu.Location = new System.Drawing.Point(28, 103);
            this.cb_menu.Name = "cb_menu";
            this.cb_menu.Size = new System.Drawing.Size(223, 21);
            this.cb_menu.TabIndex = 1;
            this.cb_menu.Text = "Tipo de menu";
            this.cb_menu.SelectedIndexChanged += new System.EventHandler(this.cb_menu_SelectedIndexChanged);
            // 
            // cb_categoria
            // 
            this.cb_categoria.FormattingEnabled = true;
            this.cb_categoria.Location = new System.Drawing.Point(28, 130);
            this.cb_categoria.Name = "cb_categoria";
            this.cb_categoria.Size = new System.Drawing.Size(223, 21);
            this.cb_categoria.TabIndex = 2;
            this.cb_categoria.Text = "Tipo de categoria";
            this.cb_categoria.SelectedIndexChanged += new System.EventHandler(this.cb_categoria_SelectedIndexChanged);
            // 
            // txt_preco
            // 
            this.txt_preco.Location = new System.Drawing.Point(28, 157);
            this.txt_preco.Name = "txt_preco";
            this.txt_preco.Size = new System.Drawing.Size(223, 20);
            this.txt_preco.TabIndex = 3;
            this.txt_preco.Text = "Preço do produto";
            this.txt_preco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_preco.Click += new System.EventHandler(this.txt_preco_Click);
            this.txt_preco.Leave += new System.EventHandler(this.txt_preco_Leave);
            // 
            // pb_foto
            // 
            this.pb_foto.Location = new System.Drawing.Point(292, 77);
            this.pb_foto.Name = "pb_foto";
            this.pb_foto.Size = new System.Drawing.Size(294, 275);
            this.pb_foto.TabIndex = 5;
            this.pb_foto.TabStop = false;
            // 
            // btn_foto
            // 
            this.btn_foto.Location = new System.Drawing.Point(395, 47);
            this.btn_foto.Name = "btn_foto";
            this.btn_foto.Size = new System.Drawing.Size(85, 24);
            this.btn_foto.TabIndex = 6;
            this.btn_foto.Text = "Escolher foto";
            this.btn_foto.UseVisualStyleBackColor = true;
            this.btn_foto.Click += new System.EventHandler(this.btn_foto_Click);
            // 
            // txt_descricao
            // 
            this.txt_descricao.Location = new System.Drawing.Point(28, 233);
            this.txt_descricao.Multiline = true;
            this.txt_descricao.Name = "txt_descricao";
            this.txt_descricao.Size = new System.Drawing.Size(223, 119);
            this.txt_descricao.TabIndex = 7;
            this.txt_descricao.Text = "Descrição";
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Location = new System.Drawing.Point(28, 386);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(154, 58);
            this.btn_adicionar.TabIndex = 8;
            this.btn_adicionar.Text = "Adicionar produto";
            this.btn_adicionar.UseVisualStyleBackColor = true;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // AdicionarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 498);
            this.Controls.Add(this.btn_adicionar);
            this.Controls.Add(this.txt_descricao);
            this.Controls.Add(this.btn_foto);
            this.Controls.Add(this.pb_foto);
            this.Controls.Add(this.txt_preco);
            this.Controls.Add(this.cb_categoria);
            this.Controls.Add(this.cb_menu);
            this.Controls.Add(this.txt_nome);
            this.Name = "AdicionarProduto";
            this.Text = "AdicionarProduto";
            this.Load += new System.EventHandler(this.AdicionarProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.ComboBox cb_menu;
        private System.Windows.Forms.ComboBox cb_categoria;
        private System.Windows.Forms.TextBox txt_preco;
        private System.Windows.Forms.PictureBox pb_foto;
        private System.Windows.Forms.Button btn_foto;
        private System.Windows.Forms.TextBox txt_descricao;
        private System.Windows.Forms.Button btn_adicionar;
    }
}