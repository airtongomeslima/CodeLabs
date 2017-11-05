using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ModeloDDD.Infra.Dados.Contexto
{
    /// <summary>
    /// Falta adicionar insert/update e delete de objetos relacionados
    /// Missing insert/update and delete of related objects
    /// </summary>
    public class Contexto : IDisposable
    {
        private string ObterIdDoObjeto<T>()
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

            return key;
        }

        IDbConnection db;

        //TODO: Verificar por que diabos na primeira execução ele dá pau.
        public Contexto(IConfiguration config)
        {
            db = new SqlConnection(config.GetConnectionString("ModeloDDDConnection"));
        }

        public List<T> LerTudo<T>()
        {
            string tipo = typeof(T).Name;
            return db.Query<T>($"Select * From {tipo} (nolock)").ToList();
        }

        public T ObterPorId<T>(int id)
        {
            string key = ObterIdDoObjeto<T>();
            return db.Query<T>($"Select * From {typeof(T).Name} (nolock) WHERE {key} = @Id", new { id }).SingleOrDefault();
        }

        public IEnumerable<T> Where<T>(string param)
        {
            return db.Query<T>($"Select * From {typeof(T).Name} (nolock) WHERE {param}").ToList();
        }

        public int Inserir<T>(T objeto)
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

        public int Atualizar<T>(T objeto)
        {
            string key = ObterIdDoObjeto<T>();

            var props = typeof(T).GetProperties();
            string updatestr = "";
            var nomes = props.Where(p => p.Name.ToUpper() != "ID" || p.Name.ToUpper() == $"{typeof(T).Name}ID")
                .Select(p => p.Name);
            updatestr = nomes.Aggregate((a, b) => $"{a}=@{a}, {b}=@{b}");

            string sqlQuery = $"UPDATE Author SET {updatestr} WHERE {key} = @Id";
            int rowsAffected = db.Execute(sqlQuery, objeto);
            return rowsAffected;
        }

        public T Deletar<T>(int id)
        {
            string key = ObterIdDoObjeto<T>();
            return db.Query<T>($"Delete From {typeof(T).Name} WHERE {key} = @Id", new { id }).SingleOrDefault();
        }

        public List<T> Ler<T>(string sPName)
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
