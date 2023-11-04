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
    public class CountryControllerTest
    {
        private ICountryRepository _countryRepository;
        private IMapper _mapper;
        public CountryControllerTest()
        {
            _countryRepository = A.Fake<ICountryRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void CategoryController_GetCategories_ReturnOk()
        {
            //Arrange
            var countries = A.Fake<ICollection<CountryDto>>();
            var countriesList = A.Fake<List<CountryDto>>();
            A.CallTo(() => _mapper.Map<List<CountryDto>>(countries)).Returns(countriesList);
            var controller = new CountryController(_countryRepository, _mapper);
            //Act
            var result = controller.GetCountries();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void CategoryController_CreateCategory_ReturnOk()
        {
            //Arrange
            var countryMap = A.Fake<Country>();
            var country = A.Fake<Country>();
            var countryCreate = A.Fake<CountryDto>();
            var countries = A.Fake<ICollection<CountryDto>>();
            var countriesList = A.Fake<List<CountryDto>>();
            A.CallTo(() => _countryRepository.GetCountryTrimToUpper(countryCreate)).Returns(country);
            A.CallTo(() => _mapper.Map<Country>(countryCreate));
            A.CallTo(() => _countryRepository.CreateCountry(countryMap)).Returns(true);//bool
            var controller = new CountryController(_countryRepository, _mapper);
            //Act
            var result = controller.CreateCountry(countryCreate);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
