using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.Models.Common
{
    public static class AppConstant
    {
        public enum ApprovalStatus
        {
            Draft,
            Pending,
            InProgress,
            Approved,
            Rejected,
            Return
        }       
        
        public enum BillApprovalStatus
        {
            Pending,
            Waiting,
            Approved,
            Rejected,
            Cancel
        }

        public enum PaymentStatus
        {
            Due,
            Paid,
            Cancel
        }

        public enum ElectionCandidateApplicationStatus
        {
            Draft,
            Approved,
            Rejected,
            Withdrawal
        }

        public enum VoteResultStatus
        {            
            Approved,
            Rejected
        }
    }
}
