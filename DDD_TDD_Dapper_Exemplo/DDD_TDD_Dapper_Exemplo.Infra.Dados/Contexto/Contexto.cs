using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DDD_TDD_Dapper_Exemplo.Infra.Dados.Contexto
{
    /// <summary>
    /// Falta adicionar insert/update e delete de objetos relacionados
    /// Missing insert/update and delete of related objects
    /// </summary>
    public class Contexto : IDisposable
    {
        IDbConnection db;

        //TODO: Verificar por que diabos na primeira execução ele dá pau.
        public Contexto(IConfiguration config)
        {
            db = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public List<T> ReadAll<T>()
        {
            string tipo = typeof(T).Name;
            return db.Query<T>($"Select * From {tipo}").ToList();
        }

        public T Find<T>(int id)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            string key = $"{typeof(T).Name}Id";

            foreach (PropertyInfo property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(KeyAttribute))
                    as KeyAttribute;

                if (attribute != null)
                {
                    key = property.Name;
                }
            }

            return db.Query<T>($"Select * From {typeof(T).Name} WHERE {key} = @Id", new { id }).SingleOrDefault();
        }

        public IEnumerable<T> Where<T>(string param)
        {
            return db.Query<T>($"Select * From {typeof(T).Name} WHERE {param}").ToList();
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
