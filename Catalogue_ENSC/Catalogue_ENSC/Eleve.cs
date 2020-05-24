using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Eleve : Personne
    {
        public int Promo { get; private set; }
        public bool ARedouble { get; private set; }
        public int AnneeEtudeRedoublement { get; private set; }


        public Eleve(string identifiant, string prenom, string nom, int promo, bool aRedouble, int anneeEtudeRedoublement, string pronom, Program program) : base(identifiant, prenom, nom, pronom, program)
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
            int place = 0;

            if (attribut == "prénom")
            {
                Prenom = valeur;
                place = 2;
                SauvegarderModifFichierTxtEleve(place, Identifiant, valeur);
                string nouvelIdentifiant = Prenom[0].ToString().ToLower() + Nom.ToLower();
                SauvegarderModifFichierTxtEleve(0, Identifiant, nouvelIdentifiant);
                Identifiant = nouvelIdentifiant;


            }
            if (attribut == "nom")
            {
                Nom = valeur;
                place = 3;
                SauvegarderModifFichierTxtEleve(place, Identifiant, valeur);
                string nouvelIdentifiant = Prenom[0].ToString().ToLower() + Nom.ToLower();
                SauvegarderModifFichierTxtEleve(0, Identifiant, nouvelIdentifiant);
                Identifiant = nouvelIdentifiant;

            }
            if (attribut == "pronom")
            {
                Pronom = valeur;
                place = 7;
                SauvegarderModifFichierTxtEleve(place, Identifiant, valeur);
            }
            if (attribut == "promo")
            {
                Promo = int.Parse(valeur);
                place = 4;
                SauvegarderModifFichierTxtEleve(place, Identifiant, valeur);
                Console.WriteLine("La promo change-t-elle parce que l'élève vient de redoubler ? Ecrivez oui ou non :");
                string reponse = Program.EnleverLesEspaces(Console.ReadLine());
                if (reponse == "oui")
                    ModifierAttribut("redoublement", "oui");
            }

            if (attribut == "redoublement")
            {
                place = 5;
                SauvegarderModifFichierTxtEleve(place, Identifiant, valeur);
                if (valeur == "oui")
                    ARedouble = true; ;
                if (valeur == "non")
                    ARedouble = false;
                Console.WriteLine("En quelle année " + Prenom + " " + Nom + " a-t-" + Pronom + " redoublé ?");
                place = 6;
                string stringAnneeEtudeRedoublement = Console.ReadLine();
                AnneeEtudeRedoublement = int.Parse(stringAnneeEtudeRedoublement);
                SauvegarderModifFichierTxtEleve(place, Identifiant, stringAnneeEtudeRedoublement);

            }

            Console.WriteLine("Modification réalisée avec succès !");
            Console.ReadLine();


        }

        public void SauvegarderModifFichierTxtEleve(int place, string identifiant, string valeur)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Eleves.txt", encoding);

            string contenuModifie = "";
            int nbMots = 0;
            string mot = "";
            int ratio = 7;
            bool identifiantPasse = false;

            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();

                if (nbMots % ratio == 1 & mot == identifiant)
                {
                    if (place == 0)
                    {
                        if (nbMots == 1)
                            contenuModifie += valeur;
                        else
                            contenuModifie += "\n" + valeur;
                    }
                    else
                    {
                        identifiantPasse = true;
                        if (nbMots == 1)
                            contenuModifie += mot;
                        else
                        {
                            nbMots = 1;
                            contenuModifie += "\n" + mot;
                        }
                    }
                }
                else if (identifiantPasse & nbMots == place)
                {
                    contenuModifie += "\n" + valeur;
                }
                else
                {
                    if (nbMots == 1)
                        contenuModifie += mot;
                    else
                        contenuModifie += "\n" + mot;
                }

            }

            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();

            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.CreateText("Eleves.txt");

            monStreamWriter.WriteLine(contenuModifie);


            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

       /* public void Supprimer()
        {

        }
        */
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
