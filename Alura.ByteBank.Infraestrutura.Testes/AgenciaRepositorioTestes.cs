using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private IAgenciaRepositorio _repositorio;
        public ITestOutputHelper SaidaConsole { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsole)
        {
            SaidaConsole = _saidaConsole;
            SaidaConsole.WriteLine("Construtor executado");

            _repositorio = new AgenciaRepositorio();
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //Arrange
            //Act
            List<Agencia> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Arrange
            //Act
            var agencia = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(agencia);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestaObterAgenciasPorVariosId(int id)
        {
            //Arrange
            //Act
            var agencia = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(agencia);
        }

        // Testes com Mock
        [Fact]
        public void TestaObterAgenciasMock()
        {
            //Arange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }

        [Fact]
        public void TestaAdiconarAgenciaMock()
        {
            // Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }
    }
}
