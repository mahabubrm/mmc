using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mwc.Core.UtilityClassLib
{
    public static class UtilityManager
    {

        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            foreach (PropertyInfo pi in pia)
            {
                dt.Columns.Add(pi.Name, Nullable.GetUnderlyingType(
                pi.PropertyType) ?? pi.PropertyType);
            }

            foreach (T item in collection)
            {

                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null);
                }

                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static DataTable ToSingleDataTable<T>(T entity) where T : class
        {
            var properties = typeof(T).GetProperties();
            var table = new DataTable();

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
            }

            table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
            return table;
        }

        //public static bool RecycleApplicationPool(string siteName = null)
        //{
        //    // EDIT: thanks to Emir Krkic for the suggestion below! 
        //    // ref.: https://www.ryadel.com/en/asp-net-c-recycle-net-web-applications-app-pool-programmatically-iis/#comment-1552
        //    // if (siteName == null) siteName = HostingEnvironment.ApplicationHost.GetSiteName();
        //    if (siteName == null) siteName = System.Web.Hosting.HostingEnvironment.SiteName;
        //    using (ServerManager iisManager = new ServerManager())
        //    {
        //        SiteCollection sites = iisManager.Sites;
        //        foreach (Site site in sites)
        //        {
        //            if (site.Name == siteName)
        //            {
        //                iisManager.ApplicationPools[site.Applications["/"].ApplicationPoolName].Recycle();
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}


        //public static DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
