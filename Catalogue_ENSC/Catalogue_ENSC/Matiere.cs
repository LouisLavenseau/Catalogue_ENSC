using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Matiere
    {
        public string Nom { get; private set; }
        public string Ue { get; private set; }
        public string Code { get; private set; }
        public string CodeUe { get; private set; }
        public Program Program { get; private set; }

        public Matiere(string nom, string code, string ue, string codeUe, Program program)
        {
            Nom = nom;
            Ue = ue;
            Code = code;
            CodeUe = codeUe;
            Program = program;
        }

        public Matiere()
        { }

        

        public override string ToString()
        {   
            return Nom;
        }
    }
}
