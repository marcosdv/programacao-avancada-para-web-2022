using CriptografiaApp.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriptografiaApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("{texto}")]
    public IActionResult Criptografar(string texto)
    {
        return Ok(Criptografia.AesEncrypt(texto));
    }

    [HttpPost("{texto}")]
    public IActionResult Descriptografar(string texto)
    {
        return Ok(Criptografia.AesDecrypt(texto));
    }

    [HttpPut("{texto}")]
    public IActionResult CriptografarMD5(string texto)
    {
        return Ok(Criptografia.MD5Encrypt(texto));
    }
}