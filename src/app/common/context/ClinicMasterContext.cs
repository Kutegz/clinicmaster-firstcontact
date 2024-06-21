using System.Data;
using Microsoft.Data.SqlClient;

namespace ClinicMasterFirstContact.src.App.Common.Context;

public sealed class ClinicMasterContext(IConfiguration configuration)
{
    private readonly string connectionString = configuration.GetConnectionString("ClinicMasterConnection")!;
    public IDbConnection CreateConnection() => new SqlConnection(connectionString: connectionString);
}