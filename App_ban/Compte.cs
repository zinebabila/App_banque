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
		private float solde;
		static private float plafond; 
		//agregation
	     //Devise* solde;
		 //static Devise* plafond; //une valeur qu'on ne peut pas la depasser en cas de retrait
		 //vector<Operation*> historique;
		 // Methodes

		public Compte(int id,Client clt,float solde) {
			this.numcompte = id;
			this.titulaire = clt;
			this.solde = solde;
			plafond = 1000;

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
		
		
	}
}
