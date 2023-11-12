using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Domain.Models;

namespace SmartHome.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected LoggedUser _user
        {
            get
            {
                return (LoggedUser)HttpContext.Items["loggedUser"];
            }
        }
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;

        }

    }
}
