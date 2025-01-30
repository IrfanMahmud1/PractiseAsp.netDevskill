using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.EncapsulateWhatChanges
{
    public class DataService : IDataService
    {
        public string Getdata() => "Fetched data from database";
    }
}
