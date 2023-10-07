using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            
            Console.WriteLine("Digite a marca do veículo estacionado:");
            string marca = Console.ReadLine();

            Console.WriteLine("Digite a cor do veículo estacionado:");
            string cor = Console.ReadLine();

            Console.WriteLine("Digite o ano do veículo estacionado:");
            int ano = Convert.ToInt32(Console.ReadLine());

            //*IMPLEMENTADO* 
            veiculos.Add($"{placa};{marca};{cor};{ano}");
        }
        

        public void RemoverVeiculo()
        {
            Console.WriteLine("Confirme a marca do veículo para remover:");
            string carroMarca = Console.ReadLine();

            Console.WriteLine("Confirme a placa do veículo para remover:");
            //*IMPLEMENTADO*
            string placaId = Console.ReadLine();
            
            //Verifica se o veículo existe
            if (veiculos.Any(x => x.Split(';')[0].ToUpper() == placaId.ToUpper() && x.Split(';')[1].ToUpper() == carroMarca.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.RemoveAll(x => x.Split(';')[0].ToUpper() == placaId.ToUpper() && x.Split(';')[1].ToUpper() == carroMarca.ToUpper());

                 //*IMPLEMENTADO*
                Console.WriteLine($"O veículo de marca {carroMarca} e placa {placaId} foi removido. O preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                 Console.WriteLine("Os veículos estacionados são:");

                // *IMPLEMENTADO*
                foreach (string veiculo in veiculos)
                {
                    string[] infoVeiculo = veiculo.Split(';');
                    string placaId = infoVeiculo[0];
                    string marcaCarro = infoVeiculo[1];
                    string corDoVeiculo = infoVeiculo[2];
                    string anoDoVeiculo = infoVeiculo[3];

                    Console.WriteLine($"Veículo de marca {marcaCarro}, ano {anoDoVeiculo}, cor {corDoVeiculo} e placa {placaId}.");
                }
                
              
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}