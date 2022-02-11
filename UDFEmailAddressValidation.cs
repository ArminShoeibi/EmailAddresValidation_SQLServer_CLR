using System.Data.SqlTypes;
using System.Net.Mail;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean UDFEmailAddressValidation(SqlString sqlString)
    {
        if (sqlString.IsNull) return SqlBoolean.False;

        var trimmedEmailAddress = sqlString.Value.Trim();

        if (trimmedEmailAddress.StartsWith(".") ||
            trimmedEmailAddress.EndsWith(".")) return SqlBoolean.False;

        var mailAddress = new MailAddress(trimmedEmailAddress);

        return new SqlBoolean(mailAddress.Address == trimmedEmailAddress);
    }
}
