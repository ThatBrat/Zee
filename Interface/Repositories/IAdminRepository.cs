namespace Zee.Interface.Repositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetAdmin(int id);
   
    }
}