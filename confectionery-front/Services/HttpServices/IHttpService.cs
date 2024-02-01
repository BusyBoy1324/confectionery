namespace confectionery_front.Services.HttpServices
{
    public interface IHttpService
    {
        public Task<T> CreateAsync<T>(HttpResponseMessage response);
        public Task<List<T>> DeleteAsync<T>(HttpResponseMessage response);
        public Task<List<T>> GetAllAsync<T>(HttpResponseMessage response);
        public Task<T> GetByIdAsync<T>(HttpResponseMessage response);
        public Task<T> UpdateAsync<T>(HttpResponseMessage response);
    }
}
