public class User
{
    public int Id_Usuario { get; set; }
    public string Nome { get; set; }
    public int FotoPerfil { get; set; } // Certifique-se de que essa coluna está correta conforme suas necessidades.
    public string Email { get; set; }
    public string SenhaHash { get; set; }
}
