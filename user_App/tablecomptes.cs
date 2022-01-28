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
    public partial class tablecomptes : Form
    {
        static public Compte cpt_auto;
        Form3 a;
        public tablecomptes()
        {
            InitializeComponent();
            

            SqlCommand commande;
            SqlDataReader reader;
            string requete;

            requete = "select *from Client where id=" +Form1.client_auto.id_client;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            String res = "  ";
            while (reader.Read())
            {
                res = res + reader["nom"].ToString() + "     " + reader["prenom"].ToString() + "    " + reader["adresse"].ToString();


            }
            label1.Text = res;


            foreach(Compte i in Form1.client_auto.comptes)
            {
                comboBox1.Items.Add(i);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


            cpt_auto =(Compte) comboBox1.SelectedItem;
            this.Hide();
            a = new Form3();
            a.Show();

        }
    }
    }

