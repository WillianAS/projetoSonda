# projetoSonda

Olá!
Primeiramente, para rodar este projeto, clone este projeto e tenha certeza de que você tem o .Net instalado. Para isso, abra o Powershell ou o cmd (Windows) ou o Console (Linux ou Mac) e digite "dotnet --version".
Caso não tenha, siga os passos da documentação a seguir "https://dotnet.microsoft.com/download"

Após instalação do .Net, abra o prompt de comando e vá até o diretório do projeto que deseja rodar. Então digite "dotnet run" para rodar o projeto.
Com o projeto rodando, pegue a porta que está sendo usada. 

Fica algo assim:
![alt text](https://i.imgur.com/5gxSgqg.png)

Após o projeto estar rodando, abra o postman ou qualquer outra ferramenta para envio de requests e configure para mandar uma requisição do tipo POST para "[url e porta onde o projeto está rodando]/v1/exploracao".
Tomei a liberdade de organizar os dados de entrada como um Json, segue um exemplo de como o Body da request deve ser.

Exemplo de entrada:

Se trata de um planalto e suas respectivas sondas de exploração
```
{
    "tamanhoX": 5,
    "tamanhoY": 4,
    "sondas": [
        {
            "coordenadaX": 2,
            "coordenadaY": 2,
            "direcaoAtual": "n",
            "instrucoes": "lmlmlm"
        },
        {
            "coordenadaX": 0,
            "coordenadaY": 0,
            "direcaoAtual": "e",
            "instrucoes": "rmrmrm"
        },
        {
            "coordenadaX": 3,
            "coordenadaY": 3,
            "direcaoAtual": "s",
            "instrucoes": "lmrmlmrm"
        }
    ]
}

