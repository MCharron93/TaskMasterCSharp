using System;
using System.Data;
using Dapper;
using TaskMasterCSharp.Models;

namespace TaskMasterCSharp.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    // NOTE Life is hard enough as it is, don't beat yourself up for not knowing or being bad at things, Michelle
    public Profile GetByEmail(string email)
    {
      string sql = "SELECT * FROM profiles WHERE email = @Email";
      return _db.QueryFirstOrDefault<Profile>(sql, new { email });
    }

    public Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (name, email, picture, id)
      VALUES
      (@Name, @Email, @Picture, @Id);
      ";
      _db.Execute(sql, userInfo);
      return userInfo;
    }

  }

  // NOTE remember who you want to be, kind and understanding of those who struggle, even yourself. Not judging others for being good or bad at things. Some people have to work really hard Michelle, and that sucks that you're one of those people, BUT you can get better if you try. 
}