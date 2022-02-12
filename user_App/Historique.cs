using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_ban;
namespace user_App
{
    public partial class Historique : Form
    {
        static Form3 a2;
        static tablecomptes a1;
        public Historique()
        {
            InitializeComponent();
            SqlCommand commande;
            SqlDataReader reader;
            string requete;

            requete = "select *from Client where id=" + Form1.client_auto.id_client;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            String res = "  ";
            while (reader.Read())
            {
                res = res + reader["nom"].ToString() + "     " + reader["prenom"].ToString() + "    " + reader["adresse"].ToString();


            }
            label1.Text = res;
            
            int id = tablecomptes.cpt_auto.numcompte;
           

            requete = "select *from Operation where id_compte=" + id;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
           
           
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["la_date"].ToString(), reader["descri"].ToString(), reader["somme"].ToString());
                
                
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            a2 = new Form3();
            a2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            a1 = new tablecomptes();
            a1.Show();
        }
    }
}
