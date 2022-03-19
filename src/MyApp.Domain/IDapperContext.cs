

using System.Data;

namespace MyApp.Domain.Dapper
{
    public interface IDapperContext
    {
        // string ConnectionString { get; }

        IDbConnection Context { get; }
    }
}