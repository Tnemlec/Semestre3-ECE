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
            Console.ReadKey();
        }

    }
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

    
}
