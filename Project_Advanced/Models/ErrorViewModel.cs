namespace Project_Advanced.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; } //Stores the unique identifier for the current HTTP request where the error occurred.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);//Determines whether the RequestId should be displayed on the error page.
    }
}
