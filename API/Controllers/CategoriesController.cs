using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Categories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController:  BaseController
    {
         [AllowAnonymous]
         [HttpGet]
        public async Task<ActionResult<List<Category>>> List()
        {
            return await Mediator.Send(new CatgoryList.Query());
        }
    }
}