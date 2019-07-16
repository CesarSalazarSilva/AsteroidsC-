using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Asteroid : SpaceObject
    {
        //Atributos
        private double numeroParticiones;

        //Constructor Asteroide.
        public Asteroid(double posX, double posY, double velocidad, double angulo, double recorrido, double hitbox, double seed, double numeroParticiones) : base(posX, posY, velocidad, angulo, recorrido, hitbox, seed)
        {
            this.numeroParticiones = numeroParticiones;
        }

        //Getter and Setters
        public virtual double NumeroParticiones
        {
            get
            {
                return numeroParticiones;
            }
            set
            {
                this.numeroParticiones = value;
            }
        }

    }
}
