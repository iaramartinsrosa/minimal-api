using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange: são todas as variáveis que serão usadas no teste
        var veiculo = new Veiculo();

        //Act: é a ação que será testada *testa o set
        veiculo.Id = 1;
        veiculo.Marca = "Toyota";
        veiculo.Nome = "Corolla";
        veiculo.Ano = 2020;

        //Assert: é a verificação do resultado esperado *testa o get
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Toyota", veiculo.Marca);
        Assert.AreEqual("Corolla", veiculo.Nome);
        Assert.AreEqual(2020, veiculo.Ano);
    }
}