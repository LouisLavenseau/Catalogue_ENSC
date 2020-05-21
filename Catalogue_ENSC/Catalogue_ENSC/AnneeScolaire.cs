using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class AnneeScolaire
    {
        public string Nom { get; private set; }
        public int AnneeDebut { get; private set; }
        public int AnneeFin { get; private set; }
        public Program Program { get; private set; }

        public AnneeScolaire(string nom, int anneeDebut, int anneeFin, Program program)
        {
            Nom = nom;
            AnneeDebut = anneeDebut;
            AnneeFin = anneeFin;
            Program = program;
        }

        public AnneeScolaire()
        { }

        public override string ToString()
        {  
            return Nom;
        }
    }
}
