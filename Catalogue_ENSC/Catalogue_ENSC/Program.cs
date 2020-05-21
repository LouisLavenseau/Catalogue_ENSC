using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalogue_ENSC
{
    class Program
    {

        static void Main(string[] args)
        {
            Program program = new Catalogue_ENSC.Program();
            Matiere poo = new Matiere("poo", "codeMatiere", "Sciences fondamentales", "codeUe", program);
            Matiere facteurHumain = new Matiere("facteurHumain", "Sciences fondamentales", "codeMatiere", "codeUe", program);
            Matiere stats = new Matiere("stats", "Sciences fondamentales", "codeMatiere", "codeUe", program);
            Eleve llavenseau = new Eleve("llavenseau", "Louis", "Lavenseau", 2022, false, 0, "il", program);
            AutreIntervenant bpesquet = new AutreIntervenant("bpesquet", "Baptiste", "Pesquet", "professeur", "il", program);
            AutreIntervenant eclermont = new AutreIntervenant("eclermont", "Edwige", "Clermont", "professeur", "elle", program);
            Livrable rapport = new Livrable("rapport", program);
            TypeProjet tp1 = new TypeProjet("tp1", "sujet 1", "impose", new List<int> { 1, 2 }, new List<Matiere> { poo }, new List<AutreIntervenant> { bpesquet }, new List<Livrable> { rapport }, new DateTime(6, 6, 6), new DateTime(6, 6, 6), new List<string> { "inventé" });
            TypeProjet tp2 = new TypeProjet("tp2", "sujet 2", "libre", new List<int> { 1, 2 }, new List<Matiere> { poo }, new List<AutreIntervenant> { eclermont }, new List<Livrable> { rapport }, new DateTime(6, 6, 6), new DateTime(6, 6, 6), new List<string> { "inventé" });
            AnneeScolaire cetteAnnee = new AnneeScolaire("2019-2020", 2019, 2020, program);
            AnneeScolaire anneeProchaine = new AnneeScolaire("2020-2021", 2020, 2021, program);
            Repertoire repertoire = new Repertoire(new List<Projet> { }, new List<TypeProjet> { tp1, tp2 }, new List<Matiere> { poo, facteurHumain, stats },
                new List<Eleve> { llavenseau }, new List<AutreIntervenant> { bpesquet, eclermont }, new List<AnneeScolaire> { cetteAnnee, anneeProchaine }, new List<Livrable> { rapport },
                new List<string> { "blabla1", "blabla2", "blabla3" }, new List<int> { 2020, 2021, 2022 }, new List<int> { 3, 2, 1 }, new List<string> { "libre", "liste", "impose" });
            Sauvegarde sauvegarde = new Sauvegarde(repertoire, program);
            ModificationUtilisateur modificationUtilisateur = new ModificationUtilisateur(repertoire, program, sauvegarde);
            RechercheUtilisateur rechercheUtilisateur = new RechercheUtilisateur(repertoire);

            /*sauvegarde.RecupFichierTxtProjet();
            foreach (Projet projet in repertoire.RepertoireProjets)
            Console.WriteLine(projet);
            Console.ReadLine();*/

            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier source 
            /* System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
             StreamReader monStreamReader = new StreamReader("test.txt", encoding);
             int nbMots = 0;
             string mot ="";

             while (mot != null)
             {
                 mot = monStreamReader.ReadLine();
                 if (nbMots == 0)
                     Console.WriteLine(mot);
                 /* if (nbMots == 2)
                      Console.WriteLine(mot);
                 nbMots++;

             }
             // Fermeture du StreamReader (attention très important) 
             monStreamReader.Close();*/

            /* llavenseau.ModifierAttribut("nom","Rotto");
             foreach (Eleve eleve in repertoire.RepertoireEleves)
             {
                 Console.WriteLine(eleve.Nom + "\n" + eleve.Identifiant);
             }

             Console.ReadLine();
             */

            //sauvegarde.RecupFichierTxtAnneesScolaires();
            //sauvegarde.RecupFichierTxtLivrables();
            // sauvegarde.RecupFichierTxtMatieres();
            // sauvegarde.RecupFichierTxtAutresIntervenants();
            //sauvegarde.RecupFichierTxtEleves();
            // sauvegarde.RecupFichierTxtTypesProjets();
            sauvegarde.RecupFichierTxtProjets();

            /* foreach (AnneeScolaire anneeScolaire in repertoire.RepertoireAnneesScolaires)
             {
                 Console.WriteLine(anneeScolaire.Nom);
                 Console.WriteLine(anneeScolaire.AnneeDebut);
                 Console.WriteLine(anneeScolaire.AnneeFin);

             }
             foreach (Livrable livrable in repertoire.RepertoireLivrables)
             {
                 Console.WriteLine(livrable.Nom);
             }*/
            /* foreach (Matiere m in repertoire.RepertoireMatieres)
             {
                 Console.WriteLine(m.Nom);
                 Console.WriteLine(m.Code);
                 Console.WriteLine(m.Ue);
                 Console.WriteLine(m.CodeUe);

             }*/

            /* foreach (Eleve m in repertoire.RepertoireEleves)
             {
                 Console.WriteLine(m.Identifiant);
                 Console.WriteLine(m.Prenom);
                 Console.WriteLine(m.Nom);
                 Console.WriteLine(m.ARedouble);
                 Console.WriteLine(m.AnneeEtudeRedoublement);
                 Console.WriteLine(m.Pronom);

             }*/

            /*  foreach (AutreIntervenant m in repertoire.RepertoireAutresIntervenants)
              {
                  Console.WriteLine(m.Identifiant);
                  Console.WriteLine(m.Prenom);
                  Console.WriteLine(m.Nom);
                  Console.WriteLine(m.Statut);
                  Console.WriteLine(m.Pronom);

              }*/

            /*  foreach (TypeProjet m in repertoire.RepertoireTypesProjets)
              {
                  Console.WriteLine(m.Nom);
                  Console.WriteLine(m.Sujet);
                  Console.WriteLine(m.SujetLibre);
                  foreach (int e in m.AnneesEtudes)
                  Console.Write(e + "/");
                  foreach (Matiere e in m.Matieres)
                      Console.Write(e + "/");
                  foreach (AutreIntervenant a in m.Tuteurs)
                      Console.Write(a + "/");
                  foreach (Livrable i in m.Livrables)
                      Console.Write(i + "/");
                  Console.WriteLine(m.DateDebut.ToLongDateString());
                  Console.WriteLine(m.DateFin.ToLongDateString());
                  foreach (string e in m.MotsClefs)
                      Console.Write(e + "/");

              }*/

            foreach (Projet m in repertoire.RepertoireProjets)
            {
                Console.WriteLine(m);
            }




            Console.ReadLine();

            string fonctionnaliteVoulue = null;
            while (fonctionnaliteVoulue != "")
            {
                Console.Clear();
                Console.WriteLine("Voulez-vous consulter le catalogue des projets de l'ENSC (écrivez 1), ajouter un élément au catalogue (écrivez 2) ?, \n "
                    + "modifier un élément du catalogue (écrivez 3) ? Supprimer un élément du catalogue (écrivez 4) ? Ou quitter \n l'application ? (tapez juste entrée)");
                fonctionnaliteVoulue = Console.ReadLine();
                Console.Clear();

                if (fonctionnaliteVoulue == "1")
                {
                    rechercheUtilisateur.InitialiserConsultation();
                }

                if (fonctionnaliteVoulue == "2")
                {
                    modificationUtilisateur.InitialiserCreation();

                    /*foreach (TypeProjet typeProjet in repertoire.RepertoireTypesProjets)
                    {
                        Console.WriteLine("\n" + typeProjet);
                        Console.WriteLine("\n" + typeProjet.Etudiants.Count());
                        foreach (Eleve eleve in typeProjet.Etudiants)
                        {
                            Console.WriteLine(eleve);
                        }
                    }*/

                    //liste de if (1 par méthode) à faire
                    Console.ReadKey();
                }

                if (fonctionnaliteVoulue == "3")
                {
                    Console.WriteLine("Quel est le type de l'élément que vous voulez modifier ? Ecrivez projet, type de projet, élève, professeur, externe, \n année scolaire, matière, ou livrable");
                    string typeElementAModifier = Console.ReadLine();
                    //liste de if (1 par méthode) à faire
                    if (typeElementAModifier == "élève")
                    {
                        Console.WriteLine("Les données de quel élève voulez-vous modifier ?");
                        string stringEleve = program.EnleverLesEspaces(Console.ReadLine());
                        Console.Clear();
                        Eleve eleve = (Eleve)Convert.ChangeType(repertoire["eleve", stringEleve], typeof(Eleve));
                        Console.WriteLine("Quelle donnée voulez-vous modifier ? Ecrivez nom, prénom, promo, redoublement, pronom");
                        string attribut = program.EnleverLesEspaces(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Et quelle nouvelle valeur voulez-vous rentrer ?");
                        string valeur = program.EnleverLesEspaces(Console.ReadLine());
                        Console.Clear();
                        eleve.ModifierAttribut(attribut, valeur);
                        Console.WriteLine(eleve.Prenom + "\n" + eleve.Nom + "\n" + eleve.Identifiant + "\n" + eleve.Pronom + "\n" + eleve.Promo + "\n" +
                            eleve.ARedouble + "\n" + eleve.AnneeEtudeRedoublement);
                    }



                    /*        public string Nom { get; private set; }
                                public int AnneeDebut { get; private set; }
                                public int AnneeFin { get; private set; }*/


                    Console.ReadKey();
                }

                if (fonctionnaliteVoulue == "4")
                {
                    Console.WriteLine("Quel est le type de l'élément que vous voulez supprimer ? Ecrivez projet, type de projet, élève, professeur, externe, \n année d'étude, matière, ou livrable");
                    string typeElementASupprimer = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Quel est le nom de l'élément que vous voulez supprimer ?");
                    string nomElementASupprimer = Console.ReadLine();
                    if (typeElementASupprimer == "projet")
                    {
                        Projet projetTest = (Projet)Convert.ChangeType(repertoire["projet", nomElementASupprimer], typeof(Projet));
                        projetTest.Supprimer();
                    }
                    if (typeElementASupprimer == "projet")
                    {
                        Projet projetTest = (Projet)Convert.ChangeType(repertoire["projet", nomElementASupprimer], typeof(Projet));
                        projetTest.Supprimer();
                        Console.ReadKey();
                    }
                    if (typeElementASupprimer == "élève")
                    {
                        Eleve eleveTest = (Eleve)Convert.ChangeType(repertoire["eleve", nomElementASupprimer], typeof(Eleve));
                        eleveTest.Supprimer();
                        Console.ReadKey();
                    }
                    if (typeElementASupprimer == "professeur" || typeElementASupprimer == "intervenant externe")
                    {
                        AutreIntervenant autreIntervenantTest = (AutreIntervenant)Convert.ChangeType(repertoire["autreIntervenant", nomElementASupprimer], typeof(AutreIntervenant));
                        autreIntervenantTest.Supprimer();
                        Console.ReadKey();
                    }
                    if (typeElementASupprimer == "année scolaire")
                    {
                        AnneeScolaire anneeScolaireTest = (AnneeScolaire)Convert.ChangeType(repertoire["anneeScolaire", nomElementASupprimer], typeof(AnneeScolaire));
                        anneeScolaireTest.Supprimer();
                        Console.ReadKey();
                    }
                    if (typeElementASupprimer == "livrable")
                    {
                        Livrable livrableTest = (Livrable)Convert.ChangeType(repertoire["livrable", nomElementASupprimer], typeof(Livrable));
                        livrableTest.Supprimer();
                        Console.ReadKey();
                    }
                    if (typeElementASupprimer == "matiere")
                    {
                        Matiere matiereTest = (Matiere)Convert.ChangeType(repertoire["matiere", nomElementASupprimer], typeof(Matiere));
                        matiereTest.Supprimer();
                        Console.ReadKey();
                    }

                }


            }
        }

        public List<string> SeparerChaineDeCaracteres(string chaineDeCaracteres)
        {
            string element = "";
            char virgule = ',';
            char espace = ' ';
            List<string> elementsSepares = new List<string> { };
            foreach (char caractere in chaineDeCaracteres)
            {
                if (caractere == virgule)
                {
                    elementsSepares.Add(element);
                    element = "";
                }
                else
                {
                    if (caractere != espace)
                    {
                        element += caractere;
                    }
                }
            }
            elementsSepares.Add(element);
            return elementsSepares;
        }


        public string EnleverLesEspaces(string champ) //Enlever les espaces en début de champ et en fin de champ
        {
            string champSansEspaces = "";
            bool premierCaracNonEspaceAtteint = false;
            bool dernierCaracNonEspaceAtteint = false;
            int cpt = 0;
            int longueurChamp = champ.Length;
            if (longueurChamp > 0)
            {
                while (!premierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ jusqu'à atteindre le premier caractère qui n'est pas un espace ou jusqu'à atteindre la fin du champ
                {
                    if (champ[cpt] != ' ')
                        premierCaracNonEspaceAtteint = true;
                    cpt++;
                }
                cpt--;
                while (!dernierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ du premier caractèrequi n'est pas un espace jusqu'au dernier ou jusqu'à la fin du champ
                {
                    if (champ[cpt] != ' ')
                        champSansEspaces += champ[cpt];
                    else //si le caractère est un espace, on vérifie si jusqu'à la fin du champ tous les autres caractères sont des espaces aussi
                    {
                        bool autreCaracterePresentApres = false;
                        for (int i = cpt; i < longueurChamp; i++)
                        {
                            if (champ[i] != ' ')
                                autreCaracterePresentApres = true;
                        }
                        if (!autreCaracterePresentApres)
                            dernierCaracNonEspaceAtteint = true;
                        else
                            champSansEspaces += champ[cpt];
                    }
                    cpt++;
                }
                return champSansEspaces;
            }
            return champSansEspaces;
        }
        public bool VerifierChampRempli(string champ) //Vérfier que le champ contient au moins un caractère autre qu'un espace
        {
            string champNettoye = EnleverLesEspaces(champ);
            if (champNettoye == "")
            {
                return false;
            }
            return true;
        }

    }
}
