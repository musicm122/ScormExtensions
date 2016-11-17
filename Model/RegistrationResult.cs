namespace HackerFerret.ScormHelper.Model
{
    public class RegistrationResult
    {
        public RegistrationResult()
        {
        }

        public RegistrationResult(string xmlVal)
        {
        }

        public string Title { get; set; }
        public string Complete { get; set; }
        public string Success { get; set; }
        public string Score { get; set; }
        public string Attempts { get; set; }
        public string ViewTime { get; set; }

    }
}


