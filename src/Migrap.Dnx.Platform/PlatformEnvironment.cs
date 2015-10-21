using Microsoft.Dnx.Runtime;
using System;
using System.Linq;

namespace Migrap.Dnx.Platform {
    public partial class PlatformEnvironment : IPlatformEnvironment {
        private readonly IRuntimeEnvironment _runtime;

        public PlatformEnvironment(IRuntimeEnvironment runtime) {
            _runtime = runtime;
        }

        public bool Is(Func<IPlatformEnvironmentExtension, Func<IRuntimeEnvironment, bool>> platform) {
            return platform(null)(_runtime);
        }

        public bool Any(params Func<IPlatformEnvironmentExtension, Func<IRuntimeEnvironment, bool>>[] platforms) {
            return platforms.Any(x => x(null)(_runtime));
        }      
    }
}