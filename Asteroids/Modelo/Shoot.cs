using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Shoot : SpaceObject
    {
	//Constructor
	public Shoot(double posX, double posY, double velocidad, double angulo, double recorrido, double hitbox, double seed) : base(posX, posY, velocidad, angulo, recorrido, hitbox, seed)
	    {
	    }
    }
}
