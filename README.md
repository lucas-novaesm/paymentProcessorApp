# 🚀 Explicação do Código de Processamento de Transações

## 📌 Descrição do Projeto
Este projeto tem como objetivo processar transações financeiras entre contas, validando saldo disponível e registrando um histórico de operações. Ele suporta três tipos de saldo:

- **Vale Alimentação (VA)** 🍏
- **Vale Refeição (VR)** 🍽️
- **Dinheiro (Cash)** 💰

O programa valida cada transação e exibe um relatório com as operações **aprovadas** ✅ e **rejeitadas** ❌ no console.

## 📊 Diagrama de Classes
Abaixo está um diagrama UML representando as classes do sistema de processamento de transações:
![diagrama_transacoes](https://github.com/user-attachments/assets/aa7ef5cb-fc0b-4900-b3b4-6b3058f431d0)

---

## ✅ Funcionalidades
- Criar contas com diferentes tipos de saldo
- Processar transações conforme o saldo disponível
- Validar compras de acordo com o MCC (Merchant Category Code)
- Exibir o histórico de transações no console

---

## 🛠️ Tecnologias Utilizadas
- **C#** - Linguagem principal do projeto
- **.NET Core** - Framework para execução do código
---

## 1️⃣ Criação das Contas 🏦
No início, o programa cria duas contas com os seguintes saldos:

### Conta 123:
- **VA (Vale Alimentação):** R$ 1000
- **VR (Vale Refeição):** R$ 500
- **Dinheiro:** R$ 200

### Conta 456:
- **VA (Vale Alimentação):** R$ 200
- **VR (Vale Refeição):** R$ 100
- **Dinheiro:** R$ 50

---

## 2️⃣ Processamento das Transações 💳

### Transação 1:
- **Conta:** 123
- **Valor:** R$ 50
- **Estabelecimento:** Supermercado 🏬
- **MCC (Código do Estabelecimento):** 5412 (Vale Alimentação)

> Essa transação tenta debitar R$ 50 de **Vale Alimentação (VA)**. Como o saldo é suficiente, a transação será **aprovada** ✅.

### Transação 2:
- **Conta:** 123
- **Valor:** R$ 600
- **Estabelecimento:** Restaurante 🍽️
- **MCC:** 5812 (Vale Refeição)

> Essa transação tenta debitar R$ 600 de **Vale Refeição (VR)**. Como o saldo é **insuficiente** para cobrir a transação, ela será **rejeitada** ❌.

---

## 3️⃣ Saída no Console 💻
Após processar as transações, o programa exibe no console as mensagens de aprovação ou rejeição e um histórico das transações processadas.

### Exemplo de Saída no Console:
```plaintext
✅ Transação aprovada: Conta: 123, Valor: R$ 50,00, Estabelecimento: Supermercado, MCC: 5412
❌ Saldo insuficiente em VR para a transação: Conta: 123, Valor: R$ 600,00, Estabelecimento: Restaurante, MCC: 5812

🔹 Histórico de Transações:
Conta: 123, Valor: R$ 50,00, Estabelecimento: Supermercado, MCC: 5412

Pressione qualquer tecla para sair...



