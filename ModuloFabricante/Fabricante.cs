using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class Fabricante : EntidadeBase
    {
        private string nome;
        private string email;
        private string telefone;

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                    throw new ArgumentException("Nome deve ter ao menos 2 caracteres.");
                nome = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email não pode ser vazio.");
                email = value;
            }
        }

        public string Telefone
        {
            get => telefone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Telefone não pode ser vazio.");
                telefone = value;
            }
        }

        public Fabricante(int id, string nome, string email, string telefone) : base(id)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Fabricante: {Nome} | Email: {Email} | Telefone: {Telefone}");
        }
    }
}



