namespace papaMiaBackend.Api.Auth;

public interface ICurrentUser
{
    int? UserId { get; }

    bool TryGetUserId(out int userId);
}
