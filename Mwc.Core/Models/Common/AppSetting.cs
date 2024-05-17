using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public class AppSetting
    {
        public static string Session { get; set; }
        public const string LoginError = "LoginError";

        public static string WebAddress { get; set; }
        public static string ActivationLink { get; set; }
        public static string EmailSubject { get; set; }
        public static string EmailSubjectForTransaction { get; set; }
        public static string EmailSubjectForChangePassword { get; set; }
        public static string NormalReturnUrl { get; set; }
        public static string SecretKey { get; set; }
    }
}
