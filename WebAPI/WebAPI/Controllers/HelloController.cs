using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")] 
public class HelloController: ControllerBase
{
    IhelloWorldServices worldServices;

    public HelloController(IhelloWorldServices ihelloWorldServices)
    {
        worldServices = ihelloWorldServices;
    }

    public IActionResult Get(){ 
        return Ok(worldServices.GetHello);
    }
}
