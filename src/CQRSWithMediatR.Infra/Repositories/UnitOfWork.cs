using CQRSWithMediatR.Domain.Interface;
using CQRSWithMediatR.Infra.Context;

namespace CQRSWithMediatR.Infra.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepository;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    // Responsável por fornecer uma instância do repositório associado
    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository = _memberRepository ?? new MemberRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
