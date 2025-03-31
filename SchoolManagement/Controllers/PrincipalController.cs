using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Commands.Principals;
using School.Application.DTOs;
using School.Domain.Entities;

namespace SchoolManagement.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IMediator _mediator;

        public PrincipalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(PrincipalDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _mediator.Send(new RegisterPrincipalCommand(dto));
            if (!result)
            {
                ViewBag.Error = "A principal already exists or registration failed.";
                return View(dto);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var result = await _mediator.Send(new LoginPrincipalCommand(dto));

            if (result == null || string.IsNullOrEmpty(result.Token))
                return Unauthorized();

            return Ok(new
            {
                token = result.Token,
                name = result.FullName,
                photo = result.PhotoPath
            });
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

    }

}
