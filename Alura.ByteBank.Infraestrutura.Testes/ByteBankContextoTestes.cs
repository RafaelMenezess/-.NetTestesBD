using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoMySql()
        {
            //Arrange
            ByteBankContexto contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (System.Exception)
            {

                throw new Exception("Não foi possivel conectar a base de dados");
            }

            //Assert
            Assert.True(conectado);
        }
    }
}
