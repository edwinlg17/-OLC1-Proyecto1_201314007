using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class AnalizadorLexico
    {
        /////////////////////////// ATRIBUTOS
        public const String IDE = "tkIde", NUM = "tkNum", SIM = "tkSim", SES = "tkSes", COM = "tkCom", CAD = "tkCad", CON = "tkCon";

        public ArrayList lisTok;

        /////////////////////////// CONSTRUCTOR
        public AnalizadorLexico()
        {
            lisTok = new ArrayList();
        }

        /////////////////////////// METODOS
        public void analizar(String cad)
        {
            lisTok = new ArrayList();
            String lex = "";
            int est = 0, ind = 0, fil = 0, col = 0, ft = 0, ct = 0;
            char car;

            cad += "\n  ";


            while (ind < cad.Length)
            {
                car = cad[ind];
                switch (est)
                {
                    ////////////////////////// estado 0 Inicial
                    case 0:
                        ////////// identificador
                        if (esLet(car))
                        {
                            est = 1; // cambio estado
                            lex += car;
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ////////// numero
                        else if (esNum(car))
                        {
                            est = 2; // cambio estado
                            lex += car;
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ////////// simbolo especial
                        else if (car == '\\')
                        {
                            est = 3; // cambio estado
                            lex += car;
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ////////// comentario
                        else if (car == '/')
                        {
                            est = 5; // cambio estado
                            lex += car;
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ////////// comentario multi linea
                        else if (car == '<')
                        {
                            est = 6; // cambio estado
                            lex += car;
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        else if (car == '"')
                        {
                            est = 7; // cambio estado
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ////////// simbolos
                        else if (esSim(car))
                        {
                            ft = fil;
                            ct = col;
                            lisTok.Add(new Token((int)car, SIM, car.ToString(), ft, ct));
                            //Console.WriteLine(SIM + " -> " + car + " - " + (int)car + " - fil: " + ft + " - col: " + ct);
                            col++;
                        }
                        ////////// caracteres especiales
                        else if (car == '\n')
                        {
                            fil++;
                            col = 0;
                            // salto de linea
                        }
                        else if (car == ' ' | car == '\t' | car == '\r')
                        {
                            // caracteres omitibles
                            col++;
                        }
                        else
                        {
                            //Console.WriteLine("Error -> " + car);
                            ft = fil;
                            ct = col;
                            col++;
                        }
                        ind++; // cambio caracter
                        break;
                    ////////////////////////// estado 1 Identificadores
                    case 1:
                        if (esLet(car) | esNum(car) | car == '_')
                        {
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 0; // cambio de estado
                            if (lex.ToLower().Equals("conj"))
                            {
                                lisTok.Add(new Token(0, CON, lex, ft, ct));
                            }
                            else 
                            {
                                lisTok.Add(new Token(0, IDE, lex, ft, ct));
                            }
                            //Console.WriteLine(IDE + " -> " + lex + " 0" + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        break;
                    ////////////////////////// estado 2 Numeros
                    case 2:
                        if (esNum(car))
                        {
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 0; // cambio estado
                            lisTok.Add(new Token(1, NUM, lex, ft, ct));
                            //Console.WriteLine(NUM + " -> " + lex + " 1" + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        break;
                    ////////////////////////// estado 3 Simbolo Especial
                    case 3:
                        est = 0;
                        if (esSimEsp(car))
                        {
                            if (car == 'n')
                            {
                                lisTok.Add(new Token((int)'\n', SIM, "\n", ft, ct));
                                //Console.WriteLine(SIM + " -> \n - " + (int)'\n' + " - fil: " + ft + " - col: " + ct);
                            }
                            else if (car == 't')
                            {
                                lisTok.Add(new Token((int)'\t', SIM, "\t", ft, ct));
                                //Console.WriteLine(SIM + " -> \t - " + (int)'\t' + " - fil: " + ft + " - col: " + ct);
                            }
                            else
                            {
                                lisTok.Add(new Token((int)car, SIM, car.ToString(), ft, ct));
                                //Console.WriteLine(SIM + " -> " + car + " - " + (int)car + " - fil: " + ft + " - col: " + ct);
                            }
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            lisTok.Add(new Token((int)lex[0], SIM, lex[0].ToString(), ft, ct));
                            //Console.WriteLine(SIM + " -> " + lex + " - " + (int)lex[0] + " - fil: " + ft + " - col: " + ct);
                        }
                        lex = "";
                        break;
                    ////////////////////////// estado 5 Comentario
                    case 5:
                        if (car == '/')
                        {
                            est = 8; // cambio estado
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 0; // cambio estado
                            lisTok.Add(new Token((int)lex[0], SIM, lex[0].ToString(), ft, ct));
                            //Console.WriteLine(SIM + " -> " + lex + " - " + (int)lex[0] + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        break;
                    // estado 8
                    case 8:
                        if (car != '\n')
                        {
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 0; // cambio estado
                            //Console.WriteLine(COM + " -> " + lex + " - " + 3 + " - fil: " + ft + " - col: " + ct);
                            col = 0;
                            lex = "";
                        }
                        break;
                    ////////////////////////// estado 6 Comentario Multilinea
                    case 6:
                        if (car == '!')
                        {
                            est = 9; // cambio estado
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 0; // cambio estado
                            lisTok.Add(new Token((int)lex[0], SIM, lex[0].ToString(), ft, ct));
                            //Console.WriteLine(SIM + " -> " + lex + " - " + (int)lex[0] + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        break;
                    // estado 9
                    case 9:
                        if (car == '\n')
                        {
                            fil++;
                            col = 0;
                        }
                        else if (car != '!')
                        {
                            lex += car;
                            col++;
                        }
                        else
                        {
                            est = 12; // cambio estado
                            lex += car;
                            col++;
                        }
                        ind++; // cambio caracter
                        break;
                    // estado 12
                    case 12:
                        lex += car;
                        if (car == '>')
                        {
                            est = 0; // cambio estado
                            //Console.WriteLine(COM + " -> " + lex + " - " + 3 + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        else
                        {
                            est = 9; // cambio estado
                        }
                        col++;
                        ind++; // cambio caracter
                        break;
                    ////////////////////////// estado 7 Cadenas
                    case 7:
                        if (car == '[')
                        {
                            est = 10; // cambio estado
                        }
                        else if (car == '\\')
                        {
                            est = 11; // cambio estado
                        }
                        else if (car == '\n')
                        {
                            //Console.WriteLine("Error 0 -> " + car);
                        }
                        else if (car != '"')
                        {
                            lex += car;
                        }
                        else
                        {
                            est = 0; // cambio estado
                            lisTok.Add(new Token(4, CAD, lex, ft, ct));
                            //Console.WriteLine(CAD + " -> " + lex + " - " + 4 + " - fil: " + ft + " - col: " + ct);
                            lex = "";
                        }
                        col++;
                        ind++; // cambio caracter
                        break;
                    // estado 10
                    case 10:
                        if (car == ':')
                        {
                            est = 13; // cambio estado
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 7; // cambio estado
                        }
                        break;
                    // estado 13
                    case 13:
                        if (car == ':')
                        {
                            est = 14; // cambio estado
                        }
                        else
                        {
                            lex += car; // cambio estado
                        }
                        col++;
                        ind++; // cambio caracter
                        break;
                    // estado 14
                    case 14:
                        if (car == ']')
                        {
                            est = 7; // cambio estado
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 13; // cambio estado
                            lex += ':';
                        }
                        break;
                    // estado 13
                    case 11:
                        if (esSim(car))
                        {
                            est = 7; // cambio estado
                            lex += car;
                            col++;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            est = 7; // cambio estado
                            lex += '\\';
                        }
                        break;
                }
            }
        }

        private Boolean esLet(char car)
        {
            if (car >= 'a' & car <= 'z')
            {
                return true;
            }
            if (car >= 'A' & (int)car <= 'Z')
            {
                return true;
            }
            if (car == 'ñ' | car == 'Ñ')
            {
                return true;
            }
            return false;
        }
        private Boolean esNum(char car)
        {
            if (car >= '0' & car <= '9')
            {
                return true;
            }
            return false;
        }
        private Boolean esSim(char car)
        {
            if ((car >= '!' & car <= '~') & !esLet(car) & !esNum(car))
            {
                return true;
            }
            return false;
        }
        private Boolean esSimEsp(char car)
        {
            if (car == 'n' | car == 't')
            {
                return true;
            }
            if ((car >= ' ' & car <= '~') & !esLet(car) & !esNum(car))
            {
                return true;
            }
            return false;
        }
    }
}
