🎉 Sistema de Gerenciamento de Eventos

Sistema completo de gerenciamento de eventos, desenvolvido em C# com Windows Forms, durante o segundo ano do curso técnico em Análise e Desenvolvimento de Sistemas.

O projeto tem como objetivo aplicar conceitos de programação orientada a objetos (POO), CRUD, banco de dados relacional e arquitetura em camadas (MVC + DAO), resultando em uma aplicação desktop completa para gestão de eventos, clientes, produtos, orçamentos e financeiro.


🧭 Visão Geral

O sistema foi projetado para auxiliar empresas e profissionais do ramo de eventos no gerenciamento de clientes, produtos, orçamentos e agendamentos, integrando tudo em um fluxo automatizado e eficiente.

Com uma interface amigável, o usuário pode realizar desde o cadastro de clientes com busca automática de endereço, até o controle financeiro de pagamentos e parcelas.


✨ Funcionalidades Principais

👤 Módulo de Clientes

Cadastro, edição e exclusão (CRUD completo)

Busca automática de endereço (CEP, cidade, estado, rua e bairro)

Listagem com filtros e pesquisa

📦 Módulo de Produtos

Cadastro de produtos e serviços

Definição de preço e descrição

Atualização e exclusão de produtos

🧾 Módulo de Orçamentos

Criação de orçamentos vinculados a clientes

Seleção de produtos e cálculo automático do valor total

Controle de status (Aprovado, Pendente, Cancelado)

Geração automática de agendamento a partir do orçamento

📅 Módulo de Agendamentos

Associação com cliente e orçamento

Exibição de data, horário e local

Evita conflitos de horários duplicados

💰 Módulo Financeiro

Registro de pagamentos e parcelas

Cálculo automático de valores pendentes

Atualização de status conforme quitação


🧱 Estrutura do Projeto
Eventos/
 ├── Eventos.View/          # Interface gráfica (Windows Forms)
 ├── Eventos.Model/         # Modelos de dados (Cliente, Produto, Orcamento, etc.)
 ├── Eventos.DAO/           # Acesso ao banco de dados (Data Access Object)
 ├── Eventos.Control/       # Lógica de negócio e validações
 └── Banco-de-dados/        # Scripts SQL e base de dados

🧠 Tecnologias Utilizadas
Camada	Tecnologias
Linguagem	C# (.NET Framework / .NET 6)
Interface	Windows Forms
Banco de Dados	SQL Server / Mysql
Arquitetura	MVC + DAO
Padrões	CRUD, POO, Validação de dados, Tratamento de exceções
🚀 Como Executar o Projeto

Clone o repositório:

git clone https://github.com/kauabaum/Sistema-de-Gerenciamento-de-Eventos.git


Abra o projeto no Visual Studio.

Configure a string de conexão no arquivo Eventos.DAO/Db.Context.

Importe o script SQL localizado em /Banco-de-Dados.

Execute o projeto e aproveite! 🎉


📸 Telas Principais

(Adicione aqui prints das telas de Clientes, Produtos, Orçamentos, Agendamentos e Financeiro)

💡 Destaques Técnicos

CRUD completo em todas as entidades

Busca automática de endereço via base de dados

Relacionamentos entre clientes, orçamentos e agendamentos

Controle financeiro com cálculo automático

Interface intuitiva e responsiva em Windows Forms

Estrutura modular e escalável

🧾 Licença

Este projeto está sob a licença MIT — uso livre para fins acadêmicos e de aprendizado.

📘 Contexto Acadêmico

Este projeto foi desenvolvido durante o segundo ano do curso técnico em Informática, com o objetivo de:

Praticar conceitos de programação orientada a objetos (POO)

Aplicar operações CRUD em banco de dados

Estruturar um sistema completo com arquitetura em camadas

Desenvolver uma interface desktop funcional e moderna

✍️ Autor

[Kauã Davi de Senia Baum]
🎓 Estudante de curso técnico em Análise e Desenvolvimento de Sistemas - Sesi/Senai - Irati PR
💻 Desenvolvido com foco em boas práticas, aprendizado e aplicação real de C# com Windows Forms.
