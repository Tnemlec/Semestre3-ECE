using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex 1 à 9

            /*Voiture V1 = new Voiture("Mercedes", "C220", false, 2000, "rouge");//Ex2
            //Ex3: Non ce code ne fonctionne pas car il manque un get/set et lui meme commencera par une majuscule 
            //Ex4: Le premier code est en effet valide cependant il manque la partiue set afin de pouvoir manipuler les attributs(leur donner une valeur)*/

            //Ex 10
            /*Produit BriqueDeLait = new Produit("1", "BriqueDeLait", 2.00, 2);
            Produit Cereale = new Produit("2", "Cereal", 2.00, 2);
            Produit[] tab = new Produit[1];
            tab[0] = BriqueDeLait;
            Magasins Carrefour = new Magasins("Carrefour");
            Carrefour.AfficherProduits();
            Console.ReadKey();
            Carrefour.AjouterProduits(Cereale);
            Carrefour.AfficherProduits();
            Console.ReadKey();*/


            Joueurs joueur1 = new Joueurs("Clement", false, false);
            Joueurs joueur2 = new Joueurs("RobiLOrdi", true, true);

            Partie partie = new Partie(joueur1, joueur2);
            partie.StartPartie();
            Console.ReadKey();
            

        }
    }

    class Voiture //Ex1
    {
        private string marque;
        private string modele;
        private int anneeCirculation;
        private bool berline;
        private string couleur;
        static int nbVoit = 0;
        private int numVoit = 0;

        public Voiture(string marque,string modele,bool berline,int anneeCirculation,string couleur)//Ex2
        {
            this.marque = marque;
            this.modele = modele;
            this.berline = berline;
            this.anneeCirculation = anneeCirculation;
            this.couleur = couleur;
            nbVoit++;
            numVoit = nbVoit;
        }

        public Voiture(string marque, string modele, bool berline, int anneeCirculation)
        {
            this.marque = marque;
            this.modele = modele;
            this.berline = berline;
            this.anneeCirculation = anneeCirculation;
            couleur = "inconnu";
            numVoit = nbVoit;
        }

        public string Marque
        {
            get
            {
                return marque;
            }
        }

        public string Modele
        {
            get
            {
                return modele;
            }
        }

        public bool Berline
        {
            get
            {
                return berline;
            }
        }

        public int AnneeCirculation
        {
            get
            {
                return anneeCirculation;
            }
        }

        public string Couleur
        {
            get
            {
                return couleur;
            }
        }

        public int NbrAnnee()//Ex4
        {
            int nombreAnnee = 2018 - anneeCirculation;
            return nombreAnnee;
        }

        public int RetournerAgeEn(int anneeRef)
        {
            int nombre = 2018 - anneeRef;
            return nombre;
        }

        public bool PlusVieuxQue(int ageRef)
        {
            bool resultat = false;
            if(anneeCirculation < ageRef)
            {
                resultat = true;
            }
            return resultat;
        }

        public bool PlusVieuxQueVoit(Voiture v1)
        {
            bool viellesse = false;
            if (anneeCirculation > v1.AnneeCirculation) viellesse = true;
            return viellesse;
        }

        public string Message()
        {
            string message = "Voiture " + numVoit + " : " + marque + " " + modele + " mise en cirulation en " + anneeCirculation + " de couleur " + couleur + ".";
            return message;
        }
    }

    class Produit
    {
        private string reference;
        private string libelle;
        private double prixHT;
        private int quantite;
        static int nbProd;
        private int numProd;

        

        public Produit(string reference, string libelle, double prixHT, int quantite)
        {
            this.reference = reference;
            this.libelle = libelle;
            this.prixHT = prixHT;
            this.quantite = quantite;
            nbProd++;
            numProd = nbProd;

        }

        public int Quantite
        {
            get { return quantite; }
        }

        public int NumProd
        {
            get { return numProd; }
        }

        public string Reference
        {
            get { return reference; }
        }

        public string Libelle
        {
            get { return libelle; }
        }

        public double PrixHT
        {
            get { return prixHT; }
        }

        public void AugmenterStock()
        {
            Console.WriteLine("Restockage... \n Combien d'éléments voulez-vous ajouter ?: \n");
            int.TryParse(Console.ReadLine(), out int ajout);
            quantite += ajout;
        }

        public void Vente(int nbProdVente)
        {
            if (quantite > nbProdVente) quantite -= nbProdVente;
            else Console.WriteLine("Pas assez de produit en stock");
        }

        public double PrixTTC()
        {
            double prixTTC = prixHT + (prixHT * 0.055);
            return prixTTC;
        }

        public void DecrireProd()
        {
            Console.WriteLine("Produit " + numProd + " : \n" + libelle + "\n " + "Prix hors taxes : " + prixHT + "\n Prix TTC : " + PrixTTC());
        }

        public void ComparaisonDeuxProds(Produit produit)
        {
            if (reference != produit.Reference)
            {
                Console.WriteLine("Comparaison du Produit " + numProd + " et du Produit " + produit.NumProd + "\n");
                Console.WriteLine(libelle + " | " + produit.Libelle);
                Console.WriteLine("PrixHT:" + prixHT + " | " + produit.PrixHT);
                Console.WriteLine("PrixTTC: " + PrixTTC() + " | " + produit.PrixTTC());
            }
        }
    }//Ex10

    class Magasins
    {
        private string nomMagasin;
        Produit[] produits;
        List<Produit> listeProduit = new List<Produit>();
        private int nbProd;

        public Magasins(string nomMagasin)
        {
            this.nomMagasin = nomMagasin;
            nbProd = 0;
        }

        public void AjouterProduits(Produit produitAdd)
        {
            if(nbProd > 0)
            {
                nbProd++;
                Produit[] tmp = new Produit[nbProd];
                int i = 0;
                for(i = 0;i < produits.Length; i++)
                {
                    tmp[i] = produits[i];
                }
                tmp[i] = produitAdd;
                produits = tmp;
            }
            else
            {
                nbProd++;
                produits[0] = produitAdd;
            }

        }

        public void AjouterProduitBis(Produit produitAdd)
        {
            listeProduit.Add(produitAdd);
        }

        private bool RechercheProduit(Produit produit)
        {
            bool res = false;
            for(int i = 0; i < produits.Length; i++)
            {
                if(produits[i] == produit)
                {
                    res = true;
                }
            }
            return res;
        }

        public void SupprProduits(Produit produitSuppr)
        {
            if (RechercheProduit(produitSuppr))
            {
                Produit[] tmp = new Produit[produits.Length - 1];
                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    if(produits[i] != produitSuppr)
                    {
                        tmp[i] = produits[i];
                    }
                
                }
                produits = tmp;
            }

        }

        public void SupprProduitsBis(Produit produitSuppr)
        {
            listeProduit.Remove(produitSuppr);
        }

        public void AfficherProduits()
        {
            for(int i = 0; i < produits.Length;i++)
            {
                Console.WriteLine(produits[i].Libelle);
            }
        }

        public void AfficherProduitBis()
        {
            foreach(Produit c in listeProduit)
            {
                Console.WriteLine(c.ToString());//Here create a toString() method
            }
        }

    }//Ex10

    class Joueurs
    {
        //Attributs

        private string nom;
        private bool role;//Si true : Guesseur, Si false : Setteur
        private bool homme;
        private int score;
        //Constructeurs

        public Joueurs(string nom, bool role, bool homme)
        {
            this.nom = nom;
            this.role = role;
            this.homme = homme;
        }

        //Propriétés

        public string Nom
        {
            get { return nom; }
        }

        public bool Role
        {
            get { return role; }
            set { role = value; }
        }

        public bool Homme
        {
            get { return homme; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        //Methodes

        public string PropositionCode()
        {
            string code = "";
            if(homme == true)
            {
                do
                {
                    Console.WriteLine(nom + " : Saisir un code entier :");
                    code = Console.ReadLine();
                } while (code.Length != 4);

            }
            else
            {
                Random random = new Random();
                for(int i = 0; i < 4; i++)
                {
                    code += random.Next(0, 10).ToString();
                }
                
           
            }
            return code;
        }


    }//Ex11

    class Manche
    {
        //Attributs
        private string code;
        private int nbTour = 0;
        private static int mancheActu = 0;
        private int nbManche;
        private Joueurs joueur1;
        private Joueurs joueur2;


        //Constructeurs
        public Manche(string code, Joueurs joueur1, Joueurs joueur2)
        {
            this.code = code;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            mancheActu++;
            nbManche = mancheActu;
        }

        //Propriété

        //Methode
        private bool[] TabVerif(string proposition)
        {
            bool[] tab = new bool[4];
            for(int i = 0; i < 4; i++)
            {
                if(proposition[i] == code[i])
                {
                    tab[i] = true;
                }
            }
            return tab;
        }


        public void MainCoreHomme(Joueurs joueur1)
        {
            bool[] tab = new bool[4];
            string proposition;
            bool finDeManche = false;
            
            
            if (joueur1.Role == true && joueur1.Homme == true)
            {
                do
                {
                    nbTour++;
                    do
                    {
                        Console.WriteLine(joueur1.Nom + " : Proposition entre 0000 et 9999");
                        proposition = Console.ReadLine();
                        try
                        {
                            int nombre = int.Parse(proposition);
                        }
                        catch
                        {
                            proposition = "               ";
                        }
                    } while (proposition.Length != 4);
                    tab = TabVerif(proposition);
                    int nbBon = 0;
                    for(int i = 0; i < 4; i++)
                    {
                        if (tab[i])
                        {
                            nbBon++;
                        }
                    }
                    if(nbBon == 4)
                    {
                        Console.WriteLine("Bravo vous avez trouvé que le code était : " + code + " en " + nbTour + "tours ");
                        finDeManche = true;
                        joueur1.Score += nbTour;
                    }
                    else
                    {
                        Console.WriteLine("Il y a " + nbBon + " nombre bien placé et " + (4 - nbBon) + " mal placé");

                    }

                } while (finDeManche == false);

            }
        }

        public void MainCoreMachine(Joueurs joueur1)
        {
            string proposition = joueur1.PropositionCode();
            bool[] verif = TabVerif(proposition);
            int nbBon = 0;
            bool finDeManche = false;
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    if (verif[i])
                    {
                        nbBon++;
                    }
                }
                if (nbBon == 4)
                {
                    Console.WriteLine("La machine a trouvé que le code était : " + code + " en " + nbTour + "tours ");
                    finDeManche = true;
                    joueur1.Score += nbTour;
                }
                else
                {
                    Console.WriteLine("Il y a " + nbBon + " nombre bien placé et " + (4 - nbBon) + " mal placé");

                }
                nbTour++;
            } while (finDeManche == true);


        }
    }//Ex11

    class Partie
    {
        //Attributs
        private Joueurs joueur1;
        private Joueurs joueur2;
        private Manche[] manche;
        private int nbManche = -1;

        //Constructeur
        public Partie(Joueurs joueur1, Joueurs joueur2)
        {
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
        }
        //Propriété

        //Methode
       

        public void StartPartie()
        {
            do
            {
                StartManche();
                nbManche++;
                QuelManche();                
                EchangerRole();
                StartManche();
                nbManche++;
                QuelManche();
                EchangerRole();
                Joueurs gagnant = Gagnant();
                Console.WriteLine("Le gagnant est : " + gagnant.Nom + " avec un score de : " + gagnant.Score);
                
                Console.WriteLine("Voulez-vous rejouer une partie ? Y/N");
            } while (Console.ReadLine() == "Y");      
            
        }

        private void QuelManche()
        {
            if (joueur1.Role && joueur1.Homme)
            {
                manche[nbManche].MainCoreHomme(joueur1);
            }
            else
            {
                if (joueur2.Role && joueur2.Homme)
                {
                    manche[nbManche].MainCoreHomme(joueur2);
                }
                else
                {
                    if (joueur1.Role && joueur1.Homme == false)
                    {
                        manche[nbManche].MainCoreMachine(joueur1);
                    }
                    else
                    {
                        if (joueur2.Role && joueur2.Homme == false)
                        {
                            manche[nbManche].MainCoreMachine(joueur2);
                        }
                    }
                }
            }
        }

        public void StartManche()
        {
            Manche manches;
            if (joueur1.Role)
            {
                manches = new Manche(joueur2.PropositionCode(), joueur1, joueur2);
            }
            else
            {
                manches = new Manche(joueur1.PropositionCode(), joueur1, joueur2);
            }

            if (nbManche >= 0)
            {
                Manche[] temp = new Manche[manche.Length + 1];
                for(int i = 0; i < manche.Length; i++)
                {
                    temp[i] = manche[i];
                }
                temp[manche.Length] = manches;
                manche = temp;
            }
            else
            {
                
                Manche[] temp = new Manche[1];
                temp[0] = manches;
                manche = temp;
            }


        }

        private Joueurs Gagnant()
        {
            Joueurs gagnant;
            if(joueur1.Score < joueur2.Score)
            {
                gagnant = joueur1;
            }
            else
            {
                gagnant = joueur2;
            }
            return gagnant;
        }

        private void EchangerRole()
        {
            if(joueur1.Role == true)
            {
                joueur1.Role = false;
                joueur2.Role = true;
            }
            else
            {
                joueur1.Role = true;
                joueur2.Role = false;
            }
        }

        private void AttributeurDeRole()
        {
            Console.WriteLine("Qui commence (Setteur) ? 1 ou 2");
            if (Console.ReadLine() == "1")
            {
                joueur1.Role = false; //False = Setteur;
                joueur2.Role = true; //True = Guesseur;
            }
            else
            {
                joueur1.Role = true;
                joueur2.Role = false;
            }
        }
    }//Ex11
}
