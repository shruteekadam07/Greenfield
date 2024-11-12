using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxation
{
    public static class TaxHandler
    {
        public static void PayIncomeTax(float factor)
        {
            Console.WriteLine("Income tax" + factor + " has been deducted from your account !! ");
        }

        public static void PayServiceTax(float factor)
        {
            Console.WriteLine("Service tax" + factor + " has been deducted from your account !! ");

        }

        public static void PayProfessionalTax(float factor)
        {
            Console.WriteLine("Professiona tax " + factor + " has been deducted from your account !! ");

        }

        public static void PayGST(float factor)
        {
            Console.WriteLine("GST " + factor + " has been deducted from your account !! ");

        }
    }

}
