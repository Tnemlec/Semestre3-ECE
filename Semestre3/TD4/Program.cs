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
}
