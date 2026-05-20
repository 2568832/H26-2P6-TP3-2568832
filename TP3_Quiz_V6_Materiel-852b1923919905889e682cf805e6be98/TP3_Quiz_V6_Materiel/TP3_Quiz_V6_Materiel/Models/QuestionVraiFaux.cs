using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class QuestionVraiFaux:IQuestion
    {

        private string m_enonce;
        private Categorie m_categorie;
        private int m_points;
        private bool m_bonneReponse;

        public string Enonce
        {
            get { return m_enonce; }
            set
            {
                if (value == null || value.Trim().Length == 0)
                    throw new ArgumentException();

                m_enonce = value;
            }
        }

        public Categorie Categorie
        {
            get { return m_categorie; }
            set { m_categorie = value; }
        }

        public int Points
        {
            get { return m_points; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();

                m_points = value;
            }
        }

        public bool BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }
        


        public QuestionVraiFaux(string enonce,
                                Categorie categorie,
                                int points,
                                bool bonneReponse)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
        }

        public double CorrigerReponse(string reponse)
        {
           
            bool estValide = bool.TryParse(reponse, out bool val);
            if(!estValide)
            {
                return 0;
                
            }

            return val == BonneReponse ? Points : 0;
        }
        public bool ValiderReponse(string reponse)
        {
            bool valide = bool.TryParse(reponse, out bool val);
            if (valide)
            {
                return val == BonneReponse;
            }
            return false;

        }

    }


    
}
