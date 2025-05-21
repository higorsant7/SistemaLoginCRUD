using MySql.Data.MySqlClient;

public class Conexao
{
    private MySqlConnection conexao;

    public Conexao()
    {
        string conexaoString = "server=localhost;database=sistema_login;uid=root;pwd=;";
        conexao = new MySqlConnection(conexaoString);
    }

    public MySqlConnection ObterConexao()
    {
        return conexao;
    }
}