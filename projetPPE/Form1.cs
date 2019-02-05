using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetPPE
{
    /// <summary>
    /// Classe principale qui permet l'exécution du code
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// constructeur: 
        /// initialisation du timer
        /// </summary>
        public Form1()
        {
            InitializeComponent();            
        }
            

        /// <summary>
        /// Initialisation du timer et de ses caractéristiques
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Méthode appelée pour l'évenement tick du timer
        /// </summary>
        /// <param name="sender">objet correspondant à l'envoi du tick</param>
        /// <param name="e">contient les données de l'évenement</param>

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Test pour vérifier que le timer fonctionne:
            MessageBox.Show("timer ok");

            //Connexion à la bdd et création du curseur:
            AccessBdd crs = new AccessBdd();

            //On vérifie qu'on est bien entre le 1 et le 10 du mois:
            if (GestionDates.entre(1, 10) == true)
            {
                //Récupération des fiches du mois précédent et maj de celles-ci:
                //Récupération du mois précédent et son année
                String moisPrecedent = GestionDates.getMoisPrecedent();
                String annee = GestionDates.getAnnee(DateTime.Today);
                string mois = annee + moisPrecedent;

                crs.reqUpdate("update fichefrais set idetat='CL' where mois =" + mois + " and idetat='CR'");

            }
            //Si on est après le 20 du mois:
            if (GestionDates.entre(20, 31) == true)
            {
                //Récupération des fiches du mois précédent et maj de celles-ci:
                String moisPrecedent = GestionDates.getMoisPrecedent();
                String annee = GestionDates.getAnnee(DateTime.Today);
                string mois = annee + moisPrecedent;

                crs.reqUpdate("update fichefrais set idetat='RB' where mois = " + mois + " and idetat='VA'");
            }
        }
    }
}


