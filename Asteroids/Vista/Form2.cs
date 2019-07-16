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
    public partial class Form2 : Form
    {
        public Space juego;
        int Status = 1;
        Graphics g;

        public Form2(Space juego)
        {
            InitializeComponent();
            this.juego = juego;
            //Posicion de botones
            MenosVelocidad.Location = new Point(this.juego.M + 20, 70);
            MasVelocidad.Location = new Point(this.juego.M + 100, 70);

            buttonStart.Location = new Point(this.juego.M + 20 , 10);

            button4.Location = new Point(this.juego.M + 20, 100);
            buttonUP.Location = new Point(this.juego.M + 60, 100);
            button2.Location = new Point(this.juego.M + 100, 100);

            buttonLe.Location = new Point(this.juego.M + 20, 130);
            buttonSho.Location = new Point(this.juego.M + 65, 130);
            buttonRi.Location = new Point(this.juego.M + 100, 130);

            button1.Location = new Point(this.juego.M + 20, 160);
            buttonDo.Location = new Point(this.juego.M + 60, 160);
            button3.Location = new Point(this.juego.M + 100, 160);

            Reiniciar.Location = new Point(this.juego.M + 20, 200);
            Nuevo_Juego.Location = new Point(this.juego.M + 20, 240);


            pictureBox.Size = new Size(this.juego.M, this.juego.N);
            pictureBox.Location = new Point(0, 0);
            g = pictureBox.CreateGraphics();

        }
        
        private void drawSpace()
        {
            
            if (Status == 1) {
                List<Asteroid> Asteroids = this.juego.AsteroidList;
                List<Shoot> shoots = this.juego.ShootList;
                int i;


                g.FillEllipse(new SolidBrush(Color.Blue), (float)this.juego.Nave.PosX, (float)this.juego.Nave.PosY, (float)this.juego.Nave.Hitbox*10, (float)this.juego.Nave.Hitbox*10);

                for (i = 0; i < this.juego.AsteroidList.Count(); i++)
                {
                    g.FillEllipse(new SolidBrush(Color.Red), (float)Asteroids[i].PosX, (float)Asteroids[i].PosY, (float)Asteroids[i].Hitbox*10, (float)Asteroids[i].Hitbox*10);
                }
                for (i = 0; i < this.juego.ShootList.Count(); i++)
                {
                    g.FillEllipse(new SolidBrush(Color.Green), (float)shoots[i].PosX, (float)shoots[i].PosY, (float)shoots[i].Hitbox*10, (float)shoots[i].Hitbox*10);
                }
            }
        }
       
        private void Timer1_Tick(object sender, EventArgs e)
        {

            g.Clear(Color.White);
            if (this.juego.Nave.Vida == 0)
            {
                this.timer1.Stop();
                MessageBox.Show("LOS ASTEROIDES HAN DESTRIUDO LA TIERRA");
            }
            else if (this.juego.AsteroidList.Count() == 0)
            {
                this.timer1.Stop();
                MessageBox.Show("VICTORIA, SALVASTE A EL PLANETA");
            }
            else if (this.juego.Nave.Vida > 0)
            {
                drawSpace();
                this.juego.UpdateSpace();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (this.Status == 0)
            {
                this.Status = 1;
                this.timer1.Start();
            }
            else
            {
                this.Status = 0;
                this.timer1.Stop();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 90;
        }

        private void ButtonUP_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Aribba = " + this.juego.AsteroidList.Count);
            juego.Nave.Angulo = 270;
        }

        private void ButtonLe_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 180;
        }

        private void ButtonRi_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 0;
        }

        private void ButtonSho_Click(object sender, EventArgs e)
        {
            juego.ShootElement();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 135;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 315;
        }
        
        private void Button4_Click_1(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 225;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            juego.Nave.Angulo = 45;
        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.juego.CreateSpace();
        }

        private void Nuevo_Juego_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.Hide();

            var form1 = new Form1();
            form1.Show();
        }

        private void MenosVelocidad_Click(object sender, EventArgs e)
        {
            juego.Nave.Velocidad -= 1;
        }

        private void MasVelocidad_Click(object sender, EventArgs e)
        {
            juego.Nave.Velocidad += 1;
        }
    }
}
