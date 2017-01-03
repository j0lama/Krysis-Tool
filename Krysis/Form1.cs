using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace Krysis
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            
            InitializeComponent();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }
        string salida_mala;
        string Comando = "";
        string IP = "";

        void ExecuteCommand(string Command, int Decisor)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + Command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = proc.StandardOutput.ReadToEnd();
            if (Decisor == 0)
            {
                salida_mala = result;
            }
            else if (Decisor == 1)
            {
                richTextBox1.Text = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Comando = "ping " + textBox2.Text;
                ExecuteCommand(Comando, 0);
                string[] words = salida_mala.Split(' ');
                if (words[11] == "bytes=32")
                {
                    IP = textBox2.Text;
                    groupBox1.Enabled = true;
                    label8.Text = "Disponible";
                    label8.ForeColor = Color.Green;
                }
                else
                {
                    label8.Text = "No disponible";
                    label8.ForeColor = Color.Red;
                    groupBox1.Enabled = false;
                }
            }
            else
            {
                IP = textBox2.Text;
                groupBox1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Comando = "shutdown -s -m \\\\" + IP;
            if (textBox3.Text == "")
            {
                Comando = "shutdown -s -m \\\\" + IP;
            }
            groupBox4.Enabled = true;
            label2.Text = "Apagar";
            label3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Comando = "shutdown -r -m \\\\" + IP;
            if (textBox3.Text == "")
            {
                Comando = "shutdown -r -m \\\\" + IP;
            }
            groupBox4.Enabled = true;
            label2.Text = "Reiniciar";
            label3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Comando = "shutdown -l -m \\\\" + IP;
            if (textBox3.Text == "")
            {
                Comando = "shutdown -l -m \\\\" + IP;
            }
            groupBox4.Enabled = false;
            label2.Text = "Cerrar sesion";
            label3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Comando = Comando + " -t " + textBox3.Text;
            label3.Text = label3.Text + "+ Tiempo";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Comando = "tasklist /s " + IP;
            ExecuteCommand(Comando, 1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExecuteCommand(Comando, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Comando = "taskkill /s " + IP + " /im " + textBox1.Text;
            ExecuteCommand(Comando, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comando = "taskkill -f " + IP;
            ExecuteCommand(Comando, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Comando = "arp -a";
            ExecuteCommand(Comando, 1);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tool desarrollada por Jon Larrea.\nEstudiante de ingeniería informática en la UAM.\nEste software usa algunos de los comandos de administración remota que trae el terminal de Windows por defecto.\nCualquier reporte de error o sugerencia pongase en contacto conmigo.", "Informacíon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Comando = "shutdown -a";
            ExecuteCommand(Comando, 0);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 0.9.2: Añadido Enviar Mensaje.\nSolucionados algunos bugs.\n\nVersion 0.9.0:\nAñadido IP Checker.\n\nVersion 0.8.3:\nEliminado Comando Manual.\nNuevo aspecto.\n\nVersion 0.8.0:\nNueva interfaz grafica.\n\nVersion 0.7.1:\nMejorada opcion Ver Procesos. \n\nVersion 0.6.5:\nSolucionados problemas con la opcion Equipo.\nReparado problemas con la etiqueta de comando.\nAñadida opcion de Texto/Comentario.\n\nVerion 0.5.0:\nAñadido Comando manual.\nReparado varias funciones mal implementadas.\n\nVersion 0.2.0:\nReparados algunos bugs.\nAñadidas opciones de procesos y salidas\n\nVersion 0.1.0:\nInitial Release.", "Version Log", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Comando = Comando + " -c " + textBox5.Text;
            label3.Text = label3.Text + " + Texto";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Comando = "msg /server:" + IP + " * " + "/time:" + textBox4.Text + " \"" + textBox6.Text + "\"";
            ExecuteCommand(Comando, 0);
        }
    }
}
