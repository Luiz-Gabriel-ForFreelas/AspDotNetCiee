using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieeProjectData.DAO
{
    public class AnimalDao : BdSqlServerDao
    {
        public void IncludeAnimal(DTO.Animal animal)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "INSERT INTO " +
                "animais(nome_animal, descricao_animal, especie_animal, habitat_animal, pais_origem_animal) " +
                "VALUES (@nome_animal, @descricao_animal, @especie_animal, @habitat_animal, @pais_origem_animal);";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@nome_animal", animal.nome_animal);
            command.Parameters.AddWithValue("@descricao_animal", animal.descricao_animal);
            command.Parameters.AddWithValue("@especie_animal", animal.especie_animal);
            command.Parameters.AddWithValue("@habitat_animal", animal.habitat_animal);
            command.Parameters.AddWithValue("@pais_origem_animal", animal.pais_origem_animal);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                command.ExecuteNonQuery();

            } catch (Exception error)
            {
                //mostra mensagem de erro, caso um ocorra
                throw new Exception(error.Message);
            } finally
            {
                //finaliza a conexão
                connection.Close();
            }
        }

        public void AlterAnimal(DTO.Animal animal)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "UPDATE animais SET " +
                "nome_animal = @nome_animal, descricao_animal = @descricao_animal, especie_animal = @especie_animal, habitat_animal = @habitat_animal, pais_origem_animal = @pais_origem_animal " +
                "WHERE id_animal = @id_animal;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@nome_animal", animal.nome_animal);
            command.Parameters.AddWithValue("@descricao_animal", animal.descricao_animal);
            command.Parameters.AddWithValue("@especie_animal", animal.especie_animal);
            command.Parameters.AddWithValue("@habitat_animal", animal.habitat_animal);
            command.Parameters.AddWithValue("@pais_origem_animal", animal.pais_origem_animal);
            command.Parameters.AddWithValue("@id_animal", animal.id_animal);

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

        public void DeleteAnimal(int id_animal)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "DELETE FROM animais " +
                "WHERE id_animal = @id_animal;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@id_animal", id_animal);

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

        public DTO.Animal GetAnimal(int id_animal)
        {
            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "SELECT * FROM animais " +
                "WHERE id_animal = @id_animal;";

            command.CommandText = sql;

            command.CommandType = System.Data.CommandType.Text;

            //setar os values do sql
            command.Parameters.AddWithValue("@id_animal", id_animal);

            command.Connection = connection;

            //executar o insert

            try
            {
                //abrir conexão
                connection.Open();

                //executar comando
                SqlDataReader table = command.ExecuteReader();

                if(table.Read())
                {
                    DTO.Animal animal = new DTO.Animal();
                    animal.id_animal = int.Parse(table["id_animal"].ToString());
                    animal.nome_animal = table["nome_animal"].ToString();
                    animal.descricao_animal = table["descricao_animal"].ToString();
                    animal.especie_animal = table["especie_animal"].ToString();
                    animal.habitat_animal = table["habitat_animal"].ToString();
                    animal.pais_origem_animal = table["pais_origem_animal"].ToString();
                    return animal;
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

        public List<DTO.Animal> ListAnimal()
        {
            // Lista para armazenar os animais
            List<DTO.Animal> listAnimals = new List<DTO.Animal>();

            //instânciar conexão
            SqlConnection connection = new SqlConnection();

            //configurar conexão
            connection.ConnectionString = connectionSqlServer;

            //instância a conexão
            SqlCommand command = new SqlCommand();

            //sql
            string sql = "SELECT * FROM animais;";

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
                    DTO.Animal animal = new DTO.Animal();
                    animal.id_animal = int.Parse(table["id_animal"].ToString());
                    animal.nome_animal = table["nome_animal"].ToString();
                    animal.descricao_animal = table["descricao_animal"].ToString();
                    animal.especie_animal = table["especie_animal"].ToString();
                    animal.habitat_animal = table["habitat_animal"].ToString();
                    animal.pais_origem_animal = table["pais_origem_animal"].ToString();

                    // adicionando o animal à lista
                    listAnimals.Add(animal);
                }
                return listAnimals;
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
