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
        public Program Program { get; private set; }
        public Sauvegarde Sauvegarde { get; private set; }

        public ModificationUtilisateur(Repertoire repertoire, Program program, Sauvegarde sauvegarde)
        {
            Repertoire = repertoire;
            Program = program;
            Sauvegarde = sauvegarde;
        }
        // Eleve, AutreIntervenant, LnneeScolaire, Livrable, Matiere
        //string prenom, string nom, int promo, bool aRedouble, int anneeEtudeRedoublement, string pronom,

        public void InitialiserCreation()
        {
            Console.WriteLine("Quel est le type de l'élément que vous voulez ajouter ? Ecrivez projet, type de projet, élève, professeur, \n intervenant externe, année scolaire, matière, ou livrable");
            string typeElementACreer = Console.ReadLine();
            Console.Clear();
            if (typeElementACreer == "projet")
            {
                CreerProjet();
            }
            if (typeElementACreer == "type de projet")
            {
                CreerTypeProjet();
            }

            if (typeElementACreer == "élève")
            {
                CreerEleve();
            }

            if (typeElementACreer == "professeur" || typeElementACreer == "intervenant externe")
            {
                CreerAutreInvervenant(typeElementACreer);
            }

            if (typeElementACreer == "livrable")
            {
                CreerLivrable();
            }

            if (typeElementACreer == "matière")
            {
                CreerMatiere();
            }

            if (typeElementACreer == "année scolaire")
            {
                CreerAnneeScolaire();
            }

        }

        public void CreerProjet()
        {   //initialisation du booleen qui vérifie que ce que rentre l'utilisateur convient
            bool erreurSurvenue = false;

            //On récupère le type du projet
            Console.WriteLine("Quel est le type du projet ?");
            string stringTypeProjet = Program.EnleverLesEspaces(Console.ReadLine());
            TypeProjet typeProjet = (TypeProjet)Convert.ChangeType(Repertoire["typeProjet", stringTypeProjet], typeof(TypeProjet));

            //On récupère le nom du projet
            string sujet = "";
            Console.WriteLine("Quel est le nom du projet ?");
            string nom = Program.EnleverLesEspaces(Console.ReadLine());

            //On récupère le sujet du projet
            if (typeProjet.Sujet == null)
            {
                Console.WriteLine("Quel est le sujet du projet ?");
                sujet = Program.EnleverLesEspaces(Console.ReadLine());
            }
            else
            {
                sujet = typeProjet.Sujet;
            }

            //On récupère l'information de à quel point le sujet est imposé
            string sujetLibre = null;
            if (typeProjet.SujetLibre == null)
            {
                Console.WriteLine("Le sujet du projet est-il imposé (écrivez \"impose\") ? libre parmi une liste de sujets imposée (écrivez \"listeImpose\") ? ou libre (écrivez \"libre\") ?");
                sujetLibre = Program.EnleverLesEspaces(Console.ReadLine());
            }
            else
            {
                sujetLibre = typeProjet.SujetLibre;
            }

            erreurSurvenue = false;

            List<int> anneesEtudes = new List<int> { };
            string stringAnneesEtudes = "";
            //On récupère les annees d'etude du projet
            if (typeProjet.AnneesEtudes == null)
            {
                while (erreurSurvenue == true)
                {
                    Console.WriteLine("Le projet a-t-il été réalisé par des étudiants en première année (écrivez \"1\"), 2ème année (écrivez \"2\"), ou 3ème année (écrivez \"3\") ? " +
                                      "Séparez par une virgule (ajout d'un espace optionnel) les nombres si des étudiants d'années différentes sont concernés)");
                    stringAnneesEtudes = Program.EnleverLesEspaces(Console.ReadLine());
                    List<string> listStringAnneesEtudes = Program.SeparerChaineDeCaracteres(stringAnneesEtudes);
                    foreach (string stringAnneeEtude in listStringAnneesEtudes)
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
                bool premierMotPasse = false;
                foreach (int anneeEtude in anneesEtudes)
                {
                    if (premierMotPasse)
                    {
                        stringAnneesEtudes += ", " + anneeEtude.ToString();
                    }
                    else
                    {
                        stringAnneesEtudes += anneeEtude.ToString();
                        premierMotPasse = true;
                    }
                }

            }

            erreurSurvenue = false;

            //On récupère les matieres du projet
            List<Matiere> matieres = new List<Matiere> { };
            string stringMatieres = "";
            if (typeProjet.Matieres == null)
            {
                Console.WriteLine("Quelles sont la/les matière(s) du projet ? (Rentrez soit le nom de la matière comme orthographiée sur moodle, soit son code)");
                stringMatieres = Program.EnleverLesEspaces(Console.ReadLine());
                List<string> listStringMatieres = Program.SeparerChaineDeCaracteres(stringMatieres);
                foreach (string stringMatiere in listStringMatieres)
                {
                    matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", stringMatiere], typeof(Matiere)));
                }
            }
            else
            {
                matieres = typeProjet.Matieres;
                bool premierMotPasse = false;
                foreach (Matiere matiere in matieres)
                {
                    string stringMatiere = matiere.Code;
                    if (premierMotPasse)
                    {
                        stringMatieres += ", " + stringMatiere;
                    }
                    else
                    {
                        stringMatieres += stringMatiere;
                        premierMotPasse = true;
                    }
                }
            }

            //On récupère les promos du projet
            /*List<int> promos = new List<int> { };
            Console.WriteLine("Quelles sont la/les promo(s) des étudiants qui ont réalisé ce projet ? (Ex : 2020, 2021))");
            List<string> stringPromos = Program.SeparerChaineDeCaracteres(Console.ReadLine());
            foreach (string stringPromo in stringPromos)
            {
                promos.Add(int.Parse(stringPromo));
            }*/

            //On récupère l'année de scolarité du projet
            Console.WriteLine("Pendant quelle année scolaire a été réalisé ce projet ? (Ecrivez par exemple : 2019-2020)");
            string stringAnneeScolaire = Console.ReadLine();
            AnneeScolaire anneeScolaire = (AnneeScolaire)Convert.ChangeType(Repertoire["anneeScolaire", stringAnneeScolaire], typeof(AnneeScolaire));


            //On récupère le nombre d'étudiants qui ont travaillé sur ce projet
            /* int nbPersonnesImpliquees = 0;
             if (typeProjet.NbPersonnesImpliquees == 0)
             {
                 Console.WriteLine("Combien d'étudiants ont travaillé sur ce projet ?");
                 nbPersonnesImpliquees = int.Parse(Console.ReadLine());
             }
             else
             {
                 nbPersonnesImpliquees = typeProjet.NbPersonnesImpliquees;
             }*/

            //On récupère le nom des étudiants qui ont travaillé sur ce projet
            List<Eleve> etudiants = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des étudiants qui ont travaillé sur ce projet ? (écrivez le prénom puis le nom ou le code formé" +
                "de la première lettre du prénom et du nom de famille");
            string stringEtudiants = Program.EnleverLesEspaces(Console.ReadLine());
            List<string> listStringEtudiants = Program.SeparerChaineDeCaracteres(stringEtudiants);
            foreach (string etudiant in listStringEtudiants)
            {
                etudiants.Add((Eleve)Convert.ChangeType(Repertoire["eleve", etudiant], typeof(Eleve)));
            }

            //On récupère le nom du chef de projet s'il y en a un
            Eleve chefDeProjet = null;
            Console.WriteLine("Quel est le nom du chef de projet ? (s'il y en a un)");
            string stringChefDeProjet = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringChefDeProjetRempli = Program.VerifierChampRempli(stringChefDeProjet);
            if (stringChefDeProjetRempli)
            {
                chefDeProjet = (Eleve)Convert.ChangeType(Repertoire["intervenant", stringChefDeProjet], typeof(Eleve));
            }


            //On récupère les développeurs du projet s'il y en a
            List<Eleve> developpeurs = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des développeurs du projet ? (s'il y en a)");
            string stringDeveloppeurs = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringDeveloppeursRempli = Program.VerifierChampRempli(stringDeveloppeurs);
            if (stringDeveloppeursRempli)
            {
                List<string> listStringDeveloppeurs = Program.SeparerChaineDeCaracteres(stringDeveloppeurs);
                foreach (string stringDeveloppeur in listStringDeveloppeurs)
                {
                    developpeurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringDeveloppeur], typeof(Eleve)));
                }
            }


            //On récupère les maquetteurs du projet s'il y en a
            List<Eleve> maquetteurs = new List<Eleve> { };
            Console.WriteLine("Qui sont les noms des maquetteurs du projet ? (s'il y en a)");
            string stringMaquetteurs = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringMaquetteursRempli = Program.VerifierChampRempli(stringMaquetteurs);
            if (stringMaquetteursRempli)
            {
                List<string> listStringMaquetteurs = Program.SeparerChaineDeCaracteres(stringMaquetteurs);
                foreach (string stringMaquetteur in listStringMaquetteurs)
                {
                    maquetteurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringMaquetteur], typeof(Eleve)));
                }
            }


            //On récupère le pole facteur humain du projet s'il y en a
            List<Eleve> poleFacteurHumain = new List<Eleve> { };
            Console.WriteLine("Quels sont les noms des étudiants qui ont travaillé dans le pôle Facteur Humain du projet ? (s'il y en a)");
            string stringPoleFacteurHumain = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringPoleFacteurHumainRempli = Program.VerifierChampRempli(stringPoleFacteurHumain);
            if (stringPoleFacteurHumainRempli)
            {
                List<string> listStringPoleFacteurHumain = Program.SeparerChaineDeCaracteres(stringPoleFacteurHumain);
                foreach (string etudiantPoleFacteurHumain in listStringPoleFacteurHumain)
                {
                    poleFacteurHumain.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", etudiantPoleFacteurHumain], typeof(Eleve)));
                }
            }

            //On récupère le nom du client
            Personne client = null;
            Console.WriteLine("Quel est le nom du client du projet ? (s'il y en a un)");
            string stringClient = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringClientRempli = Program.VerifierChampRempli(stringClient);
            if (stringClientRempli)
            {
                client = (AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", stringClient], typeof(AutreIntervenant));
                if (client == null)
                {
                    client = (Eleve)Convert.ChangeType(Repertoire["eleve", stringClient], typeof(Eleve));
                }
            }

            //On récupère le nom des tuteurs
            List<AutreIntervenant> tuteurs = new List<AutreIntervenant> { };
            string stringTuteurs = "";
            if (typeProjet.Tuteurs == null)
            {
                Console.WriteLine("Quels sont les noms des tuteurs ? (dans le cas d'un projet intramatière, les tuteurs pourront être les professeurs encadrant le projet)");
                stringTuteurs = Program.EnleverLesEspaces(Console.ReadLine());
                bool stringTuteursRempli = Program.VerifierChampRempli(stringTuteurs);
                if (stringTuteursRempli)
                {
                    List<string> listStringTuteurs = Program.SeparerChaineDeCaracteres(stringTuteurs);
                    foreach (string tuteur in listStringTuteurs)
                    {
                        tuteurs.Add((AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", tuteur], typeof(AutreIntervenant)));
                    }
                }
            }
            else
            {
                tuteurs = typeProjet.Tuteurs;
                bool premierMotPasse = false;
                foreach (AutreIntervenant tuteur in tuteurs)
                {
                    string stringTuteur = tuteur.Identifiant;
                    if (premierMotPasse)
                    {
                        stringTuteurs += ", " + stringTuteur;
                    }
                    else
                    {
                        stringTuteurs += stringTuteur;
                        premierMotPasse = true;
                    }
                }
            }

            //On récupère les livrables 
            List<Livrable> livrables = new List<Livrable> { };
            string stringLivrables = "";
            if (typeProjet.Livrables == null)
            {
                Console.WriteLine("Quels sont les livrables attendus pour le projet ?");
                stringLivrables = Program.EnleverLesEspaces(Console.ReadLine());
                List<string> listStringLivrables = Program.SeparerChaineDeCaracteres(stringLivrables);
                foreach (string livrable in listStringLivrables)
                {
                    livrables.Add((Livrable)Convert.ChangeType(Repertoire["livrable", livrable], typeof(Livrable)));
                }
            }
            else
            {
                livrables = typeProjet.Livrables;
                bool premierMotPasse = false;
                foreach (Livrable livrable in livrables)
                {
                    string stringLivrable = livrable.Nom;
                    if (premierMotPasse)
                    {
                        stringLivrables += ", " + stringLivrable;
                    }
                    else
                    {
                        stringLivrables += stringLivrable;
                        premierMotPasse = true;
                    }
                }
            }

            //On récupère la date de début du projet
            DateTime dateDebut = new DateTime(2000, 1, 1);
            string stringDateDebut = "";
            if (typeProjet.DateDebut.Year < 2001)
            {
                Console.WriteLine("Quelle est la date de début du projet ? (écrivez sous la forme \"jour,mois,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"3,2,2019\"");
                stringDateDebut = Program.EnleverLesEspaces(Console.ReadLine());
                List<string> listStringDateDebut = Program.SeparerChaineDeCaracteres(stringDateDebut);
                int moisDebut = int.Parse(listStringDateDebut[1]);
                int jourDebut = int.Parse(listStringDateDebut[2]);
                int anneeDebut = int.Parse(listStringDateDebut[0]);
                dateDebut = new DateTime(moisDebut, jourDebut, anneeDebut);
            }
            else
            {
                dateDebut = typeProjet.DateDebut;
                string jourDebut = dateDebut.Day.ToString();
                string moisDebut = dateDebut.Month.ToString();
                string anneeDebut = dateDebut.Year.ToString();
                stringDateDebut = jourDebut + ", " + moisDebut + ", " + anneeDebut;

            }

            //On récupère la date de fin du projet
            DateTime dateFin = new DateTime(2000, 1, 1);
            string stringDateFin = "";
            if (typeProjet.DateFin.Year < 2001)
            {
                Console.WriteLine("Quelle est la date de fin du projet ? (écrivez sous la forme \"jour,mois,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"3,2,2019\"");
                stringDateFin = Program.EnleverLesEspaces(Console.ReadLine());
                List<string> listStringDateFin = Program.SeparerChaineDeCaracteres(stringDateFin);
                int moisFin = int.Parse(listStringDateFin[1]);
                int jourFin = int.Parse(listStringDateFin[2]);
                int anneeFin = int.Parse(listStringDateFin[0]);
                dateFin = new DateTime(moisFin, jourFin, anneeFin);
            }
            else
            {
                dateFin = typeProjet.DateFin;
                string jourFin = dateFin.Day.ToString();
                string moisFin = dateFin.Month.ToString();
                string anneeFin = dateFin.Year.ToString();
                stringDateFin = jourFin + ", " + moisFin + ", " + anneeFin;
            }

            //On récupère les mots-clefs
            List<string> motsClefs = null;
            string stringMotsClefs = "";
            if (typeProjet.MotsClefs == null)
            {
                Console.WriteLine("Quels sont les mots-clefs liés au projet ?");
                stringMotsClefs = Program.EnleverLesEspaces(Console.ReadLine());
                motsClefs = Program.SeparerChaineDeCaracteres(stringMotsClefs);
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
                stringMotsClefs = Program.EnleverLesEspaces(Console.ReadLine());
                bool stringMotsClefsRempli = Program.VerifierChampRempli(stringMotsClefs);
                if (stringMotsClefsRempli)
                {
                    motsClefs = Program.SeparerChaineDeCaracteres(stringMotsClefs);
                    foreach (string motClef in typeProjet.MotsClefs)
                    {
                        motsClefs.Add(motClef);
                    }
                }
                else
                {
                    motsClefs = typeProjet.MotsClefs;
                    bool premierMotPasse = false;
                    foreach (string motClef in motsClefs)
                    {
                        if (premierMotPasse)
                        {
                            stringMotsClefs += ", " + motClef;
                        }
                        else
                        {
                            stringMotsClefs += motClef;
                            premierMotPasse = true;
                        }
                    }
                }
            }

            int NbProjetsAvant = Repertoire.RepertoireProjets.Count();
            Repertoire.RepertoireProjets.Add(new Projet(nom, sujet, sujetLibre, typeProjet, anneesEtudes, matieres, anneeScolaire, etudiants, chefDeProjet,
                developpeurs, maquetteurs, poleFacteurHumain, client, tuteurs, livrables, dateDebut, dateFin, motsClefs));
            int NbProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbProjetsAprès == NbProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine("Le projet a été ajouté avec succès !");
                Sauvegarde.SauvegarderFichierTxtProjet(nom, sujet, sujetLibre, stringTypeProjet, stringAnneesEtudes, stringMatieres, stringAnneeScolaire,
                    stringEtudiants, stringChefDeProjet, stringDeveloppeurs, stringMaquetteurs, stringPoleFacteurHumain, stringClient, stringTuteurs,
                    stringLivrables, stringDateDebut, stringDateFin, stringMotsClefs);
            }



        }
           
        public void CreerTypeProjet()
        {
            // NOM projet
            Console.WriteLine("Quel est le nom du projet ?");
            string nom = Program.EnleverLesEspaces(Console.ReadLine());

            //Sujet
            string sujet = null;
            Console.WriteLine("Quel est le sujet du type de projet ?");
            string stringSujet = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringSujetRempli = Program.VerifierChampRempli(stringSujet);
            if (stringSujetRempli)
            {
                sujet = stringSujet;
            }



            //sujet imposé 
            string sujetLibre = null;
            Console.WriteLine("Le sujet du projet est-il imposé (écrivez \"impose\") ? libre parmi une liste de sujets imposée (écrivez \"listeImpose\") ? ou libre (écrivez \"libre\") ?");
            string stringSujetLibre = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringSujetLibreRempli = Program.VerifierChampRempli(stringSujetLibre);
            if (stringSujetLibreRempli)
            {
                sujetLibre = stringSujetLibre;
            }


            //  Demande des matières
            List<Matiere> matieres = new List<Matiere> { };
            Console.WriteLine("Quelles sont la/les matière(s) du projet ? (Rentrez soit le nom de la matière comme orthographiée sur moodle, soit son code)");
            string stringMatieres = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringMatieresRempli = Program.VerifierChampRempli(stringMatieres);
            if (stringMatieresRempli)
            {
                List<string> listStringMatieres = Program.SeparerChaineDeCaracteres(stringMatieres);
                foreach (string matiere in listStringMatieres)
                {
                    matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", matiere], typeof(Matiere)));
                }
            }
            else
            {
                matieres = null;
            }

            // Nombre de personne implique
           /* int nbPersonnesImpliquees = 0;
            Console.WriteLine("Combien de personnes sont impliquées dans le projet (Veuillez rentrer un nombre entier)");
            string stringNbPersonnesImpliquees = Console.ReadLine();
            bool stringNbpersonnesImpliqueesRempli = Program.VerifierChampRempli(stringNbPersonnesImpliquees);
            if (stringNbpersonnesImpliqueesRempli)
            {
                nbPersonnesImpliquees = int.Parse(stringNbPersonnesImpliquees);
            }*/



            // ANNEEs ETUDEs
            List<int> anneesEtudes = new List<int> { };
            Console.WriteLine("Le projet a-t-il été réalisé par des étudiants en première année (écrivez \"1\"), 2ème année (écrivez \"2\"), ou 3ème année (écrivez \"3\") ? " +
                                      "Séparez par une virgule (ajout d'un espace optionnel) les nombres si des étudiants d'années différentes sont concernés)");
            string stringAnneesEtudes = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringAnnnesEtudesRempli = Program.VerifierChampRempli(stringAnneesEtudes);
            if (stringAnnnesEtudesRempli)
            {
                List<string> listStringAnneesEtudes = Program.SeparerChaineDeCaracteres(stringAnneesEtudes);
                anneesEtudes = new List<int> { };
                foreach (string anneeEtude in listStringAnneesEtudes)

                {
                    anneesEtudes.Add(int.Parse(anneeEtude));
                }
            }
            else
            {
                anneesEtudes = null;
            }


            //TUTEURS
            List<AutreIntervenant> tuteurs = new List<AutreIntervenant> { };
            Console.WriteLine("Quel est le nom du client du Tuteur ?");
            string stringTuteurs = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringTuteursRempli = Program.VerifierChampRempli(stringTuteurs);
            if (stringTuteursRempli)
            {
                List<string> listStringTuteurs = Program.SeparerChaineDeCaracteres(stringTuteurs);
                foreach (string stringTuteur in listStringTuteurs)
                {
                    tuteurs.Add((AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", stringTuteur], typeof(AutreIntervenant)));
                }

            }
            else
            {
                tuteurs = null;
            }



            //Livrables
            List<Livrable> livrables = new List<Livrable> { };
            Console.WriteLine("Quels sont les livrables attendus pour le type de projet ? ");
            string stringLivrables = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringLivrablesRempli = Program.VerifierChampRempli(stringLivrables);
            if (stringLivrablesRempli)
            {
                List<string> listeLivrables = Program.SeparerChaineDeCaracteres(stringLivrables);
                foreach (string stringLivrable in listeLivrables)
                {
                    livrables.Add((Livrable)Convert.ChangeType(Repertoire["livrable", stringLivrable], typeof(Livrable)));
                }

            }
            else
            {
                livrables = null;
            }


            //On récupère la date de début du projet
            DateTime dateDebut = new DateTime(2000, 1, 1);
            Console.WriteLine("Quelle est la date de début du projet ? (écrivez sous la forme \"jour,mois,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"3,2,2019\"");
            string stringDateDebut = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringDateDebutRempli = Program.VerifierChampRempli(stringDateDebut);
            if (stringDateDebutRempli)
            {
                List<string> listStringDateDebut = Program.SeparerChaineDeCaracteres(stringDateDebut);
                int moisDebut = int.Parse(listStringDateDebut[1]);
                int jourDebut = int.Parse(listStringDateDebut[2]);
                int anneeDebut = int.Parse(listStringDateDebut[0]);
                dateDebut = new DateTime(moisDebut, jourDebut, anneeDebut);
            }



            //On récupère la date de fin du projet
            DateTime dateFin = new DateTime(2000, 1, 1);
            Console.WriteLine("Quelle est la date de fin du projet ? (écrivez sous la forme \"jour,mois,année\" en chiffres (4 chiffres pour l'année). Exemple pour le 3 février 2019 : \"3,2,2019\"");
            string stringDateFin = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringDateFinRempli = Program.VerifierChampRempli(stringDateFin);
            if (stringDateFinRempli)
            {
                List<string> listStringDateFin = Program.SeparerChaineDeCaracteres(stringDateFin);
                int moisFin = int.Parse(listStringDateFin[1]);
                int jourFin = int.Parse(listStringDateFin[2]);
                int anneeFin = int.Parse(listStringDateFin[0]);
                dateFin = new DateTime(moisFin, jourFin, anneeFin);
            }


            // Mots-Clefs
            List<string> motsClefs = null;
            Console.WriteLine("Quels sont les mots clés du projet que tu recherches ? ");
            string stringMotsClefs = Program.EnleverLesEspaces(Console.ReadLine());
            bool stringMotsClefsRempli = Program.VerifierChampRempli(stringMotsClefs);
            if (stringMotsClefsRempli)
            {
                motsClefs = Program.SeparerChaineDeCaracteres(stringMotsClefs);
            }


            int NbTypesProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireTypesProjets.Add(new TypeProjet(nom, sujet, sujetLibre, anneesEtudes, matieres, tuteurs, livrables,
                dateDebut, dateFin, motsClefs));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbTypesProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine("Le projet a été ajouté avec succès !");

            }


        }

        public void CreerEleve() // Creer un nouvel élève

        {

            Console.WriteLine("Quel est le prénom de l'éléve ? (première lettre en majuscule)");
            string prenom = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("Quel est le nom de l'éléve ? (première lettre en majuscule)");
            string nom = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("Quel est le pronom de l'élève ? Ecrivez il ou elle");
            string pronom = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("Quel est l'année de promotion de l'éléve ?");
            string stringPromo = Program.EnleverLesEspaces(Console.ReadLine());
            int promo = int.Parse(stringPromo);

            bool aRedouble = false;
            int anneeEtudeRedoublement = 0;
            Console.WriteLine("Est ce que l'éléve a redoublé ? Ecrivez oui ou non");
            string stringARedouble = Program.EnleverLesEspaces(Console.ReadLine());
            if (stringARedouble == "oui")
            {
                aRedouble = true;
                Console.WriteLine("En quelle année d'étude l'élève a redoublé ? Ecrivez 1, 2 ou 3");
                anneeEtudeRedoublement = int.Parse(Program.EnleverLesEspaces(Console.ReadLine()));
            }

            string identifiant = prenom[0].ToString().ToLower() + nom.ToLower();


            int NbElevesProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireEleves.Add(new Eleve(identifiant, prenom, nom, promo, aRedouble, anneeEtudeRedoublement, pronom, Program));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbElevesProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine("L'élève a été ajouté avec succès !");
            }


        }

        public void CreerAutreInvervenant(string statut) // Permet d'ajouter un nouveau intervenant 
        {
            string nom = "";
            string prenom = "";
            string pronom = "";

            if (statut == "professeur")
            {
                Console.WriteLine("Quel est le prénom du professeur ? (première lettre en majuscule)");
                prenom = Program.EnleverLesEspaces(Console.ReadLine());

                Console.WriteLine("Quel est le nom du professeur ? (première lettre en majuscule)");
                nom = Program.EnleverLesEspaces(Console.ReadLine());

                Console.WriteLine("Quel est le pronom du professeur ? Répondre par il ou elle");
                pronom = Program.EnleverLesEspaces(Console.ReadLine());

            }
            if (statut == "intervenant externe")
            {
                Console.WriteLine("Quel est le nom de l'intervenant externe ? (première lettre en majuscule)");
                nom = Program.EnleverLesEspaces(Console.ReadLine());

                Console.WriteLine("Quel est le prénom de l'intervenant externe ? (première lettre en majuscule)");
                prenom = Program.EnleverLesEspaces(Console.ReadLine());

                Console.WriteLine("Quel est le pronom de l'intervenant externe ? Ecrivez il ou elle");
                pronom = Program.EnleverLesEspaces(Console.ReadLine());
            }

            string identifiant = prenom[0].ToString().ToLower() + nom.ToLower();

            int NbAutreIntervantProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireAutresIntervenants.Add(new AutreIntervenant(identifiant, prenom, nom, statut, pronom, Program));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbAutreIntervantProjetsAvant + 1)
            {
                Console.Clear();
                if (statut == "professeur")
                    Console.WriteLine(" Le professeur a été ajouté avec succès !");
                if (statut == "intervenant externe")
                    Console.WriteLine("L'intervenant externe a été ajouté avec succés !");
            }

        }

        public void CreerLivrable()
        {

            Console.WriteLine("Quel est le nom du livrable ?");
            string nom = Program.EnleverLesEspaces(Console.ReadLine());


            int NbLivrablesProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireLivrables.Add(new Livrable(nom, Program));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbLivrablesProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine(" Le livrable a été ajouté avec succès !");                

            }
        }

        public void CreerMatiere() // Creer une nouvelle matière
        {

            Console.WriteLine("Quel est le nom de la matière ? Ecrivez comme écrit sur moodle");
            string nom = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("Quel est le code de la matière ? Ecrivez comme écrit sur moodle");
            string code = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("A quelle UE appartient la matière ? Ecrivez comme écrit sur moodle");
            string ue = Program.EnleverLesEspaces(Console.ReadLine());

            Console.WriteLine("Quel est le code de l'UE ? Ecrivez comme écrit sur moodle");
            string codeUe = Program.EnleverLesEspaces(Console.ReadLine());

            int NbMatieresProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireMatieres.Add(new Matiere(nom, ue, code, codeUe, Program));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbMatieresProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine(" La matière a été ajouté avec succès !");


            }
        }

        public void CreerAnneeScolaire() // Creer une année scolaire
        {


            Console.WriteLine("En quelle année commence l'année scolaire ?");
            string stringAnneeDebut = Program.EnleverLesEspaces(Console.ReadLine());
            int anneeDebut = int.Parse(stringAnneeDebut);

            Console.WriteLine("En quelle année finit l'année scolaire ?");
            string stringAnneeFin = Program.EnleverLesEspaces(Console.ReadLine());
            int anneeFin = int.Parse(stringAnneeFin);

            string nom = anneeDebut.ToString() + "-" + anneeFin;

            int NbAnneeScolaireProjetsAvant = Repertoire.RepertoireTypesProjets.Count();
            Repertoire.RepertoireAnneesScolaires.Add(new AnneeScolaire(nom, anneeDebut, anneeFin, Program));
            int NbTypesProjetsAprès = Repertoire.RepertoireProjets.Count();

            if (NbTypesProjetsAprès == NbAnneeScolaireProjetsAvant + 1)
            {
                Console.Clear();
                Console.WriteLine("L'année scolaire a été ajouté avec succés !");
            }

        }






    public void SupprimerProjet()
        { }
        public void SupprimerTypeProjet()
        { }


    }
}
