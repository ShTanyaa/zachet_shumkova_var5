using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zachet_shumkova_var5
{
   public class Letters
    {
        List<string> list1 = new List<string>( );
        List<string> list2 = new List<string>( );
        public string z (string path)
        {
            string st = "";
            if ( File.Exists(path) )
            {
                var lines = File.ReadAllLines(path);
                foreach ( string line in lines )
                {
                    string [ ] s = line.Split(',');
                    for ( int i = 0; i < s.Length; i++ )
                    {
                        string s2 = s [ i ].Substring(0, 1);
                        list1.Add($"{s2}");
                        st += $"{s [i]}:{list1[i]}*";
                    }
                }
            }
            return $"{st}";
        }
        public string del (string letter)//Удаление
        {
            string rez = "";
            string t = "file.txt";
            if ( File.Exists(t) )
            {
                var lines = File.ReadAllLines(t);
                foreach ( string line in lines )
                {
                    string [ ] s = line.Split(',');
                    for ( int i = 0; i < s.Length; i++ )
                    {
                        list2.Add($"{s [ i ]}");
                    }
                }
                Queue<string> listNum = new Queue<string>(list2);
                List<string> list = new List<string>( );
                foreach ( var x in listNum )
                {
                    if ( !x.StartsWith(letter))
                    {
                        list.Add(x);
                    }
                }
                listNum.Clear( );
                listNum = new Queue<string>(list);
                foreach ( var pers in listNum )
                {

                    rez += ($"{pers}*");

                }

            }
            return rez;

        }
        public void add (string sl)//Добавление
        {
            string t = "file.txt";
            if (File.Exists(t))
            {
                var lines = File.ReadAllLines(t);
                list1.Add(sl);
                File.AppendAllLines(t, list1);
            }
        }
    }
}
