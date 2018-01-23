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
    public static class FrameParser
    {
        private static char nameValueSeparator = '=';
        private static char frameSeparator = ';';

        /// <summary>
        /// Caractère utilisé pour séparer les valeurs des noms
        /// </summary>
        public static char NameValueSeparator
        {
            get
            {
                return nameValueSeparator;
            }

            set
            {
                nameValueSeparator = value;
            }
        }

        /// <summary>
        /// Caractère utilisé pour séparer les différentes trames
        /// </summary>
        public static char FrameSeparator
        {
            get
            {
                return frameSeparator;
            }

            set
            {
                frameSeparator = value;
            }
        }

        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec tous les élèments de la liste
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Encode (List<DataWrapper> list)
        {
            return Encode(list.ToArray());
        }

        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec tous les éléments du tableau
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string Encode (DataWrapper[] array)
        {
            string result = "";

            foreach (DataWrapper data in array)
            {
                string parse = Encode(data);
                result += parse + FrameSeparator;
            }

            result = result.TrimEnd(FrameSeparator);

            return result;
        }

        /// <summary>
        /// Retourne une chaîne de caractères mise en forme avec le nom et la valeur passées en paramètre
        /// </summary>
        /// <param name="name">Nom de la variable</param>
        /// <param name="value">Valeur de la variable</param>
        /// <returns></returns>
        public static string Encode (string name, object value)
        {
            return string.Format("{0}{1}{2}", name.ToUpper(), NameValueSeparator,value.ToString());
        }
        
        /// <summary>
        /// Retourne une chaîne de caractères mise en forme
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public static string Encode(DataWrapper data)
        {
            return Encode(data.Name, data.Value);
        }

        /// <summary>
        /// Retourne les messages découpés dans une liste d'instance de la structure ParseData
        /// </summary>
        /// <param name="parsedData"></param>
        /// <returns></returns>
        public static List<DataWrapper> DecodeArray (string parsedData)
        {
            string[] exploded = parsedData.Split(FrameSeparator);
            List<DataWrapper> parseDataArray = new List<DataWrapper>();

            foreach (string e in exploded)
            {
                parseDataArray.Add(Decode(e));
            }

            return parseDataArray;
        }

        /// <summary>
        /// Retourne le message découpé dans une instance de la structure ParseData
        /// </summary>
        /// <param name="frame">Message formé</param>
        /// <returns></returns>
        public static DataWrapper Decode (string frame)
        {
            if (frame.Contains(NameValueSeparator))
            {
                string[] exploded = frame.Split(NameValueSeparator);
                return new DataWrapper(exploded[0], exploded[1]);
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
    public struct DataWrapper
    {
        private string name;
        private object value;

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
        public object Value
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
        public DataWrapper(string name, object value)
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
            return string.Format("Name: {0}; Value: {1}", this.name, this.value.ToString());
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
