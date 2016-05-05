using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMLDemo
{
    using System.Security.Principal;

    class Program
    {
        static void Main(string[] args)
        {
            var id = WindowsIdentity.GetCurrent();
            Console.WriteLine(id.Name);

            var account = new NTAccount(id.Name);
            var sid = account.Translate(typeof(SecurityIdentifier));
            Console.WriteLine(sid.Value);

            foreach (var group in id.Groups.Translate(typeof(NTAccount)))
            {
                //Console.WriteLine(group.Value);
               // Console.WriteLine(group);
            }

            var principal = new WindowsPrincipal(id);
            Console.WriteLine(principal.IsInRole("Builtin\\Users"));
           var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid,null);
            Console.WriteLine(principal.IsInRole(localAdmins));

            var domainAdmin = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, id.User.AccountDomainSid);
            Console.WriteLine("Domain Admin{0}",domainAdmin);

           



            Console.Read();
        }
    }
}
