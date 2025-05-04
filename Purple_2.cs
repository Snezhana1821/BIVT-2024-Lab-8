using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output;
        public string[] Output => _output;
        public Purple_2 (string input) : base(input) { }
        private string FormatOnWidth(string line)
        {
            int k = line.Count(x => x == ' ');
            if (k == 0) return line;
            int toEO = (50 - line.Length) / k;
            int extra = (50 - line.Length) % k;
            string add = new string (' ', toEO);
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i<line.Length;i++)
            {
                if (line[i] == ' ')
                {
                    if (extra > 0)
                    {
                        ans.Append(' ');
                        extra--;
                    }
                    ans.Append(add);
                }
                ans.Append(line[i]);
            }
            return ans.ToString();
        }
        public override void Review()
        {
            if (_input == null) return;
            _output= new string[0];
            string remText = _input;
            while (remText.Length > 0)
            {
                int a = Math.Min(50, remText.Length);
                if (a == remText.Length)
                {
                    _output = _output.Append(FormatOnWidth(remText)).ToArray();
                    break;
                }
                while (a >=0 && remText[a] != ' ') a--;
                if (a == -1) a =50;
                _output = _output.Append(FormatOnWidth(remText.Substring(0,a))).ToArray();
                remText = remText.Substring(a + 1);
                
            }
        }
        public override string ToString()
        {
            if (Output == null)  return null;
            string answ = "";
            for(int i = 0; i<Output.Length-1; i++)
            {
                answ += Output[i]+"\r\n";
            }
            answ += Output[Output.Length-1];
            return answ;
        }
    }
}
