using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    [DataContract]
    public class DBdata
    {
        [DataMember]
        public DataTable GetorSetTable { get; set; }
    }
}
