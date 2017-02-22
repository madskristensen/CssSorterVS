using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using System;

namespace CssSorter
{
    internal sealed class FormatDocumentCommand : BaseCommand
    {
        private Guid _commandGroup = VSConstants.VSStd2K;
        private const int _commandId = (int)VSConstants.VSStd2KCmdID.FORMATDOCUMENT;

        private IWpfTextView _view;
        private ITextBufferUndoManager _undoManager;
        private NodeProcess _node;

        public FormatDocumentCommand(IWpfTextView view, ITextBufferUndoManager undoManager, NodeProcess node)
        {
            _view = view;
            _undoManager = undoManager;
            _node = node;
        }

        public override int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (pguidCmdGroup == _commandGroup && nCmdID == _commandId)
            {
                if (CssSorterPackage.Options.RunOnFormat && _node != null && _node.IsReadyToExecute())
                {
                    ThreadHelper.JoinableTaskFactory.Run(() => SortCommand.ExecuteAsync(_view, _undoManager, _node));
                }
            }

            return Next.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }

        public override int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == _commandGroup && prgCmds[0].cmdID == _commandId)
            {
                if (CssSorterPackage.Options.RunOnFormat && _node != null)
                {
                    if (_node.IsReadyToExecute())
                    {
                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                    }
                    else
                    {
                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_SUPPORTED;
                    }
                }

                return VSConstants.S_OK;
            }

            return Next.QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }
    }
}