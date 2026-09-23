public class Alunos
{
    private int Matricula;
    private string Nome;
    private double N1;
    private double N2;
    private double Media;
    private string Status;

    public Alunos() { }

    public Alunos(int matricula, string nome, double n1, double n2, double media, string status)
    {
        this.Matricula = matricula;
        this.Nome = nome;
        this.N1 = n1;
        this.N2 = n2;
        this.Media = media;
        this.Status = status;
    }

    public int getMatricula() { return Matricula; }
    public void setMatricula(int matricula) { this.Matricula = matricula; }

    public string getNome() { return Nome; }
    public void setNome(string nome) { this.Nome = nome; }

    public double getN1() { return N1; }
    public void setN1(double n1) { this.N1 = n1; }

    public double getN2() { return N2; }
    public void setN2(double n2) { this.N2 = n2; }

    public double getMedia() { return Media; }
    public void setMedia(double media) { this.Media = media; }

    public string getStatus() { return Status; }
    public void setStatus(string status) { this.Status = status; }
}