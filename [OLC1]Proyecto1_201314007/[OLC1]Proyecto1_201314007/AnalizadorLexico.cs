using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class AnalizadorLexico
    {
        /////////////////////////// ATRIBUTOS


        /////////////////////////// CONSTRUCTOR
        public AnalizadorLexico()
        {

        }
        public const String IDE = "tkIde", NUM = "tkNum", SIM = "tkSim", SES = "tkSes", COM = "tkCom";

        /////////////////////////// METODOS
        public void analizar(String cad)
        {
            String lex = "";
            int est = 0, ind = 0, fil = 0, col = 0;
            char car = ' ';

            cad += "\n  ";


            while (ind < cad.Length)
            {
                car = cad[ind];
                switch (est)
                {
                    ////////////////////////// estado 0 Inicial
                    case 0:
                        if (esLet(car))
                        {
                            lex += car;
                            est = 1; // cambio estado
                        }
                        else if (esNum(car))
                        {
                            lex += car;
                            est = 2; // cambio estado
                        }
                        else if (car == '\\')
                        {
                            lex += car;
                            est = 3; // cambio estado
                        }
                        else if (car == '/')
                        {
                            lex += car;
                            est = 5; // cambio estado
                        }
                        else if (car == '<')
                        {
                            lex += car;
                            est = 6; // cambio estado
                        }
                        else if (esSim(car))
                        {
                            Console.WriteLine(SIM + " -> " + car + " - " + (int)car);
                        }
                        else if (car == '\n')
                        {
                            // salto de linea
                        }
                        else if (car == ' ' | car == '\t' | car == '\r')
                        {
                            // caracteres omitibles
                        }

                        ind++;
                        break;
                    ////////////////////////// estado 1 Identificadores
                    case 1:
                        if (esLet(car) | esNum(car) | car == '_')
                        {
                            lex += car;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(IDE + " -> " + lex + " 0");
                            lex = "";
                            est = 0;
                        }
                        break;
                    ////////////////////////// estado 2 Numeros
                    case 2:
                        if (esNum(car))
                        {
                            lex += car;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(NUM + " -> " + lex + " 1");
                            lex = "";
                            est = 0;
                        }
                        break;
                    ////////////////////////// estado 3 Simbolo Especial
                    case 3:
                        if (esSimEsp(car))
                        {
                            if (car == 'n')
                            {
                                Console.WriteLine(SIM + " -> \n - " + (int)'\n');
                            }
                            else if (car == 't')
                            {
                                Console.WriteLine(SIM + " -> \t - " + (int)'\t');
                            }
                            else
                            {
                                Console.WriteLine(SIM + " -> " + car + " - " + (int)car);
                            }
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(SIM + " -> " + lex + " - " + (int)lex[0]);
                        }
                        lex = "";
                        est = 0;
                        break;
                    ////////////////////////// estado 5 Comentario
                    case 5:
                        if (car == '/')
                        {
                            lex += car;
                            est = 8;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(SIM + " -> " + lex + " - " + (int)'/');
                            lex = "";
                            est = 0;
                        }
                        break;
                    // estado 8
                    case 8:
                        if (car != '\n')
                        {
                            lex += car;
                            est = 8;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(COM + " -> " + lex + " - " + 3);
                            lex = "";
                            est = 0;
                        }
                        break;
                    ////////////////////////// estado 6 Comentario Multilinea
                    case 6:
                        if (car == '!')
                        {
                            lex += car;
                            est = 9;
                            ind++; // cambio caracter
                        }
                        else
                        {
                            Console.WriteLine(SIM + " -> " + lex + " - " + (int)'<');
                            lex = "";
                            est = 0;
                        }
                        break;
                    // estado 9
                    case 9:
                        if (car != '!')
                        {
                            est = 9;
                        }
                        else
                        {
                            est = 12;
                        }
                        lex += car;
                        ind++; // cambio caracter
                        break;
                    // estado 9
                    case 12:
                        lex += car;
                        if (car == '>')
                        {
                            Console.WriteLine(COM + " -> " + lex + " - " + 3);
                            lex = "";
                            est = 0;
                        }
                        else
                        {
                            est = 9;
                        }
                        ind++; // cambio caracter
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
