using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponseUnique : IQuestion
    {
        private string m_enonce;
        private Categorie m_categorie;
        private int m_points;
        private string m_bonneReponse;
        private List<string> m_options;

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

        public List<string> Options
        {
            get { return m_options; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (value.Count < 2)
                    throw new ArgumentException();

                m_options = value;
            }
        }

        public string BonneReponse
        {
            get { return m_bonneReponse; }
            set
            {
                if (value == null || value.Trim().Length == 0)
                    throw new ArgumentException();

                if (m_options == null)
                    throw new ArgumentException();

                if (!m_options.Contains(value))
                    throw new ArgumentException();

                m_bonneReponse = value;
            }
        }

        // Constructeur
        public QuestionReponseUnique(string enonce,Categorie categorie,int points,string bonneReponse,List<string> options)
        {
            Options = options;          // 1. assigner d'abord options
            BonneReponse = bonneReponse; // 2. ensuite valider bonne réponse

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
        }

        public bool ValiderReponse(string reponse)
        {
            if (string.IsNullOrWhiteSpace(reponse))
                return false;

            return reponse.Trim().ToLower() ==
                   m_bonneReponse.Trim().ToLower();
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }
    }
}
