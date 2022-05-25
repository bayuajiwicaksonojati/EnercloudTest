using System.Web;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace EnercloudTest.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StringComparerController : ControllerBase{
    [HttpPost]
    public Result<List<int>> allIndexOf([FromBody] StringCompareAllIndexOf compareobj)
    {
        if(string.IsNullOrEmpty(compareobj.text) || string.IsNullOrEmpty(compareobj.comparer)) return new Result<List<int>>(){success = false, code = 400, message = "Text and comparer text cannot be empty"};
        return new Result<List<int>>(){success = true, code = 200, data = compareobj.text.AllIndexOf(compareobj.comparer)};
    }

    public class StringCompareAllIndexOf
    {
        public string text{get;set;} = string.Empty;
        public string comparer{get;set;} = string.Empty;
    }
}