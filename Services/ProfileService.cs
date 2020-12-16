using System;
using TaskMasterCSharp.Models;
using TaskMasterCSharp.Repositories;

namespace TaskMasterCSharp.Services
{
  public class ProfileService
  {
    private readonly ProfileRepository _repo;

    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }

    // NOTE it's okay to lose, it just means there's so much more the learn, Michelle

    public Profile GetProfile(Profile userInfo)
    {
      Profile foundProfile = _repo.GetByEmail(userInfo.Email);
      if (foundProfile == null)
      {
        return _repo.Create(userInfo);
      }
      return foundProfile;
    }

    // NOTE If people only care about your accomplishments, then they don't care about you; they care about your glory, which isn't the same
  }
}