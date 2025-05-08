namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class Fabricante
    {
        public int Id;
        public string Nome;
        public string Email;
        public string Telefone;

        public Fabricante(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}

