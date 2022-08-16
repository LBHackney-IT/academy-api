using System;
using System.Data.Common;

namespace AcademyApi.V1.Gateways;

public static class SqlHelpers
{
    public static string SafeGetString(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetString(colIndex);
        return string.Empty;
    }
    public static int SafeGetInt(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetInt32(colIndex);
        return 0;
    }

    public static decimal SafeGetDecimal(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetDecimal(colIndex);
        return 0;
    }

    public static int SafeGetInt16(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? 0 : reader.GetInt16(colIndex);
    }

    public static int SafeGetInt32(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex);
    }

    public static DateTime SafeGetDateTime(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? new DateTime() : reader.GetDateTime(colIndex);
    }
}
