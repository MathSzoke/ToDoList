<h1>Documentação da solução - ToDoList</h1>

<h5>Descrição:</h5>

O projeto é orientado a DDD (Domain-driven design). Apesar de saber que o teste requisitava de um teste super básico, e sabendo que eu poderia ter evitado um monte de código, preferi apresentá-los meus conhecimentos em projetos orientados a DDD.

A Solution consiste em 4 projetos, sendo eles:

Application (Application é o projeto onde irá atuar como o intermédio entre Presentation e Domain)
Domain (Domain é o núcleo da aplicação, onde residem as regras de negócios e as entidades principais do domínio)
Infra (O projeto Infra é responsável pela implementação das camadas de infraestrutura, como persistência de dados, comunicação com serviços externos)
Presentation (O projeto Presentation é responsável por lidar com a interação do usuário e pela entrega da resposta da aplicação)

<h5>Application:</h5>

Dependências:
- AutoMapper;
- Microsoft.AspNetCore.Mvc.Core;

Objetivo de Application:

Transferir dados da entidade ToDoList de Presentation para Domain e realizar as devidas tarefas para a comuniccação com o banco de dados, coordena a execução de casos de uso e fornece uma interface entre a camada de apresentação e o domínio..

<h5>Domain:</h5>

Dependências: Não tem

Objetivo de Domain:

Registrar suas entidades de domínio da aplicação. Definir regras de negócios, assim como de exemplo eu criei o StringExpression, com a finalidade de deixar as frases do Titulo separado com apenas 1 espaço.

<h5>Infra:</h5>

Dependências:
- EntityFramework
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

Objetivo de Infra:

Conectar-se ao Banco de Dados, com o contexto e configurações para sua base de dados. Realizar interações com o banco de dados, como criar, alterar e excluir informações.

<h5>Presentation:</h5>

Dependêcias:
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Swashbuckle.AspNetCore

Objetivo de Presentation:

Apresentar informações do sistema para o usuário com alguma interface, no caso foi utilizado o Swagger. API Controllers: Recebem as solicitações HTTP e orquestram a execução dos serviços de Application.
