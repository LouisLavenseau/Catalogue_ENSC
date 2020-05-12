using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class ModificationUtilisateur
    {
        public Repertoire Repertoire { get; private set; }

        public ModificationUtilisateur(Repertoire repertoire)
        {
            Repertoire = repertoire;
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

            //On récupère le sujet du projet
            Console.WriteLine("Quel est le sujet du projet ?");
            string sujet = EnleverLesEspaces(Console.ReadLine());

            //On récupère l'information de à quel point le sujet est imposé
            string sujetLibre = null;
            if (typeProjet.SujetLibre == null)
            {
                Console.WriteLine("Le sujet du projet est-il imposé (écrivez \"impose\") ? libre parmi une liste de sujets imposée (écriez \"listeImpose\") ? ou libre (écrivez \"libre\") ?");
                sujetLibre = EnleverLesEspaces(Console.ReadLine());
            }
            else
            {
                sujetLibre = typeProjet.SujetLibre;
            }

            erreurSurvenue = false;

            List<int> anneesEtudes = new List<int> { };
            //On récupère les annees d'etude du projet
            if (typeProjet.AnneesEtudes == null)
            {
                while (erreurSurvenue == true)
                {
                    Console.WriteLine("Le projet a-t-il été réalisé par des étudiants en première année (écrivez \"1\"), 2ème année (écrivez \"2\"), ou 3ème année (écrivez \"3\") ? " +
                                      "Séparez par une virgule (ajout d'un espace optionnel) les nombres si des étudiants d'années différentes sont concernés)");
                    List<string> stringAnneesEtudes = SeparerChaineDeCaracteres(EnleverLesEspaces(Console.ReadLine()));
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
                anneesEtudes = typeProjet.AnneesEtudes;
            }

            erreurSurvenue = false;

            //On récupère les matieres du projet
            List<Matiere> matieres = new List<Matiere> { };
            if (typeProjet.Matieres == null)
            {
                Console.WriteLine("Quelles sont la/les matière(s) du projet ? (Rentrez soit le nom de la matière comme orthographiée sur moodle, soit son code)");
                List<string> stringMatieres = SeparerChaineDeCaracteres(EnleverLesEspaces(Console.ReadLine()));
                foreach (string stringMatiere in stringMatieres)
                {
                    matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", stringMatiere], typeof(Matiere)));
                }
            }
            else
            {
                matieres = typeProjet.Matieres;
            }

            //On récupère les promos du projet
            List<int> promos = new List<int> { };
            Console.WriteLine("Quelles sont la/les promo(s) des étudiants qui ont réalisé ce projet ? (Ex : 2020, 2021))");
            List<string> stringPromos = SeparerChaineDeCaracteres(Console.ReadLine());
            foreach (string stringPromo in stringPromos)
            {
                promos.Add(int.Parse(stringPromo));
            }

            //On récupère l'année de scolarité du projet
            Console.WriteLine("Pendant quelle année scolaire a été réalisé ce projet ? (Ecrivez par exemple : 2019-2020)");
            string stringAnneeScolaire = Console.ReadLine();
            AnneeScolaire anneeScolaire = (AnneeScolaire)Convert.ChangeType(Repertoire["anneeScolaire", stringAnneeScolaire], typeof(AnneeScolaire));


            //On récupère le nombre d'étudiants qui ont travaillé sur ce projet
            int nbPersonnesImpliquees = 0;
            if (typeProjet.NbPersonnesImpliquees == 0)
            {
                Console.WriteLine("Combien d'étudiants ont travaillé sur ce projet ?");
                nbPersonnesImpliquees = int.Parse(Console.ReadLine());
            }
            else
            {
                nbPersonnesImpliquees = typeProjet.NbPersonnesImpliquees;
            }

            //On récupère le nom des étudiants qui ont travaillé sur ce projet
            List<Eleve> etudiants = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des étudiants qui ont travaillé sur ce projet ? (écrivez le prénom puis le nom ou le code formé" +
                "de la première lettre du prénom et du nom de famille");
            string stringEtudiants = EnleverLesEspaces(Console.ReadLine());
            List<string> listStringEtudiants = SeparerChaineDeCaracteres(stringEtudiants);
            foreach (string etudiant in listStringEtudiants)
            {
                etudiants.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", etudiant], typeof(Eleve)));
            }

            //On récupère le nom du chef de projet s'il y en a un
            Eleve chefDeProjet = null;
            Console.WriteLine("Quel est le nom du chef de projet ? (s'il y en a un)");
            string stringChefDeProjet = EnleverLesEspaces(Console.ReadLine());
            bool stringChefDeProjetRempli = VerifierChampRempli(stringChefDeProjet);
            if (stringChefDeProjetRempli)
            {
                chefDeProjet = (Eleve)Convert.ChangeType(Repertoire["intervenant", stringChefDeProjet], typeof(Eleve));
            }


            //On récupère les développeurs du projet s'il y en a
            List<Eleve> developpeurs = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des développeurs du projet ? (s'il y en a)");
            string stringDeveloppeurs = EnleverLesEspaces(Console.ReadLine());
            bool stringDeveloppeursRempli = VerifierChampRempli(stringDeveloppeurs);
            if (stringDeveloppeursRempli)
            {
                List<string> listStringDeveloppeurs = SeparerChaineDeCaracteres(stringDeveloppeurs);
                foreach (string stringDeveloppeur in listStringDeveloppeurs)
                {
                    developpeurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringDeveloppeur], typeof(Eleve)));
                }
            }


            //On récupère les maquetteurs du projet s'il y en a
            List<Eleve> maquetteurs = new List<Eleve> { };
            Console.WriteLine("Qui sont les noms des maquetteurs du projet ? (s'il y en a)");
            string stringMaquetteurs = EnleverLesEspaces(Console.ReadLine());
            bool stringMaquetteursRempli = VerifierChampRempli(stringMaquetteurs);
            if (stringMaquetteursRempli)
            {
                List<string> listStringMaquetteurs = SeparerChaineDeCaracteres(stringMaquetteurs);
                foreach (string stringMaquetteur in listStringMaquetteurs)
                {
                    maquetteurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringMaquetteur], typeof(Eleve)));
                }
            }


            //On récupère le pole facteur humain du projet s'il y en a
            List<Eleve> poleFacteurHumain = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des étudiants qui ont travaillé dans le pôle Facteur Humain du projet ? (s'il y en a)");
            string stringPoleFacteurHumain = EnleverLesEspaces(Console.ReadLine());
            bool stringPoleFacteurHumainRempli = VerifierChampRempli(stringPoleFacteurHumain);
            if (stringPoleFacteurHumainRempli)
            {
                List<string> listStringPoleFacteurHumain = SeparerChaineDeCaracteres(stringPoleFacteurHumain);
                foreach (string etudiantPoleFacteurHumain in listStringPoleFacteurHumain)
                {
                    poleFacteurHumain.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", etudiantPoleFacteurHumain], typeof(Eleve)));
                }
            }

            //On récupère le nom du client
            AutreIntervenant client = null;
            Console.WriteLine("Quel est le nom du client du projet ? (s'il y en a un)");
            string stringClient = EnleverLesEspaces(Console.ReadLine());
            bool stringClientRempli = VerifierChampRempli(stringClient);
            if (stringClientRempli)
            {
                client = (AutreIntervenant)Convert.ChangeType(Repertoire["intervenant", stringClient], typeof(AutreIntervenant));
            }

            //On récupère le nom des tuteurs
            List<AutreIntervenant> tuteurs = new List<AutreIntervenant> { };
            if (typeProjet.Tuteurs == null)
            {
                Console.WriteLine("Quels sont les noms des tuteurs ? (dans le cas d'un projet intramatière, les tuteurs pourront être les professeurs encadrant le projet)");
                string stringTuteurs = EnleverLesEspaces(Console.ReadLine());
                bool stringTuteursRempli = VerifierChampRempli(stringClient);
                if (stringClientRempli)
                {
                    List<string> listStringTuteurs = SeparerChaineDeCaracteres(stringTuteurs);
                    foreach (string tuteur in listStringTuteurs)
                    {
                        tuteurs.Add((AutreIntervenant)Convert.ChangeType(Repertoire["intervenant", tuteur], typeof(AutreIntervenant)));
                    }
                }
            }
            else
            {
                tuteurs = typeProjet.Tuteurs;
            }

            //On récupère les livrables 
            List<Livrable> livrables = new List<Livrable> { };
            if (typeProjet.Livrables == null)
            {
                Console.WriteLine("Quels sont les livrables attendus pour le projet ?");
                string stringLivrables = EnleverLesEspaces(Console.ReadLine());
                List<string> listStringLivrables = SeparerChaineDeCaracteres(stringLivrables);
                foreach (string livrable in listStringLivrables)
                {
                    livrables.Add((Livrable)Convert.ChangeType(Repertoire["livrable", livrable], typeof(Livrable)));
                }
            }
            else
            {
                livrables = typeProjet.Livrables;
            }

            //On récupère la date de début du projet
            DateTime dateDebut = new DateTime(2000, 1, 1);
            if (typeProjet.DateDebut.Year <2001)
            {
                Console.WriteLine("Quelle est la date de début du projet ? (écrivez sous la forme \"mois,jour,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"2,3,2019\"");
                string stringDateDebut = EnleverLesEspaces(Console.ReadLine());
                List<string> listStringDateDebut = SeparerChaineDeCaracteres(stringDateDebut);
                int moisDebut = int.Parse(listStringDateDebut[0]);
                int jourDebut = int.Parse(listStringDateDebut[1]);
                int anneeDebut = int.Parse(listStringDateDebut[2]);
                dateDebut = new DateTime(moisDebut, jourDebut, anneeDebut);
            }
            else
            {
                dateDebut = typeProjet.DateDebut;
            }

            //On récupère la date de fin du projet
            DateTime dateFin = new DateTime(2000, 1, 1);
            if (typeProjet.DateFin.Year <2001)
            {
                Console.WriteLine("Quelle est la date de fin du projet ? (écrivez sous la forme \"mois,jour,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"2,3,2019\"");
                string stringDateFin = EnleverLesEspaces(Console.ReadLine());
                List<string> listStringDateFin = SeparerChaineDeCaracteres(stringDateFin);
                int moisFin = int.Parse(listStringDateFin[0]);
                int jourFin = int.Parse(listStringDateFin[1]);
                int anneeFin = int.Parse(listStringDateFin[2]);
                dateFin = new DateTime(moisFin, jourFin, anneeFin);
            }
            else
            {
                dateFin = typeProjet.DateFin;
            }

            //On récupère les mots-clefs
            List<string> motsClefs = null;
            if (typeProjet.MotsClefs == null)
            {
                Console.WriteLine("Quels sont les mots-clefs liés au projet ?");
                string stringMotsClefs = EnleverLesEspaces(Console.ReadLine());
                motsClefs = SeparerChaineDeCaracteres(stringMotsClefs);
            }
            else
            {   //On récupère dans un string tous les mots-clefs déjà présents pour les présenter à l'utilisateur
                string motsClefsDejaExistants = "";
                bool premierMotClefPasse = false;
                foreach (string motClef in typeProjet.MotsClefs)
                {
                    if (premierMotClefPasse)
                    {
                        motsClefsDejaExistants += ", " + motClef;
                    }
                    else
                    {
                        motsClefsDejaExistants += motClef;
                        premierMotClefPasse = true;
                    }
                }
                Console.WriteLine("Voici les mots-clefs associés au type de projet \"" + typeProjet.Nom + "\" : " + motsClefsDejaExistants + ". Quels sont les mots-clefs que vous voulez rajouter ?");
                string stringMotsClefs = EnleverLesEspaces(Console.ReadLine());
                bool stringMotsClefsRempli = VerifierChampRempli(stringMotsClefs);
                if (stringMotsClefsRempli)
                {
                    motsClefs = SeparerChaineDeCaracteres(stringMotsClefs);
                    foreach (string motClef in typeProjet.MotsClefs)
                    {
                        motsClefs.Add(motClef);
                    }
                }

                Repertoire.RepertoireProjets.Add(new Projet(nom, sujet, sujetLibre, typeProjet, anneesEtudes, matieres, promos, anneeScolaire, nbPersonnesImpliquees, etudiants,
                    chefDeProjet, developpeurs, maquetteurs, poleFacteurHumain, client, tuteurs, livrables, dateDebut, dateFin, motsClefs));
            }





        }
        public void CreerTypeProjet()
        { }
        public void SupprimerProjet()
        { }
        public void SupprimerTypeProjet()
        { }

    }
}
