using DesafioFundamentos.Models;

namespace DesafioFundamentos.Test.Models
{
    public class EstacionamentoTests
    {
        [Fact]
        public void TestAdicionarVeiculo()
        {
            decimal precoInicial = 5.0m;
            decimal precoPorHora = 2.0m;
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            string placaSimulada = "ABC123";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(placaSimulada + Environment.NewLine));

                estacionamento.AdicionarVeiculo();

                Assert.Contains(placaSimulada, estacionamento.Veiculos);
            }
        }
        [Fact]
        public void TestRemoverVeiculo()
        {
            decimal precoInicial = 5.0m;
            decimal precoPorHora = 2.0m;
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            string placaSimulada = "ABC123";
            string horasSimuladas = "2";
            decimal valorTotal = precoInicial + precoPorHora * int.Parse(horasSimuladas);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(placaSimulada + Environment.NewLine));

                estacionamento.AdicionarVeiculo();

                Console.SetOut(sw);
                Console.SetIn(new StringReader(placaSimulada + Environment.NewLine + horasSimuladas + Environment.NewLine));

                estacionamento.RemoverVeiculo();


                Assert.DoesNotContain(placaSimulada, estacionamento.Veiculos);
            }
        }
        [Fact]
        public void TestListarVeiculosComVeiculos()
        {
            decimal precoInicial = 5.0m;
            decimal precoPorHora = 2.0m;
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                Console.SetIn(new StringReader("Veículo 1" + Environment.NewLine));

                estacionamento.AdicionarVeiculo();

                Console.SetIn(new StringReader("Veículo 2" + Environment.NewLine));

                estacionamento.AdicionarVeiculo();

                estacionamento.ListarVeiculos();

                string consoleOutput = sw.ToString();
                Assert.Contains("Os veículos estacionados são:", consoleOutput);
                Assert.Contains("Veículo 1", consoleOutput);
                Assert.Contains("Veículo 2", consoleOutput);
            }
        }

        [Fact]
        public void TestListarVeiculosSemVeiculos()
        {
            // Arrange
            decimal precoInicial = 5.0m;
            decimal precoPorHora = 2.0m;
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                estacionamento.ListarVeiculos();

                string consoleOutput = sw.ToString();
                Assert.Contains("Não há veículos estacionados.", consoleOutput);
            }
        }
    }
}