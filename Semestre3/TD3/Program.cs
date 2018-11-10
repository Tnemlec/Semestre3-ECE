using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    //Ex1
    class Appareil
    {
        protected string nom;
        protected string identifiant;

        public Appareil(string identifiant, string nom)
        {
            this.nom = nom;
            this.identifiant = identifiant;
        }
    }
    class Voltmetre : Appareil
    {
        private double tensionMax;

        public Voltmetre(string identifiant, string nom, double tensionMax):base(identifiant, nom)
        {
            this.tensionMax = tensionMax;
        }
    }
    class Ampermetre : Appareil
    {
        private double intensiteMax;

        public Ampermetre(string identifiant, string nom, double intensiteMax) : base(identifiant, nom)
        {
            this.intensiteMax = intensiteMax;
        }
    }
    class Oscilloscope : Appareil
    {
        private string marque;
        private string taille;

        public Oscilloscope(string identifiant, string nom, string marque, string taille) : base(identifiant, nom)
        {
            this.marque = marque;
            this.taille = taille;
        }
    }
    class Centre
    {
        private List<Appareil> listApp;

        public Centre()
        {
            listApp = new List<Appareil>();
        }

        public void AjoutApp(Appareil a)
        {
            listApp.Add(a);
        }

        public void SuppApp(Appareil a)
        {
            listApp.Remove(a);
        }


    }

    //Ex2
    class Document
    {
        //Attributs
        protected int num;
        protected string titre;

        public Document(int num, string titre)
        {
            this.num = num;
            this.titre = titre;

        }

        public string Titre
        {
            get
            {
                return titre;
            }
        }



        override
        public string ToString()
        {
            string stg = "";
            stg += "Num doc :" + num + "\nTitre :" + titre + "\n";
            return stg;
        }

    }
    class Livre : Document
    {
        protected string auteur;
        protected int nbPage;

        public Livre(int num, string titre, string auteur, int nbPage) : base(num, titre)
        {
            this.auteur = auteur;
            this.titre = titre;
        }

        override
        public string ToString()
        {
            string str = "";
            str += base.ToString() + "Auteur : " + auteur + "\nNombre Page : " + nbPage + "\n";
            return str;
        }

    }
    class Dictionnaire : Document
    {
        private string langue;

        public Dictionnaire(int num, string titre, string langue): base(num,titre)
        {
            this.langue = langue;
        }

        override
        public string ToString()
        {
            string str = "";
            str = base.ToString() + "Lanque : " + langue + "\n";
            return str;
        }
    }
    class Revue : Document
    {
        private int mois;
        private int annee;

        public Revue(int num, string titre, int mois, int annee) : base(num, titre)
        {
            this.mois = mois;
            this.annee = annee;
        }

        override
        public string ToString()
        {
            string str = "";
            str += base.ToString() + "Mois : " + mois + "\nAnnee" + annee + "\n";
            return str;
        }
    }
    class Roman : Livre
    {
        private string prixLitt;

        public Roman(int num, string titre, string auteur, int nbPage, string prixLitt) : base(num,titre,auteur,nbPage)
        {
            this.prixLitt = prixLitt;
        }

        override
        public string ToString()
        {
            string stg = "";
            stg += base.ToString() + "\nPrix Litterature : " + prixLitt + "\n";
            return stg;
        }
    }
    class Manuel : Livre
    {
        private int nivScolaire;

        public Manuel(int num, string titre, string auteur, int nbPage, int nivScolaire) : base(num, titre, auteur, nbPage)
        {
            this.nivScolaire = nivScolaire;
        }

        override
        public string ToString()
        {
            string stg = base.ToString() + "Niveau Scolaire : " + nivScolaire + "\n";
            return stg;
        }
    }
    class Etagere
    {
        private int nbPlaces;
        private List<Document> listDoc;

        public Etagere(int nbPlaces)
        {
            this.nbPlaces = nbPlaces;
            listDoc = new List<Document>();
        }

        public void AjouterDocument(Document d)
        {
            if(nbPlaces > listDoc.Count)
            {
                listDoc.Add(d);
            }
            else
            {
                Console.WriteLine("Plus de place sur l'étagère");
            }
            
        }

        public void SuppDoc(string titre)
        {
            for(int i = 0; i < listDoc.Count; i++)
            {
                if(listDoc[i].Titre == titre)
                {
                    listDoc.RemoveAt(i);
                    i--;
                }
            }
        }

        public List<Document> ListDoc
        {
            get
            {
                return listDoc;
            }
        }

        override
        public string ToString()
        {
            string stg = "";
            foreach(Document d in listDoc)
            {
                stg += d.ToString();
            }
            stg += "Nombre de place : " + nbPlaces + "\n";
            return stg;
        }
        
    }
    class Bibliotheque
    {   
        private string nom;
        private List<Etagere> listEta;

        public Bibliotheque(string nom)
        {
            this.nom = nom;
            listEta = new List<Etagere>();
        }

        public void AjoutEtagere(Etagere e)
        {
            listEta.Add(e);
        }

        public void SuppEtagere(Etagere et)
        {
            foreach(Etagere e in listEta)
            {
                if (e.Equals(et))
                {
                    listEta.Remove(e);
                }
            }
        }

        public Document RechercheDocParTitre(string str)
        {
            Document d = null;
            bool trouve = false;
            int i = 0;

            while(i < listEta.Count && trouve == false)
            {
                int j = 0;
                while(j < listEta[i].ListDoc.Count && trouve == false)
                {
                    if (listEta[i].ListDoc[j].Titre.Equals(str))
                    {
                        d = listEta[i].ListDoc[j];
                        trouve = true;
                    }
                    j++;
                }
                i++;               
            }
            if(trouve == false)
            {
                Console.WriteLine("Le doc n'existe pas");
            }
            return d;

        }
    }

    //Ex3
    class Restaurant0Etoiles
    {
        protected string nom;
        protected string adresse;
        protected string heureOuverture;
        protected string heureFermeture;
        protected int nbOuvrier;

        public Restaurant0Etoiles(string nom, string adresse, string heureOuverture, string heureFermeture, int nbOuvrier)
        {
            this.nom = nom;
            this.adresse = adresse;
            this.heureOuverture = heureOuverture;
            this.heureFermeture = heureFermeture;
            this.nbOuvrier = nbOuvrier;

        }

        public override string ToString()
        {
            string stg = "Nom : " + nom + "\nAdresse : " + adresse + "\nHeure d'ouverture : " + heureOuverture + "\nHeure de fermeture : " + heureFermeture + "\nNombre ouvrier : " + nbOuvrier;
            return stg;
        }

        public virtual void calculCout()
        {
            Console.WriteLine(70 * nbOuvrier);

        }


    }
    class Restaurant1Etoiles : Restaurant0Etoiles
    {
        protected int nbChef;

        public Restaurant1Etoiles(string nom, string adresse, string heureOuverture, string heureFermeture, int nbOuvrier, int nbChef):base( nom,  adresse,  heureOuverture,  heureFermeture, nbOuvrier)
        {
            this.nbChef = nbChef;
        }

        public override string ToString()
        {
            return base.ToString() + "\nNombre de chef : " + nbChef;
        }

        public override void calculCout()
        {
            Console.WriteLine(70 * nbOuvrier + 110 * nbChef);
        }
    }
    class Restaurant2Etoiles : Restaurant1Etoiles
    {
        private int nbServeur;
        public Restaurant2Etoiles(string nom, string adresse, string heureOuverture, string heureFermeture, int nbOuvrier, int nbChef, int nbServeur):base( nom,  adresse,  heureOuverture,  heureFermeture,  nbOuvrier,  nbChef)
        {
            this.nbChef = nbChef;
        }

        public override string ToString()
        {
            return base.ToString() + "\nNombre de serveur : " + nbServeur;
        }

        public override void calculCout()
        {
            Console.WriteLine(70 * nbOuvrier + 110 * nbChef + 85 * nbServeur);
        }
    }
}
