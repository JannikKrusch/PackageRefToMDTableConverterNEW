using NewPackageRefToMDTableConverter.Models;

namespace NewPackageRefToMDTableConverter.Util;

public static class TableExtensionMethods
{
    public static void CreateHeader(this Table table, int lengthOfName, int lengthOfVersion)
    {
        table.Lines.Add($"| Reference{new string(' ', lengthOfName - "Reference".Length)} | Version{new string(' ', lengthOfVersion - "Version".Length)} |");
    }

    public static void CreatePartingLine(this Table table, int lengthOfName, int lengthOfVersion)
    {
        table.Lines.Add($"| {new string('-', lengthOfName)} | {new string('-', lengthOfVersion)} |");
    }

    public static void CreateRow(this Table table, Reference reference, int lengthOfName, int lengthOfVersion)
    {
        table.Lines.Add($"| {reference.Name}{new string(' ', lengthOfName - reference.Name.Length)} | {reference.Version}{new string(' ', lengthOfVersion - reference.Version.Length)} |");
    }
}
