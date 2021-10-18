using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCSharp
{
    class CheckExpression
    {
        string un = "])}";//第一次出现时抛异常
        string value;
        Dictionary<char, char> dir = new Dictionary<char, char>() 
        {
                {'(',')' },
                {'{','}' },
                {'[',']' },
        };
        public CheckExpression(string value)
        {
            this.value = value;
        }
        public bool check()
        {
            int i = 0;
            for (; i < value.Length; i++)
            {
                if (un.Contains(value[i]))
                {
                    throw new Exception(value[i] + " is illegal");
                }
                if (dir.Keys.Contains(value[i]))
                {
                    parse(ref i, dir[value[i]]);
                }
            }
            return true;
        }

        void parse(ref int i, char c)
        {
            i++;
            for (; i < value.Length; i++)
            {
                if (value[i] == c)
                    return;
                if (un.Contains(value[i]))
                {
                    throw new Exception(c + " is illegal");
                }
                if (dir.Keys.Contains(value[i]))
                {
                    parse(ref i, dir[value[i]]);
                }
            }
            throw new Exception(c + " Not Found");

        }


    }
}
