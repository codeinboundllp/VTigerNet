using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// A session timeout at the server may required to re-logon again
    /// </summary>
    public class VTigerApiSessionTimedOutException : VTigerApiException
    {
        internal VTigerApiSessionTimedOutException(VTigerError apiError) : base(apiError)
        {
            base.VTigerErrorCode = apiError.code;
            base.VTigerMessage = apiError.message;
        }
    }
}
