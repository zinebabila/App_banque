using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_ban;
using System.Data.SqlClient;
namespace user_App
{
    public partial class Form1 : Form
    {
       static public SqlConnection connexion;
       static Form3 a1;
        List<Client> clients = new List<Client>();
        
        static public  Client client_auto;
       
        public Form1()
        {
            
            /*********************Db connexion************************/
          
            string connexStr;
            connexStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Banque;MultipleActiveResultSets = True;";
            connexion = new SqlConnection(connexStr);
            connexion.Open();
            SqlCommand commande;
            SqlDataReader reader;
            string requete;
            requete = "select *from Client";
            commande = new SqlCommand(requete, connexion);
            reader = commande.ExecuteReader();
            while (reader.Read())
            {
                int idclt = int.Parse(reader["id_client"].ToString());
                Client c = new Client(idclt,reader["nom"].ToString(), reader["prenom"].ToString(), reader["adresse"].ToString(), reader["identifiant"].ToString(), reader["mot_de_passe"].ToString());
                SqlCommand com;
                SqlDataReader re;
                string req = "select* from compte where id_client=" + idclt;
                com = new SqlCommand(req, connexion);
                re = com.ExecuteReader();
                while (re.Read())
                {
                    Compte cp1 = new Compte(int.Parse(re["id"].ToString()), c,float.Parse(re["solde"].ToString()));
                    c.comptes.Add(cp1);
                }
                
                clients.Add(c);
            }

            /**/
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;
            bool res = false;

           for (int i = 0; i < clients.Count(); i++)
            {
                if (clients[i].auth(login, password) == true)
                {
                    client_auto = clients[i];

                    this.Hide();
                    a1 = new Form3();
                    a1.Show();

                    res = true;
                    break;
                }
               
            }
            if (res == false)
            {
                MessageBox.Show("error");
            }
             
          
        }

       
    }
}
