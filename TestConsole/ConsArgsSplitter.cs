using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Null.Library
{
    public class ConsArgsSplitter
    {
        public static List<string> Split(string cmdline)
        {
            List<string> rstBulder = new List<string>();
            StringBuilder temp = new StringBuilder();
            bool escape = false, quote = false;

            foreach (char i in cmdline)
            {
                if (escape)
                {
                    escape = false;
                    switch(i)
                    {
                        case 'a':
                            temp.Append('\a');
                            break;
                        case 'b':
                            temp.Append('\b');
                            break;
                        case 'f':
                            temp.Append('\f');
                            break;
                        case 'n':
                            temp.Append('\n');
                            break;
                        case 'r':
                            temp.Append('\r');
                            break;
                        case 't':
                            temp.Append('\t');
                            break;
                        case 'v':
                            temp.Append('\v');
                            break;
                        default:
                            temp.Append(i);
                            break;
                    }
                }
                else
                {
                    if (i == '\\')
                    {
                        escape = true;
                    }
                    else
                    {
                        if (quote)
                        {
                            if (i == '"')
                            {
                                rstBulder.Add(temp.ToString());
                                temp.Clear();
                                quote = false;
                            }
                            else
                            {
                                temp.Append(i);
                            }
                        }
                        else
                        {
                            if (i == '"')
                            {
                                rstBulder.Add(temp.ToString());
                                temp.Clear();
                                quote = true;
                            }
                            else if (i == ' ')
                            {
                                if (temp.Length > 0)
                                {
                                    rstBulder.Add(temp.ToString());
                                    temp.Clear();
                                }
                            }
                            else
                            {
                                temp.Append(i);
                            }
                        }
                    }
                }
            }
            if (temp.Length > 0)
            {
                rstBulder.Add(temp.ToString());
            }

            return rstBulder;
        }
    }
}
