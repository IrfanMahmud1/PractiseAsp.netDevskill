using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.OCP
{
    public class SHA256EncryptionUtility : IEncryptionProcess
    {
        public string EncryptPassword(string password)
        {
            // uses SHA256 hashing algorithm
            throw new NotImplementedException();
        }
    }
}
