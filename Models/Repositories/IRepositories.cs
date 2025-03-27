namespace project_clinic.Models.Repositories
{
    public interface IRepositories<Table>
    {
        List<Table> GetAll();
        int Add(Table item);
        void Edit(int id, Table item);
        void Delete(int id);

        List<Table> Search(string SerachItem);
        Table Find(int Id);


    }
}
