namespace papaMiaBackend.Domain.Models.User;

public enum ChangePasswordResult
{
    Success,
    UserNotFound,
    InvalidCurrentPassword
}
