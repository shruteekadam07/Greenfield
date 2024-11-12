using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty;
using Taxation;
using Accounts;
using Delegation;

namespace CsharpFeatureApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //object creation
            Accounting acct = new Accounting(15000);
            //event registration
            acct.underBalance += PenaltyHandler.ServiceDisconnectionPenaltyCharges;
            acct.underBalance += PenaltyHandler.NotificationPenaltyCharges;
            acct.overBalance += TaxHandler.PayIncomeTax;
            //object invocation
            //acct.Withdraw(8000);

            acct.Deposit(300000);

            // Compile time , early binding,static linking
            /* Handler.PayIncomeTax();
            Handler.PayProfessionalTax();
            Handler.PayServiceTax();
            Handler.PayGST();*/


            //register method with delegate instance ,, runtime 
           /* Operation opn1=new Operation(TaxHandler.PayProfessionalTax);
            Operation opn2 = new Operation(TaxHandler.PayServiceTax);
            Operation opn3 = new Operation(TaxHandler.PayGST);


            Operation masterOperation = null;
            masterOperation += opn1;
            masterOperation += opn2;
            masterOperation += opn3;

            masterOperation.Invoke(56);
            //opn1.Invoke(30);
            //opn2.Invoke(20);
            //opn3.Invoke(12);

            masterOperation -= opn1;
            Console.WriteLine("After detachment");
            masterOperation.Invoke(56);*/

            Console.ReadLine();

        }
    }
}
