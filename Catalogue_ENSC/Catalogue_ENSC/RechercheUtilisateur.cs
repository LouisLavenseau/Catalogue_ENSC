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
            Console.WriteLine("Quel mode de recherche voulez-vous utiliser ? Ecrivez élève, tuteur, client, année scolaire, \n " +
                "promo, mot-clef, liberté de sujet, ou type de projet");
            string modeDeRecherche = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Et une recherche sur quel " + modeDeRecherche + " voulez-vous réaliser ?");
            string instanceDeRecherche = Console.ReadLine();
            Console.Clear();
            if (modeDeRecherche == "élève") // année d'étude, matiere, liberté de sujet, 
            {
                ConsulterEleve(instanceDeRecherche);
            }
            if (modeDeRecherche == "type de projet") //promos, année de scolarité, matiere
            {
                ConsulterTypeDeProjet(instanceDeRecherche);
            }
            if (modeDeRecherche == "promo") //matiere, année d'étude, liberté de sujet
            {
                ConsulterPromo(instanceDeRecherche);
            }
            if (modeDeRecherche == "mot-clef")
            {
                ConsulterMotClef(instanceDeRecherche);
            }
            if (modeDeRecherche == "année scolaire") //année d'étude, matiere, liberté de sujet
            {
                ConsulterAnneeScolaire(instanceDeRecherche);
            }
        }


        public void ConsulterEleve(string instanceDeRecherche)
        {
            Console.WriteLine("Comment voulez-classer à l'affichage les projets qui correspondent à la recherche ? Ecrivez année d'étude, liberté de sujet, ou matière");
            string classement = Console.ReadLine();
            //Console.Clear();
            List<Projet> projetsAAfficher = new List<Projet> { };
            Eleve eleveRecherche = (Eleve)Convert.ChangeType(Repertoire["eleve", instanceDeRecherche], typeof(Eleve));
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {
                foreach (Eleve eleve in projet.Etudiants)
                {
                    if (eleve == eleveRecherche)
                    {
                        projetsAAfficher.Add(projet);
                    }
                }
            }
            
            if (classement == "année d'étude")
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
                                Console.WriteLine(projet + "\n \n");
                                if (projet.AnneesEtudes.Count() == 1)
                                {
                                    Console.WriteLine(projet + "\n \n");
                                }
                                else // Dans le cas d'un projet comme le transpromo qui a plusieurs années d'études, on détermine en quelle année l'élève l'a réalisé et on affiche seulement si ça correspond
                                {
                                    if (anneeEtudeProjet == eleveRecherche.CalculerAnneeEtudeProjet(projet))
                                    {
                                        Console.WriteLine(projet);
                                    }
                                }
                            }
                        }
                    }
                }
                Console.ReadLine();
            }

            if (classement == "matière")
            {
                foreach (Matiere matiere in Repertoire.RepertoireMatieres) // Pour chaque matière, on affiche les projets
                {

                    Console.WriteLine("\n \n" + matiere + ": \n");

                    foreach (Projet projet in projetsAAfficher)
                    {
                        foreach (Matiere matiereProjet in projet.Matieres)
                        {
                            if (matiereProjet == matiere)
                            {
                                Console.WriteLine(projet);
                            }
                        }
                    }
                }
                Console.ReadLine();
            }

                if (classement == "liberté de sujet")
                {
                    foreach (string liberteDeSujet in Repertoire.RepertoireLibertesDeSujet) // Pour chaque liberté de sujet, on affiche les projets
                    {
                        if (liberteDeSujet == "liste")
                            Console.WriteLine("\n \n Choix libre parmi une liste imposée de sujets : \n");
                        if (liberteDeSujet == "impose")
                            Console.WriteLine("\n \n Sujet imposé : \n");
                        if (liberteDeSujet == "libre")
                            Console.WriteLine("\n \n Sujet libre : \n");
                        foreach (Projet projet in projetsAAfficher)
                        {
                            if (projet.SujetLibre == liberteDeSujet)
                            {
                                Console.WriteLine(projet);
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }
        

        public void ConsulterTypeDeProjet(string instanceDeRecherche) //matiere,  promotion , année de scolarité, 
        {

            Console.WriteLine("Comment voulez-classer à l'affichage les projets qui correspondent à la recherche ? Ecrivez matière, promo ou année scolaire");
            string classement = Console.ReadLine();
            //Console.Clear();
            List<Projet> projetsAAfficher = new List<Projet> { };
            TypeProjet typeProjetRecherche = (TypeProjet)Convert.ChangeType(Repertoire["typeProjet", instanceDeRecherche], typeof(TypeProjet));
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {
                if (projet.TypeProjet == typeProjetRecherche)
                {
                    projetsAAfficher.Add(projet);
                }
            }
                if (classement == "promo")
                {
                    foreach (int promo in Repertoire.RepertoirePromos) // Pour chaque année d'étude, on affiche les projets
                    {
                        if (promo == 2022)
                            Console.WriteLine("\n \n Promotion 2022 : \n");
                        if (promo == 2021)
                            Console.WriteLine("\n \n Promotion 2021 : \n");
                        if (promo == 2020)
                            Console.WriteLine("\n \n Promotion 2020 : \n");
                        foreach (Projet projet in projetsAAfficher)
                        {
                            foreach (int promoProjet in projet.Promos)
                            {
                                if (promoProjet == promo)


                                {
                                    Console.WriteLine(projet);
                                }


                            }
                        }
                    }
                    Console.ReadLine();

                }
            if (classement == "année scolaire")
            {
                foreach (AnneeScolaire anneeScolaire in Repertoire.RepertoireAnneesScolaires) // Pour chaque année de scolarité, on affiche les projets
                {

                    Console.WriteLine(" \n \n Année scolaire \"" + anneeScolaire + "\" : \n");

                    foreach (Projet projet in projetsAAfficher)
                    {

                        {
                            if (projet.AnneeScolaire == anneeScolaire)


                            {
                                Console.WriteLine(projet);
                            }


                        }
                    }
                }
                Console.ReadLine();
            }

                    if (classement == "matière")
                    {
                        foreach (Matiere matiere in Repertoire.RepertoireMatieres) // Pour chaque année d'étude, on affiche les projets
                        {

                            Console.WriteLine("\n \n" + matiere + ": \n");

                            foreach (Projet projet in projetsAAfficher)
                            {
                                foreach (Matiere matiereProjet in projet.Matieres)
                                {
                                    if (matiereProjet == matiere)


                                    {
                                        Console.WriteLine(projet);
                                    }


                                }
                            }
                        }
                        Console.ReadLine();
                    }

                }



        public void ConsulterPromo(string instanceDeRecherche) // matière
        {
            Console.WriteLine("Comment voulez-classer à l'affichage les projets qui correspondent à la recherche ? Ecrivez matière, année d'étude, liberté du sujet");
            string classement = Console.ReadLine();
            //Console.Clear();
            List<Projet> projetsAAfficher = new List<Projet> { };
            int typePromoRecherche = int.Parse(instanceDeRecherche);
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {
                foreach (int promo in projet.Promos)
                {
                    if (promo == typePromoRecherche)
                    {
                        projetsAAfficher.Add(projet);
                    }
                }
            }

                if (classement == "matière")
                {
                    foreach (Matiere matiere in Repertoire.RepertoireMatieres) // Pour chaque année d'étude, on affiche les projets
                    {

                        Console.WriteLine(matiere + ":");

                        foreach (Projet projet in projetsAAfficher)
                        {
                            foreach (Matiere matiereProjet in projet.Matieres)
                            {
                                if (matiereProjet == matiere)


                                {
                                    Console.WriteLine(projet);
                                }


                            }
                        }
                    }
                    Console.ReadLine();
                }
                if (classement == "année d'étude")
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

                                    Console.WriteLine(projet);


                                }
                            }
                        }
                    }
                    Console.ReadLine();

                }
                if (classement == "liberté de sujet")
                {
                    foreach (string liberteDeSujet in Repertoire.RepertoireLibertesDeSujet) // Pour chaque année d'étude, on affiche les projets
                    {
                    if (liberteDeSujet == "liste")
                        Console.WriteLine("\n \n Choix libre parmi une liste imposée de sujets : \n");
                    if (liberteDeSujet == "impose")
                        Console.WriteLine("\n \n Sujet impose : \n");
                    if (liberteDeSujet == "libre")
                        Console.WriteLine("\n \n Sujet libre : \n");
                    foreach (Projet projet in projetsAAfficher)
                        {                    
                            if (projet.SujetLibre == liberteDeSujet)
                            {
                                Console.WriteLine(projet);
                            }
                        }
                    }
                    Console.ReadLine();
                }
            }

        public void ConsulterMotClef(string instanceDeRecherche) // année d'étude, matière , promo
        {
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {

                foreach (string motClef in projet.MotsClefs)
                {

                    if (motClef == instanceDeRecherche)
                    {
                        Console.WriteLine(projet);
                    }
                }
            }
            Console.ReadLine();
        }

        public void ConsulterAnneeScolaire(string instanceDeRecherche) // année d'étude
        {
            Console.WriteLine("Comment voulez-classer à l'affichage les projets qui correspondent à la recherche ? Ecrivez liberté de sujet, matière et année d'étude");
            string classement = Console.ReadLine();
            //Console.Clear();
            List<Projet> projetsAAfficher = new List<Projet> { };
            AnneeScolaire AnneeScolaireRecherche = (AnneeScolaire)Convert.ChangeType(Repertoire["anneeScolaire", instanceDeRecherche], typeof(AnneeScolaire));
            foreach (Projet projet in Repertoire.RepertoireProjets) // On parcourt tous les projets de l'application, on ajoute les projets comprenant l'élève à la liste
            {
                if (projet.AnneeScolaire == AnneeScolaireRecherche)
                {
                    projetsAAfficher.Add(projet);
                }

            }
            if (classement == "année d'étude")
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

                                Console.WriteLine(projet);


                            }
                        }
                    }
                }
                Console.ReadLine();
            }
            if (classement == "matière")
            {
                foreach (Matiere matiere in Repertoire.RepertoireMatieres) // Pour chaque année d'étude, on affiche les projets
                {

                    Console.WriteLine(matiere + ":");

                    foreach (Projet projet in projetsAAfficher)
                    {
                        foreach (Matiere matiereProjet in projet.Matieres)
                        {
                            if (matiereProjet == matiere)


                            {
                                Console.WriteLine(projet);
                            }


                        }
                    }
                }
                Console.ReadLine();
            }
            if (classement == "liberté de sujet")
            {
                foreach (string liberteDeSujet in Repertoire.RepertoireLibertesDeSujet) // Pour chaque année d'étude, on affiche les projets
                {
                    if (liberteDeSujet == "liste")
                        Console.WriteLine("\n \n Choix libre parmi une liste imposée de sujets : \n");
                    if (liberteDeSujet == "impose")
                        Console.WriteLine("\n \n Sujet imposé : \n");
                    if (liberteDeSujet == "libre")
                        Console.WriteLine("\n \n Sujet libre : \n");
                    foreach (Projet projet in projetsAAfficher)
                    {


                        if (projet.SujetLibre == liberteDeSujet)


                        {
                            Console.WriteLine(projet);
                        }


                    }

                }
                Console.ReadLine();
            }
        }
    }
}

    


