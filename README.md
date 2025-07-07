# Sistema de Gerenciamento de Biblioteca

## Visão Geral
Este projeto implementa um sistema de gerenciamento de biblioteca em C#, utilizando uma arquitetura em camadas (MVC - Model-View-Controller) e persistência de dados em arquivos JSON. O sistema oferece funcionalidades essenciais para gerenciar usuários, livros e empréstimos em uma biblioteca.

## Funcionalidades Principais
- Cadastro e consulta de usuários
- Cadastro e consulta de livros
- Realização de empréstimos
- Registro de devoluções
- Consulta de empréstimos com informações detalhadas

## Estrutura do Projeto
O projeto segue uma arquitetura em camadas bem definida:

### Models (Modelos)
Contém as classes que representam as entidades do sistema:
- `Usuarios`: Armazena informações de usuários (ID, nome, email, telefone, endereço)
- `Livros`: Armazena informações de livros (ID, título, autor, categoria, etc.)
- `Emprestimo`: Gerencia a relação entre usuários e livros durante empréstimos

### Controllers (Controladores)
Gerenciam a lógica de negócio e intermediam a comunicação entre os modelos e as views:
- `BibliotecaController`: Controlador principal que gerencia o fluxo da aplicação
- `UsuariosController`: Gerencia operações relacionadas a usuários
- `LivroController`: Gerencia operações relacionadas a livros
- `EmprestimoController`: Gerencia operações de empréstimo e devolução

### Views (Visualização)
Responsável pela interface com o usuário:
- `BibliotecaView`: Exibe o menu principal e opções para o usuário

### Data (Repositórios)
Gerencia a persistência e recuperação de dados:
- `UsuarioRepositorio`: Gerencia a persistência de usuários em JSON
- `LivrosRepositorio`: Gerencia a persistência de livros em JSON
- `EmprestimoRepositorio`: Gerencia a persistência de empréstimos em JSON

## Sistema de Persistência em JSON

### Características do Sistema de Persistência
O sistema utiliza arquivos JSON para armazenar dados de forma persistente, eliminando a necessidade de um banco de dados tradicional. Esta abordagem oferece diversas vantagens:

1. **Simplicidade**: Não requer configuração de servidor de banco de dados
2. **Portabilidade**: Os dados são armazenados em arquivos que podem ser facilmente transferidos
3. **Legibilidade**: Arquivos JSON são legíveis por humanos, facilitando a depuração
4. **Serialização/Deserialização Nativa**: O .NET oferece suporte nativo para trabalhar com JSON

### Implementação da Persistência
Cada repositório (`UsuarioRepositorio`, `LivrosRepositorio`, `EmprestimoRepositorio`) segue um padrão consistente:

1. **Inicialização de Arquivos**: 
   - Na construção do repositório, verifica se o arquivo JSON existe
   - Se não existir, cria o arquivo com uma estrutura JSON válida (uma lista vazia `[]`)

2. **Leitura de Dados**:
   - Implementa métodos como `ObterUsuarios()`, `ObterLivros()` e `ObterEmprestimos()`
   - Lê o conteúdo do arquivo JSON
   - Deserializa o conteúdo para listas de objetos C# usando `System.Text.Json.JsonSerializer`
   - Inclui tratamento para arquivos vazios ou inexistentes

3. **Escrita de Dados**:
   - Implementa métodos como `SalvarUsuarios()`, `SalvarLivros()` e `SalvarEmprestimos()`
   - Serializa listas de objetos para JSON usando `System.Text.Json.JsonSerializer`
   - Escreve o JSON resultante nos arquivos correspondentes

### Arquivos JSON
O sistema utiliza três arquivos principais para armazenar dados:
- `usuarios.json`: Armazena informações de usuários
- `livros.json`: Armazena informações de livros
- `emprestimos.json`: Armazena informações de empréstimos

## Padrões de Projeto Utilizados
- **Repository Pattern**: Utilizado para abstrair o acesso aos dados
- **MVC (Model-View-Controller)**: Separa a aplicação em componentes lógicos
- **Dependency Injection**: Implementado através de injeção de dependências nos construtores

## Como Executar o Projeto
1. Certifique-se de ter o .NET 8.0 ou superior instalado
2. Clone o repositório
3. Navegue até a pasta do projeto: `cd Biblioteca`
4. Execute o projeto: `dotnet run`

## Melhorias Futuras
- Implementar validações mais robustas para entrada de dados
- Adicionar sistema de login e autenticação
- Implementar relatórios e estatísticas de uso
- Melhorar a interface do usuário com uma aplicação gráfica
- Adicionar testes automatizados

## Considerações Finais
Este projeto demonstra a implementação de um sistema funcional de gerenciamento de biblioteca usando C# e persistência em JSON. A arquitetura em camadas facilita a manutenção e extensão do sistema, enquanto o uso de JSON para armazenamento de dados oferece uma solução simples e eficaz para persistência sem a necessidade de configurar um banco de dados relacional.
