using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class Equipamento : EntidadeBase
    {
        private string nome;
        private decimal preco;
        private string numeroSerie;
        private DateTime dataFabricacao;
        private string fabricante;

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

        public decimal Preco
        {
            get => preco;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Preço deve ser maior que zero.");
                preco = value;
            }
        }

        public string NumeroSerie
        {
            get => numeroSerie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Número de série não pode ser vazio.");
                numeroSerie = value;
            }
        }

        public DateTime DataFabricacao
        {
            get => dataFabricacao;
            set => dataFabricacao = value;
        }

        public string Fabricante
        {
            get => fabricante;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Fabricante não pode ser vazio.");
                fabricante = value;
            }
        }

        public Equipamento(int id, string nome, decimal preco, string numeroSerie, DateTime dataFabricacao, string fabricante)
            : base(id)
        {
            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }

        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Equipamento: {Nome} | Nº Série: {NumeroSerie} | Preço: R${Preco} | Fabricante: {Fabricante}");
        }
    }
}


