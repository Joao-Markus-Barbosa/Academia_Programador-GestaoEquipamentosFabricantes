namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class Equipamento
    {
        public int Id;
        public string Nome;
        public decimal Preco;
        public string NumeroSerie;
        public DateTime DataFabricacao;
        public string Fabricante;

        public Equipamento(int id, string nome, decimal preco, string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }
    }
}

