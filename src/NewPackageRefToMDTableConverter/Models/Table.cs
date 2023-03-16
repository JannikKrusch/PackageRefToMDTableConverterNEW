using NewPackageRefToMDTableConverter.Util;

namespace NewPackageRefToMDTableConverter.Models;

public record Table
{
    public List<string> Lines { get; set; } = new List<string>();
}
