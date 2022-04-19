using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    public class VTigerResult<T>
    {
        public bool success;
        public VTigerError error;
        public T result;
    }
}
