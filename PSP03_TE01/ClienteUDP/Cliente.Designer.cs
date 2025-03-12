
namespace PSP03_TE01_CHAT_ClienteUDP {
  partial class Cliente {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent() {
            this.textBox2_chat = new System.Windows.Forms.TextBox();
            this.textBox1_ip = new System.Windows.Forms.TextBox();
            this.button1_conectar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2_desconectar = new System.Windows.Forms.Button();
            this.button3_enviar = new System.Windows.Forms.Button();
            this.textBox3_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4_chat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2_chat
            // 
            this.textBox2_chat.Location = new System.Drawing.Point(60, 220);
            this.textBox2_chat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2_chat.Name = "textBox2_chat";
            this.textBox2_chat.Size = new System.Drawing.Size(788, 26);
            this.textBox2_chat.TabIndex = 7;
            this.textBox2_chat.Text = "mensaje cliente";
            this.textBox2_chat.TextChanged += new System.EventHandler(this.textBox2_chat_TextChanged);
            // 
            // textBox1_ip
            // 
            this.textBox1_ip.Location = new System.Drawing.Point(154, 160);
            this.textBox1_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1_ip.Name = "textBox1_ip";
            this.textBox1_ip.Size = new System.Drawing.Size(163, 26);
            this.textBox1_ip.TabIndex = 6;
            this.textBox1_ip.Text = "127.0.0.1";
            // 
            // button1_conectar
            // 
            this.button1_conectar.Location = new System.Drawing.Point(60, 39);
            this.button1_conectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1_conectar.Name = "button1_conectar";
            this.button1_conectar.Size = new System.Drawing.Size(409, 84);
            this.button1_conectar.TabIndex = 5;
            this.button1_conectar.Text = "Conectar al servidor";
            this.button1_conectar.UseVisualStyleBackColor = true;
            this.button1_conectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP Servidor";
            // 
            // button2_desconectar
            // 
            this.button2_desconectar.Location = new System.Drawing.Point(477, 39);
            this.button2_desconectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2_desconectar.Name = "button2_desconectar";
            this.button2_desconectar.Size = new System.Drawing.Size(371, 80);
            this.button2_desconectar.TabIndex = 9;
            this.button2_desconectar.Text = "Desconectar Cliente";
            this.button2_desconectar.UseVisualStyleBackColor = true;
            this.button2_desconectar.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3_enviar
            // 
            this.button3_enviar.Location = new System.Drawing.Point(278, 611);
            this.button3_enviar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3_enviar.Name = "button3_enviar";
            this.button3_enviar.Size = new System.Drawing.Size(368, 75);
            this.button3_enviar.TabIndex = 10;
            this.button3_enviar.Text = "Enviar";
            this.button3_enviar.UseVisualStyleBackColor = true;
            this.button3_enviar.Click += new System.EventHandler(this.button3_enviar_Click);
            // 
            // textBox3_nombre
            // 
            this.textBox3_nombre.Location = new System.Drawing.Point(545, 163);
            this.textBox3_nombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3_nombre.Name = "textBox3_nombre";
            this.textBox3_nombre.Size = new System.Drawing.Size(295, 26);
            this.textBox3_nombre.TabIndex = 11;
            this.textBox3_nombre.Text = "cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "CHAT";
            // 
            // textBox4_chat
            // 
            this.textBox4_chat.Location = new System.Drawing.Point(60, 258);
            this.textBox4_chat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4_chat.Multiline = true;
            this.textBox4_chat.Name = "textBox4_chat";
            this.textBox4_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4_chat.Size = new System.Drawing.Size(788, 325);
            this.textBox4_chat.TabIndex = 14;
            this.textBox4_chat.Text = "\r\n";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 707);
            this.Controls.Add(this.textBox4_chat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3_nombre);
            this.Controls.Add(this.button3_enviar);
            this.Controls.Add(this.button2_desconectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2_chat);
            this.Controls.Add(this.textBox1_ip);
            this.Controls.Add(this.button1_conectar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Cliente";
            this.Text = "CLIENTE";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox2_chat;
    private System.Windows.Forms.TextBox textBox1_ip;
    private System.Windows.Forms.Button button1_conectar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2_desconectar;
    private System.Windows.Forms.Button button3_enviar;
    private System.Windows.Forms.TextBox textBox3_nombre;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox4_chat;
    }
}

