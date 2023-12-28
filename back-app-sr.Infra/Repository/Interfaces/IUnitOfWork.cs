namespace back_app_sr.Infra.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Commit();
}