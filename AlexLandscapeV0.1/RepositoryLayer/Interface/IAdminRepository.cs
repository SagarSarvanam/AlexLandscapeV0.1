using AlexLandscapeV0._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AlexLandscapeV0._1.RepositoryLayer.Interface
{
    public interface IAdminRepository
    {
        DataTable Login(string username, string password);
    }
}
