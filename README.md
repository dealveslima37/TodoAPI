# TodoAPI

A TodoAPI é uma Web API construida utilizando o Padrão de Arquitetura em Camadas. Essa API permite gerenciar uma lista de tarefas (todos), incluindo a criação, atualização, marcação como concluído e exclusão de tarefas. A API usa um banco de dados SQLite embutido para armazenar as tarefas.

## Requisitos

- .NET 5 SDK (ou superior) instalado
- Visual Studio (ou outra IDE de sua preferência) ou Visual Studio Code

## Configuração do Ambiente de Desenvolvimento

1. Certifique-se de ter o .NET 5 SDK instalado. Você pode verificar a versão do SDK usando o seguinte comando no terminal ou prompt de comando:

```shell
dotnet --version
```
# Tecnologias Usadas

- C# .NET 5.0
- ASP.NET Core
- SQLite

# Rotas da API

- GET /v1/todos: Retorna uma lista de todas as tarefas (todos) disponíveis.
- GET /v1/todos/{id}: Retorna os detalhes da tarefa com o ID especificado.
- POST /v1/todos: Cria uma nova tarefa com base nos dados fornecidos no corpo da requisição.
- PUT /v1/todos/{id}: Atualiza os dados da tarefa com o ID especificado, com base nos dados fornecidos no corpo da requisição.
- PATCH /v1/todos/{id}/done: Marca a tarefa com o ID especificado como concluída (done).
- DELETE /v1/todos/{id}: Exclui a tarefa com o ID especificado.



