using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            int anchoN = 0;
            int largoM = 0;
            int AsteroidesA = 0;
            int recorridoFR = 0;
            int numparticiones = 0;
            int seed = 0;
            int cont = 0;


            try
            {
                largoM = Convert.ToInt32(textBoxM.Text);
                cont++;
            }
            catch (FormatException) { }
            try
            {
                anchoN = Convert.ToInt32(textBoxN.Text);
                cont++;
            }
            catch (FormatException) { }
            try
            {
                AsteroidesA = Convert.ToInt32(textBoxA.Text);
                cont++;
            }
            catch (FormatException) { }
            try
            {
                recorridoFR = Convert.ToInt32(textBoxL.Text);
                cont++;
            }
            catch (FormatException) { }
            try
            {
                numparticiones = Convert.ToInt32(textBoxP.Text);
                cont++;
            }
            catch (FormatException) { }
            try
            {
                seed = Convert.ToInt32(textBoxSeed.Text);
                cont++;
            }
            catch (FormatException) { }
            if ((numparticiones >= 1 && 7 >= numparticiones) && (anchoN *largoM * 0.5 > AsteroidesA * Math.Pow(Space.hitboxAsteroide, 2) * Space.PI))
            {
                Space space = new Space(largoM*10, anchoN*10, AsteroidesA, numparticiones, recorridoFR, seed);
                space.CreateSpace();

                //Prueba update
                Console.WriteLine("Cantidad de Asteroides" + space.AsteroidList.Count());
                Console.WriteLine("Asteroide Posiciones X,Y");
                for (int i = 0; i < space.AsteroidList.Count(); i++)
                {
                    Console.WriteLine("PosicionX Asteroide Px = " + space.AsteroidList[i].PosX);
                    Console.WriteLine("PosicionX Asteroide Py = " + space.AsteroidList[i].PosY);
                }

                space.ColDispAst(); 
                //Nuevamente
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Cantidad de Asteroides" + space.AsteroidList.Count());
                Console.WriteLine("Cantidad de Asteroides" + space.AsteroidList.Count());
                Console.WriteLine("Asteroide Posiciones X,Y");
                for (int i = 0; i < space.AsteroidList.Count(); i++)
                {
                    Console.WriteLine("PosicionX Asteroide Px = " + space.AsteroidList[i].PosX);
                    Console.WriteLine("PosicionX Asteroide Py = " + space.AsteroidList[i].PosY);
                }

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");



                this.Hide();

                var form2 = new Form2(space);
                form2.Size = new Size(anchoN * 10 + 200, largoM * 10 + 50);
                form2.Show();

               
            }
            else
            {
                MessageBox.Show("Valores entregados son incorrectos para crear un partida Jugable");
            }

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
