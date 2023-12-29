using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace back_app_sr.Infra.Repository.Service;

public class UnitOfWork : IUnitOfWork
{
    public ApplicationContext _context = null;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }   

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}