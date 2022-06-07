using AutoMapper;
using Bookinghun.Models;
using Bookinghut.Models;
using Bookinghut.Models.Request;
using Bookinghut.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Services
{
    public interface IUserService {
        Task<List<MUser>> Get(UserSearchRequestdto search);
        Task<MUser> GetById(int ID);
        Task<MUser> Insert(UserUpsertRequestdto request);
        Task<MUser> Update(int ID, UserUpsertRequestdto request);
        Task<bool> Delete(int ID);
    }
    public class UserService:IUserService
    {
        private readonly BookinghutContext _context;
        private readonly IMapper _mapper;
        public UserService(BookinghutContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MUser>> Get(UserSearchRequestdto search)
        {

            var query = _context.Users.AsQueryable();

            if (search.ID != 0)
            {
                query = query.Where(i => i.Id == search.ID);
            }

           

            var list = await query.ToListAsync();
            return _mapper.Map<List<MUser>>(list);
        }

        public async Task<MUser> GetById(int ID)
        {
            var entity = await _context.Users
               .Where(i => i.Id== ID)
               .SingleOrDefaultAsync();

            return _mapper.Map<MUser>(entity);
        }

        public async Task<MUser> Insert(UserUpsertRequestdto request)
        {
            var entity = _mapper.Map<User>(request);
            _context.Set<User>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }

        public async Task<MUser> Update(int ID, UserUpsertRequestdto request)
        {
            var entity = _context.Set<User>().Find(ID);
            _context.Set<User>().Attach(entity);
            _context.Set<User>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }

        public async Task<bool> Delete(int ID)
        {
            var user= await _context.Users.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
