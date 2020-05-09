﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class ModificationUtilisateur
    {
        public Repertoire Repertoire { get; private set; }

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
            return elementsSepares;
        }

        public string EnleverLesEspaces(string champ) //Enlever les espaces en début de champ et en fin de champ
        {
            string champSansEspaces = "";
            bool premierCaracNonEspaceAtteint = false;
            bool dernierCaracNonEspaceAtteint = false;
            int cpt = -1;
            int longueurChamp = champ.Length;
            while (!premierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ jusqu'à atteindre le premier caractère qui n'est pas un espace ou jusqu'à atteindre la fin du champ
            {
                cpt++;
                if (champ[cpt] != ' ')
                    premierCaracNonEspaceAtteint = true;
            }
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
                }
                cpt++;
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


        public void CreerProjet()
        {   //initialisation du booleen qui vérifie que ce que rentre l'utilisateur convient
            bool erreurSurvenue = false;

            //On récupère le type du projet
            Console.WriteLine("Quel est le type du projet ?");
            string stringTypeProjet = EnleverLesEspaces(Console.ReadLine());
            TypeProjet typeProjet = (TypeProjet)Convert.ChangeType(Repertoire["typeProjet", stringTypeProjet], typeof(TypeProjet));


            //On récupère le nom du projet
            Console.WriteLine("Quel est le nom du projet ?");
            string nom = EnleverLesEspaces(Console.ReadLine());

            //On récupère l'information de à quel point le sujet est imposé
            if (typeProjet.SujetLibre == null)
            {
                Console.WriteLine("Le sujet du projet est-il imposé (écrivez \"impose\") ? libre parmi une liste de sujets imposée (écriez \"listeImpose\") ? ou libre (écrivez \"libre\") ?");
                string sujetLibre = EnleverLesEspaces(Console.ReadLine());
            }
            else
            {
                string sujetLibre = typeProjet.SujetLibre;
            }

            erreurSurvenue = false;

            //On récupère les annees d'etude du projet
            if (typeProjet.AnneesEtudes == null)
            {
                while (erreurSurvenue == true)
                {
                    Console.WriteLine("Le projet a-t-il été réalisé par des étudiants en première année (écrivez \"1\"), 2ème année (écrivez \"2\"), ou 3ème année (écrivez \"3\") ? " +
                                      "Séparez par une virgule (ajout d'un espace optionnel) les nombres si des étudiants d'années différentes sont concernés)");
                    List<string> stringAnneesEtudes = SeparerChaineDeCaracteres(EnleverLesEspaces(Console.ReadLine()));
                    List<int> anneesEtudes = new List<int> { };
                    foreach (string stringAnneeEtude in stringAnneesEtudes)
                    {
                        if (stringAnneeEtude == "1" || stringAnneeEtude == "2" || stringAnneeEtude == "3")
                            anneesEtudes.Add(int.Parse(stringAnneeEtude));
                        else
                        {
                            erreurSurvenue = true;
                            Console.WriteLine("Vous avez mal rentré une ou plusieurs des années d'étude");
                        }

                    }
                }
            }

            else
            {
                string anneesEtudes = typeProjet.SujetLibre;
            }

            erreurSurvenue = false;

            //On récupère les matieres du projet
            if (typeProjet.Matieres == null)
            {
                Console.WriteLine("Quelles sont la/les matière(s) du projet ? (Rentrez soit le nom de la matière comme orthographiée sur moodle, soit son code)");
                List<string> stringMatieres = SeparerChaineDeCaracteres(EnleverLesEspaces(Console.ReadLine()));
                List<Matiere> matieres = new List<Matiere> { };
                foreach (string stringMatiere in stringMatieres)
                {
                    matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", stringMatiere], typeof(Matiere)));
                }
            }
            else
            {
                List<Matiere> matieres = typeProjet.Matieres;
            }

            //On récupère les promos du projet
            Console.WriteLine("Quelles sont la/les promo(s) des étudiants qui ont réalisé ce projet ? (Ex : 2020, 2021))");
            List<string> stringPromos = SeparerChaineDeCaracteres(Console.ReadLine());
            List<int> promos = new List<int> { };
            foreach (string stringPromo in stringPromos)
            {
                promos.Add(int.Parse(stringPromo));
            }

            //On récupère l'année de scolarité du projet
            Console.WriteLine("A quelle année scolaire a été réalisé ce projet ?");
            string stringAnneeScolaire = Console.ReadLine();
            AnneeScolaire anneeScolaire = (AnneeScolaire)Convert.ChangeType(Repertoire["anneeScolaire", stringAnneeScolaire], typeof(AnneeScolaire));


            //On récupère le nombre d'étudiants qui ont travaillé sur ce projet
            if (typeProjet.NbPersonnesImpliquees == 0)
            {
                Console.WriteLine("Combien d'étudiants ont travaillé sur ce projet ?");
                int nbPersonnesImpliquees = int.Parse(Console.ReadLine());
            }
            else
            {
                int nbPersonnesImpliquees = typeProjet.NbPersonnesImpliquees;
            }

            //On récupère le nom du chef de projet s'il y en a un
            Console.WriteLine("Quel est le nom du chef de projet ? (s'il y en a un)");
            string stringChefDeProjet = EnleverLesEspaces(Console.ReadLine());
            bool stringChefDeProjetRempli = VerifierChampRempli(stringChefDeProjet);
            if (!stringChefDeProjetRempli)
            {
                Eleve chefDeProjet = null;
            }
            else
            {
                Eleve chefDeProjet = (Eleve)Convert.ChangeType(Repertoire["eleve", stringChefDeProjet], typeof(Eleve));
            }


            //On récupère les développeurs du projet s'il y en a
            Console.WriteLine("Quels sont les noms des développeurs du projet ? (s'il y en a)");
            string stringDeveloppeurs = EnleverLesEspaces(Console.ReadLine());
            bool stringDeveloppeursRempli = VerifierChampRempli(stringDeveloppeurs);
            if (!stringDeveloppeursRempli)
            {
                List<Eleve> developpeurs = null;
            }
            else
            {
                List<string> listStringDeveloppeurs = SeparerChaineDeCaracteres(stringDeveloppeurs);
                List<Eleve> developpeurs = new List<Eleve> { };
                foreach (string stringDeveloppeur in listStringDeveloppeurs)
                {
                    developpeurs.Add((Eleve)Convert.ChangeType(Repertoire["eleve", stringDeveloppeur], typeof(Eleve)));
                }
            }


            //On récupère les maquetteurs du projet s'il y en a
            Console.WriteLine("Qui sont les noms des maquetteurs du projet ? (s'il y en a)");
            string stringMaquetteurs = EnleverLesEspaces(Console.ReadLine());
            bool stringMaquetteursRempli = VerifierChampRempli(stringMaquetteurs);
            if (!stringMaquetteursRempli)
            {
                List<Eleve> maquetteurs = null;
            }
            else
            {
                List<string> listStringMaquetteurs = SeparerChaineDeCaracteres(stringMaquetteurs);
                List<Eleve> maquetteurs = new List<Eleve> { };
                foreach (string stringMaquetteur in listStringMaquetteurs)
                {
                    maquetteurs.Add((Eleve)Convert.ChangeType(Repertoire["eleve", stringMaquetteur], typeof(Eleve)));
                }
            }


            //On récupère le pole facteur humain du projet s'il y en a
            Console.WriteLine("Quels sont les noms des étudiants qui ont travaillé dans le pôle Facteur Humain du projet ? (s'il y en a)");
            string stringPoleFacteurHumain = EnleverLesEspaces(Console.ReadLine());
            bool stringPoleFacteurHumainRempli = VerifierChampRempli(stringPoleFacteurHumain);
            if (!stringPoleFacteurHumainRempli)
            {
                List<Eleve> poleFacteurHumain = null;
            }
            else
            {
                List<string> listStringPoleFacteurHumain = SeparerChaineDeCaracteres(Console.ReadLine());
                List<Eleve> poleFacteurHumain = new List<Eleve> { };
                foreach (string etudiantPoleFacteurHumain in listStringPoleFacteurHumain)
                {
                    poleFacteurHumain.Add((Eleve)Convert.ChangeType(Repertoire["eleve", etudiantPoleFacteurHumain], typeof(Eleve)));
                }
            }

            //On récupère le nom du client
            Console.WriteLine("Quel est le nom du client du projet ? (s'il y en a un)");
            string stringClient = EnleverLesEspaces(Console.ReadLine());
            bool stringClientRempli = VerifierChampRempli(stringClient);
            if (!stringClientRempli)
            {
                AutreIntervenant client = null;
            }
            else
            {
                AutreIntervenant client = (AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", stringClient], typeof(AutreIntervenant));
            }


            /*//On récupère les matieres du projet
            if (typeProjet.Matieres == null)
            {
                Console.WriteLine("Quelles sont la/les matière(s) du projet ? (Rentrez soit le nom de la matière comme orthographiée sur moodle, soit son code)");
                List<string> stringEleves = SeparerChaineDeCaracteres(Console.ReadLine());
                List<Eleve> eleves = new List<Eleve> { };
                foreach (string stringEleve in stringEleves)
                {
                    eleves.Add((Eleve)Convert.ChangeType(Repertoire["eleve", stringEleve], typeof(Eleve)));
                }
            }
            else
            {
                string anneesEtudes = typeProjet.SujetLibre;
            }
            */







        }
        public void CreerTypeProjet()
        { }
        public void SupprimerProjet()
        { }
        public void SupprimerTypeProjet()
        { }

    }
}
