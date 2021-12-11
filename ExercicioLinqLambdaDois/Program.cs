using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace ExercicioLinqLambdaDois
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione Enter para o arquivo .txt ser lido.");

            string path = "../../../Funcionarios.txt";

            string[] linhas = File.ReadAllLines(path);

            List<FuncionarioModel> funcionarios = new List<FuncionarioModel>();
            List<FuncionarioModel> funcionarios1 = new List<FuncionarioModel>();
            List<FuncionarioModel> funcionarios2 = new List<FuncionarioModel>();

            Console.WriteLine("Informe o salário");
            double salario = double.Parse(Console.ReadLine());

            for (int i = 0; i < linhas.Length; i++)
            {
                var nomeEmailSalario = linhas[i].Trim().Split(',');

                FuncionarioModel funcionario = new FuncionarioModel();

                funcionario.Nome = nomeEmailSalario[0].Trim();
                funcionario.Email = nomeEmailSalario[1].Trim();
                funcionario.Salario = double.Parse(nomeEmailSalario[2].Trim(), CultureInfo.InvariantCulture);

                funcionarios.Add(funcionario);
            }

            funcionarios1 = funcionarios.Where(x => x.Salario > salario).OrderBy(x => x.Nome[0]).ToList();
            var soma = funcionarios.Where(x => x.Nome[0].ToString() == "M").Sum(x => x.Salario).ToString("F2");

            Console.WriteLine($"Email das pessoas que tem o salario maior que {salario}:");

            foreach (var item in funcionarios1)
            {
                Console.WriteLine($"Nome:{item.Nome} - Salario:{item.Salario.ToString("F2")}");
            }

            Console.WriteLine($"Soma dos salários cujo nome começa com a letra 'M':{soma}");
            Console.Read();
        }
    }
}
