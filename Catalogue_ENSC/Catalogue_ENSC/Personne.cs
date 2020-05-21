using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Personne
    {
        public string Identifiant { get; protected set; }
        public string Prenom { get; protected set; }
        public string Nom { get; protected set; }
        public string Pronom { get; protected set; }
        public Program Program { get; private set; }

        public Personne(string identifiant, string prenom, string nom, string pronom, Program program)
        {
            Prenom = prenom;
            Nom = nom;
            Identifiant = identifiant;
            Pronom = pronom;
            Program = program;
        }

        public Personne()
        { }

        public virtual void Supprimer()
        {
            Identifiant = "";
        }

        public override string ToString()
        {   
            return Prenom + " " + Nom;
        }
    }
}
