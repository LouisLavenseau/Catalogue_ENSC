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

        public void SauvegarderFichierTxtProjet(string nom, string sujet, string sujetLibre, string typeProjet, string anneesEtudes, string matieres,
            string anneeScolaire, string etudiants, string chefDeProjet, string developpeurs, string maquetteurs,
            string poleFacteurHumain, string client, string tuteurs, string livrables, string dateDebut, string dateFin, string motsClefs)
        {
            // Création d'une instance de StreamWriter pour permettre l'ecriture de notre fichier cible
            StreamWriter monStreamWriter = File.AppendText("Projets.txt");

            //on écrit dans le fichier cible
            monStreamWriter.WriteLine(nom + ", " + sujet + ", " + sujetLibre + ", " + typeProjet + ", " + anneesEtudes + ", " + matieres + ", " +
                 anneeScolaire + ", " + etudiants + ", " + chefDeProjet + ", " + developpeurs + ", " + maquetteurs + ", " + poleFacteurHumain + ", " +
                 client + ", " + tuteurs + ", " + livrables + ", " + dateDebut + ", " + dateFin + ", " + motsClefs);   

            // Fermeture du StreamWriter (attention très important) 
            monStreamWriter.Close();
        }

        public void RecupFichierTxtProjet()
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader monStreamReader = new StreamReader("Projet.txt", encoding);

            int nbMots = 0;
            string mot = monStreamReader.ReadLine();
            int ratio = 19;
            string nom;
            string sujet;
            string sujetLibre;
            string stringTypeProjet; TypeProjet typeProjet;
            string stringAnneesEtudes; List<string> listStringAnneesEtudes; List<int> anneesEtudes;
            string stringMatieres; List<string> listStringMatieres; List<Matiere> matieres; ;
            string stringAnneeScolaire; string stringNBPersonnesImpliquees; string stringEtudiants; string stringChefDeProjet; string stringDeveloppeurs;
            string stringMaquetteurs; string stringPoleFacteurHumain; string stringClient; string stringTuteurs; string stringLivrables; string stringDateDebut;
            string stringDateFin; string stringMotsClefs;

            // Lecture de tous les mots du fichier (un par lignes) 
            while (mot != null)
            {
                nbMots++;
                if (nbMots % ratio == 1)              // Récupération du nom 
                {
                    mot = monStreamReader.ReadLine();
                    nom = mot;
                }
                if (nbMots % ratio == 2)              // Récupération du sujet 
                {
                    mot = monStreamReader.ReadLine();
                    sujet = mot;
                }

                if (nbMots % ratio == 3)             // Récupération de la liberté du sujet
                {
                    mot = monStreamReader.ReadLine();
                    sujetLibre = mot;
                }


                if (nbMots % ratio == 4)            // Récupération du type de projet 
                {
                    mot = monStreamReader.ReadLine();
                    stringTypeProjet = mot;
                    typeProjet = (TypeProjet)Convert.ChangeType(Repertoire["typeProjet", stringTypeProjet], typeof(TypeProjet));
                }

                if (nbMots % ratio == 5)              // Récupération des années d'étude
                {
                    mot = monStreamReader.ReadLine();
                    stringAnneesEtudes = mot;
                    listStringAnneesEtudes = Program.SeparerChaineDeCaracteres(Program.EnleverLesEspaces(Console.ReadLine()));
                    anneesEtudes = new List<int> { };
                    foreach (string stringAnneeEtude in listStringAnneesEtudes)
                    {
                        anneesEtudes.Add(int.Parse(stringAnneeEtude));
                    }
                }

                if (nbMots % ratio == 6)              // Récupération des matières
                {
                    mot = monStreamReader.ReadLine();
                    stringMatieres = mot;
                    matieres = new List<Matiere> { };
                    listStringMatieres = Program.SeparerChaineDeCaracteres(Program.EnleverLesEspaces(Console.ReadLine()));
                    foreach (string stringMatiere in listStringMatieres)
                    {
                        matieres.Add((Matiere)Convert.ChangeType(Repertoire["matiere", stringMatiere], typeof(Matiere)));
                    }


                }
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;
                if (nbMots % ratio == 20)              // Récupération des mots-clefs 
                    mot = monStreamReader.ReadLine();
                stringMotsClefs = mot;



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
