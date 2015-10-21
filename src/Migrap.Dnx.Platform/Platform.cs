using Microsoft.Dnx.Runtime;
using System;

namespace Migrap.Dnx.Platform {
    public partial class Platform {
        private readonly IRuntimeEnvironment _runtime;

        public Platform(IRuntimeEnvironment runtime) {
            _runtime = runtime;
        }

        public bool Is(Func<IPlatformExtension, Func<IRuntimeEnvironment,bool>> platform) {
            return true;
        }
    }    
}