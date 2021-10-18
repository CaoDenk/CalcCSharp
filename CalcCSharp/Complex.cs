using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCSharp
{
    class Complex
    {
        public double real, imag;
        public Complex(double real)
        {
            this.real = real;
        }
        public Complex() { }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex
            {

                real = c1.real + c2.real,
                imag = c1.imag + c2.imag

            };
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex
            {

                real = c1.real - c2.real,
                imag = c1.imag - c2.imag

            };
        }
        public static Complex operator *(Complex c1, Complex c2)
        {

            if (c1.imag == 0 && c2.imag == 0)//都是实数，不用使用复数计算
            {
                return new Complex
                {
                    real = c1.real * c2.real

                };
            }
             return new Complex//
             {
                real = c1.real * c2.real - c1.imag * c2.imag,
                imag = c1.real * c2.imag + c1.imag * c2.real
            };
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex complex = new Complex
            {
                real = c1.real * c2.real + c1.imag * c2.imag,
                imag = c1.imag * c2.real - c1.real * c2.imag
            };
            double div = c2.real * c2.real + c2.imag * c2.imag;
            complex.real /= div;
            complex.imag /= div;
            return complex;
        }
        public static Complex operator ^(Complex c1, Complex c2)
        {

            if(c1.imag==0&&c2.imag==0)
            {

                return new Complex
                {
                    real = Math.Pow(c1.real, c2.real)

                };

            }
            //if(c2.imag==0)
            //{
                

            //}

           ExpComplex e=  (new ExpComplex(c1)) ^ c2;

            return e.toComplex();
        }
        public override string ToString()
        {
            double showReal=0,showImag=0;//用于显示
            if(Math.Abs(real)>=0.000000001)//如果小于十亿分之一，就显示为0
            {
                showReal = real;
            }
            if (Math.Abs(imag) < 0.000000001)
            {
                return string.Format("{0}", showReal);
            }else
            {
                return string.Format("{0}+{1}i", showReal, showImag);
            }
        }

    }
    class ExpComplex
    {
        double theta;
        double r;//r是系数,或者距离
        public ExpComplex(Complex c)
        {
            r = Math.Sqrt(c.real * c.real + c.imag * c.imag);

            if(c.real==0)
            {
                theta = Math.PI / 2;
            }else
                theta = Math.Atan(c.imag / c.real);

        }
        public ExpComplex() { }
        public static ExpComplex operator ^(ExpComplex c1,ExpComplex c2)
        {

            return new ExpComplex
            {

                r = c1.r * c2.r,
                theta = c1.theta + c2.theta
            };
        }
        public static ExpComplex operator ^(ExpComplex c1, Complex c)
        {
            // c*e^
            if(c.imag==0)
            {
                return new ExpComplex
                {

                    r = c1.r,
                    theta = c1.theta * c.real
                };

            }else
            {
                Complex tmp = new Complex { imag = c1.theta };
                Complex res = tmp * c;
                return new ExpComplex
                {
                    r = c1.r * Math.Exp(res.real),
                    theta = res.imag
                };

            }

          
        }
        public Complex toComplex()
        {

            return new Complex
            {
                real = r * Math.Cos(theta),
                imag = r * Math.Sin(theta)

            };

        }
      
       



    }
    enum Func
    {
        SIN,
        COS,       

    }
    class Calcu
    {

        public static Complex calcFun(Func func, Stack<Complex> complices)
        {
            switch(func)
            {
                case Func.SIN:
                    Complex c=  complices.Pop();


                    break;





            }



            return null;
        }


        public static Complex sin(Complex c)
        {
            //if(c.imag==0)

            //e^i(bi) =cos(bi) +isin(bi)
            // e^(-b) =cos(bi) +isin(bi) 
            //e^i(-bi) =cos(-bi)+isin(-bi)
            //e^(-b)+e^b =2cos(bi)
            //cos(bi) =(e^b+e^(-b))/2
            //sin(bi) =(e^b-e^(-b))/2
            //如果是复数计算 sin(a+bi)
            //sinacos（bi）+sin（bi）cosa
            //sina
            double sina = Math.Sin(c.real);
            double cosa = Math.Cos(c.real);
            double cosbi = (Math.Exp(c.imag) + Math.Exp(-c.imag)) / 2;
            double sinbi = (Math.Exp(c.imag) - Math.Exp(-c.imag)) / 2;

            return new Complex(sina * cosbi + sinbi * cosa);
 
        }


    }




   
}
