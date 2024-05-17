using Mwc.Core.Models;
using Mwc.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Net.Mime.MediaTypeNames;

namespace Mwc.Core.UtilityClassLib
{
    public class SqlQryManager
    {
        MWCEntities context;


        public SqlQryManager()
        {
            context = new MWCEntities();
        }

        public string GetTransactionNo()
        {
            return context.Database.SqlQuery<string>("SELECT CAST(DATEPART(year, GETDATE()) as char(4)) + CAST(right('00' + convert(varchar(2),month(getdate())),2) as char(2))+ CAST(right('00' + convert(varchar(2),day(getdate())),2) as char(2)) + CAST(DATEPART(hour,GETDATE()) as varchar(2)) + CAST(DATEPART(minute,GETDATE()) as varchar(2)) + CAST(DATEPART(second,GETDATE()) as varchar(2)) + CAST(DATEPART(millisecond,GETDATE()) as varchar(3))").First();
        }

    }
}
