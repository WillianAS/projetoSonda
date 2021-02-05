using System;
using System.Collections.Generic;
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

        public bool status { get; set; }

        private List<char> comandos { get; set; }

        public Sonda explorar(Sonda sonda, Planalto planalto)
        {
            if (posicaoEhValida(sonda, planalto))
            {
                comandos = transformaInstrucoesEmComandos(sonda.instrucoes);

                foreach(var comando in comandos)
                {
                    if (comando.Equals('l') || comando.Equals('r'))
                    {
                        sonda.direcaoAtual = girar(sonda.direcaoAtual, comando);
                    }
                    else if (comando.Equals('m'))
                    {
                        sonda.mover(sonda, planalto);
                    }
                }
                return sonda;
            } 
            else 
            {
                return new Sonda();
            }
        }


        #region Funções Privadas
        private bool posicaoEhValida(Sonda sonda, Planalto planalto)
        {
            return ((sonda.coordenadaX-1 <= planalto.tamanhoX && sonda.coordenadaY-1 <= planalto.tamanhoY) ? true : false);
        }

        private string girar(string direcaoAtual, char comando) 
        {
            if (direcaoAtual.Equals("n") && comando.Equals('l'))
            {
                return "w";
            }
            else if (direcaoAtual.Equals("n") && comando.Equals('r'))
            {
                return "e";
            }
            else if (direcaoAtual.Equals("s") && comando.Equals('l'))
            {
                return "e";
            }
            else if (direcaoAtual.Equals("s") && comando.Equals('r'))
            {
                return "w";
            }
            else if (direcaoAtual.Equals("e") && comando.Equals('l'))
            {
                return "n";
            }
            else if (direcaoAtual.Equals("e") && comando.Equals('r'))
            {
                return "s";
            }
            else if (direcaoAtual.Equals("w") && comando.Equals('l'))
            {
                return "s";
            }
            else
            {
                return "n";
            }
        }

        private Sonda mover(Sonda sonda, Planalto planalto) 
        {
            switch (sonda.direcaoAtual)
            {
                case "n":
                {
                    if (sairaDoPlanaltoY(++sonda.coordenadaY, planalto))
                    {
                        return sonda;
                    }
                    else
                    {
                        sonda.coordenadaY--;
                        return sonda;
                    }
                }
                case "s":
                {
                    if (sairaDoPlanaltoY(--sonda.coordenadaY, planalto))
                    {
                        return sonda;
                    }
                    else
                    {
                        sonda.coordenadaY++;
                        return sonda;
                    }
                }
                case "e":
                {
                    if (sairaDoPlanaltoX(++sonda.coordenadaX, planalto))
                    {
                        return sonda;
                    }
                    else
                    {
                        sonda.coordenadaX--;
                        return sonda;
                    }
                }
                case "w":
                {
                    if (sairaDoPlanaltoX(--sonda.coordenadaX, planalto))
                    {
                        return sonda;
                    }
                    else
                    {
                        sonda.coordenadaX++;
                        return sonda;
                    }
                }
            }
            return sonda;
        }

        private bool sairaDoPlanaltoX(int coordenadaX, Planalto planalto)
        {
            return (coordenadaX <= planalto.tamanhoX && coordenadaX >= 0) ? true : false;
        }

        private bool sairaDoPlanaltoY(int coordenadaY, Planalto planalto)
        {
            return (coordenadaY <= planalto.tamanhoY && coordenadaY >= 0) ? true : false;
        }

        private List<char> transformaInstrucoesEmComandos(string instrucoes)
        {
            List<char> comandos = new List<char>();

            foreach(char caractere in instrucoes.ToLower().Trim())
            {
                comandos.Add(caractere);
            }
            
            return comandos;
        }
        #endregion       
    }
}