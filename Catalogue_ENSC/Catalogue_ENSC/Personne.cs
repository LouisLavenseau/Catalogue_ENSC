using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    abstract class Personne
    {
        public string Nom { get; private set; }

        public Personne(string nom)
        {
            Nom = nom;
        }

        public override string ToString()
        {   //A compléter
            return base.ToString();
        }
    }
}
