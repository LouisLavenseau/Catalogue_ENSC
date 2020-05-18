﻿using System;
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
            TypeProjet tp2 = new TypeProjet("tp2", "sujet 2", "libre", new List<int> { 1, 2 }, new List<Matiere> { poo }, 2, new List<AutreIntervenant> { eclermont }, new List<Livrable> { rapport }, new DateTime(2019, 8, 8), new DateTime(2019, 8, 12), new List<string> { "inventé" });
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
                Console.Clear();
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
                    /*foreach (TypeProjet typeProjet in repertoire.RepertoireTypesProjets)
                    {
                        Console.WriteLine("\n" + typeProjet);
                        Console.WriteLine("\n" + typeProjet.Etudiants.Count());
                        foreach (Eleve eleve in typeProjet.Etudiants)
                        {
                            Console.WriteLine(eleve);
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
                    Console.WriteLine("Quel est le type de l'élément que vous voulez supprimer ? Ecrivez projet, type de projet, élève, tuteur, client, \n année d'étude, matière, ou livrable");
                    string typeElementASupprimer = Console.ReadLine();
                    //liste de if (1 par méthode) à faire
                    Console.ReadKey();
                }

            }


        }

        public List<string> SeparerChaineDeCaracteres(string chaineDeCaracteres)
        {
            string element = "";
            char virgule = ',';
            char espace = ' ';
            List<string> elementsSepares = new List<string> { };
            foreach (char caractere in chaineDeCaracteres)
            {
                if (caractere == virgule)
                {
                    elementsSepares.Add(element);
                    element = "";
                }
                else
                {
                    if (caractere != espace)
                    {
                        element += caractere;
                    }
                }
            }
            elementsSepares.Add(element);
            return elementsSepares;
        }


        public string EnleverLesEspaces(string champ) //Enlever les espaces en début de champ et en fin de champ
        {
            string champSansEspaces = "";
            bool premierCaracNonEspaceAtteint = false;
            bool dernierCaracNonEspaceAtteint = false;
            int cpt = 0;
            int longueurChamp = champ.Length;
            if (longueurChamp > 0)
            {
                while (!premierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ jusqu'à atteindre le premier caractère qui n'est pas un espace ou jusqu'à atteindre la fin du champ
                {
                    if (champ[cpt] != ' ')
                        premierCaracNonEspaceAtteint = true;
                    cpt++;
                }
                cpt--;
                while (!dernierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ du premier caractèrequi n'est pas un espace jusqu'au dernier ou jusqu'à la fin du champ
                {
                    if (champ[cpt] != ' ')
                        champSansEspaces += champ[cpt];
                    else //si le caractère est un espace, on vérifie si jusqu'à la fin du champ tous les autres caractères sont des espaces aussi
                    {
                        bool autreCaracterePresentApres = false;
                        for (int i = cpt; i < longueurChamp; i++)
                        {
                            if (champ[i] != ' ')
                                autreCaracterePresentApres = true;
                        }
                        if (!autreCaracterePresentApres)
                            dernierCaracNonEspaceAtteint = true;
                        else
                            champSansEspaces += champ[cpt];
                    }
                    cpt++;
                }
                return champSansEspaces;
            }
            return champSansEspaces;
        }
        public bool VerifierChampRempli(string champ) //Vérfier que le champ contient au moins un caractère autre qu'un espace
        {
            string champNettoye = EnleverLesEspaces(champ);
            if (champNettoye == "")
            {
                return false;
            }
            return true;
        }

    }
}
