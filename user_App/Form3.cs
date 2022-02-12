using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using App_ban;

namespace user_App
{
    public partial class Form3 : Form
    {
        
        static Form2 a5;
        static crediter a2;
        static Historique a6;
     
        public Form3()
        {
           
            InitializeComponent();
            int id = Form1.client_auto.id_client;
            Compte c = tablecomptes.cpt_auto;
            int idc = c.numcompte;
           
            SqlCommand commande;
            SqlDataReader reader;
            string requete;

            requete = "select *from Client where id_client=" + id;


            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            
            String res = "  ";
            while (reader.Read())
            {
                res = res + reader["nom"].ToString() + "     " + reader["prenom"].ToString() + "    " + reader["adresse"].ToString();
                

            }
            label1.Text = res;

           
            requete = "select *from compte where id=" + idc;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();

            res = "Votre solde est :  ";
            while (reader.Read())
            {
                res = res + reader["solde"].ToString();
        


            }
            label2.Text = res;

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.Hide();
                a5 = new Form2();
                a5.Show();
            }
            if (radioButton2.Checked == true)
            {
                this.Hide();
                a2 = new crediter();
                a2.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            a6 = new Historique();
            a6.Show();
        }
    }
}
