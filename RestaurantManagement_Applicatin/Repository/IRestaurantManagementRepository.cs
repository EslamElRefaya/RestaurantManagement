namespace RestaurantManagement_Applicatin.Repository
{
   public interface IRestaurantManagementRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllItemsRepo();
        Task<TEntity> GetItemByIdRepo(int id);
        Task AddItemRepo(TEntity entity);
        Task UpdateItemRepo(TEntity entity);
        Task DeleteItemRepo(TEntity entity);
    }
    
}
