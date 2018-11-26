using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Medecin
    {
        //Attributs
        private string nom;
        private string prenom;
        private string tele;
        private int num;

        //Constructeur
        public Medecin(string nom, string prenom, string tele, int num)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tele = tele;
            this.num = num;
        }

        //Methode
        public override string ToString()
        {
            return "Nom : " + nom + "\nPrenom : " + prenom + "\nTelephone : " + tele + "\nNumero : " + num + "\n";
        }
    }

    class Patient
    {
        //Attributs
        private string nom;
        private string prenom;
        private string tele;
        private int nss;//Securite Social

        //Constructeur
        public Patient(string nom, string prenom, string tele, int nss)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tele = tele;
            this.nss = nss;
        }

        //Methode
        public override string ToString()
        {
            return "Nom : " + nom + "\nPrenom : " + prenom + "\nTelephone : " + tele + "\nNumero de secu : " + nss + "\n";
        }
    }

    class Intervention
    {
        //Attributs
        protected int num;
        protected string date;
        protected string heure;
        protected List<Medecin> lstMed;
        protected Patient p;

        //Constructeur
        public Intervention(int num, string date, string heure)
        {
            this.num = num;
            this.date = date;
            this.heure = heure;
            lstMed = new List<Medecin>();
        }

        //Methodes
        public void ajouterMedecin(Medecin m)
        {
            lstMed.Add(m);
        }

        public void ajouterPatient(Patient p)
        {
            this.p = p;
        }
        public override string ToString()
        {
            string str = "Numero intervention : " + num + "\nDate d'inter : " + date + "\nHeure : " + heure + "List des medecins : ";
            for(int i = 0; i < lstMed.Count; i++)
            {
                str += lstMed.ElementAt(i).ToString();
            }
            return str;
        }
    }
    class InterventionLourde : Intervention, IIntervention
    {
        private int nbHeure;
        public InterventionLourde(int num, string date, string heure, int nbHeure):base(num, date, heure)
        {
            this.nbHeure = nbHeure;
        }
        //Methode
        public double CalculCout()
        {
            double cout = 200 * nbHeure * lstMed.Count;
            return cout;
        }

        public override string ToString()
        {
            return base.ToString() + "\nNombre d'heures : " + nbHeure + "\n";
        }
    }

    class InterventionLegere : Intervention, IIntervention
    {
        //Attributs
        private bool anesthesieLocal;

        public InterventionLegere(int num, string date, string heure, bool anesthesieLocal):base(num, date, heure)
        {
            this.anesthesieLocal = anesthesieLocal;
        }

        public override string ToString()
        {
            if (anesthesieLocal)
            {
                return base.ToString() + "Type d'anesthesie : Local \n";
            }
            
            else
            {
                return base.ToString() + "Type d'anesthesie : Global \n";
            }
            
        }
        
        public double CalculCout()
        {
            double mdr = 0;
            return mdr;
        }
    }

    interface IIntervention
    {
        double CalculCout();
    }

}
