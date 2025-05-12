using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieeProjectData.DAO
{
    public class CuidadoDao : BdSqlServerDao
    {
        public void IncludeCuidado(DTO.Cuidado cuidado)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "INSERT INTO " +
                "cuidados(descricao_cuidado, frequencia_cuidado, id_animal_cuidado) " +
                "VALUES (@descricao_cuidado, @frequencia_cuidado, @id_animal_cuidado);";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@descricao_cuidado", cuidado.descricao_cuidado);
            command.Parameters.AddWithValue("@frequencia_cuidado", cuidado.frequencia_cuidado);
            command.Parameters.AddWithValue("@id_animal_cuidado", cuidado.id_animal_cuidado);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public void AlterCuidado(DTO.Cuidado cuidado)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "UPDATE cuidados SET " +
                "descricao_cuidado = @descricao_cuidado, frequencia_cuidado = @frequencia_cuidado, id_animal_cuidado = @id_animal_cuidado " +
                "WHERE id_cuidado = @id_cuidado;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@descricao_cuidado", cuidado.descricao_cuidado);
            command.Parameters.AddWithValue("@frequencia_cuidado", cuidado.frequencia_cuidado);
            command.Parameters.AddWithValue("@id_animal_cuidado", cuidado.id_animal_cuidado);
            command.Parameters.AddWithValue("@id_cuidado", cuidado.id_cuidado);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public void DeleteCuidado(int id_cuidado)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "DELETE FROM cuidados " +
                "WHERE id_cuidado = @id_cuidado;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@id_cuidado", id_cuidado);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public DTO.Cuidado GetCuidado(int id_cuidado)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "SELECT * FROM cuidados " +
                "WHERE id_cuidado = @id_cuidado;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@id_cuidado", id_cuidado);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                SqlDataReader table = command.ExecuteReader();

                if (table.Read())
                {
                    DTO.Cuidado cuidado = new DTO.Cuidado();
                    cuidado.id_cuidado = int.Parse(table["id_cuidado"].ToString());
                    cuidado.descricao_cuidado = table["descricao_cuidado"].ToString();
                    cuidado.frequencia_cuidado = table["frequencia_cuidado"].ToString();
                    cuidado.id_animal_cuidado = int.Parse(table["id_animal_cuidado"].ToString());
                    return cuidado;
                }
                return null;
            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public List<DTO.Cuidado> ListCuidado()
        {
            // Lista para armazenar os animais
            List<DTO.Cuidado> listCuidados = new List<DTO.Cuidado>();

            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "SELECT * FROM cuidados;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                SqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    DTO.Cuidado cuidado = new DTO.Cuidado();
                    cuidado.id_cuidado = int.Parse(table["id_cuidado"].ToString());
                    cuidado.descricao_cuidado = table["descricao_cuidado"].ToString();
                    cuidado.frequencia_cuidado = table["frequencia_cuidado"].ToString();
                    cuidado.id_animal_cuidado = int.Parse(table["id_animal_cuidado"].ToString());

                    // adicionando o animal à lista
                    listCuidados.Add(cuidado);
                }
                return listCuidados;
            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public List<DTO.Cuidado> ListAnimalCuidado(int id_animal_cuidado)
        {
            // Lista para armazenar os animais
            List<DTO.Cuidado> listCuidados = new List<DTO.Cuidado>();

            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "SELECT * FROM cuidados " +
                "WHERE id_animal_cuidado = @id_animal_cuidado";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@id_animal_cuidado", id_animal_cuidado);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                SqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    DTO.Cuidado cuidado = new DTO.Cuidado();
                    cuidado.id_cuidado = int.Parse(table["id_cuidado"].ToString());
                    cuidado.descricao_cuidado = table["descricao_cuidado"].ToString();
                    cuidado.frequencia_cuidado = table["frequencia_cuidado"].ToString();
                    cuidado.id_animal_cuidado = int.Parse(table["id_animal_cuidado"].ToString());

                    // adicionando o animal à lista
                    listCuidados.Add(cuidado);
                }
                return listCuidados;
            }
            catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            }
            finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }
    }
}
