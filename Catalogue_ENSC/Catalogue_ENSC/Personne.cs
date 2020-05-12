using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    abstract class Personne
    {
        public string Identifiant { get; private set; }
        public string PrenomNom { get; private set; }

        public Personne(string identifiant, string prenomNom)
        {
            Identifiant = identifiant;
            PrenomNom = prenomNom;
        }

        public override string ToString()
        {   
            return PrenomNom;
        }
    }
}
