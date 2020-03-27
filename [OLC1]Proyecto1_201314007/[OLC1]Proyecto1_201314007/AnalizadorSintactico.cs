using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class AnalizadorSintactico
    {
        /////////////////////////// ATRIBUTOS
        ArrayList lisTok, lisGra, tabEst, lisAut;
        int ind, ind2;
        Token tem;
        LisNod tom;

        /////////////////////////// CONSTRUCTOR
        public AnalizadorSintactico()
        {
            this.lisTok = new ArrayList();
            this.lisGra = new ArrayList();
            this.tabEst = new ArrayList();
            this.lisAut = new ArrayList();
            this.tom = new LisNod("");
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
            else if (verificar(Token.IDE))
            {
                tom = new LisNod(tem.lex);
                oe();
            }
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
                anaGra(nt);
                return true;
            }

            return false;
        }

        private NodoGrafo ter()
        {
            if (verificar(Token.CAD))
                return new NodoGrafo(-1, null, null, tem, null, 'e');

            else if (verificar(Token.NUM))
                return new NodoGrafo(-1, null, null, tem, null, 'e');

            else if (verificar(Token.SIM, "{"))
            {
                if (verificar(Token.IDE))
                {
                    Token t = tem;
                    if (verificar(Token.SIM, "}"))
                        return new NodoGrafo(-1, null, null, t, null, 'e');
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
            else if (verificar(Token.SIM, "+"))
            {
                NodoGrafo datA = ter();
                NodoGrafo datB = new NodoGrafo(-1, null, null, datA.eIzq, null, 'e');
                if (datA != null)
                    return plaCon(datA, plaRepCer(datB));
            }
            else if (verificar(Token.SIM, "?"))
            {
                NodoGrafo datA = ter();
                NodoGrafo datB = new NodoGrafo(-1, null, null, nodEps(), null, 'e');
                if (datA != null)
                    return plaSel(datA, datB);
            }

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

        /////////////////////
        private NodoGrafo plaCon(NodoGrafo datA, NodoGrafo datB)
        {
            NodoGrafo nta = obtUlt(datA);
            NodoGrafo ntb = obtUlt(datB);
            NodoGrafo nf = new NodoGrafo();

            datA.tip = 'a';

            nta.izq = datB;
            ntb.izq = nf;

            nf.tip = 'A';

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
            ni.eIzq = nodEps();
            ni.der = datB;
            ni.eDer = nodEps();
            ni.tip = 's';

            nta.izq = nra;
            ntb.izq = nrb;

            nra.izq = nf;
            nra.eIzq = nodEps();
            nra.tip = 'E';

            nrb.der = nf;
            nrb.eDer = nodEps();
            nrb.tip = 'E';

            nf.tip = 'S';

            return ni;
        }

        private NodoGrafo plaRepCer(NodoGrafo datA)
        {
            NodoGrafo ni = new NodoGrafo();
            NodoGrafo nta = obtUlt(datA);
            NodoGrafo nra = new NodoGrafo();
            NodoGrafo nf = new NodoGrafo();

            ni.izq = datA;
            ni.eIzq = nodEps();
            ni.der = nf;
            ni.eDer = nodEps();
            ni.tip = 'c';

            nta.izq = nra;

            nra.izq = datA;
            nra.eIzq = nodEps();
            nra.der = nf;
            nra.eDer = nodEps();
            nra.tip = 'r';

            nf.tip = 'C';

            return ni;
        }

        /////////////////////
        public Token nodEps()
        {
            return new Token(0, Token.EPS, "ε", 0, 0);
        }

        private NodoGrafo obtUlt(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq == null & nt.der == null)
                    return nt;

                if (nt.izq != null & nt.tip != 'r')
                    return obtUlt(nt.izq);
                if (nt.der != null)
                    return obtUlt(nt.der);
            }
            return null;
        }

        ///////////////////// otras metodos
        private void impGra(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq != null)
                {
                    if (nt.eIzq != null)
                        //Console.WriteLine(nt.tip + "" + nt.ide + "->" + nt.izq.tip + nt.izq.ide + "[label=\"" + " IZQ " + nt.eIzq.lex + "\"];");
                        tom.agregar(nt.ide, new NodCon(nt.izq.ide, nt.eIzq));
                    else
                        Console.WriteLine(nt.tip + "" + nt.ide + "->" + nt.izq.tip + nt.izq.ide + "[label=\"" + "IZQ" + "\"];");
                    if (nt.tip != 'r')
                        impGra(nt.izq);
                }

                if (nt.der != null)
                {
                    if (nt.eDer != null)
                        //Console.WriteLine(nt.tip + "" + nt.ide + "->" + nt.der.tip + nt.der.ide + "[label=\"" + " DER " + nt.eDer.lex + "\"];");
                        tom.agregar(nt.ide, new NodCon(nt.der.ide, nt.eDer));
                    else
                        Console.WriteLine(nt.tip + "" + nt.ide + "->" + nt.der.tip + nt.der.ide + "[label=\"" + "DER" + "\"];");

                    impGra(nt.der);
                }
            }
        }

        private void numGra(NodoGrafo nt)
        {
            if (nt != null)
            {
                nt.ide = ind2++;

                if (nt.izq != null)
                    if (nt.tip != 'r')
                        numGra(nt.izq);

                if (nt.der != null)
                    numGra(nt.der);
            }
        }

        private void eliVac(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq != null)
                    if (nt.izq.izq != null)
                        if (nt.izq.eIzq == null)
                            nt.izq = obtNod(nt.izq);

                if (nt.der != null)
                    if (nt.der.izq != null)
                        if (nt.der.eIzq == null)
                            nt.der = obtNod(nt.der);

                if (nt.tip != 'r')
                    if (nt.izq != null)
                        eliVac(nt.izq);

                if (nt.der != null)
                    eliVac(nt.der);
            }
        }

        private NodoGrafo obtNod(NodoGrafo nt)
        {
            if (nt != null)
            {
                if (nt.izq != null)
                    if (nt.eIzq != null)
                        return nt;

                if (nt.izq == null & nt.der == null)
                    return nt;

                if (nt.tip != 'r')
                    if (nt.izq != null)
                        return obtNod(nt.izq);

                if (nt.der != null)
                    return obtNod(nt.der);
            }

            return null;
        }

        /////////////////////

        private void anaGra(NodoGrafo nt)
        {
            Console.WriteLine();
            ind2 = 0;
            numGra(nt);
            eliVac(nt);
            impGra(nt);

            tom.reNum();
            tom.anaLis();
            lisGra.Add(tom);
            tabEst.Add(tom.genTabTra());
            lisAut.Add(tom.genAut());


            ////////////////////////////////
            genGrafos();


        }

        public void genGrafos()
        {
            String cod = "";

            LisNod ln;
            for (int i = 0; i < lisGra.Count; i++)
            {
                cod = "digraph G {\nrankdir=LR;\n";
                ln = (LisNod)lisGra[i];
                cod += ln.genCodGra();
                cod += "}\n\n";

                // ruta del escritorio
                Environment.CurrentDirectory = Environment.GetEnvironmentVariable("USERPROFILE");
                DirectoryInfo info = new DirectoryInfo(".");

                // creo el archivo
                System.IO.StreamWriter file = new System.IO.StreamWriter(info.FullName + "/Desktop/Diagramas/gra_" + ln.nom + ".dot");
                file.WriteLine(cod);
                file.Close();

                // genero la imagen
                String comando = "dot " + info.FullName + "/Desktop/Diagramas/gra_" + ln.nom + ".dot -o " + info.FullName + "/Desktop/Diagramas/gra_" + ln.nom + ".png -Tpng -Gcharset=utf8";
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = false;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();

            }

        }

    }

    class LisNod
    {
        /////////////////////
        public ArrayList lis, lisCon;
        public String nom;
        public int fin;

        /////////////////////
        public LisNod(String nom)
        {
            this.nom = nom;
            this.lis = new ArrayList();
            this.fin = -1;
        }

        /////////////////////
        public void agregar(int id, NodCon nue)
        {
            Boolean ver = true;
            NodList nt;
            for (int i = 0; i < lis.Count; i++)
            {
                nt = (NodList)lis[i];
                if (nt.id == id)
                {
                    nt.agregar(nue);
                    ver = false;
                    break;
                }
            }
            if (ver)
                lis.Add(new NodList(id, nue));
        }

        public String genCodGra()
        {
            String cod = "";
            NodList nl;
            for (int i = 0; i < lis.Count; i++)
            {
                nl = (NodList)lis[i];
                NodCon nc;
                for (int j = 0; j < nl.lis.Count; j++)
                {
                    nc = (NodCon)nl.lis[j];
                    cod += nl.id + "->" + nc.id + "[label=\"" + nc.tk.lex + "\"];\n";
                }
            }

            return cod;
        }

        public void reNum()
        {
            NodList nl;
            ArrayList t = new ArrayList();
            for (int i = 0; i < lis.Count; i++)
            {
                nl = (NodList)lis[i];
                if (!t.Contains(nl.id))
                    t.Add(nl.id);
                NodCon nc;
                for (int j = 0; j < nl.lis.Count; j++)
                {
                    nc = (NodCon)nl.lis[j];
                    if (!t.Contains(nc.id))
                        t.Add(nc.id);
                }
            }
            t.Sort();

            for (int i = 0; i < t.Count; i++)
            {
                int n = (int)t[i];
                if ((int)t[i] != i)
                    remNum((int)t[i], i);
            }

            t.Sort();
            fin = t.Count - 1;
        }

        public void remNum(int a, int n)
        {
            NodList nl;
            for (int i = 0; i < lis.Count; i++)
            {
                nl = (NodList)lis[i];
                if (nl.id == a)
                    nl.id = n;
                NodCon nc;
                for (int j = 0; j < nl.lis.Count; j++)
                {
                    nc = (NodCon)nl.lis[j];
                    if (nc.id == a)
                        nc.id = n;
                }
            }
        }

        // Analizar Grafo
        public void anaLis()
        {
            lisCon = new ArrayList();

            // Cerradura de 0
            ArrayList tem = new ArrayList();
            tem.Add(0);
            int ind = 0;
            lisCon.Add(new SubCon('c', 0, tokEps(), obtCer(tem, tokEps()), ind++));

            // Terminales
            ArrayList ter = obtTer();

            SubCon s;
            for (int i = 0; i < lisCon.Count; i++)
            {
                s = (SubCon)lisCon[i];

                if (s.tip == 'c')
                {
                    Token tk;
                    for (int j = 0; j < ter.Count; j++)
                    {
                        tk = (Token)ter[j];
                        ArrayList mt = obtMue(s.lis, tk);
                        if (mt.Count > 0)
                        {
                            int con = verCon(lisCon, mt, 'm');
                            if (con == -1)
                                lisCon.Add(new SubCon('m', s.con, tk, mt, ind++));
                            else
                                lisCon.Add(new SubCon('m', s.con, tk, mt, con));
                        }
                    }
                }
                else if (s.tip == 'm')
                {
                    if (s.lis.Count > 0)
                    {
                        ArrayList ct = obtCer(s.lis, tokEps());
                        int con = verCon(lisCon, ct, 'c');
                        if (con == -1)
                            lisCon.Add(new SubCon('c', 0, tokEps(), ct, s.con));
                    }
                }


                if (s.tip == 'c')
                {
                    Console.WriteLine(s.tip + "=" + s.con);
                }
                else
                {
                    Console.WriteLine(s.tip + "(" + s.mue + ", " + s.tok.lex + ") = " + s.con);
                }


                for (int j = 0; j < s.lis.Count; j++)
                {
                    int e = (int)s.lis[j];
                    Console.Write(e + " ");
                }

                Console.WriteLine();
            }
        }

        public ArrayList genTabTra()
        {
            ArrayList tab = new ArrayList();

            SubCon s;
            for (int i = 0; i < lisCon.Count; i++)
            {
                s = (SubCon)lisCon[i];

                if (s.tip == 'c')
                {
                    Est est = new Est(s.con, genLisTra());
                    SubCon t;
                    for (int j = 0; j < lisCon.Count; j++)
                    {
                        t = (SubCon)lisCon[j];
                        if (t.tip == 'm')
                            if (t.mue == s.con)
                                est.agregar(new Tra(t.tok, t.con));
                    }
                    tab.Add(est);
                }

            }
            return tab;
        }

        public ArrayList genLisTra()
        {
            ArrayList ter = obtTer();
            ArrayList nue = new ArrayList();

            Token tok;
            for (int i = 0; i < ter.Count; i++)
            {
                tok = (Token)ter[i];
                nue.Add(new Tra(tok, -1));
            }
            return nue;
        }

        public Aut genAut()
        {
            Aut aut = new Aut(this.nom);

            SubCon s;
            for (int i = 0; i < lisCon.Count; i++)
            {
                s = (SubCon)lisCon[i];

                if (s.tip == 'c')
                    if (s.lis.Contains(fin))
                        aut.agrEstFin(s.con);

                if (s.tip == 'm')
                    aut.agreEnl(new Enl(s.mue, s.con, s.tok));

            }
            return aut;
        }

        // Verificar y Buscar
        private Boolean busTok(Token tok, ArrayList lis)
        {
            Token tem;
            for (int i = 0; i < lis.Count; i++)
            {
                tem = (Token)lis[i];
                if (verTok(tok, tem))
                    return true;
            }
            return false;
        }

        private Boolean verTok(Token a, Token b)
        {
            if (a.ide == b.ide)
                if (a.tok.Equals(b.tok))
                    if (a.lex.Equals(b.lex))
                        return true;
            return false;
        }

        private int verCon(ArrayList lisCon, ArrayList nueCon, char tip)
        {
            SubCon s;
            for (int i = 0; i < lisCon.Count; i++)
            {
                s = (SubCon)lisCon[i];
                s.lis.Sort();
                nueCon.Sort();

                if (s.tip == tip)
                {
                    if (s.lis.Count == nueCon.Count)
                    {
                        Boolean ver = true;
                        for (int j = 0; j < nueCon.Count; j++)
                        {
                            if ((int)nueCon[j] != (int)s.lis[j])
                                ver = false;
                        }
                        if (ver)
                            return s.con;
                    }
                }
            }
            return -1;
        }

        // Cerraduras
        private ArrayList obtCer(ArrayList lb, Token le)
        {
            ArrayList c = new ArrayList();

            int e;
            for (int i = 0; i < lb.Count; i++)
            {
                e = (int)lb[i]; // elemento
                c.Add(e);
            }

            for (int a = 0; a < c.Count; a++)
            {
                e = (int)c[a]; // elemento
                NodList nl;
                for (int i = 0; i < lis.Count; i++)
                {
                    nl = (NodList)lis[i]; // elemento
                    if (nl.id == e)
                    {
                        NodCon nc;
                        for (int j = 0; j < nl.lis.Count; j++)
                        {
                            nc = (NodCon)nl.lis[j]; // elemento
                            if (verTok(le, nc.tk))
                                c.Add(nc.id);
                        }
                    }
                }
            }

            return c;
        }

        private ArrayList obtMue(ArrayList c, Token le)
        {
            ArrayList m = new ArrayList();

            int e;
            for (int a = 0; a < c.Count; a++)
            {
                e = (int)c[a]; // elemento
                NodList nl;
                for (int i = 0; i < lis.Count; i++)
                {
                    nl = (NodList)lis[i]; // elemento
                    if (nl.id == e)
                    {
                        NodCon nc;
                        for (int j = 0; j < nl.lis.Count; j++)
                        {
                            nc = (NodCon)nl.lis[j]; // elemento
                            if (verTok(le, nc.tk))
                                m.Add(nc.id);
                        }
                    }
                }
            }

            return m;
        }

        private ArrayList obtTer()
        {
            ArrayList lt = new ArrayList();

            NodList nl;
            for (int i = 0; i < lis.Count; i++)
            {
                nl = (NodList)lis[i];
                NodCon nc;
                for (int j = 0; j < nl.lis.Count; j++)
                {
                    nc = (NodCon)nl.lis[j];

                    if (!verTok(nc.tk, tokEps()))
                        if (!busTok(nc.tk, lt))
                            lt.Add(nc.tk);
                }
            }
            return lt;
        }

        // otros
        private Token tokEps()
        {
            return new Token(0, Token.EPS, "ε", 0, 0);
        }
    }

    class NodList
    {
        /////////////////////
        public int id;
        public ArrayList lis;

        /////////////////////
        public NodList(int id, NodCon nue)
        {
            this.lis = new ArrayList();
            this.lis.Add(nue);
            this.id = id;
        }

        /////////////////////
        public void agregar(NodCon nue)
        {
            Boolean ver = true;
            for (int i = 0; i < this.lis.Count; i++)
            {
                NodCon ele = (NodCon)this.lis[i];
                if (ele.id == nue.id)
                {
                    ver = false;
                    break;
                }
            }
            if (ver)
                this.lis.Add(nue);
        }

    }

    class NodCon
    {
        /////////////////////
        public int id;
        public Token tk;

        /////////////////////
        public NodCon(int id, Token tk)
        {
            this.id = id;
            this.tk = tk;
        }

        /////////////////////

    }

    class SubCon
    {
        /////////////////////
        public char tip;
        public int con, mue;
        public Token tok;
        public ArrayList lis;

        /////////////////////    
        public SubCon(char tip, int mue, Token tok, ArrayList lis, int con)
        {
            this.tip = tip;
            this.mue = mue;
            this.tok = tok;
            this.lis = lis;
            this.con = con;
        }


        /////////////////////


    }

    ///////////////////// Automata
    class Aut
    {
        /////////////////////
        public String nom;
        public ArrayList lisEnl, estFin;

        /////////////////////
        public Aut(String nom)
        {
            this.nom = nom;
            this.lisEnl = new ArrayList();
            this.estFin = new ArrayList();
        }

        /////////////////////
        public void agreEnl(Enl enl)
        {
            this.lisEnl.Add(enl);
        }

        public void agrEstFin(int e)
        {
            estFin.Add(e);
        }


    }

    class Enl
    {
        /////////////////////
        public int ini, fin;
        public Token tok;

        /////////////////////
        public Enl(int ini, int fin, Token tok)
        {
            this.ini = ini;
            this.fin = fin;
            this.tok = tok;
        }

        /////////////////////

    }

    ///////////////////// Tabla de Transiciones 
    class Est
    {
        /////////////////////
        public int est;
        public ArrayList lisTra;

        /////////////////////
        public Est(int est, ArrayList lisTra)
        {
            this.est = est;
            this.lisTra = lisTra;
        }

        /////////////////////
        public void agregar(Tra tra)
        {
            Tra t;
            for (int i = 0; i < lisTra.Count; i++)
            {
                t = (Tra)lisTra[i];
                if (t.tok.Equals(tra.tok))
                {
                    t.est = tra.est;
                    break;
                }
            }
        }

    }

    class Tra
    {
        /////////////////////
        public Token tok;
        public int est;

        /////////////////////
        public Tra(Token tok, int est)
        {
            this.tok = tok;
            this.est = est;
        }

        /////////////////////

    }

}
