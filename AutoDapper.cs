using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DapperTest.DAL
{
    public class Context : IDisposable
    {
        IDbConnection db;

        public Context(IConfiguration config)
        {
            db = new SqlConnection(config.GetConnectionString("DefaultConnection").ToString());
        }
        
        public List<T> ReadAll<T>()
        {
            return db.Query<T>($"Select * From {typeof(T).Name}").ToList();
        }

        public T Find<T>(int id)
        {
            return db.Query<T>($"Select * From {typeof(T).Name} WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public int Insert<T>(T objeto)
        {
            var props = typeof(T).GetProperties();

            string campos = "";
            campos = props.Where(p => p.Name.ToUpper() != "ID" || p.Name.ToUpper() == $"{typeof(T).Name}ID")
                .Select(p => p.Name).Aggregate((a, b) => $"[{a}], [{b}]");

            string values = "";
            values = props.Where(p => p.Name.ToUpper() != "ID" || p.Name.ToUpper() == $"{typeof(T).Name}ID")
                .Select(p => p.Name).Select(p => typeof(T).GetProperty(p)?.GetValue(objeto, null).ToString()).Aggregate((a, b) => $"'{a}', '{b}'");

            string sqlQuery = $"INSERT INTO {typeof(T).Name} ({campos}) VALUES ({values})";
            int rowsAffected = db.Execute(sqlQuery, objeto);
            return rowsAffected;
        }

        public int Update<T>(T objeto)
        {
            var props = typeof(T).GetProperties();
            string updatestr = "";
            var nomes = props.Where(p => p.Name.ToUpper() != "ID" || p.Name.ToUpper() == $"{typeof(T).Name}ID")
                .Select(p => p.Name);
            updatestr = nomes.Aggregate((a, b) => $"{a}=@{a}, {b}=@{b}");

            string sqlQuery = $"UPDATE Author SET {updatestr} WHERE Id = @Id";
            int rowsAffected = db.Execute(sqlQuery, objeto);
            return rowsAffected;
        }

        public T Delete<T>(int id)
        {
            return db.Query<T>($"Delete From {typeof(T).Name} WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public List<T> Read<T>(string sPName)
        {
            return db.Query<T>(sPName,
            commandType: CommandType.StoredProcedure).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
