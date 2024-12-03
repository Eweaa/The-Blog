namespace Services;

public static class Utilities
{
    public static string ModifyPath(string path)
    {
        path = path?.Replace("wwwroot", "https://localhost:7145");
        return path ?? null;
    }
}