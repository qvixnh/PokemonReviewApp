using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Tests.Controller
{

    public  class CategoryControllerTests
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryControllerTests()
        {
            _categoryRepository = A.Fake<ICategoryRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void CategoryController_GetCategories_ReturnOk()
        {
            //Arrange
            var categories = A.Fake<ICollection<CategoryDto>>();
            var categoriesList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categories)).Returns(categoriesList);
            var controller = new CategoryController(_categoryRepository, _mapper);
            //Act
            var result = controller.GetCategories();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void CategoryController_CreateCategory_ReturnOk() {
            //Arrange
            var categoryMap = A.Fake<Category>(); 
            var category = A.Fake<Category>();
            var categoryCreate = A.Fake<CategoryDto>();
            var categories = A.Fake<ICollection<CategoryDto>>();
            var categoriesList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _categoryRepository.GetCategoryTrimToUpper(categoryCreate)).Returns(category);
            A.CallTo(() => _mapper.Map<Category>(categoryCreate));
            A.CallTo(() => _categoryRepository.CreateCategory(categoryMap)).Returns(true);//bool
            var controller = new CategoryController(_categoryRepository,_mapper);
            //Act
            var result = controller.CreateCategory(categoryCreate);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
