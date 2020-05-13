using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Program
    {
        static void Main(string[] args)
        {
            Matiere poo = new Matiere("poo", "Sciences fondamentales", "codeMatiere", "codeUe");
            Eleve llavenseau = new Eleve("llavenseau", "Louis LAVENSEAU", 2022, false, 0);
            AutreIntervenant bpesquet = new AutreIntervenant("bpesquet", "Baptiste Pesquet", "professeur");
            AutreIntervenant eclermont = new AutreIntervenant("eclermont", "Edwige Clermont", "professeur");
            Livrable rapport = new Livrable("rapport");
            TypeProjet tp1 = new TypeProjet("tp1", "sujet 1", "impose", new List<int> { 1, 2 }, new List<Matiere> { poo }, 2, new List<AutreIntervenant> { bpesquet }, new List<Livrable> { rapport }, new DateTime(2019, 8, 8), new DateTime(2019, 8, 12), new List<string> { "inventé" });
            TypeProjet tp2 = new TypeProjet("tp2", "sujet 2", "libre", new List<int> { 2 }, new List<Matiere> { poo }, 2, new List<AutreIntervenant> { eclermont }, new List<Livrable> { rapport }, new DateTime(2019, 8, 8), new DateTime(2019, 8, 12), new List<string> { "inventé" });
            AnneeScolaire cetteAnnee = new AnneeScolaire("2019-2020", 2019, 2020);
            AnneeScolaire anneeProchaine = new AnneeScolaire("2020-2021", 2020, 2021);
            Repertoire repertoire = new Repertoire(new List<Projet> { }, new List<TypeProjet> { tp1, tp2 }, new List<Matiere> { poo },
                new List<Eleve> { llavenseau }, new List<AutreIntervenant> { bpesquet, eclermont }, new List<AnneeScolaire> { cetteAnnee, anneeProchaine }, new List<Livrable> { rapport },
                new List<string> { }, new List<int> { }, new List<int> { 3, 2, 1 });
            ModificationUtilisateur modificationUtilisateur = new ModificationUtilisateur(repertoire);
            RechercheUtilisateur rechercheUtilisateur = new RechercheUtilisateur(repertoire);

            string fonctionnaliteVoulue = null;
            while (fonctionnaliteVoulue != "")
            {
                Console.WriteLine("Voulez-vous consulter le catalogue des projets de l'ENSC (écrivez 1), ajouter un élément au catalogue (écrivez 2) ?, \n "
                    + "modifier un élément un élément du catalogue (écrivez 3) ? Supprimer un élément du catalogue (écrivez 4) ? Ou quitter \n l'application ? (tapez juste entrée)");
                fonctionnaliteVoulue = Console.ReadLine();
                Console.Clear();

                if (fonctionnaliteVoulue == "1")
                {
                    rechercheUtilisateur.InitialiserConsultation();
                }

                if (fonctionnaliteVoulue == "2")
                {
                    modificationUtilisateur.InitialiserCreation();
                    /*foreach (Projet projet in repertoire.RepertoireProjets)
                    {
                        Console.WriteLine("\n" + projet);
                        Console.WriteLine("\n" + projet.Tuteurs.Count());
                        foreach (AutreIntervenant tuteur in projet.Tuteurs)
                        {
                            Console.WriteLine("\n \n ok voici la suite : \n " + tuteur);
                        }
                    }*/

                    //liste de if (1 par méthode) à faire
                    Console.ReadKey();
                }

                if (fonctionnaliteVoulue == "3")
                {
                    Console.WriteLine("Quel est le type de l'élément que vous voulez modifier ? Ecrivez projet, type de projet, élève, tuteur, client, \n année d'étude, matière, ou livrable");
                    string typeElementAModifier = Console.ReadLine();
                    //liste de if (1 par méthode) à faire
                    Console.ReadKey();
                }

                if (fonctionnaliteVoulue == "4")
                {
                    Console.WriteLine("Quel est le type de l'élément que vous voulez supprimr ? Ecrivez projet, type de projet, élève, tuteur, client, \n année d'étude, matière, ou livrable");
                    string typeElementASupprimer = Console.ReadLine();
                    //liste de if (1 par méthode) à faire
                    Console.ReadKey();
                }

            }


        }
    }
}
