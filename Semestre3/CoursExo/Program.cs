using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursExo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Animal c = new Chien("JOOkie", "Moi", "25/10/1999");
            Animal v = (Animal)c;
            Console.WriteLine(v.decrit_Toi());
            Console.ReadKey();
        }

    }

    //ExIncomplet
    class Compte
    {
        protected string numero;
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected int solde;

        public Compte(string numero, string nom, string prenom, string adresse, int solde)
        {
            this.numero = numero;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.solde = solde;
        }

        public string toString()
        {
            string stg = "Description du compte";
            return stg;
        }

    }
    class LivretA : Compte
    {
        private double taux;

        public LivretA(string numero, string nom, string prenom, string adresse, int solde, double taux) : base(numero, nom, prenom, adresse, solde)
        {
            this.taux = taux;
        }
    }
    class Banque
    {
        private string nom;
        private List<Compte> listCompte;

        public Banque(string nom)
        {
            this.nom = nom;
            listCompte = new List<Compte>();
        }

        public void AjoutCompte(Compte c)
        {
            listCompte.Add(c);
        }

        public void SupprCompte(Compte c)
        {
            listCompte.Remove(c);
        }
        
        public string toString()
        {
            string stg = "Banque = " + nom + "\n";
            for(int i = 0; i < listCompte.Count; i++)
            {
                stg += listCompte[i].toString();
            }
            return stg;
        }
    }

    //Ex Polymorphisme 05/11/18 Virtual-Override
    class Animal
    {
        protected string nom;
        protected string proprietaire;

        //Constructeur
        public Animal(string nom, string proprietaire)
        {
            this.nom = nom;
            this.proprietaire = proprietaire;
        }

        
        public virtual string decrit_Toi()
        {
            string stg = "Nom du proprio : " + proprietaire + "\nNom de l'animal : " + nom;
            return stg;
        }
    }
    class Chien:Animal
    {
        private string date_De_Vaccination;
        
        public Chien(string nom, string proprietaire, string date_De_Vaccination):base(nom, proprietaire)
        {
            this.date_De_Vaccination = date_De_Vaccination;
        }

        override
        public string decrit_Toi()
        {
            string stg = base.decrit_Toi() + "\nDate de Vaccination" + date_De_Vaccination;
            return stg;
        }
    }
    class Serpent : Animal
    {
        private string dangerosite;

        public Serpent(string nom, string proprietaire, string dangerosite):base(nom, proprietaire)
        {
            this.dangerosite = dangerosite;
        }

        override
        public string decrit_Toi()
        {
            string stg = base.decrit_Toi() + "\nDangerosité : " + dangerosite;
            return stg;
        }
    }
    class Peroquet : Animal
    {
        private bool parle;

        public Peroquet(string nom, string proprietaire, bool parle): base(nom, proprietaire)
        {
            this.parle = parle;
        }

        override
        public string decrit_Toi()
        {
            string stg = base.decrit_Toi() + "\nParle : " + parle;
            return stg;
        }
    }

    //Ex classe abstraite
    abstract class AnimalE
    {
        protected string nom;
        protected string couleur;
        protected int poids;

        public AnimalE(string nom, string couleur, int poids)
        {
            this.nom = nom;
            this.couleur = couleur;
            this.poids = poids;
        }

        public abstract void SeDeplacer();
        public abstract void Crier();
        public abstract void Manger();
    } 

    class ChiennE : AnimalE
    {
        public ChiennE(string nom, string couleur, int poids):base(nom, couleur, poids)
        {

        }

        public override void SeDeplacer()
        {
            Console.WriteLine("Deplacement sur 4 pattes");
        }
        public override void Crier()
        {
            Console.WriteLine("Un chien aboie");
        }
        public override void Manger()
        {
            Console.WriteLine("Il avale");
        }
    }
}
