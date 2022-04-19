using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// An exception as reported by the remote server
    /// </summary>
    public class VTigerApiException : Exception
    {
        internal VTigerApiException(VTigerError apiError)
        {
            this.VTigerErrorCode = apiError.code;
            this.VTigerMessage = apiError.message;
            /*
            if ((apiError.code == null) || (apiError.code == ""))
            {
                this.Message = "UNKNOWN ERROR: " + apiError.message;
            }
            else
            {
                this.Message = apiError.code + ": " + apiError.message;
            }
            */
        }
        /// <summary>
        /// The error code as defined by the VTiger remote server
        /// </summary>
        public string VTigerErrorCode;
        /// <summary>
        /// A human readable error message from the VTiger remote server
        /// </summary>
        public string VTigerMessage;
        /// <summary>
        /// The full message from the VTiger remote server (error code + human readable message)
        /// </summary>
        public override string Message
        {
            get
            {
                if ((this.VTigerErrorCode == null) || (this.VTigerErrorCode == ""))
                {
                    return "UNKNOWN ERROR: " + this.VTigerMessage;
                }
                else
                {
                    return this.VTigerErrorCode + ": " + this.VTigerMessage;
                }
            }
        }

    }
    //=========
}
