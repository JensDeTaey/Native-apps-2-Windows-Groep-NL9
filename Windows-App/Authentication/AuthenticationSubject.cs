using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Authentication
{
    public abstract class AuthenticationSubject
    {
            private List<IAuthenticationStatusObserver> _observers = new List<IAuthenticationStatusObserver>();

            public void Attach(IAuthenticationStatusObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IAuthenticationStatusObserver observer)
            {
                _observers.Remove(observer);
            }

            public void NotifyObservers(AuthenticatedStatusEnum authenticatedStatus)
            {
                foreach (IAuthenticationStatusObserver o in _observers)
                {
                    o.Update(authenticatedStatus);
                }
            }
        
    }
}
