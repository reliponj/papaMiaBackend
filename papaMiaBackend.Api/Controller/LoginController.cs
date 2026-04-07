using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.Api.Controller
{
    public class LoginController
    {
        private readonly ISessionAction _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        
    }
}
