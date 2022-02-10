using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_ban
{
   public class Compte
    {
	     public int numcompte;
		private Client titulaire;
		public float solde;
		static private float plafond;
		private int choix;
		//agregation
	     //Devise* solde;
		 //static Devise* plafond; //une valeur qu'on ne peut pas la depasser en cas de retrait
		public  List<Operation> historique;
		 // Methodes

		public Compte(int id,Client clt,float solde,int ch) {
			this.numcompte = id;
			this.titulaire = clt;
			this.solde = solde;
			plafond = 1000;
			this.choix = ch;
			this.historique = new List<Operation>();

		}
		//virtual void consulter();
		 public void crediter(float somme)
        {
			this.solde = this.solde + somme;

        }
		public  void debiter(float M)
        {
            if (plafond > M)
            {
				this.solde = this.solde - M;
            }
        }
		public override string ToString()
        {
			if(this.choix==1)
			return " numero de compte est :" + this.numcompte + " le type du compte est courant";
			if(this.choix==2)
				return " numero de compte est :" + this.numcompte + " le type du compte est epagne";
			
				return " numero de compte est :" + this.numcompte + " le type du compte est courant epagne";
		}
		public void ajouter_op(Operation oper)
        {
			this.historique.Add(oper);
        }
		
		
	}
}
