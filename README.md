# Projeto de Web API para Cursos de Idiomas

Este projeto é uma Web API desenvolvida em C# usando .NET 7, destinada a gerenciar cursos de idiomas oferecidos por uma empresa. A API permite o gerenciamento de alunos e turmas em diferentes níveis (básico, intermediário e avançado), fornecendo funcionalidades para cadastrar, consultar, alterar e excluir alunos e turmas.

## Tecnologias e Frameworks Utilizados

- **.NET 7**: Framework principal para desenvolvimento da API, fornecendo uma estrutura robusta e moderna para a criação de aplicações web.
- **ASP.NET Core**: Utilizado para implementar a arquitetura da API (microserviços), separando a lógica de negócios da interface do usuário.
- **Entity Framework Core**: Framework de mapeamento objeto-relacional (ORM) usado para realizar o mapeamento de objetos do C# para tabelas do banco de dados, permitindo a criação e manipulação da base de dados usando a abordagem Code First.
- **SQL Server**: Sistema de gerenciamento de banco de dados relacional utilizado para armazenar as informações de alunos, turmas e matrículas.
- **Swagger**: Ferramenta usada para documentar e testar a API, facilitando a comunicação e a integração com outros sistemas ou desenvolvedores.

## Modelagem do Domínio

O sistema possui três principais entidades:

1. **Aluno**
    - Atributos: Nome, CPF, E-mail
    - Regras: O e-mail e CPF devem ser válidos, um aluno deve estar matriculado em pelo menos uma turma.

2. **Turma**
    - Atributos: Número, Ano Letivo, Nível (Básico, Intermediário, Avançado)
    - Regras: Cada turma pode ter no máximo 5 alunos.

3. **Matrícula**
    - Atributos: TurmaId, AlunoId
    - Regras: Um aluno pode se matricular em diversas turmas, mas não pode ser matriculado mais de uma vez na mesma turma.

## Funcionalidades da API

A API fornece os seguintes métodos CRUD:

- **Alunos**
  - Criar um novo aluno
  - Consultar todos os alunos ou um aluno específico
  - Atualizar os dados de um aluno existente
  - Excluir um aluno (só será permitido se o aluno não estiver matriculado em nenhuma turma)

- **Turmas**
  - Criar uma nova turma
  - Consultar todas as turmas ou uma turma específica
  - Atualizar os dados de uma turma existente
  - Excluir uma turma (só será permitido se não houver alunos matriculados nela)

## Regras de Negócio

1. **Cadastro de Aluno**: Um aluno deve ser cadastrado com pelo menos uma turma.
2. **Validação de E-mail e CPF**: O e-mail e CPF fornecidos devem ser válidos.
3. **Matriculando Alunos**: Um aluno pode se matricular em várias turmas, mas não mais de uma vez na mesma turma.
4. **Limite de Alunos por Turma**: Cada turma pode ter no máximo 5 alunos.
5. **Exclusão de Alunos**: Não é permitido excluir um aluno que esteja associado a uma turma.
6. **Exclusão de Turmas**: Não é permitido excluir uma turma que possua alunos matriculados.

## Instalação e Configuração

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. **Navegue até o diretório do projeto**:
    ```bash
    cd nome-do-repositorio
    ```

3. **Execute as migrations para criar as tabelas no banco de dados**:
    ```bash
    dotnet ef database update
    ```

4. **Execute o projeto**:
    ```bash
    dotnet run
    ```

7. **Acesse a documentação Swagger para interagir com a API**:
    Abra o navegador e acesse `http://localhost:5000/swagger` para visualizar e testar os endpoints disponíveis.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests para melhorias ou correções.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.
