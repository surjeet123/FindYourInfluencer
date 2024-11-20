using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models.Utilities
{
    public class HashedEncryptionModel
    {
        public string HashedValue { get; set; }
        public string Salt { get; set; }
    }
}
