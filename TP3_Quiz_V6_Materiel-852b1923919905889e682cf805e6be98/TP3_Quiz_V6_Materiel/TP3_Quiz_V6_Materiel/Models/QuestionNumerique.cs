using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;
using Models.Interfaces.Models.Interfaces;

namespace Models
{
    public class QuestionNumerique : IQuestion, IReponseAvecIndice
    {
        private string m_enonce;
        private Categorie m_categorie;
        private int m_points;
        private double m_bonneReponse;

        private string m_indice;
        private bool m_indiceUtilise;
        private double m_penaliteIndice;

        // IReponseAvecIndice--------------------
        public string Indice
        {
            get { return m_indice; }
            set
            {
                if (value == null || value.Trim().Length == 0)
                    throw new ArgumentException();

                m_indice = value;
            }
        }

        public bool IndiceUtilise
        {
            get { return m_indiceUtilise; }
            set { m_indiceUtilise = value; }
        }

        public double PenaliteIndice
        {
            get { return m_penaliteIndice; }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException();

                m_penaliteIndice = value;
            }
        }
        // IReponseAvecIndice--------------------
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

        public double BonneReponse
        {
            get { return m_bonneReponse; }
            set { m_bonneReponse = value; }
        }

        // Constructeur
        public QuestionNumerique(string enonce, Categorie categorie,int points,double bonneReponse)
        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
        }

        public void UtiliserIndice()// IReponseAvecIndice
        {
            m_indiceUtilise = true;
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }
        public bool ValiderReponse(string reponse)
        {
            if (double.TryParse(reponse, out double valeur))
            {
                return valeur == BonneReponse;
            }

            return false;
        }


        
    }
}
