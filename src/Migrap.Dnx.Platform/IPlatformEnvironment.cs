using Microsoft.Dnx.Runtime;
using System;

namespace Migrap.Dnx.Platform {
    public interface IPlatformEnvironment {
        bool Is(Func<IPlatformEnvironmentExtension, Func<IRuntimeEnvironment, bool>> platform);
        bool Any(params Func<IPlatformEnvironmentExtension, Func<IRuntimeEnvironment, bool>>[] platforms);
    }
}