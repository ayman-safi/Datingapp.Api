using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.api.Data {
    public class DatingRepository : IDatingRepository {
        private readonly DataContext _context;
        public DatingRepository (DataContext context) {
            _context = context;

        }
        public void Add<T> (T Entity) where T : class {
            _context.Add(Entity);
        }

        public void Delete<T> (T Entity) where T : class {
            _context.Remove(Entity);
        }

        public async Task<IEnumerable<User>> GetUsers() {
            var users = await _context.Users.Include(p =>p.Photos).ToListAsync();
            return users ;
        }

        public async Task<User> GetUser(int Id) {
           var user = await _context.Users.Include(p =>p.Photos).FirstOrDefaultAsync(x => x.Id == Id) ;
           return user ;
        }

        public async Task<bool> SaveAll () {
            return await _context.SaveChangesAsync() > 0 ;
        } 
    }
}