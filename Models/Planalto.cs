using System.ComponentModel.DataAnnotations;

namespace ProjetoSonda.Models
{
    public class Planalto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em X deve ser maior que zero")]
        public int tamanhoX { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em Y deve ser maior que zero")]
        public int tamanhoY { get; set; }
    }
}