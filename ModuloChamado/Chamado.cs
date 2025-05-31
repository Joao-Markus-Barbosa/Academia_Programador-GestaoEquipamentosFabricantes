using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
        private string titulo;
        private string descricao;
        private Equipamento equipamento;
        private DateTime dataAbertura;

        public string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                    throw new ArgumentException("Título deve ter pelo menos 3 caracteres.");
                titulo = value;
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Descrição não pode ser vazia.");
                descricao = value;
            }
        }

        public Equipamento Equipamento
        {
            get => equipamento;
            set
            {
                if (value == null)
                    throw new ArgumentException("Equipamento não pode ser nulo.");
                equipamento = value;
            }
        }

        public DateTime DataAbertura
        {
            get => dataAbertura;
            set => dataAbertura = value;
        }

        public Chamado(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
            : base(id)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public int DiasEmAberto()
        {
            return (DateTime.Now - DataAbertura).Days;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Chamado: {Titulo} | Equipamento: {Equipamento.Nome} | Dias em aberto: {DiasEmAberto()}");
        }
    }
}


