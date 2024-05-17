using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public class UserLogin
    {
        public int MemberSubject { set; get; }
        public int MemberBatchNo { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
