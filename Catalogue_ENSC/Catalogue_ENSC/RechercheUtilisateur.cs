using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class RechercheUtilisateur
    {

        public Repertoire Repertoire { get; private set; }

        public RechercheUtilisateur(Repertoire repertoire)
        {
            Repertoire = repertoire;
        }

        public void InitialiserConsultation()
        {
            Console.WriteLine("Quel mode de recherche voulez-vous utiliser ? Ecrivez élève, tuteur, client, année de scolarité, année d'étude, \n " +
                "promotion, mot-clef, liberté de sujet, matière, livrable, ou type de projet");
            string modeDeRecherche = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Et une recherche sur quel " + modeDeRecherche + " voulez-vous réaliser ?");
            string instanceDeRecherche = Console.ReadLine();
            Console.Clear();
            if (modeDeRecherche == "élève")
            {
                ConsulterEleve(modeDeRecherche, instanceDeRecherche);
            }
            if (modeDeRecherche == "type de projet ")
            {
                ConsulterTypeDeProjet(modeDeRecherche, instanceDeRecherche);
            }
            if (modeDeRecherche == "promo")
            {
                ConsulterPromo(modeDeRecherche, instanceDeRecherche);
            }
            if (modeDeRecherche == "mots-clef")
            {
                ConsulterMotClef(modeDeRecherche, instanceDeRecherche);
            }
            if (modeDeRecherche == "année de scolarité")
            {
                ConsulterAnneeScolaire(modeDeRecherche, instanceDeRecherche);
            }
            Console.ReadKey();
        }


        public void ConsulterEleve(string modeDeRecherche, string instanceDeRecherche)
        {
            Console.WriteLine("Comment voulez-classer à l'affichage les projets qui correspondent à la recherche ? Ecrivez année d'étude, liberté de sujet, ou matière");
            string classement = Console.ReadLine();
            Console.ReadKey();
            List<Projet> projetsAAfficher = new List<Projet> { };
            Eleve eleveDeRecherche = (Eleve)Convert.ChangeType(Repertoire["eleve", instanceDeRecherche], typeof(Eleve));
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {
                foreach (Eleve eleve in projet.Etudiants)
                {
                    if (eleve == eleveDeRecherche)
                    {
                        projetsAAfficher.Add(projet);
                        Console.WriteLine(projet);
                    }
                }
            }
            
            /*if (classement == "année d'étude")
           {
                foreach (int anneeEtude in Repertoire.RepertoireAnneesEtudes) // Pour chaque année d'étude, on affiche les projets
                {
                    if (anneeEtude == 3)
                        Console.WriteLine("\n \n Troisième année d'étude : \n");
                    if (anneeEtude == 2)
                        Console.WriteLine("\n \n Deuxième année d'étude : \n");
                    if (anneeEtude == 1)
                        Console.WriteLine("\n \n Première année d'étude : \n");
                    foreach (Projet projet in projetsAAfficher)
                    {
                        foreach (int anneeEtudeProjet in projet.AnneesEtudes)
                        {
                            if (anneeEtudeProjet == anneeEtude)
                            {
                                if (projet.AnneesEtudes.Count() == 1)
                                {
                                    Console.WriteLine(projet + "\n \n");
                                }
                                else // Dans le cas d'un projet comme le transpromo qui a plusieurs années d'études, on détermine en quelle année l'élève l'a réalisé et on affiche seulement si ça correspond
                                {
                                    if (anneeEtudeProjet == eleveDeRecherche.CalculerAnneeEtudeProjet(projet))
                                    {
                                        Console.WriteLine(projet);
                                    }
                                }
                            }
                        }
                    }
                }
            }*/


        }




        public void ConsulterTypeDeProjet(string modeDeRecherche, string instanceDeRecherche)
        { }
        public void ConsulterPromo(string modeDeRecherche, string instanceDeRecherche)
        { }
        public void ConsulterMotClef(string modeDeRecherche, string instanceDeRecherche)
        { }
        public void ConsulterAnneeScolaire(string modeDeRecherche, string instanceDeRecherche)
        { }
    }
}

