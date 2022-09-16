using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Classes
{
    class LongNumber
    {
        private string _number;
        public string Number
        {
            get
            {
                return _number;
            }
            private set
            {
                _number = value;
            }
        }


        public void Print()
        {
            Console.WriteLine(Number);
        }


        public LongNumber(LongNumber obj)
        {
            _number = obj._number;
        }
        public LongNumber(Object value)
        {
            if (value is not null)
                _number = (string)value;
            else
                _number = "0";
        }
        public LongNumber(string value)
        {
            if (value is not null)
                _number = value;
            else
                _number = "";
        }




        public override bool Equals(object? obj)
        {
            if (obj is not null)
                return Equals(obj as LongNumber);
            else
                return false;
        }
        public bool Equals(LongNumber other)
        {
            if (other._number is null)
                return false;
            if (_number.CompareTo(other._number) == 0)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }

        public static bool operator ==(LongNumber a, LongNumber b)
        {
            if (Equals(a, b))
                return true;
            else
                return false;
        }
        public static bool operator !=(LongNumber a, LongNumber b)
        {
            if (!Equals(a, b))
                return true;
            else
                return false;
        }




        public static LongNumber operator +(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");
            result.Number = FindSum(a.Number, b.Number);
            return result;
        }
        public static LongNumber operator *(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");
            result.Number = FindMult(a.Number, b.Number);
            return result;
        }
        public static LongNumber operator -(LongNumber a, LongNumber b)
        {
            LongNumber result = new LongNumber("");
            result.Number = FindDiff(a.Number, b.Number);
            return result;
        }
        public static LongNumber operator /(LongNumber a, LongNumber b)
        {
            BigInteger divisor = 0;
            LongNumber result = new LongNumber("");
            try
            {
                divisor = BigInteger.Parse(b._number);
            }
            catch(OverflowException)
            {
                divisor = 18446744073709551615;
            }
            result.Number = FindDiv(a.Number, divisor);
            return result;
        }


        private static string FindDiv(string number, BigInteger divisor)
        {
            string result = "";

            int idx = 0;
            BigInteger temp = (int)(number[idx] - '0');
            while (temp < divisor)
            {
                temp = temp * 10 + (int)(number[idx + 1] - '0');
                idx++;
            }
            ++idx;

            while (number.Length > idx)
            {
                result += (char)(temp / divisor + '0');

                temp = (temp % divisor) * 10 + (int)(number[idx] - '0');
                idx++;
            }
            result += (char)(temp / divisor + '0');

            if (result.Length == 0)
                return "0";

            return result;
        }

        private static string FindSum(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                string temp = str1;

                str1 = str2;
                str2 = temp;
            }

            string result = "";

            int n1 = str1.Length, n2 = str2.Length;
            int diff = n2 - n1;
            int carry = 0;

            for (int i = n1 - 1; i >= 0; i--)
            {
                int sum = ((int)(str1[i] - '0') + (int)(str2[i + diff] - '0') + carry);

                result += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            for (int i = n2 - n1 - 1; i >= 0; i--)
            {
                int sum = ((int)(str2[i] - '0') + carry);

                result += (char)(sum % 10 + '0');
                carry = sum / 10;

            }

            if (carry > 0)
                result += (char)(carry + '0');

            char[] ch2 = result.ToCharArray();
            Array.Reverse(ch2);

            return new string(ch2);
        }

        private static string FindMult(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            if (len1 == 0 || len2 == 0)
                return "0";

            int[] result = new int[len1 + len2];

            int i_n1 = 0;
            int i_n2 = 0;
            int i;

            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = str1[i] - '0';

                i_n2 = 0;
          
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int n2 = str2[j] - '0';
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;
                    carry = sum / 10;
                    result[i_n1 + i_n2] = sum % 10;
                    i_n2++;
                }
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;
                i_n1++;
            }

            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            if (i == -1)
                return "0";

            String s = "";

            while (i >= 0)
                s += (result[i--]);

            return s;
        }

        private static bool Lesser(string str1, string str2)
        {
            int n1 = str1.Length, n2 = str2.Length;

            if (n1 < n2)
                return true;
            if (n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
            {
                if (str1[i] < str2[i])
                    return true;
                else if (str1[i] > str2[i])
                    return false;
            }
            return false;
        }
        private static string FindDiff(string str1, string str2)
        {
            bool lesser = false;

            if (Lesser(str1, str2))
            {
                string t = str1;
                str1 = str2;
                str2 = t;
                lesser = true;
            }
            string result = "";

            int n1 = str1.Length, n2 = str2.Length;
            int diff = n1 - n2;

            int carry = 0;

            for (int i = n2 - 1; i >= 0; i--)
            {
                int sub = (((int)str1[i + diff] - (int)'0')
                           - ((int)str2[i] - (int)'0') - carry);
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result += sub.ToString();
            }

            for (int i = n1 - n2 - 1; i >= 0; i--)
            {
                if (str1[i] == '0' && carry > 0)
                {
                    result += "9";
                    continue;
                }
                int sub = (((int)str1[i] - (int)'0') - carry);
                if (i > 0 || sub > 0)
                    result += sub.ToString();
                carry = 0;
            }

            char[] aa = result.ToCharArray();
            Array.Reverse(aa);
            result = new string(aa);
            if (lesser)
                result = result.Insert(0, "-");
            return result;
        }




        public static implicit operator LongNumber(int num)
        {
            return new LongNumber(System.Convert.ToString(num));
        }
        public static implicit operator LongNumber(long num)
        {
            return new LongNumber(System.Convert.ToString(num));
        }
        public static implicit operator LongNumber(short num)
        {
            return new LongNumber(System.Convert.ToString(num));
        }
        public static implicit operator LongNumber(bool num)
        {
            return new LongNumber(System.Convert.ToString(num));
        }
        public static implicit operator LongNumber(string str)
        {
            return new LongNumber(str);
        }

        public static explicit operator int(LongNumber obj)
        {
            try
            {
                return System.Convert.ToInt32(obj._number);
            }
            catch(System.OverflowException)
            {
                if (obj._number[0] != '-')
                    return Int32.MaxValue;
                else
                    return Int32.MinValue;
            }
        }

        public static explicit operator long(LongNumber obj)
        {
            try
            {
                return System.Convert.ToInt64(obj._number);
            }
            catch (System.OverflowException)
            {
                if (obj._number[0] != '-')
                    return Int64.MaxValue;
                else
                    return Int64.MinValue;
            }
        }

        public static explicit operator short(LongNumber obj)
        {
            try
            {
                return System.Convert.ToInt16(obj._number);
            }
            catch (System.OverflowException)
            {
                if (obj._number[0] != '-')
                    return Int16.MaxValue;
                else
                    return Int16.MinValue;
            }
        }

        public static explicit operator bool(LongNumber obj)
        {
            try
            {
                int a = System.Convert.ToInt32(obj._number);
                if (a < 0)
                    return false;
                bool b = System.Convert.ToBoolean(a);
                return b;
            }
            catch (System.OverflowException)
            {
                if (obj._number[0] != '-')
                    return true;
                else
                    return false;
            }
            catch (System.FormatException)
            {
                bool flag;
                if (bool.TryParse(obj._number, out flag))
                    return bool.Parse(obj._number);
                else
                    return false;
            }
        }
    }
}
