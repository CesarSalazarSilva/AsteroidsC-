using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class SpaceObject
    {
	//Atributos de Movimiento.
	protected internal double posX;
	protected internal double posY;
	protected internal double velocidad;
	protected internal double angulo;
	protected internal double recorrido;
    protected internal double seed;
	//Atributos Caracteristicos.
	protected internal double hitbox;
    
    //Constructor SpaceObject.
    public SpaceObject(double posX, double posY, double velocidad, double angulo, double recorrido, double hitbox, double seed)
	{
		this.posX = posX;
		this.posY = posY;
		this.velocidad = velocidad;
		this.angulo = angulo;
		this.recorrido = recorrido;
		this.hitbox = hitbox;
		this.seed = seed;
	}

	// Metodo que mueve un elemento espacial a un t+1. 
	public virtual void MoveElement(double angulo, double velocidad, double m, double n)
	{
		if (velocidad > 0)
		{
			this.velocidad += velocidad;
			this.angulo += angulo;
			double angulogradian = ToRadians(this.angulo);
			this.posX = (this.posX + this.velocidad * Math.Cos(angulogradian)) % m;
			this.posY = (this.posY + this.velocidad * Math.Sin(angulogradian)) % n;
			this.recorrido -= this.velocidad*0.01;
                if (this.posX <0)
                {
                    this.posX = m;
                }
                if(this.posY < 0)
                {
                    this.posY = m; 
                }
            }
		else
		{
			this.angulo += angulo;
			double angulogradian = ToRadians(this.angulo);            
			this.posX = (this.posX + this.velocidad * Math.Cos(angulogradian)) % m;
			this.posY = (this.posY + this.velocidad * Math.Sin(angulogradian)) % n;
			this.recorrido -= this.velocidad*0.01;
                if (this.posX < 0)
                {
                    this.posX = m;
                    
                }
                if (this.posY < 0)
                {
                    this.posY = m;
                    
                }

            }
	}
    //Metodo que convierte un angulo de Grados a Radianes
    private double ToRadians(double angulo)
    {
        return (Math.PI / 180) * angulo;
    }

    //Getters and Setters.
    public virtual double PosX
	{
		get
		{
			return posX;
		}
		set
		{
			this.posX = value;
		}
	}

	public virtual double PosY
	{
		get
		{
			return posY;
		}
		set
		{
			this.posY = value;
		}
	}

	public virtual double Velocidad
	{
		get
		{
			return velocidad;
		}
		set
		{
			this.velocidad = value;
		}
	}

	public virtual double Angulo
	{
		get
		{
			return angulo;
		}
		set
		{
			this.angulo = value;
		}
	}

	public virtual double Recorrido
	{
		get
		{
			return recorrido;
		}
		set
		{
			this.recorrido = value;
		}
	}

	public virtual double Hitbox
	{
		get
		{
			return hitbox;
		}
		set
		{
			this.hitbox = value;
		}
	}

	public virtual double Seed
	{
		get
		{
			return seed;
		}
		set
		{
			this.seed = value;
		}
	}

    }
}
