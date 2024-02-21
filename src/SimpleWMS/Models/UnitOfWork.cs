using Microsoft.EntityFrameworkCore.Storage;
using SimpleWMS.Database.Context;

namespace SimpleWMS.Mdels;


public class UnitOfWork : IDisposable
{
    private readonly ApplicationDbContext _context;
    private bool _disposed = false;
    private IDbContextTransaction _currentTransaction;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        _currentTransaction = _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        if (_currentTransaction == null)
        {
            throw new InvalidOperationException("No active transaction to commit.");
        }

        try
        {
            _context.SaveChanges();
            _currentTransaction.Commit();
        }
        catch
        {
            _currentTransaction.Rollback();
            throw;
        }
        finally
        {
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }
    }

    public void RollbackTransaction()
    {
        if (_currentTransaction != null)
        {
            _currentTransaction.Rollback();
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
