using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace zachet_shumkova_var5
{
    public partial class Form1 :Form
    {
        List<string> list1 = new List<string>( );
        List<string> list2 = new List<string>( );
        string letter;
        string new_letter;
        Letters l = new Letters( );
        public Form1 ()
        {
            InitializeComponent( );
        }

        private void Form1_Load (object sender, EventArgs e)
        {

        }

        static bool checkFile(string file)
        {
            if ( File.Exists(file) )
            {
                string [ ] lines = File.ReadAllLines(file);
                if ( lines.Length == 0 )
                {
                    MessageBox.Show("Файл пустой");
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Файла не существует");
                return true;
            }
             return true;
        }
        private void button1_Click (object sender, EventArgs e)
        {
            listBox1.Items.Clear( );
            if ( checkFile($"{textBox3.Text}") )
            {
                string [ ] Lines = File.ReadAllLines($"{textBox3.Text}");
                for ( int i = 0; i < Lines.Length; i++ )
                {
                    listBox1.Items.Add(Lines [ i ]);
                }
            }
        }

        private void button2_Click (object sender, EventArgs e)
        {
            listBox1.Items.Clear( );
            letter = textBox1.Text;
            if ( textBox1.Text == "" ) MessageBox.Show("Введите значение", "Ошибка");
            else
            {
                bool check = false;
                for ( int i = 0; i < letter.Length; i++ )
                {
                    if ( Char.IsDigit(letter [ i ]) ) check = true;

                }
                if ( check ) { MessageBox.Show("Введите букву", "Ошибка"); listBox1.Items.Clear( ); }
                string [ ] array = l.del(letter).Split('*');
                for ( int i = 0; i < array.Length; i++ )
                {
                    listBox1.Items.Add(array [ i ]);
                }
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            listBox1.Items.Clear( );
            if ( textBox3.Text.Length != 0 )
            {
                if ( Char.IsLetter(Convert.ToChar(textBox2.Text.Remove(1))) )
                {
                    if ( !listBox1.Items.Contains(textBox2.Text + $": {textBox2.Text.Remove(1).ToLower( )}") )
                    {
                        listBox1.Items.Add(textBox2.Text + $": {textBox2.Text.Remove(1).ToLower( )}");
                    }
                }
            }
            else
                MessageBox.Show("error");
        }
        private void button4_Click (object sender, EventArgs e)
        {
            
            
        }
        string [ ] tovars = File.ReadAllLines($"file.txt");
        private void button4_Click_1 (object sender, EventArgs e)
        {
            listBox1.Items.Clear( );
            var sort = from p in tovars orderby p select p;
            foreach ( var p in sort )
                listBox1.Items.Add(p);
        }
    }
}
