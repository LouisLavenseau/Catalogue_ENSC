using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class TypeProjet
    {
        public string Nom { get; private set; }
        public string SujetLibre { get; private set; }
        public List<int> AnneesEtudes { get; private set; }
        public List<Matiere> Matieres { get; private set; }
        public int NbPersonnesImpliquees { get; private set; }
        public List<AutreIntervenant> Tuteurs { get; private set; }
        public List<Livrable> Livrables { get; private set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public List<string> MotsClefs { get; private set; }

        public TypeProjet(string nom, string sujetLibre, List<int> anneesEtudes, List<Matiere> matieres, int nbPersonnesImpliquees, List<AutreIntervenant> tuteurs,
            List<Livrable> livrables, DateTime dateDebut, DateTime dateFin, List<string> motsClefs)
        {
            Nom = nom;
            SujetLibre = sujetLibre;
            AnneesEtudes = anneesEtudes;
            Matieres = matieres;
            NbPersonnesImpliquees = nbPersonnesImpliquees;
            Tuteurs = tuteurs;
            Livrables = livrables;
            DateDebut = dateDebut;
            DateFin = dateFin;
            MotsClefs = motsClefs;
        }

        public void ModifierTypeProjet()
        {
            //A compléter
        }
    }
}
