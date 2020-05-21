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

            Console.WriteLine("yo");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine("yo " + nom + "\n" + sujet + "\n" + sujetLibre + "\n" + anneesEtudes + "\n" + matieres + "\n"
            + "\n" + tuteurs + "\n" + livrables + "\n" + dateDebut + "\n" + dateFin + "\n" + motsClefs);

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }



        public void RecupFichierTxtProjet()
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
                        chefDeProjet = (Eleve)Convert.ChangeType(Repertoire["intervenant", stringChefDeProjet], typeof(Eleve));
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
                            developpeurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringDeveloppeur], typeof(Eleve)));
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
                            maquetteurs.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", stringMaquetteur], typeof(Eleve)));
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
                            poleFacteurHumain.Add((Eleve)Convert.ChangeType(Repertoire["intervenant", etudiantPoleFacteurHumain], typeof(Eleve)));
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
        public void SauvegarderFichierTxtTypeProjet()
        { }
        public void RecupFichierTxtTypeProjet()
        { }


    }
}
