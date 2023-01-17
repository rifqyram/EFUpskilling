namespace EFUpskilling.Repositories;

public interface IPersistence
{
    void SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
}