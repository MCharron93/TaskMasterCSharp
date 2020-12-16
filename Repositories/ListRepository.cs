using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMasterCSharp.Models;

namespace TaskMasterCSharp.Repositories
{
  public class BlogRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT blog.*, profile.* FROM blogs blog INNER JOIN profiles profile ON blog.creatorId = profile.id";

    public BlogRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Blog newBlog)
    {
      string sql = @"
      INSERT INTO blogs
      (title, body, creatorId)
      VALUES
      (@Title, @Body, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      return _db.ExecuteScalar<int>(sql, newBlog);
    }

    public IEnumerable<Blog> GetBlogs()
    {
      string sql = populateCreator + "WHERE isPublished = 1";
      return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, splitOn: "id");
    }
  }
}