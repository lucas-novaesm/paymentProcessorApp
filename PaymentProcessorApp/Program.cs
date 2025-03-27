using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Um dicionário que armazena as contas bancárias, onde a chave é o ID da conta
    private static readonly Dictionary<string, Account> _accounts = new Dictionary<string, Account>();

    // Uma lista que armazena todas as transações realizadas
    private static readonly List<Transaction> _transactions = new List<Transaction>();

    public static void Main()
    {
        // Criando contas de exemplo e inicializando os saldos
        _accounts["123"] = new Account("123", 1000m, 500m, 200m); // Conta 123 com saldos VA=1000, VR=500, Cash=200
        _accounts["456"] = new Account("456", 200m, 100m, 50m);   // Conta 456 com saldos VA=200, VR=100, Cash=50

        // Criando transações de exemplo
        ProcessTransaction(new Transaction("123", 50m, "Supermercado", 5412)); // Deve ser aprovada (VA)
        ProcessTransaction(new Transaction("123", 600m, "Restaurante", 5812)); // Deve ser rejeitada por saldo insuficiente (VR)

        // Exibindo todas as transações realizadas
        Console.WriteLine("\n🔹 Histórico de Transações:");
        if (_transactions.Count == 0)
        {
            Console.WriteLine("Nenhuma transação encontrada.");
        }
        else
        {
            foreach (var transaction in _transactions)
            {
                Console.WriteLine(transaction);  // Exibe detalhes de cada transação
            }
        }

        // Mantendo o console aberto para visualizar as transações
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    // Método responsável por processar uma transação
    public static void ProcessTransaction(Transaction transaction)
    {
        // Verifica se a conta associada à transação existe
        if (!_accounts.ContainsKey(transaction.AccountId))
        {
            Console.WriteLine($"❌ Erro: Conta {transaction.AccountId} não encontrada.");
            return;  // Se a conta não existe, a transação é rejeitada
        }

        var account = _accounts[transaction.AccountId];  // Recupera a conta correspondente ao ID

        // Verifica o tipo de estabelecimento e processa a transação de acordo com o MCC (código do tipo de comércio)
        if (transaction.Mcc == 5411 || transaction.Mcc == 5412) // Supermercado e similares -> VA (Vale Alimentação)
        {
            if (account.VA >= transaction.Amount)  // Verifica se o saldo VA é suficiente para a transação
            {
                account.VA -= transaction.Amount;  // Deduz o valor da transação do saldo VA
                _transactions.Add(transaction);    // Adiciona a transação à lista de transações aprovadas
                Console.WriteLine($"✅ Transação aprovada: {transaction}");  // Confirma que a transação foi aprovada
            }
            else
            {
                Console.WriteLine($"❌ Saldo insuficiente em VA para a transação: {transaction}");  // Caso o saldo VA seja insuficiente
            }
        }
        else if (transaction.Mcc == 5812) // Restaurante -> VR (Vale Refeição)
        {
            if (account.VR >= transaction.Amount)  // Verifica se o saldo VR é suficiente para a transação
            {
                account.VR -= transaction.Amount;  // Deduz o valor da transação do saldo VR
                _transactions.Add(transaction);    // Adiciona a transação à lista de transações aprovadas
                Console.WriteLine($"✅ Transação aprovada: {transaction}");  // Confirma que a transação foi aprovada
            }
            else
            {
                Console.WriteLine($"❌ Saldo insuficiente em VR para a transação: {transaction}");  // Caso o saldo VR seja insuficiente
            }
        }
        else // Para outros casos, utiliza o saldo em Dinheiro
        {
            if (account.Cash >= transaction.Amount)  // Verifica se o saldo em dinheiro (Cash) é suficiente
            {
                account.Cash -= transaction.Amount;  // Deduz o valor da transação do saldo em dinheiro
                _transactions.Add(transaction);    // Adiciona a transação à lista de transações aprovadas
                Console.WriteLine($"✅ Transação aprovada: {transaction}");  // Confirma que a transação foi aprovada
            }
            else
            {
                Console.WriteLine($"❌ Saldo insuficiente em dinheiro para a transação: {transaction}");  // Caso o saldo em dinheiro seja insuficiente
            }
        }
    }
}

// Classe que representa uma conta bancária de um cliente
public class Account
{
    public string AccountId { get; set; }  // Identificador único da conta
    public decimal VA { get; set; }        // Saldo de Vale Alimentação
    public decimal VR { get; set; }        // Saldo de Vale Refeição
    public decimal Cash { get; set; }      // Saldo de Dinheiro

    // Construtor que inicializa uma nova conta com valores de saldo
    public Account(string accountId, decimal va, decimal vr, decimal cash)
    {
        AccountId = accountId;
        VA = va;
        VR = vr;
        Cash = cash;
    }
}

// Classe que representa uma transação realizada em uma conta
public class Transaction
{
    public string AccountId { get; set; }  // ID da conta associada à transação
    public decimal Amount { get; set; }    // Valor da transação
    public string Merchant { get; set; }   // Nome do estabelecimento onde a transação foi realizada
    public int Mcc { get; set; }           // Código do tipo de estabelecimento (MCC)

    // Construtor que inicializa uma nova transação com os dados necessários
    public Transaction(string accountId, decimal amount, string merchant, int mcc)
    {
        AccountId = accountId;
        Amount = amount;
        Merchant = merchant;
        Mcc = mcc;
    }

    // Sobrescreve o método ToString para exibir uma representação legível da transação
    public override string ToString()
    {
        return $"Conta: {AccountId}, Valor: {Amount:C}, Estabelecimento: {Merchant}, MCC: {Mcc}";
    }
}
