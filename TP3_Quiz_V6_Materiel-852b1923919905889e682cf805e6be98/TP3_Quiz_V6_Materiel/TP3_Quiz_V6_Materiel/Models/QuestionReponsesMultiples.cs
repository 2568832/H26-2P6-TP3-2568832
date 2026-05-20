using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponsesMultiples : IQuestion
    {
        private string m_enonce;
        private Categorie m_categorie;
        private int m_points;
        private List<string> m_bonneReponse;
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

        public List<string> BonneReponse
        {
            get { return m_bonneReponse; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                if (value.Count == 0)
                    throw new ArgumentException();

                if (m_options != null)
                {
                    foreach (string rep in value)
                    {
                        if (!m_options.Contains(rep))
                        {
                            throw new ArgumentException();

                        }
                    }
                }

                m_bonneReponse = value;
            }
        }
        public QuestionReponsesMultiples(string enonce,Categorie categorie,int points,List<string> bonneReponse,List<string> options)
        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Options = options;
        }

        public bool ValiderReponse(string reponse)
        {
            List<string> Ressus = reponse.Split(',').ToList();

            if (Ressus.Count != BonneReponse.Count)
            {
                return false;
            }

            for (int i = 0; i < BonneReponse.Count; i++)
            {
                bool trouvee = false;

                for (int j = 0; j < Ressus.Count; j++)
                {
                    if (BonneReponse[i].Trim().ToLower() ==
                        Ressus[j].Trim().ToLower())
                    {
                        trouvee = true;
                    }
                }

                if (!trouvee)
                {
                    return false;
                }
            }

            return true;
        }
        

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }
    }
}
