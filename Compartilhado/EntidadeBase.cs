namespace Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado
{
    public abstract class EntidadeBase
    {
        private int id;

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");
                id = value;
            }
        }

        public EntidadeBase(int id)
        {
            Id = id;
        }

        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"ID: {Id}");
        }
    }
}
