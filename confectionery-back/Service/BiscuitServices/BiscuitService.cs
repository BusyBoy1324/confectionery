using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.Service.BiscuitServices
{
	public class BiscuitService : IBiscuitService
	{
		private readonly ConfectionaryContext _context;
		private readonly IMapper _mapper;

		public BiscuitService(ConfectionaryContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Biscuit>> GetAllAsync()
		{
			return await _context.Biscuits.ToListAsync();
		}

		public async Task<Biscuit> GetByIdAsync(Guid id)
		{
			return await _context.Biscuits.FirstOrDefaultAsync(biscuit => biscuit.Id == id);
		}

		public async Task<Biscuit> InsertAsync(BiscuitDto biscuitDto)
		{
			Biscuit biscuit = GetMappedBiscuit(biscuitDto);

			if (biscuit is null)
			{
				throw new Exception("Can't insert biscuit because it's null");
			}

			_context.Biscuits.Add(biscuit);
			await SaveAsync();
			return biscuit;
		}

		public async Task DeleteAsync(Guid id)
		{
			Biscuit biscuit = await GetByIdAsync(id);
			_context.Biscuits.Remove(biscuit);
			await SaveAsync();
		}

		public async Task<Biscuit> UpdateAsync(Biscuit biscuit)
		{
			_context.Biscuits.Update(biscuit);
			await SaveAsync();
			return biscuit;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		private Biscuit GetMappedBiscuit(BiscuitDto biscuitDto)
		{
			return _mapper.Map<Biscuit>(biscuitDto);
		}
	}
}
