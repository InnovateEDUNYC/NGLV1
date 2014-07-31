namespace NGL.Web.Extensions
{
    public static class BooleanExtensions
{
    public static string ToYesNoString(this bool value)
    {
        return value ? "Yes" : "No";
    }
}
}