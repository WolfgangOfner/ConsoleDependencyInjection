namespace ConsoleDependencyInjection
{
    public class ConsoleGreeter : IGreeter
    {
        private readonly IFooService _fooService;

        public ConsoleGreeter(IFooService fooService)
        {
            _fooService = fooService;
        }

        public string Greet()
        {
            _fooService.DoCoolStuff();
            
            return "Hello World from the Console Greeter";
        }
    }
}