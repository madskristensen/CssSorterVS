using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace CssSorter
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [Guid(PackageGuids.guidPackageString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class CssSorterPackage : AsyncPackage
    {

    }
}
