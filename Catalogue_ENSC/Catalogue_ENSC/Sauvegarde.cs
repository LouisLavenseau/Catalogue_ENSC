using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Sauvegarde
    {
        public Repertoire Repertoire { get; private set; }
        public Program Program { get; private set; }

        public Sauvegarde(Repertoire repertoire, Program program)
        {
            Repertoire = repertoire;
            Program = program;
        }

        public void SauvegarderFichierTxtProjet(string nom, string sujet, string sujetLibre, string typeProjet, string anneesEtudes, string matieres,
            string anneeScolaire, string etudiants, string chefDeProjet, string developpeurs, string maquetteurs,
            string poleFacteurHumain, string client, string tuteurs, string livrables, string dateDebut, string dateFin, string motsClefs)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("Projets.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(nom + "\n" + sujet + "\n" + sujetLibre + "\n" + typeProjet + "\n" + anneesEtudes + "\n" + matieres + "\n" +
                 anneeScolaire + "\n" + etudiants + "\n" + chefDeProjet + "\n" + developpeurs + "\n" + maquetteurs + "\n" + poleFacteurHumain + "\n" +
                 client + "\n" + tuteurs + "\n" + livrables + "\n" + dateDebut + "\n" + dateFin + "\n" + motsClefs);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtEleve(string identifiant, string prenom, string nom, string promo, string ARedouble, string anneeEtudeRedoublement, string pronom)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("Eleves.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(identifiant + "\n" + prenom + "\n" + nom + "\n" + promo + "\n" + ARedouble + "\n" + anneeEtudeRedoublement + "\n" + pronom);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtAutreIntervenant(string identifiant, string prenom, string nom, string statut, string pronom)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("AutresIntervenants.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(identifiant + "\n" + prenom + "\n" + nom + "\n" + statut + "\n" + pronom);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtMatiere(string nom, string code, string ue, string codeUe)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("Matieres.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(nom + "\n" + code + "\n" + ue + "\n" + codeUe);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtAnneeScolaire(string nom, string anneeDebut, string anneeFin)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("AnneesScolaires.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(nom + "\n" + anneeDebut + "\n" + anneeFin);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtLivrable(string nom)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("Livrables.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(nom);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void SauvegarderFichierTxtTypeProjet(string nom, string sujet, string sujetLibre, string anneesEtudes, string matieres, string tuteurs,
           string livrables, string dateDebut, string dateFin, string motsClefs)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("TypesProjets.txt");


            //on écrit dans le fichier cible
            monStreamWriter.WriteLine("yo " + nom + "\n" + sujet + "\n" + sujetLibre + "\n" + anneesEtudes + "\n" + matieres + "\n"
            + "\n" + tuteurs + "\n" + livrables + "\n" + dateDebut + "\n" + dateFin + "\n" + motsClefs);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void RecupFichierTxtProjets()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Projets.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 18;
            string nom = "";
            string sujet = "";
            string sujetLibre = "";
            string stringTypeProjet = ""; TypeProjet typeProjet = new TypeProjet();
            string stringAnneesEtudes = ""; List<string> listStringAnneesEtudes; List<int> anneesEtudes = new List<int> { };
            string stringMatieres = ""; List<string> listStringMatieres; List<Matiere> matieres = new List<Matiere> { };
            string stringAnneeScolaire = ""; AnneeScolaire anneeScolaire = new AnneeScolaire();
            string stringEtudiants = ""; List<string> listStringEtudiants; List<Eleve> etudiants = new List<Eleve> { };
            string stringChefDeProjet = ""; bool stringChefDeProjetRempli; Eleve chefDeProjet = new Eleve();
            string stringDeveloppeurs = ""; bool stringDeveloppeursRempli; List<string> listStringDeveloppeurs; List<Eleve> developpeurs = new List<Eleve> { };
            string stringMaquetteurs = ""; bool stringMaquetteursRempli; List<string> listStringMaquetteurs; List<Eleve> maquetteurs = new List<Eleve> { };
            string stringPoleFacteurHumain = ""; bool stringPoleFacteurHumainRempli; List<string> listStringPoleFacteurHumain; List<Eleve> poleFacteurHumain = new List<Eleve> { };
            string stringClient = ""; bool stringClientRempli; Personne client = new Personne();
            string stringTuteurs = ""; bool stringTuteursRempli; List<string> listStringTuteurs; List<AutreIntervenant> tuteurs = new List<AutreIntervenant> { };
            string stringLivrables = ""; List<string> listStringLivrables; List<Livrable> livrables = new List<Livrable> { };
            string stringDateDebut = ""; List<string> listStringDateDebut; DateTime dateDebut = new DateTime();
            string stringDateFin = ""; List<string> listStringDateFin; DateTime dateFin = new DateTime();
            string stringMotsClefs = ""; List<string> motsClefs;

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();

                if (nbMots % ratio == 1)              // Récupération du nom 
                {
                    nom = mot;
                }

                if (nbMots % ratio == 2)              // Récupération du sujet 
                {
                    sujet = mot;
                }

                if (nbMots % ratio == 3)             // Récupération de la liberté du sujet
                {
                    sujetLibre = mot;
                }


                if (nbMots % ratio == 4)            // Récupération du type de projet 
                {
                    stringTypeProjet = mot;
                    typeProjet = (TypeProjet)Convert.ChangeType(Repertoire["typeProjet", stringTypeProjet], typeof(TypeProjet));
                }

                if (nbMots % ratio == 5)              // Récupération des années d'étude
                {
                    stringAnneesEtudes = mot;
                    listStringAnneesEtudes = Program.SeparerChaineDeCaracteres(stringAnneesEtudes);
                    anneesEtudes = new List<int> { };
                    foreach (string stringAnneeEtude in listStringAnneesEtudes)
                    {
                        anneesEtudes.Add(int.Parse(stringAnneeEtude));
                    }
                }

                if (nbMots % ratio == 6)              // Récupération des matières
                {
                    stringMatieres = mot;
                    matieres = new List<Matiere> { };
                    listStringMatieres = Program.SeparerChaineDeCaracteres(stringMatieres);
                    foreach (string stringMatiere in listStringMatieres)
                    {
                        matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", stringMatiere], typeof(Matiere)));
                    }


                }
                if (nbMots % ratio == 7)              // Récupération de l'année scolaire 
                {
                    stringAnneeScolaire = mot;
                    anneeScolaire = (AnneeScolaire)Convert.ChangeType(Repertoire["anneeScolaire", stringAnneeScolaire], typeof(AnneeScolaire));
                }

                if (nbMots % ratio == 8)              // Récupération des étudiants 
                {
                    stringEtudiants = mot;
                    etudiants = new List<Eleve>();
                    listStringEtudiants = Program.SeparerChaineDeCaracteres(stringEtudiants);
                    foreach (string etudiant in listStringEtudiants)
                    {
                        etudiants.Add((Eleve)Convert.ChangeType(Repertoire["eleve", etudiant], typeof(Eleve)));
                    }
                }

                if (nbMots % ratio == 9)              // Récupération du chef de projet 
                {
                    stringChefDeProjet = mot;
                    stringChefDeProjetRempli = Program.VerifierChampRempli(stringChefDeProjet);
                    if (stringChefDeProjetRempli)
                    {
                        chefDeProjet = (Eleve)Convert.ChangeType(Repertoire["eleve", stringChefDeProjet], typeof(Eleve));
                    }
                }
                if (nbMots % ratio == 10)              // Récupération des développeurs 
                {
                    stringDeveloppeurs = mot;
                    developpeurs = new List<Eleve>();
                    stringDeveloppeursRempli = Program.VerifierChampRempli(stringDeveloppeurs);
                    if (stringDeveloppeursRempli)
                    {
                        listStringDeveloppeurs = Program.SeparerChaineDeCaracteres(stringDeveloppeurs);
                        foreach (string stringDeveloppeur in listStringDeveloppeurs)
                        {
                            developpeurs.Add((Eleve)Convert.ChangeType(Repertoire["eleve", stringDeveloppeur], typeof(Eleve)));
                        }
                    }
                }
                if (nbMots % ratio == 11)              // Récupération des maquetteurs 
                {
                    stringMaquetteurs = mot;
                    maquetteurs = new List<Eleve>();
                    stringMaquetteursRempli = Program.VerifierChampRempli(stringMaquetteurs);
                    if (stringMaquetteursRempli)
                    {
                        listStringMaquetteurs = Program.SeparerChaineDeCaracteres(stringMaquetteurs);
                        foreach (string stringMaquetteur in listStringMaquetteurs)
                        {
                            maquetteurs.Add((Eleve)Convert.ChangeType(Repertoire["eleve", stringMaquetteur], typeof(Eleve)));
                        }
                    }
                }
                if (nbMots % ratio == 12)              // Récupération du pôle facteur humain 
                {

                    stringPoleFacteurHumain = mot;
                    poleFacteurHumain = new List<Eleve>();
                    stringPoleFacteurHumainRempli = Program.VerifierChampRempli(stringPoleFacteurHumain);
                    if (stringPoleFacteurHumainRempli)
                    {
                        listStringPoleFacteurHumain = Program.SeparerChaineDeCaracteres(stringPoleFacteurHumain);
                        foreach (string etudiantPoleFacteurHumain in listStringPoleFacteurHumain)
                        {
                            poleFacteurHumain.Add((Eleve)Convert.ChangeType(Repertoire["eleve", etudiantPoleFacteurHumain], typeof(Eleve)));
                        }
                    }
                }
                if (nbMots % ratio == 13)              // Récupération du client 
                {
                    stringClient = mot;
                    stringClientRempli = Program.VerifierChampRempli(stringClient);
                    if (stringClientRempli)
                    {
                        client = (AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", stringClient], typeof(AutreIntervenant));
                        if (client == null)
                        {
                            client = (Eleve)Convert.ChangeType(Repertoire["eleve", stringClient], typeof(Eleve));
                        }
                    }
                }
                if (nbMots % ratio == 14)              // Récupération des tuteurs
                {
                    stringTuteurs = mot;
                    tuteurs = new List<AutreIntervenant>();
                    stringTuteursRempli = Program.VerifierChampRempli(stringTuteurs);
                    if (stringTuteursRempli)
                    {
                        listStringTuteurs = Program.SeparerChaineDeCaracteres(stringTuteurs);
                        foreach (string tuteur in listStringTuteurs)
                        {
                            tuteurs.Add((AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", tuteur], typeof(AutreIntervenant)));
                        }
                    }
                }
                if (nbMots % ratio == 15)              // Récupération des livrables 
                {
                    stringLivrables = mot;
                    livrables = new List<Livrable>();
                    listStringLivrables = Program.SeparerChaineDeCaracteres(stringLivrables);
                    foreach (string livrable in listStringLivrables)
                    {
                        livrables.Add((Livrable)Convert.ChangeType(Repertoire["livrable", livrable], typeof(Livrable)));
                    }
                }
                if (nbMots % ratio == 16)              // Récupération de la date de début 
                {
                    stringDateDebut = mot;
                    listStringDateDebut = Program.SeparerChaineDeCaracteres(stringDateDebut);
                    int moisDebut = int.Parse(listStringDateDebut[1]);
                    int jourDebut = int.Parse(listStringDateDebut[2]);
                    int anneeDebut = int.Parse(listStringDateDebut[0]);
                    dateDebut = new DateTime(moisDebut, jourDebut, anneeDebut);
                }
                if (nbMots % ratio == 17)              // Récupération de la date de fin 
                {
                    stringDateFin = mot;
                    listStringDateFin = Program.SeparerChaineDeCaracteres(stringDateFin);
                    int moisFin = int.Parse(listStringDateFin[1]);
                    int jourFin = int.Parse(listStringDateFin[2]);
                    int anneeFin = int.Parse(listStringDateFin[0]);
                    dateFin = new DateTime(moisFin, jourFin, anneeFin);
                }
                if (nbMots % ratio == 0)              // Récupération des mots-clefs 
                {
                    stringMotsClefs = mot;
                    motsClefs = Program.SeparerChaineDeCaracteres(stringMotsClefs);

                    Repertoire.RepertoireProjets.Add(new Projet(nom, sujet, sujetLibre, typeProjet, anneesEtudes, matieres, anneeScolaire, etudiants, chefDeProjet,
                    developpeurs, maquetteurs, poleFacteurHumain, client, tuteurs, livrables, dateDebut, dateFin, motsClefs));
                }

            }
            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();
        }

        public void RecupFichierTxtTypesProjets()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("TypesProjets.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 10;
            string nom = "";
            string stringSujet = ""; string sujet = ""; bool stringSujetRempli = false;
            string stringSujetLibre = ""; string sujetLibre = ""; bool stringSujetLibreRempli = false;
            string stringAnneesEtudes = ""; List<string> listStringAnneesEtudes = new List<string> { }; List<int> anneesEtudes = new List<int> { }; bool stringAnneesEtudesRempli = false;
            string stringMatieres; List<string> listStringMatieres = new List<string> { }; List<Matiere> matieres = new List<Matiere> { }; bool stringMatieresRempli = false;
            string stringTuteurs = ""; List<string> listStringTuteurs = new List<string> { }; List<AutreIntervenant> tuteurs = new List<AutreIntervenant> { }; bool stringTuteursRempli = false;
            string stringLivrables = ""; List<string> listStringLivrables = new List<string> { }; List<Livrable> livrables = new List<Livrable> { }; bool stringLivrablesRempli = false;
            string stringDateDebut; List<string> listStringDateDebut = new List<string> { }; DateTime dateDebut = new DateTime(); bool stringDateDebutRempli = false;
            string stringDateFin; List<string> listStringDateFin = new List<string> { }; DateTime dateFin = new DateTime(); bool stringDateFinRempli = false;
            string stringMotsClefs; List<string> motsClefs = new List<string> { }; bool stringMotsClefsRempli = false;

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                if (nbMots % ratio == 1)              // Récupération nom
                {
                    nom = mot;
                }
                if (nbMots % ratio == 2)              // Récupération Sujet
                {
                    sujet = mot;
                    stringSujetRempli = Program.VerifierChampRempli(stringSujet);
                    if (stringSujetRempli)
                    {
                        sujet = stringSujet;
                    }
                }

                if (nbMots % ratio == 3)              // Récupération imposé
                {
                    stringSujetLibre = mot;
                    stringSujetLibreRempli = Program.VerifierChampRempli(stringSujetLibre);
                    if (stringSujetLibreRempli)
                    {
                        sujetLibre = stringSujetLibre;
                    }
                }

                if (nbMots % ratio == 4)              // Récupération des années d'étude
                {
                    stringAnneesEtudes = mot;
                    stringAnneesEtudesRempli = Program.VerifierChampRempli(stringAnneesEtudes);
                    listStringAnneesEtudes = new List<string> { };
                    if (stringAnneesEtudesRempli)
                    {
                        listStringAnneesEtudes = Program.SeparerChaineDeCaracteres(stringAnneesEtudes);
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
                }

                if (nbMots % ratio == 5)              // Récupération des Matieres;
                {

                    stringMatieres = mot;
                    stringMatieresRempli = Program.VerifierChampRempli(stringMatieres);
                    listStringMatieres = new List<string> { };
                    if (stringMatieresRempli)
                    {
                        listStringMatieres = Program.SeparerChaineDeCaracteres(stringMatieres);
                        foreach (string matiere in listStringMatieres)
                        {
                            matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", matiere], typeof(Matiere)));
                        }
                    }
                    else
                    {
                        matieres = null;
                    }
                }

                if (nbMots % ratio == 6)              // Récupération des tuteurs

                {
                    stringTuteurs = Program.EnleverLesEspaces(Console.ReadLine());
                    stringTuteursRempli = Program.VerifierChampRempli(stringTuteurs);
                    listStringTuteurs = new List<string> { };
                    if (stringTuteursRempli)
                    {
                        listStringTuteurs = Program.SeparerChaineDeCaracteres(stringTuteurs);
                        foreach (string stringTuteur in listStringTuteurs)
                        {
                            tuteurs.Add((AutreIntervenant)Convert.ChangeType(Repertoire["autreIntervenant", stringTuteur], typeof(AutreIntervenant)));
                        }

                    }
                    else
                    {
                        tuteurs = null;
                    }

                }

                if (nbMots % ratio == 7)              // Récupération des livrables
                {

                    stringLivrables = Program.EnleverLesEspaces(Console.ReadLine());
                    stringLivrablesRempli = Program.VerifierChampRempli(stringLivrables);
                    listStringLivrables = new List<string> { };
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
                }

                if (nbMots % ratio == 8)              // Récupération de la date de début 
                {
                    stringDateDebut = mot;
                    stringDateDebutRempli = Program.VerifierChampRempli(stringDateDebut);
                    listStringDateDebut = new List<string> { };
                    if (stringDateDebutRempli)
                    {
                        listStringDateDebut = Program.SeparerChaineDeCaracteres(stringDateDebut);
                        int moisDebut = int.Parse(listStringDateDebut[1]);
                        int jourDebut = int.Parse(listStringDateDebut[0]);
                        int anneeDebut = int.Parse(listStringDateDebut[2]);
                        dateDebut = new DateTime(anneeDebut, moisDebut, jourDebut);
                    }
                }
                if (nbMots % ratio == 9)              // Récupération de la date de fin 
                {
                    stringDateFin = mot;
                    stringDateFinRempli = Program.VerifierChampRempli(stringDateFin);
                    listStringDateFin = new List<string> { };
                    if (stringDateFinRempli)
                    {
                        listStringDateFin = Program.SeparerChaineDeCaracteres(stringDateFin);
                        int moisFin = int.Parse(listStringDateFin[1]);
                        int jourFin = int.Parse(listStringDateFin[0]);
                        int anneeFin = int.Parse(listStringDateFin[2]);
                        dateFin = new DateTime(anneeFin, moisFin, jourFin);
                    }
                }
                if (nbMots % ratio == 0)              // Récupération des mots-clefs 
                {
                    stringMotsClefs = mot;
                    stringMotsClefsRempli = Program.VerifierChampRempli(stringMotsClefs);
                    motsClefs = new List<string> { };
                    if (stringMotsClefsRempli)
                    {
                        motsClefs = Program.SeparerChaineDeCaracteres(stringMotsClefs);
                    }

                    Repertoire.RepertoireTypesProjets.Add(new TypeProjet(nom, sujet, sujetLibre, anneesEtudes, matieres, tuteurs, livrables, dateDebut, dateFin, motsClefs));
                }

            }

            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();

        }

        public void RecupFichierTxtEleves()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Eleves.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 7;
            string identifiant = "";
            string prenom = "";
            string nom = "";
            string stringPromo = ""; int promo = 0;
            string stringARedouble; bool aRedouble = false;
            string stringAnneeEtudeRedoublement = ""; int anneeEtudeRedoublement = 0;
            string pronom = "";

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                if (nbMots % ratio == 1)              // Récupération nom
                {
                    identifiant = mot;
                }

                if (nbMots % ratio == 2)
                {
                    prenom = mot;
                }

                if (nbMots % ratio == 3)
                {
                    nom = mot;
                }

                if (nbMots % ratio == 4)
                {
                    stringPromo = mot;
                    promo = int.Parse(stringPromo);
                }

                if (nbMots % ratio == 5)
                {
                    stringARedouble = mot;
                    if (stringARedouble == "oui")
                    {
                        aRedouble = true;

                    }
                    else if (stringARedouble == "non")
                    {
                        aRedouble = false;
                    }
                }

                if (nbMots % ratio == 6)
                {
                    stringAnneeEtudeRedoublement = mot;
                    anneeEtudeRedoublement = int.Parse(stringAnneeEtudeRedoublement);

                }

                if (nbMots % ratio == 0)              // Récupération pronom
                {
                    pronom = mot;
                    Repertoire.RepertoireEleves.Add(new Eleve(identifiant, prenom, nom, promo, aRedouble, anneeEtudeRedoublement, pronom, Program));
                }
            }

            monStreamReader.Close();

        }

        public void RecupFichierTxtLivrables()
        {

            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Livrables.txt", encoding);

            int nbMots = 0;
            string mot = "";
            string nom = "";

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                nom = mot;
                Repertoire.RepertoireLivrables.Add(new Livrable(nom, Program));
            }

            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();

        }

        public void RecupFichierTxtMatieres()
        {

            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Matieres.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 4;
            string nom = "";
            string code = "";
            string ue = "";
            string codeUe = "";


            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                if (nbMots % ratio == 1)              // Récupération nom
                {
                    nom = mot;
                }

                if (nbMots % ratio == 2)
                {
                    code = mot;
                }
                if (nbMots % ratio == 3)              // Récupération nom
                {
                    ue = mot;
                }

                if (nbMots % ratio == 0)
                {
                    codeUe = mot;
                    Repertoire.RepertoireMatieres.Add(new Matiere(nom, code, ue, codeUe, Program));
                }
            }

            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();

        }

        public void RecupFichierTxtAutresIntervenants()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("AutresIntervenants.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 5;
            string identifiant = "";
            string prenom = "";
            string nom = "";
            string statut = "";
            string pronom = "";

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                if (nbMots % ratio == 1)              // Récupération nom
                {
                    identifiant = mot;
                }

                if (nbMots % ratio == 2)              // Récupération nom
                {
                    prenom = mot;
                }
                if (nbMots % ratio == 3)              // Récupération nom
                {
                    nom = mot;
                }

                if (nbMots % ratio == 4)              // Récupération nom
                {
                    statut = mot;
                }

                if (nbMots % ratio == 0)              // Récupération nom
                {
                    pronom = mot;
                    Repertoire.RepertoireAutresIntervenants.Add(new AutreIntervenant(identifiant, nom, prenom, statut, pronom, Program));
                }                

            }
            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();


        }

        public void RecupFichierTxtAnneesScolaires()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("AnneesScolaires.txt", encoding);

            int nbMots = 0;
            string mot = "";
            int ratio = 3;
            string nom = "";
            string stringAnneeDebut = ""; int anneeFin = 0;
            string stringAnneeFin = ""; int anneeDebut = 0;

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                mot = monStreamReader.ReadLine();
                if (nbMots % ratio == 1)              // Récupération nom
                {
                    nom = mot;
                }

                if (nbMots % ratio == 2)              // Récupération nom
                {
                    stringAnneeDebut = mot;
                    anneeDebut = int.Parse(stringAnneeDebut);
                }

                if (nbMots % ratio == 0)              // Récupération nom
                {
                    stringAnneeFin = mot;
                    anneeFin = int.Parse(stringAnneeFin);           
                    Repertoire.RepertoireAnneesScolaires.Add(new AnneeScolaire(nom, anneeDebut, anneeFin, Program));
                }                

            }
            // Fermeture du StreamReader (attention très important) 
            monStreamReader.Close();


        }

    }
}
