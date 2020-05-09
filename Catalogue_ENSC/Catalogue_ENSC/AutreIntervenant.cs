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

        public AutreIntervenant(string nom, string statut) : base(nom)
        {
            Statut = statut;
        }


        public override string ToString()
        {
            //A Compléter
            return base.ToString();
        }
    }
}
