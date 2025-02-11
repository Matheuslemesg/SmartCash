using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SmartCash : ControllerBase 
{
    public SmartCash()
    {

    }

    [HttpPost]
    public string Post()
    {
        return "Post";
    }

    [HttpGet]
    public string Get()
    {
        return "Get";
    }

    [HttpPut]
    public string Put()
    {
        return "Put";
    }

    [HttpDelete]
    public string HttpDelete()
    {
        return "Delete";
    }
}
