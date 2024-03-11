using CQRSWithMediatR.Domain.Entities;
using CQRSWithMediatR.Domain.Interface;
using CQRSWithMediatR.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatR.Infra.Repositories;
public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;

    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Member> AddMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        await _context.AddAsync(member);
        return member;
    }

    public async Task<Member> DeleteMember(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        _context.Members.Remove(member);

        return member;
    }

    public async Task<Member> GetMemberById(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member is null)
            throw new InvalidOperationException("Member not found");

        return member;
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        var members = await _context.Members.ToListAsync();
        return members ?? Enumerable.Empty<Member>();
    }

    public void UpdateMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        _context.Members.Update(member);
    }
}
