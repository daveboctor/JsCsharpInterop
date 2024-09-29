namespace JsDotNetInterop.Services
{
    // Class adapated from:
    // https://stackoverflow.com/questions/70046997/how-would-you-call-methods-from-a-different-class-in-a-razor-class-file-in-blazo/70048391#70048391
    internal class FormaterService
    {
        public string? FormattedSerialNum { get; private set; }

        public string? FormatSerial(int? id)
        {
            FormattedSerialNum = MyFormater.GetFormatedSerial(id);
            StateChanged?.Invoke();
            return FormattedSerialNum;
        }

        public event Action? StateChanged;
    }
}
