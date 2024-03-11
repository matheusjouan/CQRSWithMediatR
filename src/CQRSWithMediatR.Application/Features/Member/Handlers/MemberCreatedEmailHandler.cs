using CQRSWithMediatR.Application.Features.Member.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSWithMediatR.Application.Features.Member.Handlers;
public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
{
    private readonly ILogger<MemberCreatedEmailHandler>? _logger;

    public Task Handle(MemberCreatedNotification notification, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
