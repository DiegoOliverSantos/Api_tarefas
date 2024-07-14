namespace API.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(string message, 
                    string documentation)
        {
            Message = message;
            Documentation = documentation;
        }


        public string Message { get; set; } = string.Empty;
        public string Documentation { get; set; } = string.Empty;
    }
}