using AutoMapper;
using Bookinghun.Models;
using Bookinghun.Models.Request;
using Bookinghut.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Services
{
    public interface IVenueService
    {
        Task<List<MVenue>> Get(VenueSearchRequest search);
        Task<MVenue> GetById(int ID);
        Task<MVenue> Insert(VenueInsertRequest request);
        Task<MVenue> Update(int ID, VenueInsertRequest request);
        Task<bool> Delete(int ID);
    }


    public class VenueService{
        public BookinghutContext Context { get; set; }
        protected readonly IMapper _mapper;

        public VenueService(BookinghutContext bookinghutContext, IMapper mapper)
        {
            Context = bookinghutContext;
            _mapper = mapper;
        }


        public async Task<List<MVenue>> Get(VenueSearchRequest search)
        {

            var query = Context.Venue.AsQueryable();

            if (search.ID != 0)
            {
                query = query.Where(i => i.ID == search.ID);
            }


            var list = await query.ToListAsync();
            return _mapper.Map<List<MVenue>>(list);
        }

        public async Task<MVenue> GetById(int ID)
        {
            var entity = await Context
               .Include(i => i.Proizvod)
               .Where(i => i.KorisnikID == ID)
               .SingleOrDefaultAsync();

            return _mapper.Map<MVenue>(entity);
        }

        public async Task<MVenue> Insert(VenueSearchRequest request)
        {
            var entity = _mapper.Map<MVenue>(request);
            Context.Set<MVenue>().Add(entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<MVenue>(entity);
        }

        public async Task<Model.Rate> Update(int ID, RateUpsertRequest request)
        {
            var entity = _context.Set<Rate>().Find(ID);
            _context.Set<Rate>().Attach(entity);
            _context.Set<Rate>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Rate>(entity);
        }

        public async Task<bool> Delete(int ID)
        {
            var rate = await _context.Rate.Where(i => i.KorisnikID == ID).Include(i => i.ProizvodID).FirstOrDefaultAsync();
            if (rate != null)
<<<<<<< HEAD
    {
                Context.Venues.Remove(rate);
                await Context.SaveChangesAsync();
=======
            {
                _context.Rate.Remove(rate);
                await _context.SaveChangesAsync();
>>>>>>> parent of acbdd70 (venuee)
                return true;
            }
            return false;
        }

    }

    
}
