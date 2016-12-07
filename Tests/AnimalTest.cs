using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace  AnimalShelter
{
  public class AnimalShelterTest : IDisposable
  {
    public AnimalShelterTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=animalshelter_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange
      int result = Animal.GetAll().Count;
      //Act
      //Assert
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_EqualOverridedTrueForSameDescription()
    {
      Animal firstAnimal = new Animal("Rover", "Male","december 26,1979", "Labradoodle");
      Animal secondAnimal = new Animal("Rover", "Male","december 26,1979", "Labradoodle");

      Assert.Equal(firstAnimal, secondAnimal);
    }
    [Fact]
    public void Test_Save()
    {
      //Arrange
      Animal testAnimal = new Animal("Rover", "Male","december 26,1979", "Labradoodle",1);
      testAnimal.Save();
      //Act
      List<Animal> result = Animal.GetAll();
      List<Animal> testList = new List<Animal>{testAnimal};
      //Assert
      Assert.Equal(testList,result);
    }
    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Animal testAnimal = new Animal("Rover", "Male","december 26,1979", "Labradoodle",1);
      testAnimal.Save();
      //Act
      Animal savedAnimal = Animal.GetAll()[0];
      int result = savedAnimal.GetId();
      int testId = testAnimal.GetId();
      Console.WriteLine(result);
      Console.WriteLine(testId);
      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_FindFindsTaskInDatabase()
    {
      //Arrange
      Animal testAnimal = new Animal("Rover", "Male","december 26,1979", "Labradoodle",1);
      testAnimal.Save();
      //Act
      Animal foundAnimal = Animal.Find(testAnimal.GetId());
      //Assert
      Assert.Equal(testAnimal, foundAnimal);
    }



    public void Dispose()
    {
      Animal.DeleteAll();
    }
  }
}
