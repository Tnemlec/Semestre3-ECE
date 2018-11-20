using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnage m1 = new Magicien("Gandalph", 100, false);
            Personnage g1 = new Guerrier(true, "Garen", 100);

            Arme a1 = new Epee("Jedusor", 10000000, 100);
            Arme a2 = new Epee("Lame d'infini", 100, 100);
            Arme a3 = new Epee("Sterak", 5, 100);

            g1.AjouterArme(a1);
            g1.AjouterArme(a2);
            g1.AjouterArme(a3);

            g1.AffecterArme();
        }
    }

    //Ex Combat
    abstract class Arme
    {
        protected string nom;
        protected int nivArme;

        public Arme(string nom, int nivArme)
        {
            this.nom = nom;
            this.nivArme = nivArme;
        }

        public string Nom
        {
            get
            {
                return nom;
            }
        }

        public int NivAtt
        {
            get
            {
                return nivArme;
            }
        }

        public override string ToString()
        {
            return "Nom : " + nom + "\nNiveau de l'arme : " + nivArme; 
        }
    }
    class Epee : Arme
    {
        private int indice;

        public Epee(string nom, int nivArme, int indice) : base(nom, nivArme)
        {
            this.indice = indice;
        }
    }
    class Baton : Arme
    {
        private int age;

        public Baton(string nom, int nivArme, int age) : base(nom, nivArme)
        {
            this.age = age;
        }
    }
    abstract class Personnage
    {
        protected bool enVie;
        protected int nivDeVie;
        protected string nom;
        protected List<Arme> listArme;
        protected Arme armeUtil;

        public Personnage(int nivDeVie, string nom)
        {
            this.nivDeVie = nivDeVie;
            this.nom = nom;
            enVie = true;
            listArme = new List<Arme>();
        }

        public string Nom
        {
            get
            {
                return nom;
            }
        }

        public int NivDeVie
        {
            get
            {
                return nivDeVie;
            }
        }

        public void AjouterArme(Arme a)
        {
            if(listArme.Count > 5)
            {
                Console.WriteLine("Deso pas deso tu peut pas");
            }
            else
            {
                listArme.Add(a);
            }
        }

        public void AffecterArme()
        {
            int i = 1;
            int choix;
            Console.WriteLine("Quelle arme voulez-vous équiper ?");
            foreach(Arme a in listArme)
            {
                Console.Write(i + ") " + a.Nom);
            }
            choix = int.Parse(Console.ReadLine());
            armeUtil = listArme[choix - 1];
        }

        public abstract void SeFatiguer();

        public void TesterVie()
        {
            if(nivDeVie <= 0)
            {
                enVie = false;
            }
        }
    }
    class Guerrier : Personnage
    {
        private bool aCheval;

        public Guerrier(bool aCheval, string nom, int nivDeVie):base(nivDeVie, nom)
        {
            this.aCheval = aCheval;
        }

        public override void SeFatiguer()
        {
            if(nivDeVie > 20)
            {
                nivDeVie -= 20;
            }
            else
            {
                nivDeVie = 0;
                enVie = false;
            }
        }
    }
    class Magicien : Personnage
    {
        private bool novice;

        public Magicien(string nom, int nivDeVie, bool novice):base(nivDeVie, nom)
        {
            this.novice = novice;
        }

        public override void SeFatiguer()
        {
            if(nivDeVie > 10)
            {
                nivDeVie -= 10;
            }
            else
            {
                nivDeVie = 0;
                enVie = false;
            }
        }
    }

    //Ex Magasins
    abstract class Produit
    {
        protected string reference;
        protected string libelle;
        protected int quantite;
        protected double prixAchat;
        protected double prixVenteHT;

        public Produit(string reference, string libelle, double prixAchat)
        {
            this.reference = reference;
            this.libelle = libelle;
            this.prixAchat = prixAchat;
            quantite = 0;
        }

        public abstract void CalculPrix();

        public abstract double CalculBenef();

        public override string ToString()
        {
            return "Reference : " + reference + "\nLibelle : " + libelle + "\nQuantite : " + quantite;
        }

        public void AjouterStock(int Ajout)
        {
            quantite += Ajout;
        }

        public void Vente(int Vente)
        {
            if(Vente > quantite)
            {
                quantite -= Vente;
            }
            else
            {
                quantite = 0;
            }
            
        }

        public string Reference
        {
            get
            {
                return reference;
            }
        }

        public int Quantite
        {
            get
            {
                return quantite;
            }
        }
    }
    class Alimentaire : Produit
    {
        private string dateLimite;
        private double prixTTC;

        public Alimentaire(string reference, string libelle, double prixAchat, string dateLimite):base( reference,  libelle, prixAchat)
        {
            this.dateLimite = dateLimite;
            prixTTC = (prixAchat + CalculBenef()) * (1 + 0.18);
        }

        public override double CalculBenef()
        {
            double prixBenef = prixAchat * 0.15;
            return prixBenef;
        }

        public override void CalculPrix()
        {
            Console.WriteLine("\nLe prix TTC de se produit est : " + prixTTC);
        }

        public override string ToString()
        {
            return base.ToString() + "\nDate limite de consomation : " + dateLimite + "\nLe prix TTC de ce produit est : " + prixTTC;
        }
    }
    class Electromenager : Produit
    {
        private string taille;
        private string marque;
        private double prixTTC;

        public Electromenager(string reference, string libelle, double prixAchat, string taille, string marque):base(reference, libelle, prixAchat)
        {
            this.taille = taille;
            this.marque = marque;
            prixTTC = (prixAchat + CalculBenef()) * (1 + 0.20);
        }
        public override double CalculBenef()
        {
            double prixBenef = prixAchat * 0.18;
            return prixBenef;
        }
        public override void CalculPrix()
        {
            Console.WriteLine("\nLe prix TTC de se produit est : " + prixTTC);
        }
        public override string ToString()
        {
            return base.ToString() + "\nTaille : " + taille + "\nMarque : " + marque + "\nLe prix TTC de ce produit est : " + prixTTC;
        }
    }
    class Cosmetique : Produit
    {
        private bool liquide;
        private double prixTTC;

        public Cosmetique(string reference, string libelle, double prixAchat, bool liquide):base(reference, libelle, prixAchat)
        {
            this.liquide = liquide;
            prixTTC = (prixAchat + CalculBenef()) * (1 + 0.22);
        }

        public override double CalculBenef()
        {
            double prixBenef = prixAchat * 0.23;
            return prixBenef;
        }
        public override void CalculPrix()
        {
            Console.WriteLine("\nLe prix TTC de se produit est : " + prixTTC);
        }
        public override string ToString()
        {
            return base.ToString() + "\nLe produit est liquide : " + liquide + "\nLe prix TTC de ce produit est : " + prixTTC;
        }
    }
    class Fournisseur
    {
        private string nom;
        private List<Produit> listPrd;

        public Fournisseur(string nom)
        {
            this.nom = nom;
            listPrd = new List<Produit>();
        }

        public bool Satisfaction(int nombreATester, Produit p)
        {
            bool possible = false;
            foreach(Produit a in listPrd)
            {
                if(a.Reference == p.Reference)
                {
                    if(a.Quantite >= nombreATester)
                    {
                        possible = true;
                    }
                }
            }
            return possible;
        }

        public void AjouterProduit(Produit p)
        {
            listPrd.Add(p);
        }
        public void SupprProduit(Produit p)
        {
            listPrd.Remove(p);
        }

    }
    class Magasins
    {
        private string nom;
        private List<Produit> listPrd;
        private List<Fournisseur> listFourn;

        public Magasins(string nom)
        {
            this.nom = nom;
        }

        public double CalculBenef()
        {
            double benef = 0.00;
            foreach(Produit p in listPrd)
            {
                benef += p.CalculBenef();
            }
            return benef;
        }

        public void Approvisioner(int quantiteDemande,Produit p)
        {
            int i = 0;
            foreach(Fournisseur f in listFourn)
            {
                if(f.Satisfaction(quantiteDemande, p) && i == 0)
                {
                    i++;
                    p.AjouterStock(quantiteDemande);
                }
            }
        }

        public void VenteProduit(int nombreVendu, Produit p)
        {
            p.Vente(nombreVendu);
        }

        public bool ComparerProduit(Produit a, Produit b)
        {
            bool egal = false;
            if(a.Reference == b.Reference)
            {
                egal = true;
            }
            return egal;
        }
    }
}
