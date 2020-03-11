using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201314007
{
    class Token
    {
        /////////////////////////// ATRIBUTOS
        public String tok, lex;
        public int fil, col;

        /////////////////////////// CONSTRUCTOR
        public Token()
        {
            this.tok = "";
            this.lex = "";
            this.fil = 0;
            this.col = 0;
        }

        public Token(String tok, String lex, int fil, int col)
        {
            this.tok = tok;
            this.lex = lex;
            this.fil = fil;
            this.col = col;
        }

        /////////////////////////// METODOS

    }
}
