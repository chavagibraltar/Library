namespace web_api.Middlewares
{
    public class ShabbatMiddleware
    {


        private readonly RequestDelegate _next;

        public ShabbatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestSeq = Guid.NewGuid().ToString();
            // context.Items.Add("RequestSequence", requestSeq);
            DateTime today = DateTime.Today;
            // Check if today's DayOfWeek is Saturday
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                Console.WriteLine("Today is Saturday!");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                Console.WriteLine("Today is not Saturday.");
                await _next(context);
            }
        }
    }
    public static class TrackMiddlewareExtensions
    {
        public static IApplicationBuilder UseTrack(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }

}
