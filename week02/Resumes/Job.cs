public class Job
{
    public string _company { get; set; }
    public string _title { get; set; }
    public string _startDate { get; set; }
    public string _endDate { get; set; }

    public void Display()
    {
        Console.WriteLine($"Job title ({_company}) {_startDate} - {_endDate}");
    }
}
