using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class Chamado
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public Equipamento Equipamento;
        public DateTime DataAbertura;

        public Chamado(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public int DiasEmAberto()
        {
            return (DateTime.Now - DataAbertura).Days;
        }
    }
}

