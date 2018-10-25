using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Forfait
    {
        //Attributs
        private string typeDeForfait;
        private double prix;

        //Constructeur
        public Forfait(string typeDeForfait, double prix)
        {
            this.typeDeForfait = typeDeForfait;
            this.prix = prix;
        }
        //Methode
        public string toString()
        {
            string stg = "";
            stg = "Type de forfait :" + typeDeForfait + "\nPrix" + prix;
            return stg;
        }

    }
    class Permis
    {
        //Attributs
        private string nom;
        private List<Forfait> listforfPermis;
        
        //Constructeurs
        public Permis(string nom, List<Forfait> listforfPermis)
        {
            this.nom = nom;
            this.listforfPermis = listforfPermis;
        }
        public Permis(string nom)
        {
            listforfPermis = new List<Forfait>();
        }
        //Propriété
        public List<Forfait> ListforfPermis
        {
            get
            {
                return listforfPermis;
            }
        }
        //Methode
        public string toString()
        {
            string stg = "";
            stg += "Nom Permis :" + nom + "\nForfait associé :";
            foreach(Forfait f in listforfPermis)
            {
                stg += "\n- " + f.toString();
            }
            return stg;
        }

        public void AjouterForfait(Forfait f)
        {
            listforfPermis.Add(f);
        }
    }
    class Apprentis
    {
        //Attributs
        private string nom;
        private string prenom;
        private string tel;
        private Permis permis;
        private Forfait forf;

        //Constructeur

        public Apprentis(string nom, string prenom, string tel, string telephone, Permis permis)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.permis = permis;
        }

        //Methode

        public void ChoixForfait()
        {
            for(int i = 0; i < permis.ListforfPermis.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + permis.ListforfPermis[i].toString());
            }
            Console.Write("Choisir un numero de forfait : ");
            int n = 0;
            do
            {
                n = int.Parse(Console.ReadLine());

            } while (n <= 0 || n >= permis.ListforfPermis.Count);
            forf = permis.ListforfPermis[n];
        }

        public string toString()
        {
            string stg = "";
            stg += "Nom :" + nom + "\n Prenom :" + prenom + "\nTelephone :" + tel + "\nPermis :" +permis.toString() + "\nForfait :" + forf.toString();
            return stg;
        }
    }
    class Moniteur
    {
        //Attributs
        private string nom;
        private string prenom;
        private string tel;
        //Constructeurs
        public Moniteur(string nom, string prenom, string tel)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
        }
        //Methodes
        public string toString()
        {
            string stg = "";
            stg = "Nom :" + nom + "\n Prenom :" + prenom + "\nTelephone :" + tel;
            return stg;
        }
    }
    class Vehicule
    {
        //Attributs
        private string marque;
        private string modele;
        private string immatriculation;

        //Constructeurs
        public Vehicule(string marque, string modele, string immatriculation)
        {
            this.marque = marque;
            this.modele = modele;
            this.immatriculation = immatriculation;
        }
        //Methode 
        public string toString()
        {
            string stg = "Marque: " + marque + "\nModele: " + modele + "\nImmatriculation: " + immatriculation;
            return stg;
        }
    }
    class Lecon
    {
        private string date;
        private string duree;
        private Apprentis apprentis;
        private Moniteur moniteurs;
        private Vehicule vehicule;

        //Constructeurs
        public Lecon(string date, string duree, Apprentis apprentis, Moniteur moniteurs, Vehicule vehicule)
        {
            this.date = date;
            this.duree = duree;
            this.apprentis = apprentis;
            this.moniteurs = moniteurs;
            this.vehicule = vehicule;
        }
        //Methode
        public string toString()
        {
            string stg = "Date Lecon: " + date + "\nDuree: " + duree + "\nApprentis: " + apprentis.toString() + "\nMoniteurs: " + moniteurs.toString() + "\nVehicule: " + vehicule.toString();
            return stg;
        }
    }
    class AutoEcole
    {
        private string nom;
        private List<Permis> permis;
        private List<Forfait> forfait;
        private List<Apprentis> apprentis;
        private List<Moniteur> moniteurs;
        private List<Vehicule> vehicule;
        private List<Lecon> lecon;

        public AutoEcole(string nom)
        {
            this.nom = nom;
            permis = new List<Permis>();
            forfait = new List<Forfait>();
            apprentis = new List<Apprentis>();
            moniteurs = new List<Moniteur>();
            vehicule = new List<Vehicule>();
            lecon = new List<Lecon>();
        }
        public void AddApprentis(Apprentis a)
        {
            apprentis.Add(a);
        }
        public void AddMoniteur(Moniteur a)
        {
            moniteurs.Add(a);
        }
        public void AddVehicule(Vehicule a)
        {
            vehicule.Add(a);
        }
        public void AddForfait(Forfait a)
        {
            forfait.Add(a);
        }
        public void AddPermis(Permis a)
        {
            permis.Add(a);
        }
        public void AfficherListApprentis()
        {
            string str = "";int i = 1;
            foreach(Apprentis a in apprentis)
            {
                str = "";
                str += i + ") " + a.toString();
                Console.WriteLine(str);
            }
        }
        public void AfficherListMoniteurs()
        {
            string str = ""; int i = 1;
            foreach (Moniteur a in moniteurs)
            {
                str = "";
                str += i + ") " + a.toString();
                Console.WriteLine(str);
            }
        }
        public void AfficherListVehicule()
        {
            string str = ""; int i = 1;
            foreach (Vehicule a in vehicule)
            {
                str = "";
                str += i + ") " + a.toString();
                Console.WriteLine(str);
            }
        }
        public void AddLecon()
        {
            //Choix apprentis
            int a = -1;
            AfficherListApprentis();
            do
            {
                Console.WriteLine("Veuillez choisir un apprentis");
                a = Convert.ToInt32(Console.ReadLine());
            } while (a <= 0 || a > apprentis.Count);
            //Choix de l'index du vehicule
            int v = -1;
            do
            {
                Console.WriteLine("Veuillez choisir un vehicule");
                v = int.Parse(Console.ReadLine());
            } while (v <= 0 || v > vehicule.Count);
            //Choix Moniteurs
            int m = -1;
            do
            {
                Console.WriteLine("Veuillez choisir un moniteur");
                m = int.Parse(Console.ReadLine());
            } while (m <= 0 || m > moniteurs.Count);
            string date = "";
            Console.WriteLine("Veuillez choisir une date");
            date = Console.ReadLine();
            Lecon l = new Lecon(date, "1h", apprentis[a], moniteurs[m], vehicule[v]);
        }
    }

    class Article
    {
        //Attributs
        private string nom;
        private int quantite;
        private bool type;//True = Bon 

        //Constructeurs
        public Article(string nom, int quantite, bool type)
        {
            this.nom = nom;
            this.quantite = quantite;
            this.type = type;
        }
        //Propriete
        public int Quantite
        {
            get
            {
                return quantite;
            }
            set
            {
                quantite = value;
            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
        }

        //Methode
        public string toString()
        {
            string stg = "";
            stg = "Nom: " + nom + "\nQuantite: " + quantite + "\nType: " + type;
            return stg;
        }


    }
    class Rayon
    {
        //Attribut
        private string libelle;
        private List<Article> ListArt;
        //Constructeurs
        public Rayon(string libelle, List<Article> ListArt)
        {
            this.libelle = libelle;
            this.ListArt = ListArt;
        }
    }
    class Client
    {
        //Attribut
        private string nom;
        private List<Article> listArt;
        //Constructeurs
        public Client(string nom)
        {
            this.nom = nom;
            listArt = new List<Article>();
        }
        //Propriete
        public List<Article> ListArt
        {
            get
            {
                return listArt;
            }
        }
        //Methode
        public void AjouterArt(Article a)
        {
            listArt.Add(a);
        }
    }
    class Fournisseur
    {
        private string nom;
        private List<Article> listArt;
        //Constructeur
        public Fournisseur(string nom, List<Article> listArt)
        {
            this.nom = nom;
            this.listArt = listArt;
        }
        //Propriete
        public List<Article> ListArt
        {
            get
            {
                return listArt;
            }
        }
    }
    class Magasin 
    {
        //Attribut
        private string nom;
        private List<Article> listArticle;
        private List<Client> listClient;
        private List<Fournisseur> listFournisseur;
        private List<Rayon> listRayon;

        //Constructeur
        public Magasin(string nom)
        {
            this.nom = nom;
            listArticle = new List<Article>();
            listClient = new List<Client>();
            listFournisseur = new List<Fournisseur>();
            listRayon = new List<Rayon>();
        }

        public void AjouterArticle(Article a)
        {
            listArticle.Add(a);
        }
        public void AjouterClient(Client a)
        {
            listClient.Add(a);
        }
        public void AjouterRayon(Rayon a)
        {
            listRayon.Add(a);
        }
        public void AjouterFournisseur(Fournisseur a)
        {
            listFournisseur.Add(a);
        }

        public void AjouterStock(Fournisseur f)
        {
            for(int i = 0; i < listArticle.Count; i++)
            {
                for(int j = 0; j< f.ListArt.Count; j++)
                {
                    if(listArticle[i].Nom == f.ListArt[j].Nom)
                    {
                        listArticle[i].Quantite += f.ListArt[j].Quantite;
                    }
                }
            }
        }
        public void SupprStock(Client c)
        {
            for(int i = 0; i < listArticle.Count; i++)
            {
                for(int j = 0; j < c.ListArt.Count; j++)
                {
                    if(listArticle[i].Nom == c.ListArt[j].Nom)
                    {
                        listArticle[i].Quantite -= c.ListArt[j].Quantite;
                    }
                }
            }
        }
        public bool RechercherProd(Article abc)
        {
            bool verif = listArticle.Contains(abc);
            return verif;
        }
        public void AfficherStock()
        {
            foreach(Article a in listArticle)
            {
                Console.WriteLine(a.toString());
            }
        }
    }
}
