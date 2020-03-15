using System;
using System.Collections.Generic;
using System.Text;


namespace Modelo{
    public class Space{
        //
        public static double PI = 3.14159265358979323846;
        public static int velocidadInicialNave = 1;
        public static int vidaInicial = 3;
        public static int hitboxAsteroide = 4;
        public static int hitboxDisparo = 1;
        public static int hitboxNave = 1;
        public static int aumento = 4;
        public static int modulo = 9;
        public static int constante = 1;
        public static int Valido = 0;
        public static int escala = 10;

        //Entrega un random a partir de otro.
        public static int Random(int numero){
            return (((numero * aumento) + constante) % modulo);
        }

        //Entrega un numero random en parametros controlados.
        public static int RandomEsp(int numero, int aumento, int constante, int modulo){
            return (((numero * aumento) + constante) % modulo);
        }
        


        //Atributos de un Space
        private int n;
        private int m;
        private int numAsteroides;
        private int numPart;
        private int firerange;
        private int seed;

        private List<Asteroid> asteroidList;
        private List<Shoot> shootList;
        private Ship nave;

        //Constructor de una plantilla Space.
        public Space(int n, int m, int numAsteroides, int numPart, int firerange, int seed){
            this.n = n;
            this.m = m;
            this.numAsteroides = numAsteroides;
            this.numPart = numPart;
            this.firerange = firerange;
            this.seed = seed;
            this.asteroidList = new List<Asteroid>();
            this.shootList = new List<Shoot>();
            this.nave = new Ship(0, 0, 0, 0, 0, 0, 0, 3);
        }

        //Constructor de un espacio valido
        public virtual void CreateSpace(){
            this.asteroidList = new List<Asteroid>();
            this.shootList = new List<Shoot>();
            double posX = m / 2;
            double posY = n / 2;
            this.nave = new Ship(posX, posY,velocidadInicialNave, 0, 0, hitboxNave, seed, vidaInicial);
            int i = 0;
            int valorrandom = 14;
            int angulo = 543;
            while (i < this.numAsteroides && valorrandom < 10000){
                int valorposyN = RandomEsp(valorrandom, (int)m/4, (int)n/3, n);
                int valorposxM = RandomEsp(valorrandom, (int)m/43, (int)n/3, m);

                //De chocar el asteroide con la nave no se asigna el asteroide.
                if (Chocan(valorposxM, valorposyN, hitboxAsteroide, posX, posY, hitboxNave)){
                    valorrandom += 1; // Asignamos el asteroide con la posicion valida
                }else{
                    Asteroid asteroide = new Asteroid(valorposxM, valorposyN, 1, RandomEsp(valorrandom, (int)m / 4, (int)n / 3, m), 0, hitboxAsteroide, seed, numPart);
                    this.asteroidList.Add(asteroide);
                    valorrandom += 1;
                    i += 1;
                }
                angulo += RandomEsp(valorrandom, (int)m / 43, (int)n * 7, m);
            }
            Valido = 1;
            if (valorrandom > 9900){
                Valido = 0;
                Console.WriteLine("No se ha podido crear un espacio valido con lo valores dados, favor usar otros parametros, debe crear una nueva partida (Seleccione 3 , luego 2).");
            }
        }

        //Movimiento simple para la nave, asteroides y disparos de un space
        public virtual void MovimientoSimpleAll(){
            this.nave.MoveElement(0, 0, this.m, this.n);
            //Mover Asteroides
            for (int i = 0; i < this.asteroidList.Count; i++){
                this.asteroidList[i].MoveElement(0, 0, this.m, this.n);
            }
            //Mover Disparos
            for (int i = 0; i < this.shootList.Count; i++){
                this.shootList[i].MoveElement(0, 0, this.m, this.n);
            }
            this.numAsteroides = asteroidList.Count;
        }

        //Agrega un disparo a un Space
        public virtual void ShootElement(){
            double posX = this.nave.PosX;
            double posY = this.nave.PosY;
            double firerange = this.firerange;
            Shoot disparo = new Shoot(posX, posY, this.nave.Velocidad + 1, this.nave.Angulo, firerange, hitboxDisparo, this.seed);
            this.shootList.Add(disparo);
        }

        //Verifica si un elemento choca con otro.
        public virtual bool Chocan(double Ob1Px, double Ob1Py, double Ob1Rad, double Ob2Px, double Ob2Py, double Ob2Rad){
            double suma1 = Ob1Px - Ob2Px;
            double suma2 = Ob1Py - Ob2Py;
            double pot1 = Math.Pow(suma1, 2);
            double pot2 = Math.Pow(suma2, 2);
            double res = pot1 + pot2;
            double resultado = Math.Sqrt(res);
            //Logica de colision
            if (resultado < (Ob1Rad*escala/2 + Ob2Rad*escala/2)){
                return true;
            }else{
                return false;
            }
        }

