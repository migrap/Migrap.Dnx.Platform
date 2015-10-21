using Microsoft.Dnx.Runtime;
using System;
using System.Runtime.InteropServices;

namespace Migrap.Dnx.Platform {
    public static partial class PlatformExtensions {
        private static bool? _windows;
        private static bool? _mono;
        private static bool? _nano;

        public static bool Windows(this IPlatformExtension extension, IRuntimeEnvironment runtime) {
            if(_windows== null) {
                _windows= runtime.RuntimeType.Equals(nameof(Windows), StringComparison.OrdinalIgnoreCase);
            }
            return _windows.Value;             
        }

        public static bool Mono(this IPlatformExtension extension, IRuntimeEnvironment runtime) {
            if(_mono == null) {
                _mono = runtime.RuntimeType.Equals(nameof(Mono), StringComparison.OrdinalIgnoreCase);
            }
            return _mono.Value;
        }

        public static bool Nano(this IPlatformExtension extension, IRuntimeEnvironment runtime) {
            if(_nano == null) {
                var version = new Version(runtime.OperatingSystemVersion ?? "");

                try {
                    int productType;
                    _nano = GetProductInfo(version.Major, version.Minor, 0, 0, out productType) && productType == PRODUCT_NANO_SERVER;
                }
                catch {
                    _nano = false;
                }
            }
            return _nano.Value;
        }

        private const int PRODUCT_NANO_SERVER = 0x0000006D;

        [DllImport("api-ms-win-core-sysinfo-l1-2-1.dll", SetLastError = false)]
        private static extern bool GetProductInfo(int dwOSMajorVersion, int dwOSMinorVersion, int dwSpMajorVersion, int dwSpMinorVersion, out int pdwReturnedProductType);
    }
}