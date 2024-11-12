using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesignPatternApp
{

    public class Complex : ICloneable
    {
        public int real;
        public int imaginary;
        public Complex(){
            real = imaginary=0;}

        public Complex(int r , int i)
        {
            this.real = r;
            this.imaginary = i;
        }

        public object Clone()
        {
            Complex temp = new Complex();
            temp.real = this.real;
            temp.imaginary= this.imaginary;
            return temp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Complex c = new Complex(1, 2);
            Complex c2 = (Complex)c.Clone();    // only one object object is created on heap , but there are 2 references on stack
            Console.WriteLine(c.real + "," +c.imaginary);
            Console.WriteLine(c2.real + "," + c2.imaginary);

            Console.ReadLine();


            //OfficeBoy waiter  = OfficeBoy.Create();
            //OfficeBoy admin = OfficeBoy.Create();
        }
    }
}
