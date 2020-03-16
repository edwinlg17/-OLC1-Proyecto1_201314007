using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class AnalizadorSintactico
    {
        /////////////////////////// ATRIBUTOS
        ArrayList lisTok;
        int ind;

        /////////////////////////// CONSTRUCTOR
        public AnalizadorSintactico()
        {
            lisTok = new ArrayList();
            ind = 0;
        }

        /////////////////////////// METODOS
        public void analizar(ArrayList lisTok)
        {
            this.lisTok = lisTok;
            ind = 0;
            ini();
        }

        private void ini()
        {
            if (verificar(Token.CON))
            {
                con();
            }
            /*else if (verificar(Token.IDE))
            {
                ind++;
            }*/
            else
            {
                ind++;
            }

            if (ind < lisTok.Count) ini();
        }

        ///////////////////// Estados de Conjuntos
        private void con()
        {
            Boolean ver = true;
            if (ver) ver = verificar(Token.SIM, ":");
            if (ver) ver = verificar(Token.IDE);
            if (ver) ver = verificar(Token.SIM, "-");
            if (ver) ver = verificar(Token.SIM, ">");

            ini();
        }


        private void error()
        {
            Token t;
            if (ind < lisTok.Count)
            {
                t = (Token)lisTok[ind];
                Console.WriteLine("Error Sintactico " + t.tok + " - " + t.lex + " - " + t.fil + " - " + t.col);
            }

            while (ind < lisTok.Count)
            {
                t = (Token)lisTok[ind];
                if (t.lex.Equals(";"))
                {
                    //ind++;
                    break;
                }
                ind++;
            }
        }

        /////////////////////
        private Boolean verificar(String tk)
        {
            Token t = (Token)lisTok[ind];
            if (t.tok.Equals(tk))
            {
                ind++;
                return true;
            }
            else
            {
                error();
                return false;
            }

        }

        private Boolean verificar(String tk, String le)
        {
            Token t = (Token)lisTok[ind];
            if (t.tok.Equals(tk) & t.lex.Equals(le))
            {
                ind++;
                return true;
            }
            else
            {
                error();
                return false;
            }
        }

    }
}
