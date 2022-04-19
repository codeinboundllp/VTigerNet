using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    public class VTigerEntity
    {
        public VTigerType elementType { get { return GetElementType(); } }
        public virtual VTigerType GetElementType()
        {
            return VTigerType.Undefined;
        }
        public virtual string RemoteTableName()
        {
            return null;
        }
        public virtual VTigerEntity CreateNewInstance()
        {
            return new VTigerEntity();
        }
        public string id;
    }
}
