using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Datos.Acceso
{
    public class UsuarioDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=ejercicio3; Uid=root; Pwd=Moreno22;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string idUsuario, string clave)
        {
            Usuario user = null;

            try
            {
                string sql = "SELECT * FROM usuario WHERE IdUsuario = @IdUsuario AND Clave = @Clave;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new Usuario();
                    user.IdUsuario = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Apellido = reader[2].ToString();
                    user.Edad = reader[3].ToString();
                    user.CorreoElectronico = reader[4].ToString();
                    user.Clave = reader[5].ToString();
                    user.EstaActivo = Convert.ToBoolean(reader[6]);

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return user;
        }

        public DataTable ListarUsuarios()
        {
            DataTable ListaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM usuario;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                ListaUsuariosDT.Load(reader);

            }
            catch (Exception ex)
            {

            }
            return ListaUsuariosDT;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            bool inserto = false;

            try
            {
                string sql = "INSERT INTO usuario VALUES (@IdUsuario, @Nombre, @Apellido, @Edad, @CorreoElectronico , @Clave, @EstaActivo);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@EstaActivo", usuario.EstaActivo);

                cmd.ExecuteNonQuery();
                inserto = true;
            }
            catch (Exception ex)
            {

            }
            return inserto;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            bool modifico = false;

            try
            {
                string sql = "UPDATE usuario SET IdUsuario = @IdUsuario, Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad ,CorreoElectronico = @CorreoElectronico , Clave = @Clave, EstaActivo = @EstaActivo WHERE IdUsuario = @IdUsuario;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@EstaActivo", usuario.EstaActivo);

                cmd.ExecuteNonQuery();
                modifico = true;
            }
            catch (Exception ex)
            {

            }
            return modifico;
        }

        public bool EliminarUsuario(string idUsuario)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM usuario WHERE IdUsuario = @IdUsuario;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                cmd.ExecuteNonQuery();
                elimino = true;
            }
            catch (Exception ex)
            {

            }
            return elimino;

        }
    }
}
