using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using App_ban;
namespace user_App
{
    public partial class Form2 : Form
    {
        static Form3 a1;
        static Historique a6;
        public Form2()
        {
            InitializeComponent();
            int id = tablecomptes.cpt_auto.numcompte ;
            int i = Form1.client_auto.id_client;
           Compte  compt = tablecomptes.cpt_auto;

            SqlCommand commande;
            SqlDataReader reader;
            string requete;

            requete = "select *from Client where id=" + i;

            commande = new SqlCommand(requete, Form1.connexion);
            reader = commande.ExecuteReader();
            String res = "  ";
            while (reader.Read())
            {
                res = res + reader["nom"].ToString() + "     " + reader["prenom"].ToString() + "    " + reader["adresse"].ToString();


            }
            label1.Text = res;


            requete = "select *from compte where id=" + id;

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
            tablecomptes.cpt_auto.debiter(float.Parse(somme));
           
            SqlDataAdapter adap=new SqlDataAdapter();
            string requete;

            requete = "update compte set solde = solde-" +somme+"where id="+tablecomptes.cpt_auto.numcompte;

            adap.UpdateCommand= new SqlCommand(requete, Form1.connexion);
            adap.UpdateCommand.ExecuteNonQuery();
            adap.UpdateCommand.Dispose();
            SqlCommand commande;

            commande = Form1.connexion.CreateCommand();
            commande.CommandText = "INSERT INTO Operation(id , descri , la_date ,somme, id_compte) VALUES ("+  int.Parse(new Random().Next().ToString())+ " , 'Debiter' ,convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+ " ' ), " + somme + " , " + tablecomptes.cpt_auto.numcompte + " );";

            commande.ExecuteNonQuery();

            this.Hide();
            a1 = new Form3();
            a1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            a6 = new Historique();
            a6.Show();
        }
    }
}
