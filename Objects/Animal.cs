using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnimalShelter
{
  public class Animal
  {
    private string _name;
    private string _gender;
    private string _date;
    private string _breed;
    private int _id;


    public Animal(string name, string gender, string date, string breed, int id = 0)
    {
      _name = name;
      _gender = gender;
      _date = date;
      _breed = breed;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetGender()
    {
      return _gender;
    }
    public string GetDate()
    {
      return _date;
    }
    public string GetBreed()
    {
      return _breed;
    }
    public int GetId()
    {
      return _id;
    }
    public override bool Equals(Object otherAnimal)
    {
      if(!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        Animal newAnimal = (Animal) otherAnimal;
        bool idEquality = (this.GetId() == newAnimal.GetId());
        bool nameEquality = (this.GetName() == newAnimal.GetName());
        bool dateEquality = (this.GetDate() == newAnimal.GetDate());
        bool genderEquality = (this.GetGender() == newAnimal.GetGender());
        bool breedEquality = (this.GetBreed() == newAnimal.GetBreed());
        return (idEquality && nameEquality && dateEquality && genderEquality && breedEquality);
      }
    }
    public static List<Animal> GetAll()
    {
      List<Animal> allAnimals = new List<Animal>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(4);
        string animalName = rdr.GetString(0);
        string animalGender = rdr.GetString(1);
        string admittanceDate = rdr.GetString(2);
        string animalBreed = rdr.GetString(3);
        Animal newAnimal = new Animal(animalName, animalGender, admittanceDate, animalBreed, animalId);
        allAnimals.Add(newAnimal);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allAnimals;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO animals (name, gender, date, breed) OUTPUT INSERTED.id VALUES (@Name, @Gender, @Date, @Breed);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@Name";
      nameParameter.Value = this.GetName();

      SqlParameter genderParameter = new SqlParameter();
      genderParameter.ParameterName = "@Gender";
      genderParameter.Value = this.GetGender();

      SqlParameter dateParameter = new SqlParameter();
      dateParameter.ParameterName = "@Date";
      dateParameter.Value = this.GetDate();

      SqlParameter breedParameter = new SqlParameter();
      breedParameter.ParameterName = "@Breed";
      breedParameter.Value = this.GetBreed();


      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(genderParameter);
      cmd.Parameters.Add(dateParameter);
      cmd.Parameters.Add(breedParameter);


      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
    }
    public static Animal Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM animals WHERE id = @AnimalId;", conn);
      SqlParameter animalIdParameter = new SqlParameter();
      animalIdParameter.ParameterName = "@animalId";
      animalIdParameter.Value = id.ToString();
      cmd.Parameters.Add(animalIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundAnimalId = 0;
      string foundAnimalName = null;
      string foundAnimalGender = null;
      string foundAnimalDate = null;
      string foundAnimalBreed = null;

      while(rdr.Read())
      {
        foundAnimalName = rdr.GetString(0);
        foundAnimalGender = rdr.GetString(1);
        foundAnimalDate = rdr.GetString(2);
        foundAnimalBreed = rdr.GetString(3);
        foundAnimalId = rdr.GetInt32(4);
      }
      Animal foundAnimal = new Animal(foundAnimalName, foundAnimalGender, foundAnimalDate, foundAnimalBreed, foundAnimalId);

      if (rdr != null)
			{
				rdr.Close();
			}
			if (conn != null)
			{
				conn.Close();
			}
      return foundAnimal;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM animals", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
