using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using System;
using System.Threading.Tasks;

namespace CssSorter
{
    internal sealed class ModeCommand : BaseCommand
    {
        private Guid _commandGroup = PackageGuids.guidPackageCmdSet;

        public override int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (pguidCmdGroup == _commandGroup)
            {
                switch (nCmdID)
                {
                    case PackageIds.SortAlphabeticallyId:
                        Execute(Mode.Alphabetically);
                        return VSConstants.S_OK;
                    case PackageIds.SortSmacssId:
                        Execute(Mode.SMACSS);
                        return VSConstants.S_OK;
                    case PackageIds.SortconcentricId:
                        Execute(Mode.Concentric);
                        return VSConstants.S_OK;
                }
            }

            return Next.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        private void Execute(Mode mode)
        {
            CssSorterPackage.Options.Mode = mode;
            CssSorterPackage.Options.SaveSettingsToStorage();
        }

        public override int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == _commandGroup)
            {
                if (prgCmds[0].cmdID == PackageIds.SortAlphabeticallyId)
                {
                    prgCmds[0].cmdf = GetFlags(Mode.Alphabetically);
                    return VSConstants.S_OK;
                }
                else if (prgCmds[0].cmdID == PackageIds.SortSmacssId)
                {
                    prgCmds[0].cmdf = GetFlags(Mode.SMACSS);
                    return VSConstants.S_OK;
                }
                else if (prgCmds[0].cmdID == PackageIds.SortconcentricId)
                {
                    prgCmds[0].cmdf = GetFlags(Mode.Concentric);
                    return VSConstants.S_OK;
                }
            }

            return Next.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        private static uint GetFlags(Mode mode)
        {
            if (CssSorterPackage.Options.Mode == mode)
            {
                return (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED | (uint)OLECMDF.OLECMDF_LATCHED;
            }
            else
            {
                return (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
            }
        }
    }
}