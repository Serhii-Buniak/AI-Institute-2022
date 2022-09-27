namespace Lab2;

public static class Numbers
{
    public static List<bool> One => new List<int>()
    {
        0, 0, 1, 0, 0,
        0, 1, 1, 0, 0,
        1, 0, 1, 0, 0,
        0, 0, 1, 0, 0,
        0, 0, 1, 0, 0,
        0, 0, 1, 0, 0,
        1, 1, 1, 1, 1,
    }.Select(n => Convert.ToBoolean(n)).ToList();   
    
    public static List<bool> Two => new List<int>()
    {
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 0, 0, 1, 0,
        0, 0, 1, 0, 0,
        0, 1, 0, 0, 0,
        1, 1, 1, 1, 1,
    }.Select(n => Convert.ToBoolean(n)).ToList();    

    public static List<bool> Three => new List<int>()
    {
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 0, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();

    public static List<bool> Four => new List<int>()
    {
        0, 0, 0, 1, 0,
        0, 0, 1, 1, 0,
        0, 1, 0, 1, 0,
        1, 0, 0, 1, 0,
        1, 1, 1, 1, 1,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();

    public static List<bool> Five => new List<int>()
    {
        1, 1, 1, 1, 1,
        1, 0, 0, 0, 0,
        1, 0, 0, 0, 0,
        1, 1, 1, 1, 0,
        0, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        1, 1, 1, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();

    public static List<bool> Six => new List<int>()
    {
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 0,
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();   
    
    public static List<bool> Seven => new List<int>()
    {
        0, 1, 1, 1, 0,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
        0, 0, 0, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();    

    public static List<bool> Eight => new List<int>()
    {
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();

    public static List<bool> Nine => new List<int>()
    {
        0, 1, 1, 1, 0,
        1, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 1,
        0, 0, 0, 0, 1,
        1, 0, 0, 0, 1,
        0, 1, 1, 1, 0,
    }.Select(n => Convert.ToBoolean(n)).ToList();
}
