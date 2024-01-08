using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.Service.FillingServices
{
	public class FillingService : IFillingService
	{
		private readonly ConfectionaryContext _context;
		private readonly IMapper _mapper;

		public FillingService(ConfectionaryContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<Filling>> GetAllAsync()
		{
			return await _context.Fillings.ToListAsync();
		}

		public async Task<Filling> GetByIdAsync(Guid id)
		{
			return await _context.Fillings.FirstOrDefaultAsync(filling => filling.Id == id);
		}

		public async Task<Filling> InsertAsync(FillingDto fillingDto)
		{
			Filling filling = GetMappedFilling(fillingDto);

			if (filling is null)
			{
				throw new Exception("Can't insert filling because it's null");
			}

			_context.Fillings.Add(filling);
			await SaveAsync();
			return filling;
		}

		public async Task DeleteAsync(Guid id)
		{
			Filling filling = await GetByIdAsync(id);
			_context.Fillings.Remove(filling);
			await SaveAsync();
		}

		public async Task<Filling> UpdateAsync(Filling filling)
		{
			_context.Fillings.Update(filling);
			await SaveAsync();
			return filling;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		private Filling GetMappedFilling(FillingDto fillingDto)
		{
			return _mapper.Map<Filling>(fillingDto);
		}
	}
}
