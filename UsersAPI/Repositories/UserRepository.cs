using Microsoft.EntityFrameworkCore;
using UsersAPI.Context;
using UsersAPI.Models;
using UsersAPI.Repositories.Interface;

namespace UsersAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private const string Ativo = "ATIVO";

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Delete(int id)
        {
            var user = GetById(id).Result;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> GetByNameAndPassword(User user)
        {
            return await _context.Users.Where(u => u.Login == user.Login && u.Password == user.Password && u.Status.ToUpper() == Ativo).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateStatus(User user)
        {
            var userLocal = GetById(user.Id).Result;
            _context.Entry(userLocal).State = EntityState.Detached;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public bool GetUserByLoginEmailCpf(string login, string email, string cpf)
        {
            var user = _context.Users.Where(u => u.Login == login && u.Email == email && u.CPF == cpf).FirstOrDefaultAsync().Result;
            return (user != null);
        }
    }
}