        //Convierte un Space en String
        public virtual string Textyfy(){
            //Creamos una matriz que contendra nuestro tablero y se rellena de ceros
            //JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
            //ORIGINAL LINE: int[][] matriz = new int[this.m][this.n];
            int[][] matriz = RectangularArrays.ReturnRectangularIntArray(this.m, this.n);
            for (int i = 0; i < this.m; i++){
                for (int j = 0; j < this.n; j++)
                {
                    matriz[i][j] = 0;
                }
            }
            //Introducimos la nave
            matriz[((int)(this.nave.PosX)) % m][((int)(this.nave.PosY)) % n] = 5;

            //Introducimos los Asteroides
            for (int i = 0; i < this.asteroidList.Count; i++){
                matriz[((int)(this.asteroidList[i].PosX)) % m][((int)(this.asteroidList[i].PosY)) % n] = (int)(this.asteroidList[i].Hitbox);
            }

            //Introducimos los Disparos
            for (int i = 0; i < this.shootList.Count; i++){
                matriz[((int)(this.shootList[i].PosX)) % m][((int)(this.shootList[i].PosY)) % n] = 3;
            }
            string spaceToString = "";
            for (int i = 0; i < this.m; i++){
                for (int j = 0; j < this.n; j++){
                    spaceToString = spaceToString + " " + matriz[i][j] + " ";
                }
                spaceToString += "\n";
            }
            return spaceToString;
        }

        //Imprime el String de un Space
        public virtual void Printify(string spaceToString){
            Console.WriteLine("Simbologia Asteroids: (5) Ship ; (3) Shoot ; (Otro) Asteroide de radio indicado ;(0) Espacio Vacio");
            Console.WriteLine("");
            Console.WriteLine(spaceToString);
        }

        //Colision entre Nave y Asteroides
        public virtual void ColNavAsts(){
            for (int i = 0; i < this.asteroidList.Count; i++)
            {
                if (Chocan(this.nave.PosX, this.nave.PosY, hitboxNave, this.asteroidList[i].PosX, this.asteroidList[i].PosY, this.asteroidList[i].Hitbox))
                {
                    this.nave.Vida = 0;
                }
            }
            this.numAsteroides = asteroidList.Count;
        }

        //Colision entre Disparos y Asteroides
        public virtual void ColDispAst(){
            //Nos preparamos a separ los disparos que chocan de los que no
            List<Shoot> dispchocan = new List<Shoot>();
            List<Shoot> dispNochocan = new List<Shoot>();
            int choca = 0;
            //Separamos
            for (int i = 0; i < this.shootList.Count; i++){
                if (shootList[i].Recorrido > 0 ){
                    for (int j = 0; j < this.asteroidList.Count; j++){
                        if (this.shootList[i].Recorrido > 0){
                            if (Chocan(this.shootList[i].PosX, this.shootList[i].PosY, this.shootList[i].Hitbox, this.asteroidList[j].PosX, this.asteroidList[j].PosY, this.asteroidList[j].Hitbox)){
                                dispchocan.Add(this.shootList[i]);
                                choca = 1;
                            }
                        }
                    }
                    if (choca == 0){
                        dispNochocan.Add(this.shootList[i]);
                    }
                }
                choca = 0;
            }

            //Separamos los asteroides que chocan de los que no
            List<Asteroid> astchocan = new List<Asteroid>();
            List<Asteroid> astNochocan = new List<Asteroid>();
            choca = 0;
            for (int i = 0; i < this.asteroidList.Count; i++){
                for (int j = 0; j < this.shootList.Count; j++){
                    if (Chocan(this.asteroidList[i].PosX, this.asteroidList[i].PosY, this.asteroidList[i].Hitbox, this.shootList[j].PosX, this.shootList[j].PosY, this.shootList[j].Hitbox)){
                        if ((this.asteroidList[i].Hitbox) / 2 > 0.8){
                            astchocan.Add(this.asteroidList[i]);
                            choca = 1;
                        }
                    }
                }
                if (choca == 0 /*&& this.asteroidList[i].Hitbox > 0.8*/){
                    astNochocan.Add(this.asteroidList[i]);
                }
                choca = 0;
            }
            
            //this.asteroidList = astChocadosEntreSi;
            this.asteroidList = astNochocan;
            this.shootList = dispNochocan;
            this.numAsteroides = asteroidList.Count;
        }

        //UpdateSpace
        public virtual void UpdateSpace(){
            //Movemos Todos Los elementos
            this.MovimientoSimpleAll();
            this.ColDispAst();
            this.ColNavAsts();
        }

