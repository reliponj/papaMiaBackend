using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.BusinessLogic.Structure;

namespace papaMiaBackend.BusinessLogic;

public class BusinessLogic
{
    public BusinessLogic() { }

    public IUserAction UserAction()
    {
        return new UserActionExecution();
    }
}