using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Matiere
    {
        public string Nom { get; private set; }
        public string Ue { get; private set; }
        public string Code { get; private set; }
        public string CodeUe { get; private set; }

        public Matiere(string nom, string ue, string code, string codeUe)
        {
            Nom = nom;
            Ue = ue;
            Code = code;
            CodeUe = codeUe;
        }

        public Matiere()
        { }

        public override string ToString()
        {   
            return Nom;
        }
    }
}
