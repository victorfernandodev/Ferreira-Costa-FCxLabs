using UsersAPI.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Delete(int id);
        Task<User> Update(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByNameAndPassword(User user);
        Task<User> UpdateStatus(User user);
        bool GetUserByLoginEmailCpf(string login, string email, string cpf);


    }
}
