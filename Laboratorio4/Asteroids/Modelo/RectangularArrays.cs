using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    //Clase utilizada para ocupar arreglos
    internal static partial class RectangularArrays
    {
        internal static int[][] ReturnRectangularIntArray(int Size1, int Size2)
        {
            int[][] Array;
            if (Size1 > -1)
            {
                Array = new int[Size1][];
                if (Size2 > -1)
                {
                    for (int Array1 = 0; Array1 < Size1; Array1++)
                    {
                        Array[Array1] = new int[Size2];
                    }
                }
            }
            else
                Array = null;
            return Array;
        }
    }
}