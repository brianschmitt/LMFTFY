using EnvDTE80;
using System;

namespace BrianSchmitt.LMFTFY
{
    public class Search
    {
        private const string webFiletypes = "*.as?x;*.*htm*";
        private const string codeFiletypes = "*.*";
        private const string allFiletypes = "*.*";

        private readonly DTE2 dte;

        public Search(DTE2 dte)
        {
            this.dte = dte;
        }

        public void FindRegions(object sender, EventArgs e)
        {
            /// ^.*\#(\s)*(end)*(?([^\r\n])\s)*region.*\n
            FindRegex("^.*\\#(\\s)*(end)*(?([^\\r\\n])\\s)*region.*\\n", allFiletypes);
        }

        public void FindDeprecatedStyles(object sender, EventArgs e)
        {
            /// ((style|align|width)=)|(strong)
            FindRegex("((style|align|width)=)|(strong)", webFiletypes);
        }

        public void FindRepeatedBlankLines(object sender, EventArgs e)
        {
            /// (\r?\n){3,}
            FindRegex("(\\r?\\n){3,}", allFiletypes, "\\n\\n");
        }

        public void FindCommentedCode(object sender, EventArgs e)
        {
            /// [\\\|']\s*(if|while|for|do|var|Dim|return|try)
            FindRegex("[\\\\\\|']\\s*(if|while|for|do|var|Dim|return|try)", codeFiletypes);
        }

        public void FindTrailingWhiteSpace(object sender, EventArgs e)
        {
            /// [^\S\r\n]\r
            FindRegex("[^\\S\\r\\n]\\r", codeFiletypes);
        }

        public void FindEmptyCatch(object sender, EventArgs e)
        {
            /// catch.*\r?\n\s+((End Try)|(\{[\s\n]+\})|(\}))
            /// catch.*[\r?\n\s]*((End Try)|(\{\s*\r?\n*\}))
            FindRegex("catch.*[\\r?\\n\\s]*((End Try)|(\\{\\s*\\r?\\n*\\}))", codeFiletypes);
        }

        public void FindHardcodedStyles(object sender, EventArgs e)
        {
            /// (backcolor|border.*|Font-.*|forecolor|height|width)
            FindRegex("(backcolor|border.*|Font-.*|forecolor|height|width)", webFiletypes);
        }

        private void FindRegex(string pattern, string fileTypes, string replacement = "")
        {
            dte.ExecuteCommand("Edit.FindinFiles");
            dte.Find.FindWhat = pattern;
            dte.Find.FilesOfType = fileTypes;
            dte.Find.Action = EnvDTE.vsFindAction.vsFindActionFindAll;
            dte.Find.Target = EnvDTE.vsFindTarget.vsFindTargetSolution;
            dte.Find.PatternSyntax = EnvDTE.vsFindPatternSyntax.vsFindPatternSyntaxRegExpr;
            dte.Find.ReplaceWith = replacement;
        }
    }
}
