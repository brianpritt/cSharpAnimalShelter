using System;
using System.Collections.Generic;

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
  }
}
