using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {

        public int Numero { get; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            Saldo = 0.0;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Deposito(depositoInicial);
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            if (quantia + 3.50 > Saldo)
            {
                Console.WriteLine("Erro: Saldo insuficiente para saque.");
            }
            else
            {
                Saldo -= quantia + 3.50;
            }
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }

    public class Banco
    {
        private ContaBancaria[] contas;

        public Banco(int capacidade)
        {
            contas = new ContaBancaria[capacidade];
        }

        public void AdicionarConta(ContaBancaria conta)
        {
            int indice = conta.Numero % contas.Length;
            while (contas[indice] != null)
            {
                indice = (indice + 1) % contas.Length;
            }
            contas[indice] = conta;
        }

        public ContaBancaria ConsultarConta(int numero)
        {
            int indice = numero % contas.Length;
            while (contas[indice] != null && contas[indice].Numero != numero)
            {
                indice = (indice + 1) % contas.Length;
            }
            return contas[indice];
        }

        public void AtualizarTitular(int numero, string novoTitular)
        {
            ContaBancaria conta = ConsultarConta(numero);
            if (conta != null)
            {
                conta.Titular = novoTitular;
            }
        }
    }

}
