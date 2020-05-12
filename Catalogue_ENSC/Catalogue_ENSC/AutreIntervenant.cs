using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class AutreIntervenant : Personne
    {
        public string Statut { get; private set; }

        public AutreIntervenant(string identifiant, string prenomNom, string statut) : base(identifiant, prenomNom)
        {
            Statut = statut;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
