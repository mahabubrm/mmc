using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public enum MessageTypes
    {
        
        None = 0,
        Success = 1,
        Warning = 2,
        Error = 3,
        Info=4
        
    }
    public class ReturnMessage
    {
        public string Message { get; set; }
        public MessageTypes MessageType { get; set; }

        public ReturnMessage()
        {
            Message = string.Empty;
            MessageType = MessageTypes.None;
        }

        public static ReturnMessage SetSuccessMessage(string message = "Information Save Successfully.")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Success;
            msg.Message = message;

            return msg;
        }

        public static ReturnMessage SetDeleteSuccessMessage(string message = "Information Deleted Successfully.")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Success;
            msg.Message = message;

            return msg;
        }

        public static ReturnMessage SetUpdateSuccessMessage(string message = "Information Updated Successfully.")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Success;
            msg.Message = message;

            return msg;
        }
        public static ReturnMessage SetErrorMessage(string message = "Failed to save data.")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Error;
            msg.Message = message;
            return msg;
        }
        public static ReturnMessage SetInfoMessage(string message = "Information")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Info;
            msg.Message = message;
            return msg;
        }
        public static ReturnMessage SetWarningMessage(string message = "Warning")
        {
            var msg = new ReturnMessage();
            msg.MessageType = MessageTypes.Warning;
            msg.Message = message;
            return msg;
        }
    }
}
