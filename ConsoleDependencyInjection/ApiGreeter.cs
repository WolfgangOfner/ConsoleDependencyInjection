namespace ConsoleDependencyInjection
{
    public class ApiGreeter : IGreeter
    {
        private readonly IFooService _fooService;

        public ApiGreeter(IFooService fooService)
        {
            _fooService = fooService;
        }
        
        public string Greet()
        {
            _fooService.DoCoolStuff();
            
            return "Hello World from the API Greeter";
        }
    }
}