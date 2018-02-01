﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPackage
{
    namespace Parser
    {

        /// <summary>
        /// Représente une donnée parsée.
        /// </summary>
        public class DataWrapper
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
}
