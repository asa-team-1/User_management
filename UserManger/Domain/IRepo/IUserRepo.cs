using Domain.Entity;


namespace Domain.IRepo
{
    public interface IUserRepo
    {
        public Task<bool> Add(string name, string lastName, string phoneNumber, string password, bool isActive = true,
            int level = 0);

        public Task<bool> Remove(int id);

        public Task<bool> Update(int id, string name, string lastName, string password);

        public IEnumerable<User> GetAll();

        public User? GetByMobile(string mobile);
    }
}
