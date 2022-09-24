using Domain.Entity;


namespace Domain.IRepo
{
    public interface IAddressRepo
    {
        public bool Add(string province, string city, int postal, int user_fk,string detail);
        public bool Remove(int id);
        public bool Update(int id ,string province, string city, int postal, string detail);
        public IQueryable GetAll();

        public Address GetById(int id);
    }
}
