using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class TypeProjet
    {
        public string Nom { get; private set; }
        public string Sujet { get; private set; }
        public string SujetLibre { get; private set; }
        public List<int> AnneesEtudes { get; private set; }
        public List<Matiere> Matieres { get; private set; }
        public int NbPersonnesImpliquees { get; private set; }
        public List<AutreIntervenant> Tuteurs { get; private set; }
        public List<Livrable> Livrables { get; private set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public List<string> MotsClefs { get; private set; }

        public TypeProjet(string nom, string sujet, string sujetLibre, List<int> anneesEtudes, List<Matiere> matieres,  List<AutreIntervenant> tuteurs,
            List<Livrable> livrables, DateTime dateDebut, DateTime dateFin, List<string> motsClefs)
        {
            Nom = nom;
            Sujet = sujet;
            SujetLibre = sujetLibre;
            AnneesEtudes = anneesEtudes;
            Matieres = matieres;
            Tuteurs = tuteurs;
            Livrables = livrables;
            DateDebut = dateDebut;
            DateFin = dateFin;
            MotsClefs = motsClefs;
        }

        public TypeProjet()
        { }

        public void ModifierTypeProjet()
        {
            //A compléter
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
