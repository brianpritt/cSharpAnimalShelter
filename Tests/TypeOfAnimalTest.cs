using Xunit;
using System;
using System.Collections.Generic;


namespace  AnimalShelter
{
  public class TypeOfAnimalTest
  {
    public TypeOfAnimalTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=animalshelter_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_TypeOfAnimalEmptyAtFirst()
    {
      //arrange, Act
      int result = TypeOfAnimal.GetAll().Count;
      //Assert
      Assert.Equal(0, result);
    }
  }
}
