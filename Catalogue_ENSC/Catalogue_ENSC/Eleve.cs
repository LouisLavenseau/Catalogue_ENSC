using System;
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


        public Eleve(string prenom, string nom, int promo, bool aRedouble, int anneeEtudeRedoublement, string pronom, Program program) : base(prenom, nom, pronom, program)
        {
            Promo = promo;
            ARedouble = aRedouble;
            AnneeEtudeRedoublement = anneeEtudeRedoublement;
        }

        public Eleve()
        { }

        public int CalculerAnneeEtudeProjet(Projet projet)
        {
            return 3 - Promo + projet.AnneeScolaire.AnneeFin;
        }

        public void ModifierAttribut(string attribut, string valeur)
        {
            if (attribut == "prénom")
            {
                Prenom = valeur;
                Identifiant = Prenom[0].ToString().ToLower() + Nom.ToLower();
            }
            if (attribut == "nom")
            {
                Nom = valeur;
                Identifiant = Prenom[0].ToString().ToLower() + Nom.ToLower();
            }
            if (attribut == "pronom")
            {
                Pronom = valeur;
            }
            if (attribut == "promo")
            {
                Promo = int.Parse(valeur);
                Console.WriteLine("La promo change-t-elle parce que l'élève vient de redoubler ? Ecrivez oui ou non :");
                string reponse = Program.EnleverLesEspaces(Console.ReadLine());
                if (reponse == "oui")
                    ModifierAttribut("redoublement", "oui");
            }

            if (attribut == "redoublement")
            {
                if (valeur == "oui")
                    ARedouble = true; ;
                if (valeur == "non")
                    ARedouble = false;
                Console.WriteLine("En quelle année " + Prenom + " " + Nom + " a-t-" + Pronom + " redoublé ?");
                AnneeEtudeRedoublement = int.Parse(Console.ReadLine());

            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
