using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public class AlunosDB
{
    string conexao;

    public AlunosDB()
    {
        this.conexao = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
    }

    // ---------- INSERIR ----------
    public void IncluirAluno(Alunos alunos)
    {
        MySqlConnection CN = new MySqlConnection(conexao);
        MySqlCommand Com = CN.CreateCommand();
        Com.CommandText = "INSERT INTO Alunos(matricula,nome,n1,n2,media,status) " +
                          "VALUES(@matricula,@nome,@n1,@n2,@media,@status)";
        Com.Parameters.AddWithValue("@matricula", alunos.getMatricula());
        Com.Parameters.AddWithValue("@nome", alunos.getNome());
        Com.Parameters.AddWithValue("@n1", alunos.getN1());
        Com.Parameters.AddWithValue("@n2", alunos.getN2());
        Com.Parameters.AddWithValue("@media", alunos.getMedia());
        Com.Parameters.AddWithValue("@status", alunos.getStatus());
        try
        {
            CN.Open();
            Com.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException(ex.ToString());
        }
        finally
        {
            CN.Close();
        }
    }

    // ---------- LISTAR ----------
    public DataTable getAlunos()
    {
        MySqlConnection CN = new MySqlConnection(conexao);
        try
        {
            CN.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Alunos", CN);
            DataTable dtAlunos = new DataTable();
            da.Fill(dtAlunos);
            return dtAlunos;
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException(ex.ToString());
        }
        finally
        {
            CN.Close();
        }
    }

    // ---------- ATUALIZAR ----------
    public int AtualizarAluno(Alunos alunos)
    {
        MySqlConnection CN = new MySqlConnection(conexao);
        MySqlCommand Com = CN.CreateCommand();
        Com.CommandText = "UPDATE Alunos SET nome=@nome, n1=@n1, n2=@n2, media=@media, status=@status " +
                          "WHERE matricula=@matricula";
        Com.Parameters.AddWithValue("@nome", alunos.getNome());
        Com.Parameters.AddWithValue("@n1", alunos.getN1());
        Com.Parameters.AddWithValue("@n2", alunos.getN2());
        Com.Parameters.AddWithValue("@media", alunos.getMedia());
        Com.Parameters.AddWithValue("@status", alunos.getStatus());
        Com.Parameters.AddWithValue("@matricula", alunos.getMatricula());
        try
        {
            CN.Open();
            return Com.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException(ex.ToString());
        }
        finally
        {
            CN.Close();
        }
    }

    // ---------- EXCLUIR ----------
    public int ExcluirAluno(int matricula)
    {
        MySqlConnection CN = new MySqlConnection(conexao);
        MySqlCommand Com = CN.CreateCommand();
        Com.CommandText = "DELETE FROM Alunos WHERE matricula=@matricula";
        Com.Parameters.AddWithValue("@matricula", matricula);
        try
        {
            CN.Open();
            return Com.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException(ex.ToString());
        }
        finally
        {
            CN.Close();
        }
    }
}