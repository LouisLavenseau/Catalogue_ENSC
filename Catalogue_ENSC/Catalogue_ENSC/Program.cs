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


            AnneeScolaire cetteAnnee = new AnneeScolaire("2019-2020", 2019, 2020, program);
            AnneeScolaire annee19 = new AnneeScolaire("2018-2019", 2018, 2019, program);
            AnneeScolaire annee18 = new AnneeScolaire("2017-2018", 2017, 2018, program);
            AnneeScolaire annee17 = new AnneeScolaire("2016-2017", 2016, 2017, program);
            AnneeScolaire annee16 = new AnneeScolaire("2015-2016", 2015, 2016, program);
            AnneeScolaire anneeProchaine = new AnneeScolaire("2020-2021", 2020, 2021, program);

            Eleve iciattoni = new Eleve("iciattoni", "Ines", "Ciattoni", 2022, false, 0, "elle", program);
            Eleve cbrissaud = new Eleve("cbrissaud", "Cloe", "Brissaud", 2022, false, 0, "elle", program);
            Eleve llavenseau = new Eleve("llavenseau", "Louis", "Lavenseau", 2022, false, 0, "il", program);
            Eleve tholstein = new Eleve("tholstein", "Thomas", "Holstein", 2022, false, 0, "il", program);
            Eleve lthomasson = new Eleve("lthomasson", "Lucie", "Thomasson", 2022, false, 0, "elle", program);
            Eleve msille = new Eleve("msille", "Marie", "Sille", 2022, false, 0, "elle", program);
            Eleve jgadeau = new Eleve("jgadeau", "Juliette", "Gadeau", 2022, false, 0, "elle", program);
            Eleve motheguy = new Eleve("motheguy", "Marion", "Otheguy", 2022, false, 0, "elle", program);
            Eleve acorbeau = new Eleve("acorbeau", "Anne", "Corbeau", 2019, false, 0, "elle", program);
            Eleve tmerlin = new Eleve("tmerlin", "Tom", "Merlin", 2019, false, 0, "il", program);
            Eleve aanne = new Eleve("aanne", "Arthur", "Anne", 2019, false, 0, "elle", program);
            Eleve gmartin = new Eleve("gmartin", "Guillaume", "Martin", 2019, false, 0, "il", program);
            Eleve jguyet = new Eleve("jguyet", "Jean", "Guyet", 2019, false, 0, "il", program);
            Eleve ghute = new Eleve("ghute", "Guy", "Hute", 2019, false, 0, "il", program);
            Eleve tfaure = new Eleve("tfaure", "Thomas", "Faure", 2022, false, 0, "il", program);
            Eleve slaur = new Eleve("slaur", "Simon", "Laur", 2022, false, 0, "il", program);
            Eleve jbriand = new Eleve("jbriand", "Julien", "Briand", 2022, false, 0, "il", program);
            Eleve nchauvier = new Eleve("nchauvier", "Nathan", "Chauvier", 2022, false, 0, "il", program);
            Eleve mzuliani = new Eleve("mzuliani", "Mattheo", "Zuliani", 2022, false, 0, "il", program);
            Eleve tarrachquesne = new Eleve("tarrachquesne", "Thomas", "Arrachquesne", 2022, false, 0, "il", program);
            Eleve mdhellin = new Eleve("mzuliani", "Mattheo", "Zuliani", 2022, false, 0, "il", program);
            Eleve vleroy = new Eleve("vleroy", "Victor", "Leroy", 2022, false, 0, "il", program);
            Eleve tconstans = new Eleve("tconstans", "Thea", "Constans", 2022, false, 0, "il", program);
            Eleve tmorassin = new Eleve("tmorassin", "Thibault", "Morassin", 2022, false, 0, "il", program);

            Livrable rapport = new Livrable("rapport", program);
            Livrable produit = new Livrable("produit", program);
            Livrable codeSource = new Livrable("code source", program);
            Livrable soutenance = new Livrable("soutenance", program);

            AutreIntervenant aroc = new AutreIntervenant("aroc", "Aline", "Roc", "professeur", "elle", program);
            AutreIntervenant pfavier = new AutreIntervenant("pfavier", "Pierre-Alexandre", "Favier", "professeur", "il", program);
            AutreIntervenant bprebot = new AutreIntervenant("bprebot", "Baptiste", "Prebot", "professeur", "il", program);
            AutreIntervenant gkurtag = new AutreIntervenant("gkurtag", "Gyorgy", "Kurtag", "intervenant externe ", "il", program);
            AutreIntervenant saries = new AutreIntervenant("saries", "Serge", "Aries", "professeur", "il", program);
            AutreIntervenant bleblanc = new AutreIntervenant("bleblanc", "Benoit", "Leblanc", "professeur", "il", program);
            AutreIntervenant tletouzet = new AutreIntervenant("tletouzet", "Theodore", "Letouzet", "professeur", "il", program);
            AutreIntervenant bpesquet = new AutreIntervenant("bpesquet", "Baptiste", "Pesquet", "professeur", "il", program);
            AutreIntervenant eclermont = new AutreIntervenant("eclermont", "Edwige", "Clermont", "professeur", "elle", program);
            AutreIntervenant csemal = new AutreIntervenant("csemal", "Catherine", "Semal", "professeur", "elle", program);
            AutreIntervenant rgay = new AutreIntervenant("rgay", "Roland", "Gay", "intervenant externe", "il", program);

            Matiere commweb = new Matiere("communication_web", "CO6SFCWO", "sciences fondamentales", "C06SFON0", program);
            Matiere introInfo = new Matiere("introduction_a_l'informatique", "CO6SFPA0", "sciences fondamentales", "C06SFON0", program);
            Matiere transdi = new Matiere("projet_transdisciplinaire", "CO5PRTD0", "projets", "CO5PRST0", program);
            Matiere ia1 = new Matiere("intelligence_artificielle_1", "CO7SCIA0", "ingenierie cognitique", "C07SCOG0", program);
            Matiere infoIndivi = new Matiere("projet_informatique_indivuduel", "C0ESFPI0", "sciences fondamtentales", "CO8SFON0", program);
            Matiere systemeCogni = new Matiere("systemes_cognitifs", "C09SYCO0", "systemes cognitifs", "C09SYCO0", program);

            TypeProjet projetCommunicationWeb = new TypeProjet("projet communication web", null, "impose", new List<int> { 1 }, new List<Matiere> { commweb }, new List<AutreIntervenant> { aroc, eclermont, bprebot }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2000, 1, 25), new DateTime(2000, 3, 28), new List<string> { "site web", "programmation web" });
            TypeProjet projetIntroductionALaProgrammation = new TypeProjet("projet introduction a la programmation", "codage du jeu motus", "impose", new List<int> { 1 }, new List<Matiere> { introInfo }, new List<AutreIntervenant> { pfavier, eclermont, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2000, 11, 12), new DateTime(2000, 1, 16), new List<string> { "motus", "programmation" });
            TypeProjet projetIntelligenceArtificielle = new TypeProjet("projet intelligence artificielle", null, "impose", new List<int> { 2 }, new List<Matiere> { ia1 }, new List<AutreIntervenant> { bpesquet, bprebot }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2000, 10, 29), new DateTime(2000, 12, 22), new List<string> { "intelligence artificielle", "programmation" });
            TypeProjet projetInformatiqueindividuel = new TypeProjet("projet informatique individuel", null, "libre", new List<int> { 2 }, new List<Matiere> { infoIndivi }, new List<AutreIntervenant> { saries, bleblanc, tletouzet, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2000, 1, 9), new DateTime(2000, 1, 9), new List<string> { "programmation" });
            TypeProjet projetEtudeCerveau = new TypeProjet("projet etude cerveau", null, "impose", new List<int> { 2 }, new List<Matiere> { systemeCogni }, new List<AutreIntervenant> { pfavier }, new List<Livrable> { rapport }, new DateTime(2000, 10, 12), new DateTime(2000, 12, 16), new List<string> { "cerveau", "cognitif" });
            TypeProjet projetTransdi = new TypeProjet("projet transdisciplinaire", null, "liste", new List<int> { 1 }, new List<Matiere> { transdi }, null, new List<Livrable> { produit, soutenance }, new DateTime(2000, 9, 12), new DateTime(2000, 5, 25), null);


            Projet harryPottest = new Projet("Harrypotest", "création d'un site de quizz", "impose",  projetCommunicationWeb, new List<int> { 1 }, new List<Matiere> { commweb }, cetteAnnee, new List<Eleve> { cbrissaud, iciattoni }, null, new List<Eleve> { cbrissaud, iciattoni }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { aroc, eclermont, bprebot }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2020, 1, 25), new DateTime(2020, 3, 28), new List<string> { "site web", "programmation web","harry potter" });
            Projet motusLavenseauHolstein = new Projet("Motus Lavenseau et Holstein", "Codage du jeu Motus", "impose", projetIntroductionALaProgrammation, new List<int> { 1 }, new List<Matiere> { introInfo }, cetteAnnee, new List<Eleve> { llavenseau, tholstein }, null, new List<Eleve> { llavenseau, tholstein }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { pfavier, eclermont, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2019, 11, 12), new DateTime(2020, 1, 16), new List<string> { "programmation", "motus", "jeu" });
            Projet motusBrissaudFaure = new Projet("Motus Brissaud et Faure", "Codage du jeu Motus", "impose", projetIntroductionALaProgrammation, new List<int> { 1 }, new List<Matiere> { introInfo }, cetteAnnee, new List<Eleve> { cbrissaud, tfaure }, null, new List<Eleve> { cbrissaud, tfaure }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { pfavier, eclermont, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2019, 11, 12), new DateTime(2020, 1, 16), new List<string> { "programmation", "motus", "jeu" });
            Projet motusLaurBriand = new Projet("Motus Briand et Laur", "Codage du jeu Motus", "impose", projetIntroductionALaProgrammation, new List<int> { 1 }, new List<Matiere> { introInfo }, cetteAnnee, new List<Eleve> { jbriand, slaur }, null, new List<Eleve> { jbriand, slaur }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { pfavier, eclermont, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2019, 11, 12), new DateTime(2020, 1, 16), new List<string> { "programmation", "motus", "jeu" });
            Projet motusChauvierZuliani = new Projet("Motus Chauvier et Zuliani", "Codage du jeu Motus", "impose", projetIntroductionALaProgrammation, new List<int> { 1 }, new List<Matiere> { introInfo }, cetteAnnee, new List<Eleve> { nchauvier, mzuliani }, null, new List<Eleve> { nchauvier, mzuliani }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { pfavier, eclermont, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2019, 11, 12), new DateTime(2020, 1, 16), new List<string> { "programmation", "motus", "jeu" });
            Projet blackout = new Projet("Blackout", "évaluation UX et amélioration d'un serious game", "liste", projetTransdi, new List<int> { 1 }, new List<Matiere> { transdi }, cetteAnnee, new List<Eleve> { cbrissaud, lthomasson, msille, jgadeau, motheguy }, cbrissaud, new List<Eleve> { lthomasson, motheguy }, new List<Eleve> { msille, jgadeau }, new List<Eleve> { cbrissaud, msille, jgadeau }, gkurtag , new List<AutreIntervenant> { csemal }, new List<Livrable> { soutenance, produit }, new DateTime(2019, 9, 12), new DateTime(2020, 5, 25), new List<string> { "UX design", "serious game" });
            Projet galaxieux = new Projet("Galax'ieux", "développement d'un outil de reconnaissance de cartes/synthèse vocale pour malvoyants", "liste", projetTransdi, new List<int> { 1 }, new List<Matiere> { transdi }, cetteAnnee, new List<Eleve> { llavenseau, tconstans, tmorassin, vleroy, mdhellin, tconstans, tarrachquesne }, tconstans, new List<Eleve> { llavenseau, vleroy, mdhellin, tarrachquesne }, null, new List<Eleve> { tconstans, tmorassin }, rgay, new List<AutreIntervenant> { csemal }, new List<Livrable> { soutenance, produit }, new DateTime(2019, 9, 12), new DateTime(2020, 5, 25), new List<string> { "UX design", "serious game" });
            Projet taquin = new Projet("Taquin", "développement d'un jeu de taquin", "impose", projetIntelligenceArtificielle, new List<int> { 2 }, new List<Matiere> { ia1 }, annee18, new List<Eleve> { acorbeau, tmerlin }, null, new List<Eleve> { acorbeau, tmerlin }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { bpesquet, bprebot }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2017, 10, 29), new DateTime(2018, 12, 22), new List<string> { "programmation", "IA"});
            Projet rainbow = new Projet("Rainbow", "développement d'un jeu de plateau", "libre", projetInformatiqueindividuel, new List<int> { 2 }, new List<Matiere> { infoIndivi }, annee18, new List<Eleve> { aanne, gmartin }, null, new List<Eleve> { aanne, gmartin }, new List<Eleve> { }, new List<Eleve> { }, null, new List<AutreIntervenant> { saries, bleblanc, tletouzet, bpesquet }, new List<Livrable> { rapport, produit, codeSource }, new DateTime(2018, 1, 9), new DateTime(2018, 4, 15), new List<string> { "programmation", "individuel" });
            Projet cerveauGuyHute = new Projet("Etude du cerveau Guyet et Hute", "Etude du cerveau", "impose", projetEtudeCerveau, new List<int> { 3}, new List<Matiere> { systemeCogni }, annee19, new List<Eleve> { jguyet, ghute }, null, new List<Eleve> { }, new List<Eleve> { }, new List<Eleve> { jguyet, ghute }, null, new List<AutreIntervenant> { pfavier }, new List<Livrable> { rapport}, new DateTime(2018, 10, 12), new DateTime(2018, 12, 16), new List<string> { "cognitif", "cerveau" });
            

            Repertoire repertoire =
            new Repertoire(new List<Projet> {harryPottest, motusLavenseauHolstein, motusBrissaudFaure, motusChauvierZuliani, motusLaurBriand, blackout, galaxieux, taquin, rainbow, cerveauGuyHute },
            new List<TypeProjet> {projetCommunicationWeb, projetIntroductionALaProgrammation, projetIntelligenceArtificielle, projetInformatiqueindividuel, projetEtudeCerveau, projetTransdi },
            new List<Matiere> { commweb, introInfo, transdi, ia1, infoIndivi, systemeCogni },
            new List<Eleve> { llavenseau, cbrissaud, iciattoni, tholstein, lthomasson, msille, jgadeau, motheguy, acorbeau, tmerlin, aanne, gmartin, jguyet, ghute, tfaure, slaur, jbriand, nchauvier, mzuliani, tarrachquesne, mdhellin, vleroy, tconstans, tmorassin },
            new List<AutreIntervenant> { bpesquet, eclermont, csemal, aroc, pfavier, bprebot, gkurtag, saries, bleblanc, tletouzet, rgay},
            new List<AnneeScolaire> { annee16, annee17, annee18, annee19, cetteAnnee, anneeProchaine },
            new List<Livrable> { soutenance, produit, rapport, codeSource },
            new List<string> {"site web", "programmation", "motus", "intelligence artificielle", "cerveau", "cognitif", "programmation web", "harry potter", "motus", "jeu", "UX design", "serious game", "IA", "individuel" },
            new List<int> { 2015,2016,2017,2018,2019, 2020, 2021, 2022 },
            new List<int> {1, 2, 3 },
            new List<string> { "libre", "liste", "impose" });

            Sauvegarde sauvegarde = new Sauvegarde(repertoire, program);
            ModificationUtilisateur modificationUtilisateur = new ModificationUtilisateur(repertoire, program, sauvegarde);
            RechercheUtilisateur rechercheUtilisateur = new RechercheUtilisateur(repertoire);


            /*  sauvegarde.RecupFichierTxtAnneesScolaires();
               sauvegarde.RecupFichierTxtLivrables();
               sauvegarde.RecupFichierTxtMatieres();
                sauvegarde.RecupFichierTxtAutresIntervenants();
              sauvegarde.RecupFichierTxtEleves();
                sauvegarde.RecupFichierTxtTypesProjets();
               sauvegarde.RecupFichierTxtProjets();



               foreach (Projet m in repertoire.RepertoireProjets)
               {
                   Console.WriteLine("yo" + m);
               }

               Console.ReadLine();*/

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


                    Console.ReadKey();
                }

                if (fonctionnaliteVoulue == "3")
                {
                    Console.WriteLine("Quel est le type de l'élément que vous voulez modifier ? Ecrivez projet, type de projet, élève, professeur, externe, \n année scolaire, matière, ou livrable");
                    string typeElementAModifier = Console.ReadLine();
                    Console.Clear();

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

                    }






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

                    }
                    if (typeElementASupprimer == "élève")
                    {
                        Eleve eleveTest = (Eleve)Convert.ChangeType(repertoire["eleve", nomElementASupprimer], typeof(Eleve));
                        eleveTest.Supprimer();
                    }
                    if (typeElementASupprimer == "professeur" || typeElementASupprimer == "intervenant externe")
                    {
                        AutreIntervenant autreIntervenantTest = (AutreIntervenant)Convert.ChangeType(repertoire["autreIntervenant", nomElementASupprimer], typeof(AutreIntervenant));
                        autreIntervenantTest.Supprimer();
                    }
                    if (typeElementASupprimer == "année scolaire")
                    {
                        AnneeScolaire anneeScolaireTest = (AnneeScolaire)Convert.ChangeType(repertoire["anneeScolaire", nomElementASupprimer], typeof(AnneeScolaire));
                        anneeScolaireTest.Supprimer();
                    }
                    if (typeElementASupprimer == "livrable")
                    {
                        Livrable livrableTest = (Livrable)Convert.ChangeType(repertoire["livrable", nomElementASupprimer], typeof(Livrable));
                        livrableTest.Supprimer();
                    }
                    if (typeElementASupprimer == "matiere")
                    {
                        Matiere matiereTest = (Matiere)Convert.ChangeType(repertoire["matiere", nomElementASupprimer], typeof(Matiere));
                        matiereTest.Supprimer();
                    }
                    Console.Clear();
                    Console.WriteLine("La suppression a été réalisée avec succès !");
                    Console.ReadLine();

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
                while (!dernierCaracNonEspaceAtteint & cpt < longueurChamp) //On parcourt le champ du premier caractère qui n'est pas un espace jusqu'au dernier ou jusqu'à la fin du champ
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
