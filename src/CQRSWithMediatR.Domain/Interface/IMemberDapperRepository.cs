using CQRSWithMediatR.Domain.Entities;

namespace CQRSWithMediatR.Domain.Interface;
public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int id);
}
