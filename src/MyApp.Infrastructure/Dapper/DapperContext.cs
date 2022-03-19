using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyApp.Domain.Dapper;

namespace MyApp.Infrastructure.Dapper
{
    public class DapperContext : IDapperContext, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _context;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = configuration.GetConnectionString("sqlServerdatabase");

            _context = new SqlConnection(connectionString);
        }


        public IDbConnection Context { get => _context; }

        public void Dispose()
        {
            _context.Close();
            _context.Dispose();
        }
    }
}