using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_8
{
    public class Purple_4 : Purple
    {
        public string Output{get;private set;}
        private (string, char) [] _codes;
        public Purple_4(string input, (string,char)[] codes) : base(input)
        {
            Output = null;
            _codes = codes;
        }
        public override void Review()
        {
            if (Input == null) return;
            Output = "";
            string text = string.Copy(Input);
            for (int i =0;i<_codes.Length;i++)
            {
                text = text.Replace(_codes[i].Item2.ToString(), _codes[i].Item1);
            }
            Output = string.Copy(text.ToString());
        }
        public override string ToString()
        {
            return Output;
        }
    }
}