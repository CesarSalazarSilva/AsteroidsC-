namespace Vista
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonLe = new System.Windows.Forms.Button();
            this.buttonUP = new System.Windows.Forms.Button();
            this.buttonRi = new System.Windows.Forms.Button();
            this.buttonDo = new System.Windows.Forms.Button();
            this.buttonSho = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.Nuevo_Juego = new System.Windows.Forms.Button();
            this.MenosVelocidad = new System.Windows.Forms.Button();
            this.MasVelocidad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(696, 21);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Play/Stop";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.MouseCaptureChanged += new System.EventHandler(this.StartButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(19, 21);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(650, 450);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // buttonLe
            // 
            this.buttonLe.Location = new System.Drawing.Point(672, 103);
            this.buttonLe.Name = "buttonLe";
            this.buttonLe.Size = new System.Drawing.Size(39, 23);
            this.buttonLe.TabIndex = 3;
            this.buttonLe.Text = "<";
            this.buttonLe.UseVisualStyleBackColor = true;
            this.buttonLe.Click += new System.EventHandler(this.ButtonLe_Click);
            // 
            // buttonUP
            // 
            this.buttonUP.Location = new System.Drawing.Point(713, 74);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(39, 23);
            this.buttonUP.TabIndex = 4;
            this.buttonUP.Text = "^";
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.Click += new System.EventHandler(this.ButtonUP_Click);
            // 
            // buttonRi
            // 
            this.buttonRi.Location = new System.Drawing.Point(756, 103);
            this.buttonRi.Name = "buttonRi";
            this.buttonRi.Size = new System.Drawing.Size(39, 23);
            this.buttonRi.TabIndex = 5;
            this.buttonRi.Text = ">";
            this.buttonRi.UseVisualStyleBackColor = true;
            this.buttonRi.Click += new System.EventHandler(this.ButtonRi_Click);
            // 
            // buttonDo
            // 
            this.buttonDo.Location = new System.Drawing.Point(713, 132);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(39, 23);
            this.buttonDo.TabIndex = 6;
            this.buttonDo.Text = "V";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.Button4_Click);
            // 
            // buttonSho
            // 
            this.buttonSho.Location = new System.Drawing.Point(717, 103);
            this.buttonSho.Name = "buttonSho";
            this.buttonSho.Size = new System.Drawing.Size(33, 23);
            this.buttonSho.TabIndex = 7;
            this.buttonSho.Text = "S";
            this.buttonSho.UseVisualStyleBackColor = true;
            this.buttonSho.Click += new System.EventHandler(this.ButtonSho_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(677, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "*";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(754, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "*";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(754, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "*";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(675, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "*";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // Reiniciar
            // 
            this.Reiniciar.Location = new System.Drawing.Point(677, 177);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(111, 30);
            this.Reiniciar.TabIndex = 12;
            this.Reiniciar.Text = "Reiniciar";
            this.Reiniciar.UseVisualStyleBackColor = true;
            this.Reiniciar.Click += new System.EventHandler(this.Reiniciar_Click);
            // 
            // Nuevo_Juego
            // 
            this.Nuevo_Juego.Location = new System.Drawing.Point(677, 213);
            this.Nuevo_Juego.Name = "Nuevo_Juego";
            this.Nuevo_Juego.Size = new System.Drawing.Size(111, 27);
            this.Nuevo_Juego.TabIndex = 13;
            this.Nuevo_Juego.Text = "Juego Nuevo ";
            this.Nuevo_Juego.UseVisualStyleBackColor = true;
            this.Nuevo_Juego.Click += new System.EventHandler(this.Nuevo_Juego_Click);
            // 
            // MenosVelocidad
            // 
            this.MenosVelocidad.Location = new System.Drawing.Point(675, 50);
            this.MenosVelocidad.Name = "MenosVelocidad";
            this.MenosVelocidad.Size = new System.Drawing.Size(36, 18);
            this.MenosVelocidad.TabIndex = 14;
            this.MenosVelocidad.Text = "- V";
            this.MenosVelocidad.UseVisualStyleBackColor = true;
            this.MenosVelocidad.Click += new System.EventHandler(this.MenosVelocidad_Click);
            // 
            // MasVelocidad
            // 
            this.MasVelocidad.Location = new System.Drawing.Point(754, 50);
            this.MasVelocidad.Name = "MasVelocidad";
            this.MasVelocidad.Size = new System.Drawing.Size(34, 18);
            this.MasVelocidad.TabIndex = 15;
            this.MasVelocidad.Text = "+ V";
            this.MasVelocidad.UseVisualStyleBackColor = true;
            this.MasVelocidad.Click += new System.EventHandler(this.MasVelocidad_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.MasVelocidad);
            this.Controls.Add(this.MenosVelocidad);
            this.Controls.Add(this.Nuevo_Juego);
            this.Controls.Add(this.Reiniciar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSho);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.buttonRi);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonLe);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonLe;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.Button buttonRi;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Button buttonSho;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Button Nuevo_Juego;
        private System.Windows.Forms.Button MenosVelocidad;
        private System.Windows.Forms.Button MasVelocidad;
    }
}