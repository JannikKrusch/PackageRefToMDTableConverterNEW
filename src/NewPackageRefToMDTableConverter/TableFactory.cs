using NewPackageRefToMDTableConverter.Models;
using NewPackageRefToMDTableConverter.Util;

namespace NewPackageRefToMDTableConverter;

public class TableFactory
{
    public static Table Create(List<Reference> references)
    {
        var table = new Table();

        var lengthOfName = references.GetLongestNameLength();
        var lengthOfVersion = references.GetLongestVersionLength();

        table.CreateHeader(lengthOfName, lengthOfVersion);
        table.CreatePartingLine(lengthOfName, lengthOfVersion);

        references.ForEach(r => table.CreateRow(r, lengthOfName, lengthOfVersion));

        return table;
    }
}