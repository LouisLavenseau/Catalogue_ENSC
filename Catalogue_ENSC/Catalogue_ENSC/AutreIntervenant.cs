using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class AutreIntervenant : Personne
    {
        public string Statut { get; private set; }

        public AutreIntervenant(string identifiant, string prenom, string nom, string statut, string pronom, Program program) : base(identifiant, prenom, nom, pronom, program)
        {
            Statut = statut;
        }

        public AutreIntervenant()
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
