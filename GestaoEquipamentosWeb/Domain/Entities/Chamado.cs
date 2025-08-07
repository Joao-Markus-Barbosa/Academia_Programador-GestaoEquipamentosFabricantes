using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoEquipamentosWeb.Domain.Entities
{
    public class Chamado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de abertura é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataAbertura { get; set; }

        [Required(ErrorMessage = "O equipamento é obrigatório.")]
        public int EquipamentoId { get; set; }

        
        public Equipamento? Equipamento { get; set; }
    }
}

