namespace tunder.Model.Repository
{
    public interface IUserRepository
    {
        User GetById(long id);
    }
}