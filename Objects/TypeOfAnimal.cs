using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnimalShelter
{
  public class TypeOfAnimal
  {
    private int _id;
    private string _type;

    public TypeOfAnimal(string Type, int Id = 0)
    {
      _type = Type;
      _id = Id;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetType()
    {
      return _type;
    }
    public static List<TypeOfAnimal> GetAll()
    {
      List<TypeOfAnimal> allTypes = new List<TypeOfAnimal>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM typeofanimal;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int typeId = rdr.GetInt32(0);
        string typeName = rdr.GetString(1);
        TypeOfAnimal newType = new TypeOfAnimal(typeName, typeId);
        allTypes.Add(newType);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allTypes;
    }
  }
}
