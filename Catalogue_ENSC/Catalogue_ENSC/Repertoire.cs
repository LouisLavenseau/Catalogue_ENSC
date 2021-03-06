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
        public List<Eleve> RepertoireEleves { get; private set; }
        public List<AutreIntervenant> RepertoireAutresIntervenants { get; set; }
        public List<AnneeScolaire> RepertoireAnneesScolaires { get; set; }
        public List<Livrable> RepertoireLivrables { get; set; }
        public List<string> RepertoireMotsClefs { get; set; }
        public List<int> RepertoirePromos { get; set; }
        public List<int> RepertoireAnneesEtudes { get; set; }
        public List<string> RepertoireLibertesDeSujet { get; private set; }
 
        public Repertoire(List<Projet> repertoireProjets,List<TypeProjet> repertoireTypesProjets,List<Matiere> repertoireMatieres, List<Eleve> repertoireEleves,
                List<AutreIntervenant> repertoireAutresIntervenants,List<AnneeScolaire> repertoireAnneesScolaires, List<Livrable> repertoireLivrables,
                List<string> repertoireMotsClefs,List<int> repertoirePromos,List<int> repertoireAnneesEtudes, List<string> repertoireLibertesDeSujet)
        {
            RepertoireProjets = repertoireProjets;
            RepertoireTypesProjets = repertoireTypesProjets;
            RepertoireMatieres = repertoireMatieres;
            RepertoireEleves = repertoireEleves;
            RepertoireAutresIntervenants = repertoireAutresIntervenants;
            RepertoireAnneesScolaires = repertoireAnneesScolaires;
            RepertoireLivrables = repertoireLivrables;
            RepertoireMotsClefs = repertoireMotsClefs;
            RepertoirePromos = repertoirePromos;
            RepertoireAnneesEtudes = repertoireAnneesEtudes;
            RepertoireLibertesDeSujet = repertoireLibertesDeSujet;
        }

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

                else if (repertoire == "eleve")
                {
                    foreach (Eleve eleve in RepertoireEleves)
                    {
                        if (eleve.Identifiant == nom)
                            return eleve;
                        if (eleve.Prenom + " " + eleve.Nom == nom)
                            return eleve;
                    }
                    return null;
                }
                else if (repertoire == "autreIntervenant")
                {
                    foreach (AutreIntervenant autreIntervenant in RepertoireAutresIntervenants)
                    {
                        if (autreIntervenant.Prenom + " " + autreIntervenant.Nom == nom)
                            return autreIntervenant;
                        if (autreIntervenant.Identifiant == nom)
                            return autreIntervenant;
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
