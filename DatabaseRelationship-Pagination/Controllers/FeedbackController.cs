﻿using Microsoft.AspNetCore.Mvc;

namespace DatabaseRelationship_Pagination.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
