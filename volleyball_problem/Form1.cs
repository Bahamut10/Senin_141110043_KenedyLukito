using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace volleyball_problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         long mod = 1000000007;
        long check(int a, int b)
        {
            if (a < b)
            {
                int temp;
                temp = a;
                a = b;
                b = temp;
            }
            if (Math.Abs(a - b) < 2) return 0;
            else if (a > 25 && Math.Abs(a - b) > 2) return 0;
            else if (a < 25) return 0;
            else return 1;
        }
        private long combination(int a, int b, long mod)
        {
            if (a < b) return 0;
            long combi = 1;
            combi *= factor(a, mod);
            combi %= mod;
            combi *= modInverse(factor(b, mod), mod);
            combi %= mod;
            combi *= modInverse(factor(a - b, mod), mod);
            combi %= mod;
            return combi;
        }
        private long factor(int n, long mod)
        {
            long m = 1;
            for (int i = 1; i <= n; i++)
            {
                m *= i;
                m %= mod;
            }
            return m;

        }
        private long power(long x, int y, long mod)
        {
            long temp;
            if (y == 0)
                return 1;
            temp = power(x, y / 2, mod);
            if (y % 2 == 0)
                return (temp * temp) % mod;
            else
            {
                if (y > 0)
                    return (x * temp * temp) % mod;
                else
                    return ((temp * temp) / x) % mod;
            }
        }
        private long modInverse(long val, long mod)
        {
            long m0 = mod, t, q;
            long x0 = 0, x1 = 1;
            if (mod == 1)
                return 0;

            while (val > 1)
            {
                q = val / mod;
                t = mod;
                mod = val % mod;
                val = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }
            if (x1 < 0)
                x1 += m0;

            return x1 % m0;
        }
        private void BtnHitung_Click(object sender, EventArgs e)
        {
            int a, b;
            long combi;
            a = Convert.ToInt32(Txt1.Text);
            b = Convert.ToInt32(Txt2.Text);
            if (check(a, b) == 0) combi = 0;
            else
            {
                if (a < b)
                {
                    int temp;
                    temp = a;
                    a = b;
                    b = temp;
                }
                combi = (combination((a + b - 1 < 47) ? (a + b - 1) : 47, (a - 1 < 24) ? (a) : 24, mod) * power(2, a - 25, mod)) % mod;
            }
            TxtHasil.Text = combi.ToString();
        }
    }
}
