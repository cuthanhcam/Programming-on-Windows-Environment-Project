using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace BUS.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var dt = new DataTable();

            // Lấy tất cả các thuộc tính của kiểu T
            PropertyInfo[] props = typeof(T).GetProperties();

            // Thêm cột vào DataTable dựa trên tên thuộc tính
            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Thêm dữ liệu vào DataTable
            foreach (var item in items)
            {
                var row = dt.NewRow();
                foreach (var prop in props)
                {
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}