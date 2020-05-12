﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Eleve : Personne
    {
        public int Promo { get; private set; }
        public bool ARedouble { get; private set; }
        public int AnneeEtudeRedoublement { get; private set; }

        public Eleve(string identifiant, string prenomNom, int promo, bool aRedouble, int anneeEtudeRedoublement) : base(identifiant,prenomNom)
        {
            Promo = promo;
            ARedouble = aRedouble;
            AnneeEtudeRedoublement = anneeEtudeRedoublement;
        }

        public void CalculerAnneeEtudeProjet(Projet projet)
        {
            //A compléter
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
