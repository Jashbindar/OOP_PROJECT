namespace mudblazor2.App_Classes
{
    public class PageValidation
    {
        public bool validationstatus { get; set; }
        public string displaystatus { get; set; } = "none";
        public string ?ErrorMessage { get; set; }

        public PageValidation() { }

        public PageValidation (bool a_validationstatus, string a_displaystatus, string a_errormessage)
        {
            validationstatus = a_validationstatus;
            displaystatus = a_displaystatus;
            ErrorMessage = a_errormessage;
        }

        public void SetSuccessUI (string a_successmessage)
        {
            validationstatus = true;
            displaystatus = "flex";
            ErrorMessage = a_successmessage;
        }

        public void SetFailureUI (string a_errormessage)
        {
            validationstatus = false;
            displaystatus = "flex";
            ErrorMessage = a_errormessage;

        }
    }
}
