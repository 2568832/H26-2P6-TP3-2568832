using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente une banque de questions utilisée pour générer des quiz.
    /// Contient un ensemble de questions de différents types.
    /// </summary>
    public class BanqueQuestions
    {
        #region Propriétés

        /// <summary>
        /// Liste des questions disponibles dans la banque.
        /// Cette liste est accessible en lecture seule.
        /// </summary>
        public IReadOnlyList<IQuestion> Questions { get; protected set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une banque de questions avec un ensemble prédéfini
        /// de questions de différents types (numériques, vrai/faux, QCM, etc.).
        /// </summary>
        public BanqueQuestions()
        {

            Questions = new List<IQuestion>() // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!C'est questions sont temporaire, il sont fait par IA, je vais les refaire moi même bientot
            {
                
                
                ////TODO BQ 1: Ajouter au moins 10 questions de types variés : 
                // -QuestionNumerique
                new QuestionNumerique("Combien fait 2 + 2 ?", Categorie.Mathematiques, 10, 4)
                {
                Indice = "Résultat entre 2 et 5",
                PenaliteIndice = 0.2
                },
                new QuestionNumerique("Combien fait 10 / 2 ?", Categorie.Mathematiques, 10, 5)
                {
                Indice = "C'est la moitier de 10",
                PenaliteIndice = 0.2
                },

                // - QuestionVraiFaux
                new QuestionVraiFaux("Le ciel est bleu.", Categorie.CultureGenerale, 5, true),
                new QuestionVraiFaux("C# est un langage compilé.", Categorie.Programmation, 5, true),


                // - QuestionReponseUnique
                new QuestionReponseUnique("Quel langage est utilisé pour le développement Android ?",Categorie.Programmation,10,"Java",new List<string>() { "Java", "C#", "Python", "C++" }),
                new QuestionReponseUnique("Quel est le symbole pour une liste générique en C# ?",Categorie.Programmation,10,"<>",new List<string>() { "<>", "[]", "{}", "()" }),
                // - QuestionReponsesMultiples
                new QuestionReponsesMultiples("Quels sont des langages de programmation ?",Categorie.Programmation,15,new List<string>() { "C#", "Java" },new List<string>() { "C#", "Java", "HTML", "CSS" }),
                new QuestionReponsesMultiples("Quels sont des structures de données ?",Categorie.Programmation,15,new List<string>() { "Liste", "Tableau" },new List<string>() { "Liste", "Tableau", "Variable", "Classe" }),
                // - QuestionReponseCourte

                new QuestionReponseCourte("Quel est le mot-clé pour une classe en C# ?",Categorie.Programmation,5,"class")
                {
                Indice = "Commence par n...",
                PenaliteIndice = 0.2
                },
                new QuestionReponseCourte("Quel mot-clé crée un objet en C# ?",Categorie.Programmation,5,"new")
                {
                Indice = "C'est un mot réservé du langage",
                PenaliteIndice = 0.2
                }
            };
        }
        
        

        #endregion

        #region Génération de quiz

        /// <summary>
        /// Génère un nouveau quiz en sélectionnant aléatoirement un nombre donné
        /// de questions à partir de la banque.
        /// </summary>
        /// <param name="nom">Nom du quiz à créer.</param>
        /// <param name="nombreQuestions">Nombre de questions à inclure.</param>
        /// <returns>
        /// Un objet <see cref="Quiz"/> contenant les questions sélectionnées.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Lancée si le nombre de questions demandé est inférieur ou égal à 0.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Lancée si le nombre de questions demandé dépasse le nombre disponible.
        /// </exception>
        public Quiz GenererQuiz(string nom, int nombreQuestions)
        {
            if (nombreQuestions <= 0)
                throw new ArgumentOutOfRangeException(nameof(nombreQuestions));

            if (Questions == null || nombreQuestions > Questions.Count)
                throw new InvalidOperationException("Il n'y a pas assez de questions dans la banque.");

            // Copie de la liste
            List<IQuestion> questionsCopiees = new List<IQuestion>(Questions);

            // Mélange aléatoire
            OutilsQuiz.MelangerQuestions(questionsCopiees);

            // Sélection des premières questions
            List<IQuestion> questionsSelectionnees = new List<IQuestion>();

            for (int i = 0; i < nombreQuestions; i++)
            {
                questionsSelectionnees.Add(questionsCopiees[i]);
            }

            // Création du quiz
            return new Quiz(nom, questionsSelectionnees);
        }

        #endregion
    }
}