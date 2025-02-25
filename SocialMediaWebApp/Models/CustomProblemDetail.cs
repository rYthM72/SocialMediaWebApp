using Microsoft.AspNetCore.Mvc;

namespace SocialMediaWebApp.Models
{
    public class CustomProblemDetail : ProblemDetails
    {
        public IEnumerable<string> Errors { get; set; } = [];

    }
}
