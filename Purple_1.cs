using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;
        private static char[] punct = new char[] {'.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        private static char[] number = "0123456789".ToArray();
        public Purple_1(string input) : base(input) { }
        private  static bool ItWord(string a)
        {
            foreach(char b in a)
            {
                if (b!= '\'' && b != '-' && (punct.Contains(b) || number.Contains(b)))
                {
                    return false;
                }
            }
            return true;
        }
        public override void Review()
        {
            if (_input == null) return;
            var a = _input.Split(punct.Append(' ').ToArray());
            var res = new StringBuilder();
            int ind = -1;
            for (int i =0;i<a.Length;i++)
            {
                if (ItWord(a[i]))
                {
                    res.Append(a[i].Reverse().ToArray());
                }
                else 
                {
                    res.Append(a[i]);
                }
                ind+=a[i].Length +1;
                if (ind < _input.Length)
                {
                    res.Append(_input[ind]);
                }
            }
            _output = res.ToString();
        }
        public override string ToString()
        {
            return _output;
        }
    }
}