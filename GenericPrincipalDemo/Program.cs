using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPrincipalDemo
{
    using System.Security.Principal;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            SetupPrincipal();
            UsePrincipal();
            Console.Read();
        }

        private static void SetupPrincipal()
        {
            //Authenticate your client
            var id = new GenericIdentity("bob");

            //fetch roles
            var roles = new string[] {"Development","Marketing"};
            var p = new GenericPrincipal(id,roles);
            Thread.CurrentPrincipal = p;
        }

        private static void UsePrincipal()
        {
            var p = Thread.CurrentPrincipal;
            Console.WriteLine("Identity is: {0}",p.Identity.Name);
            Console.WriteLine("Role is: {0}",p.IsInRole("Development"));

        }
    }
}
