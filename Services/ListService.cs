using System;
using System.Collections.Generic;
using TaskMasterCSharp.Models;
using TaskMasterCSharp.Repositories;

namespace TaskMasterCSharp.Services
{
  public class ListService
  {
    private readonly ListRepository _repo;

    public ListService(ListRepository repo)
    {
      _repo = repo;
    }

    public List Create(List newList)
    {
      newList.Id = _repo.Create(newList);
      return newList;
    }

    public IEnumerable<List> GetLists()
    {
      return _repo.GetLists();
    }

    public List GetListById(int id)
    {
      return _repo.GetListById(id);
    }
  }
}