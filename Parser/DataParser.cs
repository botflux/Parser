using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    /// <summary>
    /// Outil de création de message
    /// </summary>
    public static class DataParser
    {
        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec tous les élèments de la liste
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Parse (List<ParseData> list)
        {
            return Parse(list.ToArray());
        }

        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec tous les éléments du tableau
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Parse (ParseData[] array)
        {
            string result = "";

            foreach (ParseData data in array)
            {
                string parse = Parse(data);
                result += parse + ";";
            }

            result = result.TrimEnd(';');

            return result;
        }

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
        /// Retourne une chaîne de caractères mise en forme
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public static string Parse(ParseData data)
        {
            return Parse(data.Name, data.Value);
        }

        /// <summary>
        /// Retourne les messages découpés dans une liste d'instance de la structure ParseData
        /// </summary>
        /// <param name="parsedData"></param>
        /// <returns></returns>
        public static List<ParseData> DecodeArray (string parsedData)
        {
            string[] exploded = parsedData.Split(';');
            List<ParseData> parseDataArray = new List<ParseData>();

            foreach (string e in exploded)
            {
                parseDataArray.Add(Decode(e));
            }

            return parseDataArray;
        }

        /// <summary>
        /// Retourne le message découpé dans une instance de la structure ParseData
        /// </summary>
        /// <param name="parsedData">Message formé</param>
        /// <returns></returns>
        public static ParseData Decode (string parsedData)
        {
            if (parsedData.Contains("="))
            {
                string[] exploded = parsedData.Split('=');
                return new ParseData(exploded[0], exploded[1]);
            }
            else
            {
                throw new Exception("Data not properly formatted !");
            }
        }
    }

    /// <summary>
    /// Représente une donnée parsée.
    /// </summary>
    public struct ParseData
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
        public ParseData(string name, string value)
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
