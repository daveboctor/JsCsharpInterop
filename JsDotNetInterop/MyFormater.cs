namespace JsDotNetInterop
{
    public static class MyFormater
    {
        public static string? GetFormatedSerial(int? id)
        {
            return "serial-" + id.ToString();
        }
    }
}
