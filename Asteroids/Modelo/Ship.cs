using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Ship : SpaceObject
    {
        //Atributos 
        private double vida;

        //Constructor Ship
        public Ship(double posX, double posY, double velocidad, double angulo, double recorrido, double hitbox, double seed, double vida) : base(posX, posY, velocidad, angulo, recorrido, hitbox, seed)
        {
            this.vida = vida;
        }

        //Getters and Setters
        public virtual double Vida
        {
            get
            {
                return vida;
            }
            set
            {
                this.vida = value;
            }
        }

    }
}
