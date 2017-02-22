using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using System;

namespace CssSorter
{
    internal sealed class RunOnFormatCommand : BaseCommand
    {
        private Guid _commandGroup = PackageGuids.guidPackageCmdSet;
        private const uint _commandId = PackageIds.RunOnFormatId;

        public override int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (pguidCmdGroup == _commandGroup && nCmdID == _commandId)
            {
                CssSorterPackage.Options.RunOnFormat = !CssSorterPackage.Options.RunOnFormat;
                CssSorterPackage.Options.SaveSettingsToStorage();

                return VSConstants.S_OK;
            }

            return Next.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public override int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == _commandGroup && prgCmds[0].cmdID == _commandId)
            {
                if (CssSorterPackage.Options.RunOnFormat)
                {
                    prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED | (uint)OLECMDF.OLECMDF_LATCHED;
                }
                else
                {
                    prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                }
            }

            return Next.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }
    }
}