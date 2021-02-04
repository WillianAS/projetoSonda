using System.ComponentModel.DataAnnotations;

namespace ProjetoSonda.Models
{
    public class Sonda
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em X deve ser maior que zero")]
        public int coordenadaX { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em Y deve ser maior que zero")]
        public int coordenadaY { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(1, ErrorMessage = "Tamano máximo de 1 caractere")]
        //[RegularExpression("$/[n*]|[s*]|[e*]|[w*]/i", ErrorMessage = "Direção deve ser n (North), s (South), e (East) ou w (West)")]
        public string direcaoAtual { get; set; }

        public string instrucoes { get; set; }

        public string girar(char sentido) {
            return "n";
        }

        public int mover() {
            return 0;
        }
    }
}