        //Metodo que agrega de n hasta 7 asteroides a un Space.
        public virtual List<Asteroid> FisicadeAsteroides(Asteroid asteroide, int seed){
            if (seed == 1){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 2){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 3){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx3 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy3 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                double NewAngulo3 = asteroide.Angulo + 135;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx3, Newpy3, 1, NewAngulo3, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 4){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx3 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx4 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy3 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy4 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                double NewAngulo3 = asteroide.Angulo + 135;
                double NewAngulo4 = asteroide.Angulo + 315;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx3, Newpy3, 1, NewAngulo3, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx4, Newpy4, 1, NewAngulo4, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 5){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx3 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx4 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx5 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy3 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy4 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy5 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                double NewAngulo3 = asteroide.Angulo + 135;
                double NewAngulo4 = asteroide.Angulo + 315;
                double NewAngulo5 = asteroide.Angulo + 225;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx3, Newpy3, 1, NewAngulo3, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx4, Newpy4, 1, NewAngulo4, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx5, Newpy5, 1, NewAngulo5, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 6){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx3 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx4 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx5 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx6 = (asteroide.PosX) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy3 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy4 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy5 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy6 = (asteroide.PosX + 2.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                double NewAngulo3 = asteroide.Angulo + 135;
                double NewAngulo4 = asteroide.Angulo + 315;
                double NewAngulo5 = asteroide.Angulo + 225;
                double NewAngulo6 = asteroide.Angulo + 90;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx3, Newpy3, 1, NewAngulo3, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx4, Newpy4, 1, NewAngulo4, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx5, Newpy5, 1, NewAngulo5, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx6, Newpy6, 1, NewAngulo6, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
            if (seed == 7){
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpx2 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx3 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx4 = (asteroide.PosX + 2 * asteroide.Hitbox) % this.m;
                double Newpx5 = (asteroide.PosX - 2 * asteroide.Hitbox) % this.m;
                double Newpx6 = (asteroide.PosX) % this.m;
                double Newpx7 = (asteroide.PosX) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double Newpy2 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy3 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy4 = (asteroide.PosX + 1.5 * asteroide.Hitbox) % this.n;
                double Newpy5 = (asteroide.PosX - 1.5 * asteroide.Hitbox) % this.n;
                double Newpy6 = (asteroide.PosX + 2.5 * asteroide.Hitbox) % this.n;
                double Newpy7 = (asteroide.PosX - 2.5 * asteroide.Hitbox) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                double NewAngulo2 = asteroide.Angulo + 45;
                double NewAngulo3 = asteroide.Angulo + 135;
                double NewAngulo4 = asteroide.Angulo + 315;
                double NewAngulo5 = asteroide.Angulo + 225;
                double NewAngulo6 = asteroide.Angulo + 90;
                double NewAngulo7 = asteroide.Angulo + 270;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx2, Newpy2, 1, NewAngulo2, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx3, Newpy3, 1, NewAngulo3, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx4, Newpy4, 1, NewAngulo4, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx5, Newpy5, 1, NewAngulo5, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx6, Newpy6, 1, NewAngulo6, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                nuevaLista.Add(new Asteroid(Newpx7, Newpy7, 1, NewAngulo7, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }else{
                List<Asteroid> nuevaLista = new List<Asteroid>();
                double Newpx1 = (asteroide.PosX) % this.m;
                double Newpy1 = (asteroide.PosX) % this.n;
                double NewAngulo1 = asteroide.Angulo;
                nuevaLista.Add(new Asteroid(Newpx1, Newpy1, 1, NewAngulo1, 0, (asteroide.Hitbox) / 2, this.seed, this.numPart));
                return nuevaLista;
            }
        }

        //Getters and Setters
        public virtual int N{
            get{
                return n;
            }
            set{
                this.n = value;
            }
        }

        public virtual int M{
            get{
                return m;
            }
            set{
                this.m = value;
            }
        }

        public virtual int NumAsteroides{
            get{
                return numAsteroides;
            }
            set{
                this.numAsteroides = value;
            }
        }

        public virtual int NumPart{
            get{
                return numPart;
            }
            set{
                this.numPart = value;
            }
        }

        public virtual int Firerange{
            get{
                return firerange;
            }
            set{
                this.firerange = value;
            }
        }

        public virtual int Seed{
            get{
                return seed;
            }
            set{
                this.seed = value;
            }
        }

        public virtual List<Asteroid> AsteroidList{
            get{
                return asteroidList;
            }
            set{
                this.asteroidList = value;
            }
        }

        public virtual List<Shoot> ShootList{
            get{
                return shootList;
            }
            set{
                this.shootList = value;
            }
        }

        public virtual Ship Nave{
            get{
                return nave;
            }
            set{
                this.nave = value;
            }
        }
    }
}
