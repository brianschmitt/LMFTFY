using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;

namespace BrianSchmitt.LMFTFY
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidLMFTFYPkgString)]
    public sealed class LMFTFYPackage : Package
    {
        public LMFTFYPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;
                var search = new Search(dte);
                AddMenu(mcs, search.FindRegions, (int)PkgCmdIDList.cmdidFindRegions);
                AddMenu(mcs, search.FindDeprecatedStyles, (int)PkgCmdIDList.cmdidFindDeprecatedStyles);
                AddMenu(mcs, search.FindRepeatedBlankLines, (int)PkgCmdIDList.cmdidFindRepeatedBlankLines);
                AddMenu(mcs, search.FindTrailingWhiteSpace, (int)PkgCmdIDList.cmdidFindTrailingWhiteSpace);
                AddMenu(mcs, search.FindEmptyCatch, (int)PkgCmdIDList.cmdidFindEmptyCatch);
                AddMenu(mcs, search.FindHardcodedStyles, (int)PkgCmdIDList.cmdidFindHardCodedStyles);
                AddMenu(mcs, search.FindCommentedCode, (int)PkgCmdIDList.cmdidFindCommentedCode);
            }
        }

        private void AddMenu(OleMenuCommandService mcs, EventHandler menuCallback, int commandId)
        {
            CommandID menuCommandID = new CommandID(GuidList.guidLMFTFYCmdSet, commandId);
            MenuCommand menuItem = new MenuCommand(menuCallback, menuCommandID);
            mcs.AddCommand(menuItem);
        }
    }
}
