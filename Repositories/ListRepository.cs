using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMasterCSharp.Models;

namespace TaskMasterCSharp.Repositories
{
  public class ListRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT list.*, profile.* FROM lists list INNER JOIN profiles profile ON list.creatorId = profile.id ";

    public ListRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(List newList)
    {
      string sql = @"
      INSERT INTO lists
      (title, body, creatorId)
      VALUES
      (@Title, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newList);
    }

    public IEnumerable<List> GetLists()
    {
      string sql = populateCreator;
      return _db.Query<List, Profile, List>(sql, (list, profile) => { list.Creator = profile; return list; }, splitOn: "id");
    }
  }
}