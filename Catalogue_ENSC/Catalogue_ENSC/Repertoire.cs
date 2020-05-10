﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_ENSC
{
    class Repertoire
    {
        public List<Projet> RepertoireProjets { get; set; }
        public List<TypeProjet> RepertoireTypesProjets { get; set; }
        public List<Matiere> RepertoireMatieres { get; set; }
        public List<Personne> RepertoireIntervenants { get; set; }
        public List<AnneeScolaire> RepertoireAnneesScolaires { get; set; }
        public List<Livrable> RepertoireLivrables { get; set; }
        public List<string> RepertoireMotsClefs { get; set; }
        public List<int> RepertoirePromos { get; set; }
        public List<int> RepertoireAnneesEtudes { get; set; }

        public Object this[string repertoire, string nom]
        {
            get
            {
                if (repertoire == "typeProjet")
                {
                    foreach (TypeProjet typeProjet in RepertoireTypesProjets)
                    {
                        if (typeProjet.Nom == nom)
                        {
                            return typeProjet;
                        }
                    }
                    return null;
                }

                else if (repertoire == "projet")
                {
                    foreach (Projet projet in RepertoireProjets)
                    {
                        if (projet.Nom == nom)
                            return projet;
                    }
                    return null;
                }

                else if (repertoire == "intervenant")
                {
                    foreach (AutreIntervenant intervenant in RepertoireIntervenants)
                    {
                        if (intervenant.Nom == nom)
                            return intervenant;
                    }
                    return null;
                }             

                else if (repertoire == "matiere")
                {
                    foreach (Matiere matiere in RepertoireMatieres)
                    {
                        if (matiere.Nom == nom)
                            return matiere;
                        else if (matiere.Code == nom)
                            return matiere;
                    }
                    return null;
                }

                else if (repertoire == "anneeScolaire")
                {
                    foreach (AnneeScolaire anneeScolaire in RepertoireAnneesScolaires)
                    {
                        if (anneeScolaire.Nom == nom)
                            return anneeScolaire;
                    }
                    return null;
                }

                else if (repertoire == "livrable")
                {
                    foreach (Livrable livrable in RepertoireLivrables)
                    {
                        if (livrable.Nom == nom)
                            return livrable;
                    }
                    return null;
                }

                else
                {
                    return null;
                }
            }
        }
    }
}
