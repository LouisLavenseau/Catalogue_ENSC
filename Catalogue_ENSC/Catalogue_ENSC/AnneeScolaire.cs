using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class AnneeScolaire
    {
        public string Nom { get; private set; }
        public int AnneeDebut { get; private set; }
        public int AnneeFin { get; private set; }
        public Program Program { get; private set; }

        public AnneeScolaire(int anneeDebut, int anneeFin, Program program)
        {
            AnneeDebut = anneeDebut;
            AnneeFin = anneeFin;
            Nom = anneeDebut.ToString() + "-" + anneeFin;
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
