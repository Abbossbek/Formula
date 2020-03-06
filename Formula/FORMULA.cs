using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula
{
    class FORMULA:MATN
    {
        public FORMULA(string s) : base(s) { }
        bool IsRaqam(char ch)
        {
            switch (ch)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': return true;
                default: return false;
            }
        }
        bool IsButun(string s)
        {
            if (s.Length == 1)
                if (IsRaqam(s[0]))
                    return true;
                else
                    return false;
            else
                if (IsButun(s.Remove(s.Length - 1, 1)) && IsRaqam(s[s.Length - 1]))
                    return true;
                else
                    return false;
        }
        bool IsHarf(char ch)
        {
            if (char.IsLetter(ch))
            {
                return true;
            }
            else
                return false;
        }
        bool IsNom(string s)
        {
            if (s.Length == 1)
                if (IsHarf(s[0]))
                    return true;
                else
                    return false;
            else
                if (IsNom(s.Remove(0, 1)) && IsRaqam(s[0]) || IsNom(s.Remove(s.Length - 1, 1)) && IsHarf(s[s.Length - 1]))
                    return true;
                else
                    return false;
        }
        bool IsTerm(string s){
            if (IsNom(s) || IsButun(s))
                return true;
            else
                return false;
        }
        bool Formula(string s)
        {
            matn = s;
            return IsFormula();
        }
        public bool IsFormula()
        {
            if (matn.Length != 0)
            {
                string s1, s2;
                if (matn[0] != '-' && matn[0] != '+' && matn[0] != '*')
                {
                    int k1 = 0, k2 = 0;
                    while (matn.Length!=0 && (matn[0] == '(' || matn[matn.Length - 1] == ')'))
                    {
                        for (int i = 0; i < matn.Length; i++)
                        {
                            if (matn[i] == '(')
                            {
                                k1++;
                                matn = matn.Remove(i, 1);
                                break;
                            }
                        }
                        for (int i = matn.Length - 1; i >= 0; i--)
                        {
                            if (matn[i] == ')')
                            {
                                k2++;
                                matn = matn.Remove(i, 1);
                                break;
                            }
                        }
                    }
                    if (k1 != k2)
                    {
                        return false;
                    }
                
                }
                if (matn.Length != 0)
                {
                    for (int i = 0; i < matn.Length; i++)
                    {
                        if (matn[i] == '+' || matn[i] == '-' || matn[i] == '*')
                        {
                            s1 = matn.Remove(i, matn.Length - i);
                            s2 = matn.Remove(0, i + 1);
                            if (s1 == "" && matn[i] != '*')
                            {
                                if (Formula(s2))
                                    return true;
                                else
                                    return false;
                            }
                            else
                            {
                                if (Formula(s1) && Formula(s2))
                                    return true;
                                else
                                    return false;
                            }

                        }
                    }
                    if (IsTerm(matn))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
