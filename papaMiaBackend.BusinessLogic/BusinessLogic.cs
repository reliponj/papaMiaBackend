using papaMiaBackend.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.BusinessLogic
{
    public class BusinessLogic
    {
        public ISessionAction GetSessionBL()
        {
            return new SessionBL();
        }
    }
}