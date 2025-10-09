# 🎉 Sistema de Gerenciamento de Eventos

> 💻 Desenvolvido em **C# (Windows Forms)** durante o **segundo ano do curso técnico em Análise e Desenvolvimento de Sistemas**  
> 📅 Projeto acadêmico com foco em **CRUD, POO e arquitetura em camadas (MVC + DAO)**  

---

## 🧭 Visão Geral

O **Sistema de Gerenciamento de Eventos** é uma aplicação desktop completa voltada para o **controle de clientes, produtos, orçamentos, agendamentos e financeiro**.  
Desenvolvido como projeto técnico, ele aplica conceitos de **programação orientada a objetos (POO)** e **operações CRUD** com banco de dados relacional, unindo praticidade e aprendizado em um único sistema.

---

## ✨ Funcionalidades Principais

### 👤 **Clientes**
- CRUD completo (cadastro, edição, exclusão e busca)
- Busca automática de endereço (CEP, cidade, estado, rua, bairro)
- Filtro e pesquisa por nome

### 📦 **Produtos**
- Cadastro de produtos e serviços
- Definição de preço e descrição
- Atualização e exclusão de registros

### 🧾 **Orçamentos**
- Criação de orçamentos vinculados a clientes
- Seleção de produtos e cálculo automático do valor total
- Controle de status (Aprovado, Pendente, Cancelado)
- Geração automática de agendamentos

### 📅 **Agendamentos**
- Associação com cliente e orçamento
- Exibição de data, horário e local
- Evita conflitos de horários duplicados

### 💰 **Financeiro**
- Registro de pagamentos e parcelas
- Cálculo automático de valores pendentes
- Atualização do status conforme quitação

---

## 🧱 Estrutura do Projeto

Eventos/
--├── Eventos.View/ # Interface gráfica (Windows Forms)
--├── Eventos.Model/ # Modelos (Cliente, Produto, Orçamento, etc.)
--├── Eventos.DAO/ # Acesso ao banco de dados (Data Access Object)
--├── Eventos.Control/ # Lógica de controle e validações
--└── Banco.de.Dados/ # Scripts e arquivos de banco de dados


---

## 🧠 Tecnologias Utilizadas

| Camada | Tecnologias |
|--------|--------------|
| **Linguagem** | C# (.NET Framework / .NET 6) |
| **Interface** | Windows Forms |
| **Banco de Dados** | SQL Server / MySQL |
| **Arquitetura** | MVC + DAO |
| **Recursos** | CRUD, POO, validação, tratamento de exceções |

---

## 🚀 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/kauabaum/gerenciamento-de-eventos.git

Abra o projeto no Visual Studio

Configure a string de conexão no arquivo Eventos.DAO/Db.Context

Importe o script SQL da pasta /Banco.de.Dados

Execute o projeto e aproveite 🎉

---

📸 Telas Principais

## Clientes
   ```bash
   https://imgur.com/zvqmClu
 ```
## Financeiro
   ```bash
   https://imgur.com/zDPPRmu
 ```
## Orçamento
   ```bash
   https://imgur.com/Y6OCaMu
 ```
## Produto
   ```bash
   https://imgur.com/zKJe250
 ```
 ## Tela Inicial
   ```bash
   https://imgur.com/nNPyhhG
 ```
---

💡 Destaques Técnicos

✅ CRUD completo em todas as entidades
✅ Busca automática de endereço (CEP)
✅ Relacionamento entre clientes, orçamentos e agendamentos
✅ Cálculo automático no módulo financeiro
✅ Interface intuitiva e organizada
✅ Estrutura modular e expansível

---

📘 Contexto Acadêmico

📚 Projeto desenvolvido durante o segundo ano do curso técnico em Análise e Desenvolvimento de Sistemas, com os objetivos de:

Aplicar conceitos de Programação Orientada a Objetos (POO)

Implementar operações CRUD com banco de dados

Utilizar arquitetura em camadas (MVC + DAO)

Criar uma aplicação desktop funcional e organizada

🧾 Licença

Este projeto está sob a licença MIT — uso livre para fins educacionais e aprendizado.

✍️ Autor

[Kauã Davi de Senia Baum]
🎓 Estudante de Curso Técnico em Análise e Desenvolvimento de Sistemas
💻 Apaixonado por desenvolvimento e boas práticas de programação

📫 Contato: [kaua.baum@outlook.com]
🌐 GitHub: https://github.com/kauabaum
