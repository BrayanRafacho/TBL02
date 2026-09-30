using System;
using System.Collections.Generic;

class Pagamento
{
    public double Valor { get; set; }

    public Pagamento(double valor)
    {
        Valor = valor;
    }

    public virtual void ProcessarPagamento()
    {
        Console.WriteLine($"Processando pagamento de R$ {Valor:F2}...");
    }
}

class CartaoCredito : Pagamento
{
    public CartaoCredito(double valor) : base(valor)
    {
    }

    public override void ProcessarPagamento()
    {
        Console.WriteLine($"Pagamento de R$ {Valor:F2} realizado com Cartão de Crédito.");
    }
}

class BoletoBancario : Pagamento
{
    public BoletoBancario(double valor) : base(valor)
    {
    }

    public override void ProcessarPagamento()
    {
        Console.WriteLine($"Pagamento de R$ {Valor:F2} realizado por Boleto Bancário.");
    }
}

class Pix : Pagamento
{
    public Pix(double valor) : base(valor)
    {
    }

    public override void ProcessarPagamento()
    {
        Console.WriteLine($"Pagamento de R$ {Valor:F2} realizado via Pix.");
    }
}

partial class Program
{
    static void Main()
    {
        Console.WriteLine("===== SISTEMA DE PAGAMENTO =====");

        Console.Write("Digite o valor da compra: R$ ");
        double valor = double.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Escolha a forma de pagamento:");
        Console.WriteLine("1 - Cartão de Crédito");
        Console.WriteLine("2 - Boleto Bancário");
        Console.WriteLine("3 - Pix");

        Console.Write("Digite a opção: ");
        int opcao = int.Parse(Console.ReadLine());

        List<Pagamento> pagamentos = new List<Pagamento>();

        switch (opcao)
        {
            case 1:
                pagamentos.Add(new CartaoCredito(valor));
                break;

            case 2:
                pagamentos.Add(new BoletoBancario(valor));
                break;

            case 3:
                pagamentos.Add(new Pix(valor));
                break;

            default:
                Console.WriteLine("Opção de pagamento inválida.");
                return;
        }

        Console.WriteLine();

        foreach (Pagamento pagamento in pagamentos)
        {
            pagamento.ProcessarPagamento();
        }

        Console.WriteLine();
        Console.WriteLine("Pagamento processado com sucesso!");
    }
}

