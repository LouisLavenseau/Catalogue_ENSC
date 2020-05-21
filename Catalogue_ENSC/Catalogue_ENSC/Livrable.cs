using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Livrable
    {
        public string Nom { get; private set; }
        public Program Program { get; private set; }

        public Livrable(string nom, Program program)
        {
            Nom = nom;
            Program = program;
        }

        public Livrable()
        { }

        public void Supprimer()
        {
            Nom = "";
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
