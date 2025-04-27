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
            if (line.Length == 50) return line;
            int k = line.Count(x => x == ' ');
            if (k == 0) return line;
            int toEO = (50 - line.Length) / k;
            int extra = (50 - line.Length) % k;
            string add = "";
            for (int i =0;i<toEO;i++)
            {
                add+= " ";
            }
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
            var remText = _input.Trim();
            while (remText.Length > 50)
            {
                var a = remText.Substring(0,51);
                var lastSpace = a.LastIndexOf(' ');
                if (lastSpace < 0)
                {
                    _output = _output.Append(remText).ToArray();
                    remText = string.Empty;
                    break;
                }
                else{
                    _output = _output.Append(FormatOnWidth(a.Substring(0,lastSpace))).ToArray();
                    remText = remText.Substring(lastSpace + 1).TrimStart();
                }
            }
            if (remText.Length > 0)
            {
                _output = _output.Append(FormatOnWidth(remText)).ToArray();
            }
        }
        public override string ToString()
        {
            if (_output == null) return null;
            return string.Join(Environment.NewLine,_output);
        }
    }
}