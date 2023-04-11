using BethanysPieShop.Controllers;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            //arragne 
            var MockPieRepo = RepositoryMocks.GetPieRepository();
            var MockCategoryRepo = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController(MockCategoryRepo.Object, MockPieRepo.Object);

            //act

            var result = pieController.List("");

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewmodel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewmodel.Pies.Count());



        }
    }
}
