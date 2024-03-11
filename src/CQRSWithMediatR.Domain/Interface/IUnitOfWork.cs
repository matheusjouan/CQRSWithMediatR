namespace CQRSWithMediatR.Domain.Interface;
public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }

    Task CommitAsync();
}
