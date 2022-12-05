using BenWilson295nTermProject.Controllers;
using BenWilson295nTermProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenWilson295nTermProject.Data;

namespace Tests
{
    public class ForumControllerTests
    {
        IForumRepository repo = new FakePostRepository();
        ForumController controller;

        public ForumControllerTests()
        {
            controller = new ForumController(repo);
        }

        [Fact]
        public void Forum_PostTest_Success()
        {

            var result = controller.Forum(new Post());
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void Forum_PostTest_Failure()
        {
            var result = controller.Forum(null);
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}

