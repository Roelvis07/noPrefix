using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noPrefix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //List<string> arr = new List<string> { "abcd", "bcd", "abcde", "bcde" }; //BAD SET
            //List<string> arr = new List<string> { "ab", "bc", "cd" }; //GOOD SET
            //List<string> arr = new List<string> { "aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad" }; //BAD SET
            List<string> arr = new List<string> { "aab", "aac", "aacghgh", "aabghgh" }; //BAD SET aacghgh

            noPrefix(arr);
        }
        /*
         * Complete the 'noPrefix' function below.
         *
         * The function accepts STRING_ARRAY words as parameter.
         */

        public static void noPrefix1(List<string> words)
        {
            int index = words.Count;

            for (int i = 0; i < words.Count - 1; i++)
            {
                for (int j = i+1; j < words.Count; j++)
                {
                    if (words[i].Contains(words[j]))
                    {
                        if (index > j)
                        {
                            index = j;
                        }
                    }
                    else if(words[j].Contains(words[i]))
                    {
                        if (index > i)
                        {
                            index = j;
                        }
                    }
                }
                
            }
            
            Console.WriteLine(index == -1 ? "GOOD SET" : "BAD SET");
            Console.WriteLine(index == -1 ? "" : words[index]);
        }
        public static void noPrefix(List<String> words)
        {
            // here is the solution which worked for me in hackerrank. let me know if any 
            // better suggestion
            HashSet<String> hashSet = new HashSet<String>();
            
            foreach (String curr in words)
            {
                if (hashSet.Count > 1)
                {
                    foreach (String value in hashSet)
                    {
                        if (curr.Contains(value)
                        && curr.StartsWith(value))
                        {
                            Console.WriteLine("BAD SET");
                            Console.WriteLine(curr);
                            return;
                        }
                    }
                }
                hashSet.Add(curr);
            }
            Console.WriteLine("GOOD SET");
        }
    }
}
