using NewPackageRefToMDTableConverter.Models;

public static class ReferenceExtensionMethods
{
    public static int GetLongestVersionLength(this IEnumerable<Reference> references)
    {
        return Math.Max(references.Max(x => x.Version.Length), "Version".Length);
    }

    public static int GetLongestNameLength(this IEnumerable<Reference> references)
    {
        return Math.Max(references.Max(x => x.Name.Length), "Reference".Length);
    }
}