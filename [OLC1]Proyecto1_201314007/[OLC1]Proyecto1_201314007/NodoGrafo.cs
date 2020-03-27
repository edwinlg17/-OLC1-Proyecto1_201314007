using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class NodoGrafo
    {
        /////////////////////////// ATRIBUTOS
        public NodoGrafo izq, der;
        public Token eIzq, eDer;
        public int ide;
        public char tip;

        /////////////////////////// CONSTRUCTOR
        public NodoGrafo()
        {
            this.ide = -1;
            this.izq = null;
            this.der = null;
            this.eIzq = null;
            this.eDer = null;
            this.tip = 'n';
        }

        public NodoGrafo(int ide, NodoGrafo izq, NodoGrafo der,Token eIzq, Token eDer, char tip)
        {
            this.ide = ide;
            this.izq = null;
            this.der = null;
            this.eIzq = eIzq;
            this.eDer = eDer;
            this.tip = tip;
        }

        /////////////////////////// METODOS
    }
}
