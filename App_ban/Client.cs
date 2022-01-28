using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_ban
{
    public class Client
    {
            public int id_client;
            private string nom;
            private string prenom;
            private string adresse;
            private string login;
            private string password;
            public List<Compte> comptes;

        public Client(int id, string n, string p, string c, string l, string pass)
            {
            this.id_client = id;
                this.nom = n;
                this.prenom = p;
                this.adresse = c;
                this.login = l;
                this.password = pass;
            this.comptes = new List<Compte>();
        }

            public String afficher()
            {
                string res = "nom : " + this.nom + "\nprenom : " + this.prenom +
          "\nCIN : " + this.adresse;
                return res;
            }
        public bool auth(String login,String password)
        {
            if ((this.login == login) && (this.password == password))
                return true;
            return false;
        }
        }
    
}
