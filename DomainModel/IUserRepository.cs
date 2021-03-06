namespace DomainModel
{
    public interface IUserRepository
    {
        User LoadUser(string username);
        void SaveUser(User user);
        void Delete(User user);
    }
}