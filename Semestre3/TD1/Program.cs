using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture V1 = new Voiture("Mercedes", "C220", false, 2000, "rouge");//Ex2
            //Ex3: Non ce code ne fonctionne pas car il manque un get/set et lui meme commencera par une majuscule 
            //Ex4: Le premier code est en effet valide cependant il manque la partiue set afin de pouvoir manipuler les attributs(leur donner une valeur)
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


    }
}
