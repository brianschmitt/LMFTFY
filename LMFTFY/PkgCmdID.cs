// PkgCmdID.cs
// MUST match PkgCmdID.h
using System;

namespace BrianSchmitt.LMFTFY
{
    static class PkgCmdIDList
    {
        public const uint cmdidFindRegions = 0x100;
        public const uint cmdidFindDeprecatedStyles = 0x200;
        public const uint cmdidFindRepeatedBlankLines = 0x300;
        public const uint cmdidFindTrailingWhiteSpace = 0x400;
        public const uint cmdidFindEmptyCatch = 0x500;
        public const uint cmdidFindHardCodedStyles = 0x600;
        public const uint cmdidFindCommentedCode = 0x1000;
    };
}