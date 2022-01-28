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
namespace user_App
{
    public partial class Form2 : Form
    {
        static Form3 a1;
        public Form2()
        {
            InitializeComponent();
            int id = Form3.cpt_auto.numcompte ;

            SqlCommand commande;
            SqlDataReader reader;
            string requete;

            requete = "select *from Client where id=" + id;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            String res = "  ";
            while (reader.Read())
            {
                res = res + reader["nom"].ToString() + "     " + reader["prenom"].ToString() + "    " + reader["adresse"].ToString();


            }
            label1.Text = res;


            requete = "select *from compte where id_client=" + id;

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
            String somme = textBox1.Text;
            Form3.cpt_auto.debiter(float.Parse(somme));
           
            SqlDataAdapter adap=new SqlDataAdapter();
            string requete;

            requete = "update compte set solde = solde-" +somme+"where id="+Form3.cpt_auto.numcompte;

            adap.UpdateCommand= new SqlCommand(requete, Form1.connexion);
            adap.UpdateCommand.ExecuteNonQuery();
            adap.UpdateCommand.Dispose();


            this.Hide();
            a1 = new Form3();
            a1.Show();
        }
    }
}
