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

        public AnneeScolaire(string nom, int anneeDebut, int anneeFin)
        {
            Nom = nom;
            AnneeDebut = anneeDebut;
            AnneeFin = anneeFin;
        }

        public AnneeScolaire()
        { }

        public override string ToString()
        {  
            return Nom;
        }
    }
}
