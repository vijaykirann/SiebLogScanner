using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.Collections;

namespace AdvancedSiebelLogScanner
{
    public class ErrorMsg : IEnumerable
    {
        [BsonId]
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Solution { get; set; }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }

}
