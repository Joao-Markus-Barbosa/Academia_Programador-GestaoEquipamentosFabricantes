using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoEquipamentosWeb.Domain.Entities
{
    public class Equipamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O número de série é obrigatório.")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "A data de aquisição é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataAquisicao { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        public int FabricanteId { get; set; }

    
        public Fabricante? Fabricante { get; set; }
    }
}
