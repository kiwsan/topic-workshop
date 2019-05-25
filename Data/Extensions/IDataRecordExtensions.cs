using System;
using System.Data;

namespace Data.Extensions
{
    public static class IDataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord record, string name)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.GetName(i).Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}