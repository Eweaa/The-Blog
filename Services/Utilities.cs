namespace Services;

public static class Utilities
{
    public static string ModifyPath(string path)
    {
        path = path?.Replace("wwwroot", "https://localhost:44377");
        return path ?? null;
    }
}