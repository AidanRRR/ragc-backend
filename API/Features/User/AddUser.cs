using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Mediatr;
using BL.Abstraction;
using MediatR;

namespace API.Features.User
{
    public class AddUser
    {
        public class Dto
        {
            public string Username { get; set; }
        }

        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
        }

        public class Response : ApiResult<Dto>
        {

        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Response> Handle(Request message)
            {
                try
                {
                    var dataModel = new DAL.DataModel.User
                    {
                        Username = message.Username
                    };

                    return new Response
                    {
                        HasErrors = await _userService.AddUser(dataModel),
                        Data = new Dto
                        {
                            Username = dataModel.Username
                        }
                    };
                }
                catch (Exception e)
                {
                    return new Response { HasErrors = true, ErrorMessages = new List<string> { e.Message } };
                }
            }
        }
    }
}
