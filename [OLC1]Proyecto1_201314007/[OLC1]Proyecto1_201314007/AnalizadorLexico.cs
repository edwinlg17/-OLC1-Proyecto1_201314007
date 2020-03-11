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

        /////////////////////////// METODOS
        public void analizar(String cad)
        {
            String lex = "";
            int est = 0, ind = 0, fil = 0, col = 0;
            char car = ' ';

            cad += "   ";


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
                            Console.WriteLine("->" + lex);
                            lex = "";
                            est = 0;
                        }
                        break;
                    // estado 2
                    case 2:
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
            if ((car >= ' ' & car <= '~') & !esLet(car) & !esNum(car))
            {
                return true;
            }
            return false;
        }
    }
}
