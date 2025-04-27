using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_8
{
    public class Purple_3 : Purple
    {
        public (string,char) [] Codes{get;private set; }
        public string Output {get;private set;}
        public Purple_3(string input) : base(input)
        {
            Output = null;
            Codes = new (string, char)[5];
        }
        private char[] FindReplace(char[] ch)
        {
            char[] ans = new char[0];
            for (int i = 32;i<127 && ans.Length !=5;i++)
            {
                if (!ch.Contains((char)i))
                {
                    Array.Resize(ref ans,ans.Length+1);
                    ans[ans.Length-1] = (char)i;
                }
            }
            return ans;
        }
        public override void Review()
        {
            if (_input == null) return;
            string[] pairs = new string[_input.Length /2 +1];
            int[] freq = new int[_input.Length /2 +1];
            int pairCount = 0;
            char[] chars = _input.ToCharArray();
            for (int i =0;i < chars.Length -1;i++)
            {
                if (!char.IsLetter(chars[i]) || !char.IsLetter(chars[i+1])) continue;
                string pair = string.Concat(chars[i],chars[i+1]);
                bool pairExists = false;
                for (int j =0;j<pairCount;j++)
                {
                    if (pairs[j] == pair)
                    {
                        freq[j]++;
                        pairExists = true;
                        break;
                    }
                }
                if (!pairExists)
                {
                    pairs[pairCount] = pair;
                    freq[pairCount] = 1;
                    pairCount++;
                }
            }
            for (int i =0;i<pairCount - 1;i++)
            {
                for (int j =0;j<pairCount - i-1;j++)
                {
                    if (freq[j] < freq[j+1])
                    {
                        int temp = freq[j];
                        freq[j] = freq[j+1];
                        freq[j+1] = temp;
                        string temp2 = pairs[j];
                        pairs[j] = pairs[j+1];
                        pairs[j+1] = temp2;
                    }
                }
            }
            int topPairs = Math.Min(5,pairCount);
            string[] topPairsArray = new string[topPairs];
            Array.Copy(pairs,topPairsArray,topPairs);
            char[] codes = FindReplace(chars);
            StringBuilder outputB = new StringBuilder(_input);
            for (int i =0;i<topPairs;i++)
            {
                outputB.Replace(topPairsArray[i],codes[i].ToString());
            }
            Output = outputB.ToString();
            Codes = new (string,char) [topPairs];
            for (int i =0;i<topPairs;i++)
            {
                Codes[i] = (topPairsArray[i],codes[i]);
            }
        }
        public override string ToString()
        {
            return Output;
        }
    }
}