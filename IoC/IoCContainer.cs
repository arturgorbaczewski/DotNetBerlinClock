using Autofac;
using BerlinClock.ClockDomain.DomainFacade;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.DomainFacade.TimeDomain;
using BerlinClock.TimeConverters;
using BerlinClock.TimeDomain.DomainFacade.Interfaces;

namespace BerlinClock.IoC
{
    public static class IoCContainer
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ColorPicker>().As<IColorPicker>();
            builder.RegisterType<TimeFacade>().As<ITimeFacade>();
            builder.RegisterType<ClockRowFacade>().As<IClockRowFacade>();
            builder.RegisterType<BerlinClockFacade>().As<IClockFacade>();
            builder.RegisterType<TimeConverter>().As<ITimeConverter>();
            return builder.Build();
        }
    }
}
