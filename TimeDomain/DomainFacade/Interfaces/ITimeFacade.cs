using BerlinClock.TimeDomain.Models;

namespace BerlinClock.TimeDomain.DomainFacade.Interfaces
{
    public interface ITimeFacade
    {
        Time GetTime(string strTime);
    }
}
