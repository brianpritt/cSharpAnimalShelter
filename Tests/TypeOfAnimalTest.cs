using Xunit;
using System;
using System.Collections.Generic;
using TEMPLATE.Objects;

namespace  AnimalShelter
{
  public class TEMPLATE
  {
    public TypeOfAnimalTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=animalshelter_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void TEMPLATE_true()
    {
      //Arrange
      //Act
      //Assert
      Assert.Equal(true/false, TEMPLATE);
    }
  }
}
