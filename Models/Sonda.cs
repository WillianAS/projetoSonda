using System.ComponentModel.DataAnnotations;

namespace ProjetoSonda.Models
{
    public class Sonda
    {
        [Required(ErrorMessage = "")]
        [Range(0, int.MaxValue, ErrorMessage = "A posição em X deve ser maior que zero")]
        public int posicaoX { get; set; }

        [Required(ErrorMessage = "")]
        [Range(0, int.MaxValue, ErrorMessage = "A posição em Y deve ser maior que zero")]
        public int posicaoY { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(1, ErrorMessage = "")]
        [RegularExpression()]
        public char direcao { get; set; }
    }
}