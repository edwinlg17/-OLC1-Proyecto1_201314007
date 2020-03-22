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
        int ind, ind2;
        Token tem;
        NodoGrafo ntem;

        /////////////////////////// CONSTRUCTOR
        public AnalizadorSintactico()
        {
            this.lisTok = new ArrayList();
            this.tem = new Token();
            ind = 0;
        }

        /////////////////////////// METODOS
        public void analizar(ArrayList lisTok)
        {
            this.lisTok = lisTok;
            if (lisTok.Count > 0)
            {
                ind = 0;
                ini();
            }
        }

        private void ini()
        {

            if (verificar(Token.CON)) con();
            else if (verificar(Token.IDE)) oe();
            else error();

            if (ind < lisTok.Count) ini();
        }

        ///////////////////// Conjuntos
        private void con()
        {
            Boolean ver = true;
            if (ver) ver = verificar(Token.SIM, ":");
            if (ver) ver = verificar(Token.IDE);
            if (ver) ver = verificar(Token.SIM, "-");
            if (ver) ver = verificar(Token.SIM, ">");
            if (ver) ver = ele();
            if (ver) ver = oele();
            Console.WriteLine();
            if (!ver) error();
            ini();
        }

        private Boolean ele()
        {
            if (verificar(Token.IDE)) return true;
            else if (verificar(Token.NUM)) return true;
            else if (verificar(Token.SIM)) return true;
            else if (verificar(Token.TOD)) return true;
            return false;
        }

        private Boolean oele()
        {
            if (verificar(Token.SIM, ";")) return true;
            else if (verificar(Token.SIM, ","))
            {
                Boolean ver = true;
                if (ver) ver = ele();
                if (ver) ver = com();
                return ver;
            }
            else if (verificar(Token.SIM, "~"))
            {
                Boolean ver = true;
                if (ver) ver = ele();
                if (ver) ver = verificar(Token.SIM, ";");
                return ver;
            }
            return false;
        }

        private Boolean com()
        {
            if (verificar(Token.SIM, ";")) return true;
            else if (verificar(Token.SIM, ","))
            {
                Boolean ver = true;
                if (ver) ver = ele();
                if (ver) ver = com();
                return ver;
            }
            return false;
        }

        ///////////////////// er y cadenas 
        private void oe()
        {
            Boolean ver = true;
            if (verificar(Token.SIM, ":"))
            {
                if (ver) ver = verificar(Token.CAD);
                if (ver) ver = verificar(Token.SIM, ";");
                Console.WriteLine();
                if (!ver) error();
            }
            else if (verificar(Token.SIM, "-"))
            {
                if (ver) ver = verificar(Token.SIM, ">");
                if (ver) ver = er();
                if (ver) ver = verificar(Token.SIM, ";");
                Console.WriteLine();
                if (!ver) error();
            }
            else error();
        }

        private Boolean er()
        {
            NodoGrafo nt = ter();
            if (nt != null)
            {
                ind2 = 0;
                numGra(nt);
                impGra(nt);
                return true;
            }

            return false;
        }

        private NodoGrafo ter()
        {
            if (verificar(Token.CAD))
                return new NodoGrafo(-1, null, null, tem, null, -1);

            else if (verificar(Token.NUM))
                return new NodoGrafo(-1, null, null, tem, null, -1);

            else if (verificar(Token.SIM, "{"))
            {
                if (verificar(Token.IDE))
                {
                    Token t = tem;
                    if (verificar(Token.SIM, "}"))
                        return new NodoGrafo(-1, null, null, t, null, -1);
                }
            }
            else
            {
                NodoGrafo st = sim();
                if (st != null)
                    return st;
            }

            return null;
        }

        private NodoGrafo sim()
        {
            if (verificar(Token.SIM, "."))
            {
                NodoGrafo datA = ter();
                NodoGrafo datB = ter();
                if (datA != null & datB != null)
                    return plaCon(datA, datB);
            }
            else if (verificar(Token.SIM, "|"))
            {
                NodoGrafo datA = ter();
                NodoGrafo datB = ter();
                if (datA != null & datB != null)
                    return plaSel(datA, datB);
            }
            else if (verificar(Token.SIM, "*"))
            {
                NodoGrafo datA = ter();
                if (datA != null)
                    return plaRepCer(datA);
            }
            /*else if (verificar(Token.SIM, "+"))
            {
                if (ter())
                    return true;
            }
            else if (verificar(Token.SIM, "?"))
            {
                if (ter())
                    return true;
            }*/

            return null;
        }

        private void error()
        {
            Token t;
            if (ind < lisTok.Count)
            {
                t = (Token)lisTok[ind];
                Console.WriteLine("Error Sintactico " + t.ide + " - " + t.tok + " - " + t.lex + " - " + t.fil + " - " + t.col);
            }

            while (ind < lisTok.Count)
            {
                t = (Token)lisTok[ind];
                if (t.lex.Equals(";"))
                {
                    ind++;
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
                //Console.Write(t.lex + " ");
                tem = t;
                ind++;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean verificar(String tk, String le)
        {
            Token t = (Token)lisTok[ind];
            if (t.tok.Equals(tk) & t.lex.Equals(le))
            {
                //Console.Write(t.lex + " ");
                tem = t;
                ind++;
                return true;
            }
            else
            {
                return false;
            }
        }

        private NodoGrafo plaCon(NodoGrafo datA, NodoGrafo datB)
        {
            NodoGrafo nta = obtUlt(datA);
            NodoGrafo ntb = obtUlt(datB);
            NodoGrafo nf = new NodoGrafo();

            nta.izq = datB;
            ntb.izq = nf;

            return datA;
        }

        private NodoGrafo plaSel(NodoGrafo datA, NodoGrafo datB)
        {
            NodoGrafo ni = new NodoGrafo();
            NodoGrafo nta = obtUlt(datA);
            NodoGrafo ntb = obtUlt(datB);
            NodoGrafo nra = new NodoGrafo();
            NodoGrafo nrb = new NodoGrafo();
            NodoGrafo nf = new NodoGrafo();

            ni.izq = datA;
            ni.der = datB;
            ni.eIzq = nodEps();
            ni.eDer = nodEps();
            ni.pos = 0;

            if (datA != nta)
            {
                nta.izq = nf;
                nta.eIzq = nodEps();
            }
            else 
            {
                datA.izq = nra;
                nra.izq = nf;
                nra.eIzq = nodEps();
            }

            if (datB != ntb)
            {
                ntb.der = nf;
                ntb.eDer = nodEps();
            }
            else
            {
                datB.izq = nrb;
                nrb.der = nf;
                nrb.eDer = nodEps();
            }

            nf.pos = 1;

            return ni;
        }

        private NodoGrafo plaRepCer(NodoGrafo datA)
        {
            NodoGrafo ni = new NodoGrafo();
            NodoGrafo nta = obtUlt(datA);
            NodoGrafo nra = new NodoGrafo();
            NodoGrafo nf = new NodoGrafo();

            ni.izq = datA;
            ni.der = nf;
            nta.izq = nra;
            nra.der = datA;
            nra.izq = nf;

            ni.eIzq = nodEps();
            ni.eDer = nodEps();
            nra.eIzq = nodEps();
            nra.eDer = nodEps();

            ni.pos = 0;
            nf.pos = 1;
            nra.pos = 2;

            return ni;
        }

        private Token nodEps()
        {
            return new Token(0, Token.EPS, "ε", 0, 0);
        }

        private NodoGrafo obtUlt(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq == null & nt.der == null)
                    return nt;
                if (nt.izq != null & nt.pos != 2)
                    return obtUlt(nt.izq);
                if (nt.der != null)
                    return obtUlt(nt.der);
            }
            return null;
        }

        private void impGra(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq != null)//& nt.eIzq != null
                {
                    Console.WriteLine(nt.ide + "->" + nt.izq.ide + "[label=\"" + nt.eIzq.lex + "\"];");
                    if (nt.pos != 2 & nt.izq.pos != 1)
                        impGra(nt.izq);
                }

                if (nt.der != null)//& nt.eDer != null
                {
                    Console.WriteLine(nt.ide + "->" + nt.der.ide + "[label=\"" + nt.eDer.lex + "\"];");
                    impGra(nt.der);
                }
            }
        }


        private void numGra(NodoGrafo nt)
        {
            if (nt != null)
            {
                nt.ide = ind2++;
                if (nt.izq != null & nt.eIzq != null)
                    if (nt.izq.pos != 1)
                        numGra(nt.izq);
                if (nt.der != null & nt.eDer != null)
                    numGra(nt.der);
            }
        }



    }
}
