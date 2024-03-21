using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.TryAddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //Arrange
            //Act
            List<Cliente> list = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(list);
            Assert.Equal(3, list.Count);
        }
    }
}
