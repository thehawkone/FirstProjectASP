using FirstProjectASP.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstProjectASP.Helpers;

public static class ListHelper
{
    public static HtmlString CreateParagraph(this IHtmlHelper htmlHelper, string text)
    {
        var result = $"<h2>{text}</h2>";
        return new HtmlString(result);
    }

    public static HtmlString CreateListWithStyles(this IHtmlHelper htmlHelper, IEnumerable<User> users)
    {
        var result = $@"
            div class='card col-md-12'>
            {CreatePadding(htmlHelper)}
            <select class='form-select' size='3'>";
        
        foreach (var user in users)
            result = $"{result}<option>{user.Name}</option></div>";
        
        result = $"{result}</select>{CreatePadding(htmlHelper)}";
        return new HtmlString(result);
    }

    private static HtmlString CreatePadding(this IHtmlHelper htmlHelper)
    {
        const string indent = "<div style=padding: 5px;'></div>";
        return new HtmlString(indent);
    }
}