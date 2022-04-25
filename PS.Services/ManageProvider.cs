using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
    class ManageProvider
    {
        public List<Provider> providers { get; set; } = new List<Provider>();
        /**
         *  retourne la liste des providers dont le nom
            contient name.
         */
        public List<Provider> GetProviderByName(string name)
        {
            /*
             * besh nekhdmou bel linq
             * par défaut yraja3 IEnumerable alors nzidoha .ToList() 
             * ILink  -> ICollection ( 3andha l crud) -> IEnumerable ( sért a parcourir) 
             */
            //List<Provider> req = (from p in providers
            //                      where p.UserName.Contains(name)
            //                      select p).ToList();

            //return req;

            //avec lambda 
            var req2 = providers.Where(p => p.UserName.Contains
            (name));

            return req2.ToList();
        }


        public List<String> GetProviderEmailsByName(string name)
        {
            //List<String> req = (from p in providers
            //                    where p.UserName.Contains(name)
            //                    select p.UserName).ToList();
            //return req;
            var req2 = providers.Where(p => p.UserName.Contains
            (name)).Select(p => p.Email);

            return req2.ToList();
        }

        public void DisplayUsernameAndEmail(string name)
        {
            var req = (from p in providers
                       where p.UserName.Contains(name)
                       select (p.UserName, p.Email)).ToList();
            foreach (var p in req)
                Console.WriteLine(p);
        }

        public Provider GetFirstProviderByName(string name)
        {
            var req = (from p in providers
                       where p.UserName.StartsWith(name)
                       select (p)).ToList();
            return req.First();
        }

    }
}
