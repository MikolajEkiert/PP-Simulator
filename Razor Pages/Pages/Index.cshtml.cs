using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_Pages.Pages;

public class IndexModel : PageModel
{
    public int Counter { get; private set; }
    public void OnGet() { }
    public void OnPost() => Counter++;
    private readonly ILogger<IndexModel> _logger;
    
}