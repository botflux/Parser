using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Outils de création de message
    /// </summary>
    public static class MessageParser
    {
        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec le nom et la valeur passées en paramètre
        /// </summary>
        /// <param name="name">Nom de la variable</param>
        /// <param name="value">Valeur de la variable</param>
        /// <returns></returns>
        public static string Parse (string name, string value)
        {
            return string.Format("{0}={1}", name.ToUpper(), value);
        }

        /// <summary>
        /// Retourne le message découpé dans une instance de la structure ParsedData
        /// </summary>
        /// <param name="parsedData">Message formé</param>
        /// <returns></returns>
        public static ParsedData Decode (string parsedData)
        {
            if (parsedData.Contains("="))
            {
                string[] exploded = parsedData.Split('=');
                return new ParsedData(exploded[0], exploded[1]);
            }
            else
            {
                throw new Exception("Data not properly formatted !");
            }
        }

        /// <summary>
        /// Renvoie vrai si le message est composé d'un seul égal sinon faux
        /// </summary>
        /// <param name="parsedData"></param>
        /// <returns></returns>
        private static bool IsValid (string parsedData)
        {
            int equalCount = 0;

            foreach (char c in parsedData)
            {
                if (c == '=')
                    equalCount++;
            }

            return equalCount == 1;
        }

        /// <summary>
        /// Représente une donnée parsée.
        /// </summary>
        public struct ParsedData
        {
            private string name;
            private string value;

            /// <summary>
            /// Nom de la donnée
            /// </summary>
            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            /// <summary>
            /// Valeur de la donnée
            /// </summary>
            public string Value
            {
                get
                {
                    return this.value;
                }

                set
                {
                    this.value = value;
                }
            }

            /// <summary>
            /// Initialise une nouvelle instance de la structure ParsedData
            /// </summary>
            /// <param name="name">Nom de la donnée</param>
            /// <param name="value">Valeur de la donnée</param>
            public ParsedData (string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            /// <summary>
            /// Retourne une chaine de caractère représentant l'instance.
            /// </summary>
            /// <returns>Chaine de caractère formatter</returns>
            public override string ToString()
            {
                return string.Format("Name: {0}; Value: {1}", this.name, this.value);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
