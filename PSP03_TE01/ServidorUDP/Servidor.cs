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

namespace PSP03_TE01_CHAT_ServidorUDP
{
    public partial class Servidor : Form
    {

        private UdpClient miSocketServidor;
        private const int puertoR = 2000;
        private List<IPEndPoint> endPointsClientes = new List<IPEndPoint>(); // Lista de IPs de clientes conectados
        private List<string> nombreClientes = new List<string>(); // Lista de nombres de clientes conectados
        public Servidor()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private async void button1_Click(object sender, EventArgs e) //ARRANCAR SERVIDOR
        {
            button1.Enabled = false;
            button2.Enabled = true;
            try
            {                //Se crea el socket con el puerto en el que se queda escuchando el servidor.
                miSocketServidor = new UdpClient(puertoR);
                srvtextBox1.AppendText("SERVIDOR INICIADO!!!" + Environment.NewLine);
                while (true)
                {
                    UdpReceiveResult receivedResults = await miSocketServidor.ReceiveAsync();
                    string mensaje = Encoding.ASCII.GetString(receivedResults.Buffer);
                    IPEndPoint clienteEndpoint = receivedResults.RemoteEndPoint;
                    // Almacenar la dirección del cliente en la lista si no está ya
                    if (endPointsClientes.Contains(clienteEndpoint) && !mensaje.Contains("DESCONN") && !mensaje.Contains("CONN"))
                    { // Si el mensaje no es de desconexión, se envía a todos los clientes
                        Invoke(new Action(() => srvtextBox1.AppendText($"Cliente: {mensaje}\n" + Environment.NewLine)));
                        byte[] mensajeRespuesta = Encoding.ASCII.GetBytes(mensaje);
                        foreach (IPEndPoint cliente in endPointsClientes)
                        {
                            await miSocketServidor.SendAsync(mensajeRespuesta, mensajeRespuesta.Length, cliente); // Enviar el mensaje a cada cliente
                        }
                    }
                    else if (!endPointsClientes.Contains(clienteEndpoint) && mensaje.Contains("CONN"))
                    {
                        string nombrecli = mensaje.Replace("CONN", "");
                        mensaje = "Conexion Cliente: " + nombrecli;
                        byte[] mensajeRespuesta = Encoding.ASCII.GetBytes(mensaje);
                        foreach (IPEndPoint cliente in endPointsClientes)
                        {
                            await miSocketServidor.SendAsync(mensajeRespuesta, mensajeRespuesta.Length, cliente); // Enviar el mensaje a cada cliente
                        }
                        mensaje = "Se acaba de conectar el cliente: " + nombrecli;
                        Invoke(new Action(() => srvtextBox1.AppendText(mensaje + " \n" + Environment.NewLine)));
                        endPointsClientes.Add(clienteEndpoint);
                        nombreClientes.Add(nombrecli);
                        label1.Text = "Clientes conectados: " + endPointsClientes.Count;
                        textBox2.Clear();
                        foreach (string clientes2 in nombreClientes)
                        {
                            Invoke(new Action(() => textBox2.AppendText(clientes2 + Environment.NewLine)));
                        }
                    }
                    else if (endPointsClientes.Contains(clienteEndpoint) && mensaje.Contains("DESCONN"))
                    {
                        endPointsClientes.Remove(clienteEndpoint);
                        string nombrecli = mensaje.Replace("DESCONN", "");
                        nombreClientes.Remove(nombrecli);
                        mensaje = nombrecli + " se ha desconectado!!!";
                        byte[] mensajeRespuesta = Encoding.ASCII.GetBytes(mensaje);
                        foreach (IPEndPoint cliente in endPointsClientes)
                        {
                            await miSocketServidor.SendAsync(mensajeRespuesta, mensajeRespuesta.Length, cliente); // Enviar el mensaje a cada cliente
                        }
                        Invoke(new Action(() => srvtextBox1.AppendText(mensaje + " \n" + Environment.NewLine)));
                        label1.Text = "Clientes conectados: " + endPointsClientes.Count;
                        textBox2.Clear();
                        foreach (string clientes2 in nombreClientes)
                        {
                            Invoke(new Action(() => textBox2.AppendText(clientes2 + Environment.NewLine)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (miSocketServidor != null)
                {
                    miSocketServidor.Close();
                }
            }
        }
#pragma warning disable IDE1006 // Estilos de nombres
        private void button2_ClickAsync(object sender, EventArgs e) //PARAR SERVIDOR
#pragma warning restore IDE1006 // Estilos de nombres
        {
            string mensaje = "SERVIDOR PARADO!!!";
            srvtextBox1.AppendText(mensaje + Environment.NewLine);
            avisarClientesAsync(mensaje);
            miSocketServidor.Close();
            button1.Enabled = true;
            button2.Enabled = false;
        }
        private async Task avisarClientesAsync(string mensaje)
        {
            byte[] mensajeRespuesta = Encoding.ASCII.GetBytes(mensaje);
            foreach (IPEndPoint cliente in endPointsClientes)
            {
                miSocketServidor.SendAsync(mensajeRespuesta, mensajeRespuesta.Length, cliente); // Enviar el mensaje a cada cliente
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


