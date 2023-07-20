using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizeAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class ConsultingController : ControllerBase
{
    private readonly IConsultingService _consultingService;

    public ConsultingController(IConsultingService consultingService)
    {
        _consultingService = consultingService;
    }

    [HttpGet]
    [Route("{cnpj}")]
    public async Task<IActionResult> Consult([FromRoute] string cnpj)
    {
        var response = await _consultingService.Consult(cnpj);

        return Ok(response);
    }




}

