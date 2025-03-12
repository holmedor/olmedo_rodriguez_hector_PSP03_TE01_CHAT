using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PSP03_TE01_CHAT_ClienteUDP
{
    public partial class Cliente : Form
    {

        private UdpClient clienteUDP = new UdpClient();
        private const int puertoServidor = 2000;//puerto del servidor para la conexión
        IPEndPoint servidorEndpoint;
        string ipServidor;
        public Cliente()
        {
            InitializeComponent();
            button1_conectar.Enabled = true;
            button2_desconectar.Enabled = false;
            button3_enviar.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e) //ARRANCAR CLIENTE
        {
            button1_conectar.Enabled = false;
            button2_desconectar.Enabled = true;
            if (string.IsNullOrWhiteSpace(textBox2_chat.Text))
            { button3_enviar.Enabled = false; }
            else { button3_enviar.Enabled = true; }
            ConectarAlServidor();
            RecibirMensajes();            // Iniciar la escucha de mensajes del servidor
            Invoke(new Action(() => textBox4_chat.AppendText("Conectado al Servidor..." + Environment.NewLine)));
        }
        private async void ConectarAlServidor()
        {            // Se conecta al servidor
            ipServidor = textBox1_ip.Text;//IP del servidor para la conexión
            servidorEndpoint = new IPEndPoint(IPAddress.Parse(ipServidor), puertoServidor);
            byte[] nombreClte = Encoding.ASCII.GetBytes(textBox3_nombre.Text + "CONN");
            await clienteUDP.SendAsync(nombreClte, nombreClte.Length, servidorEndpoint);
            if (string.IsNullOrWhiteSpace(textBox2_chat.Text))
            { button3_enviar.Enabled = false; }
            else { button3_enviar.Enabled = true; }
        }
        private async void button2_Click(object sender, EventArgs e) //PARAR CLIENTE
        {
            byte[] nombreClte = Encoding.ASCII.GetBytes(textBox3_nombre.Text + "DESCONN");
            clienteUDP.Send(nombreClte, nombreClte.Length, servidorEndpoint);
            clienteUDP.Close();
            Invoke(new Action(() => textBox4_chat.AppendText("CLIENTE PARADO!!!" + Environment.NewLine)));
            button1_conectar.Enabled = true;
            button2_desconectar.Enabled = false;
            if (string.IsNullOrWhiteSpace(textBox2_chat.Text))
            { button3_enviar.Enabled = false; }
            else { button3_enviar.Enabled = true; }
        }
        private async void SendMessage(IPEndPoint servidorEndpoint)
        {
            byte[] mensajeEnviar = Encoding.ASCII.GetBytes(textBox3_nombre.Text + " : " + textBox2_chat.Text);
            clienteUDP.Send(mensajeEnviar, mensajeEnviar.Length, servidorEndpoint);
            textBox2_chat.Clear();
            button3_enviar.Enabled = false;
        }
        private void button3_enviar_Click(object sender, EventArgs e)
        {
            SendMessage(servidorEndpoint);
        }
        private async void RecibirMensajes()        // Recibir mensajes del servidor
        {
            UdpReceiveResult resultado;
            try
            {
                while (true)
                {
                    resultado = await clienteUDP.ReceiveAsync();
                    string message = Encoding.ASCII.GetString(resultado.Buffer);
                    Invoke(new Action(() => textBox4_chat.AppendText(message + Environment.NewLine)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (resultado != null)
                {
                    clienteUDP.Close();
                }
            }
        }
        private void textBox2_chat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2_chat.Text))
            { button3_enviar.Enabled = false; }
            else { button3_enviar.Enabled = true; }
        }
    }
}
