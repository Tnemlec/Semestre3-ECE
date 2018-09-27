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
            Produit BriqueDeLait = new Produit("1", "BriqueDeLait", 2.00, 2);
            Produit Cereale = new Produit("2", "Cereal", 2.00, 2);
            Produit[] tab = new Produit[1];
            tab[0] = BriqueDeLait;
            Magasins Carrefour = new Magasins("Carrefour");
            Carrefour.AfficherProduits();
            Console.ReadKey();
            Carrefour.AjouterProduits(Cereale);
            Carrefour.AfficherProduits();
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

        public void AfficherProduits()
        {
            for(int i = 0; i < produits.Length;i++)
            {
                Console.WriteLine(produits[i].Libelle);
            }
        }

    }//Ex10

    class Joueurs
    {
        //Attributs

        private string nom;
        private bool role;//Si true : Guesseur, Si false : Finder
        private bool homme;
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
        }

        public bool Homme
        {
            get { return homme; }
        }

        //Methodes

        public string PropositionCode()
        {
            string code = "";
            if(homme == true)
            {
                do
                {
                    Console.WriteLine("Saisir un code entier :");
                    code = Console.ReadLine();
                } while (code.Length != 4);

            }
            else
            {
                Random random = new Random();
                for(int i = 0; i < 4; i++)
                {
                    System.Threading.Thread.Sleep(50);
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
        private int nbTour;
        private static int mancheActu = 0;
        private int nbManche;
        private Joueurs[] Joueurs;
        //Constructeurs
        public Manche(string code, Joueurs[] Joueurs)
        {
            this.code = code;
            this.Joueurs = Joueurs;
            mancheActu++;
            nbManche = mancheActu;
        }
        //Methode

        

        public void MainCore()
        {

        }
    }
}
