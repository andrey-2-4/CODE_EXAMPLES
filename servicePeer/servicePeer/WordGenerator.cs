using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicePeer
{
    /// <summary>
    /// Класс для генерации слова.
    /// </summary>
    public class WordGenerator
    {
        /// <summary>
        /// Метод для генерации слова.
        /// </summary>
        /// <returns> Случайное слово.</returns>
        public static string GetWord()
        {
            Random rnd = new();
            var count = rnd.Next(1, 11);
            char[] letters = new char[count];
            for (int i = 0; i < count; i++)
            {
                letters[i] = (char)rnd.Next('a', 'z' + 1);
            }
            return new string(letters);
        }
    }
}
