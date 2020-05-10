using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Projet
    {

        public string Nom { get; private set; }
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

        public Projet(string nom, string sujetLibre, TypeProjet typeProjet, List<int> anneesEtudes, List<Matiere> matieres, List<int> promos, AnneeScolaire anneeScolaire,
            int nbPersonnesImpliquees, List<Eleve> etudiants, Eleve chefDeProjet, List<Eleve> developpeurs, List<Eleve> maquetteurs, List<Eleve> poleFacteurHumain, AutreIntervenant client,
            List<AutreIntervenant> tuteurs, List<Livrable> livrables, DateTime dateDebut, DateTime dateFin, List<string> motsClefs)
        {
            Nom = nom;
            SujetLibre = sujetLibre;
            TypeProjet = typeProjet;
            AnneesEtudes = anneesEtudes;
            Matieres = matieres;
            Promos = promos;
            AnneeScolaire = anneeScolaire;
            NbPersonnesImpliquees = nbPersonnesImpliquees;
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
    }
}
