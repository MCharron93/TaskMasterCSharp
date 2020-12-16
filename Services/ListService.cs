using System;
using System.Collections.Generic;
using TaskMasterCSharp.Models;
using TaskMasterCSharp.Repositories;

namespace TaskMasterCSharp.Services
{
  public class BlogService
  {
    private readonly BlogRepository _repo;

    public BlogService(BlogRepository repo)
    {
      _repo = repo;
    }

    public Blog Create(Blog newBlog)
    {
      newBlog.Id = _repo.Create(newBlog);
      return newBlog;
    }

    public IEnumerable<Blog> GetBlogs()
    {
      return _repo.GetBlogs();
    }
  }
}