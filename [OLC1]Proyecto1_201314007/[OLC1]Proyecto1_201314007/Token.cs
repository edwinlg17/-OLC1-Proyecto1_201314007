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
        public const String IDE = "tkIde", NUM = "tkNum", SIM = "tkSim", SES = "tkSes", COM = "tkCom", CAD = "tkCad", CON = "tkCon";
        public String tok, lex;
        public int fil, col, ide;

        /////////////////////////// CONSTRUCTOR
        public Token()
        {
            this.ide = 0;
            this.tok = "";
            this.lex = "";
            this.fil = 0;
            this.col = 0;
        }

        public Token(int ide, String tok, String lex, int fil, int col)
        {
            this.ide = ide;
            this.tok = tok;
            this.lex = lex;
            this.fil = fil;
            this.col = col;
        }

        /////////////////////////// METODOS

    }
}
