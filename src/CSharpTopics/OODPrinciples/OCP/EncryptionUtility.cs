using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.OCP 
{
    public class MD5EncryptionUtility : IEncryptionProcess
    {
        private const string _encryptionhash = "12fedfdf";
        public string EncryptPassword(string password)
        {
            // uses MD5 hashing algorithm
            throw new NotImplementedException();
        }
    }
}
