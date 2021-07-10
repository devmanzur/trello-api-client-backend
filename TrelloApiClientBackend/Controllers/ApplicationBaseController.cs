using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TrelloApiClientBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApplicationBaseController : ControllerBase
    {
        
    }
}