using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Authentication
{
    public interface IAuthenticationStatusObserver
    {
        void Update(AuthenticatedStatusEnum authenticatedStatus);
    }
}
