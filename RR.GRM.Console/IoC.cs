using System;
using System.Collections.Generic;
using System.Text;
using RR.GRM.Core;
using RR.GRM.Core.Repositories;
using StructureMap;

namespace RR.GRM.Console
{
    public class IoC
    {
        private static readonly Lazy<IContainer> Init = new Lazy<IContainer>(() =>
        {
            var container = new Container(x =>
            {
                x.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<ArgumentParser>();
                    scanner.WithDefaultConventions();
                });

                x.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<PartnerMusicContractProvider>();
                    scanner.WithDefaultConventions();
                });

                x.For<ICoreSettings>().Use<Config>();
                x.For<IDateParser>().Use<OrdinalDateParser>();
                x.For<IInputData>().Use<FlatFileContentsProvider>();
                x.For<IMusicContractRepository>().Use<FlatFileMusicContractRepository>();
                x.For<IPartnerRepository>().Use<FlatFilePartnerRepository>();
            });

            return container;
        });

        public static IContainer Container => Init.Value;

    }
}
