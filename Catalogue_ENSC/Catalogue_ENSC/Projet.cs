using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Projet
    {
        public string Nom { get; private set; }
        public string Sujet { get; private set; }
        public string SujetLibre { get; private set; }
        public TypeProjet TypeProjet { get; set; }
        public List<int> AnneesEtudes { get; private set; }
        public List<Matiere> Matieres { get; private set; }
        public List<int> Promos { get; private set; }
        public AnneeScolaire AnneeScolaire { get; private set; }
        public int NbPersonnesImpliquees { get; private set; }
        public List<Eleve> Etudiants { get; private set; }
        public Eleve ChefDeProjet { get; private set; }
        public List<Eleve> Developpeurs { get; private set; }
        public List<Eleve> Maquetteurs { get; private set; }
        public List<Eleve> PoleFacteurHumain { get; private set; }
        public Personne Client { get; private set; }
        public List<AutreIntervenant> Tuteurs { get; private set; }
        public List<Livrable> Livrables { get; private set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public List<string> MotsClefs { get; private set; }

        public Projet(string nom, string sujet, string sujetLibre, TypeProjet typeProjet, List<int> anneesEtudes, List<Matiere> matieres, AnneeScolaire anneeScolaire,
            List<Eleve> etudiants, Eleve chefDeProjet, List<Eleve> developpeurs, List<Eleve> maquetteurs, List<Eleve> poleFacteurHumain, Personne client,
            List<AutreIntervenant> tuteurs, List<Livrable> livrables, DateTime dateDebut, DateTime dateFin, List<string> motsClefs)
        {
            Nom = nom;
            Sujet = sujet;
            SujetLibre = sujetLibre;
            TypeProjet = typeProjet;
            AnneesEtudes = anneesEtudes;
            Matieres = matieres;
            List<int> promos = new List<int> { };
            foreach (int anneeEtude in anneesEtudes) { promos.Add(anneeScolaire.AnneeFin + anneeEtude); }
            Promos = promos;
            AnneeScolaire = anneeScolaire;
            int cpt = 0;
            foreach (Eleve etudiant in etudiants) { cpt++; }
            foreach (AutreIntervenant tuteur in tuteurs) { cpt++; }
            if (client != null) { cpt++; }
            NbPersonnesImpliquees = cpt;
            Etudiants = etudiants;
            ChefDeProjet = chefDeProjet;
            Developpeurs = developpeurs;
            Maquetteurs = maquetteurs;
            PoleFacteurHumain = poleFacteurHumain;
            Client = client;
            Tuteurs = tuteurs;
            Livrables = livrables;
            DateDebut = dateDebut;
            DateFin = dateFin;
            MotsClefs = motsClefs;
        }

        public void ModifierProjet()
        {
            //A compléter
        }

        public void Supprimer()
        {
            Nom = "";
            AnneeScolaire = null;
            Etudiants = null;
            TypeProjet = null;
            Promos = null;
            MotsClefs = null;
        }

        public override string ToString()
        {
            string sujetLibre = "";
            if (SujetLibre == "libre")
                sujetLibre = "sujet libre";
            if (SujetLibre == "impose")
                sujetLibre = "sujet imposé";
            if (SujetLibre == "liste")
                sujetLibre = "sujet libre parmi une liste de sujets imposés";
            string anneeEtudes = "";
            bool premierMotPasse = false;
            foreach (int anneeEtude in AnneesEtudes)
            {
                if (premierMotPasse)
                {
                    anneeEtudes += ", " + anneeEtude;
                }
                else
                {
                    anneeEtudes += anneeEtude;
                    premierMotPasse = true;
                }
            }

            string matieres = "";
            premierMotPasse = false;
            foreach (Matiere matiere in Matieres)
            {
                if (premierMotPasse)
                {
                    matieres += ", " + matiere;
                }
                else
                {
                    matieres += matiere;
                    premierMotPasse = true;
                }
            }

            string promos = "";
            premierMotPasse = false;
            foreach (int promo in Promos)
            {
                if (premierMotPasse)
                {
                    promos += ", " + promo;
                }
                else
                {
                    promos += promo;
                    premierMotPasse = true;
                }
            }

            string etudiants = "";
            premierMotPasse = false;
            foreach (Eleve eleve in Etudiants)
            {
                if (premierMotPasse)
                {
                    etudiants += ", " + eleve;
                }
                else
                {
                    etudiants += eleve;
                    premierMotPasse = true;
                }
            }

            string developpeurs = "";
            premierMotPasse = false;
            foreach (Eleve developpeur in Developpeurs)
            {
                if (premierMotPasse)
                {
                    developpeurs += ", " + developpeur;
                }
                else
                {
                    developpeurs += developpeur;
                    premierMotPasse = true;
                }
            }

            string maquetteurs = "";
            premierMotPasse = false;
            foreach (Eleve maquetteur in Maquetteurs)
            {
                if (premierMotPasse)
                {
                    maquetteurs += ", " + maquetteur;
                }
                else
                {
                    maquetteurs += maquetteur;
                    premierMotPasse = true;
                }
            }

            string poleFacteurHumain = "";
            premierMotPasse = false;
            foreach (Eleve elevePoleFacteurHumain in PoleFacteurHumain)
            {
                if (premierMotPasse)
                {
                    poleFacteurHumain += ", " + elevePoleFacteurHumain;
                }
                else
                {
                    poleFacteurHumain += elevePoleFacteurHumain;
                    premierMotPasse = true;
                }
            }

            string tuteurs = "";
            premierMotPasse = false;
            foreach (AutreIntervenant tuteur in Tuteurs)
            {
                if (premierMotPasse)
                {
                    tuteurs += ", " + tuteur;
                }
                else
                {
                    tuteurs += tuteur;
                    premierMotPasse = true;
                }
            }

            string livrables = "";
            premierMotPasse = false;
            foreach (Livrable livrable in Livrables)
            {
                if (premierMotPasse)
                {
                    livrables += ", " + livrable;
                }
                else
                {
                    livrables += livrable;
                    premierMotPasse = true;
                }
            }

            string motsClefs = "";
            premierMotPasse = false;
            foreach (string motClef in MotsClefs)
            {
                if (premierMotPasse)
                {
                    motsClefs += ", " + motClef;
                }
                else
                {
                    motsClefs += motClef;
                    premierMotPasse = true;
                }
            }
            return "Nom : " + Nom + "\n" + "Sujet : " +Sujet + "\n" + "Liberté du sujet " + sujetLibre + "\n" + "Type du projet" + TypeProjet + "\n" + "Année(s) d'étude " + anneeEtudes + "\n" + "Matières : " 
                + matieres + "\n" + "Années de promotion : " + promos + "\n" + "Année scolaire : " + AnneeScolaire + "\n" + "Nombre de personnes impliquées : " + NbPersonnesImpliquees + 
                "\n" + "Etudiants : " + etudiants + "\n" + "Chef de projet : " + ChefDeProjet + "\n" + "Developpeurs : " + developpeurs + "\n" + "Maquetteurs : " + maquetteurs + "\n" + "Pole facteur humain : " + 
                poleFacteurHumain + "\n" + "Client : " + Client + "\n" + "Tuteurs : " + tuteurs + "\n" + "Livrables : " + livrables + "\n" + "Date de début : " + DateDebut.ToLongDateString() + "\n" +
                "Date de fin : " + DateFin.ToLongDateString() + "\n" + "Mots clés : " + motsClefs;
        }
    }
}
