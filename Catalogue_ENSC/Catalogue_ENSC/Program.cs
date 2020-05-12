using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Program
    {
        static void Main(string[] args)
        {
            Matiere poo = new Matiere("poo", "Sciences fondamentales", "codeMatiere", "codeUe");
            Eleve llavenseau = new Eleve("llavenseau", "Louis LAVENSEAU", 2022, false, 0);
            TypeProjet typeProjetInvente = new TypeProjet("typeProjetInvente", null, new List<int> { 1 }, new List<Matiere> { poo }, 2, null, null, new DateTime(2019, 8, 8), new DateTime(2019, 8, 12), new List<string> { "inventé" });
            AutreIntervenant bpesquet = new AutreIntervenant("bpesquet", "Baptise Pesquet", "professeur");
            Livrable rapport = new Livrable("rapport");
            AnneeScolaire cetteAnnee = new AnneeScolaire("2019-2020", 2019, 2020);

            Repertoire repertoire = new Repertoire(new List<Projet> { }, new List<TypeProjet> { typeProjetInvente }, new List<Matiere> { poo },
                new List<Personne> { llavenseau, bpesquet }, new List<AnneeScolaire> { cetteAnnee }, new List<Livrable> { rapport },
                new List<string> { }, new List<int> { }, new List<int> { });

            ModificationUtilisateur modificationUtilisateur = new ModificationUtilisateur(repertoire);

            modificationUtilisateur.CreerProjet();
            foreach (Projet projet in repertoire.RepertoireProjets)
            {
                Console.WriteLine("\n" + projet);
                Console.WriteLine("\n" + projet.Tuteurs.Count());
                foreach (AutreIntervenant tuteur in projet.Tuteurs)
                {
                    Console.WriteLine("\n \n ok voici la suite : \n " + tuteur);
                }
            }


                Console.ReadKey();
        }
    }
}
