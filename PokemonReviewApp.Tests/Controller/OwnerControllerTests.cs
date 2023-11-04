using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonReviewApp.Tests.Controller
{
    public class OwnerControllerTests
    {
        private IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;
        public OwnerControllerTests()
        {
            _ownerRepository = A.Fake<IOwnerRepository>();
            _countryRepository = A.Fake<ICountryRepository>();
            _mapper = A.Fake<IMapper>();
            _pokemonRepository = A.Fake<IPokemonRepository>();
        }
        [Fact]
        public async void OwnerController_GetOwners_ReturnOk()
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
        public void OwnerController_CreateOwner_ReturnOk()
        {
            //Arrange
            var countryId = 1;
            var ownerMap = A.Fake<Owner>();
            var owner = A.Fake<Owner>();
            var ownerCreate = A.Fake<OwnerDto>();
            var owners = A.Fake<ICollection<OwnerDto>>();
            var ownersList = A.Fake<List<OwnerDto>>();
            A.CallTo(() => _ownerRepository.GetOwnerTrimToUpper(ownerCreate)).Returns(owner);
            A.CallTo(() => _mapper.Map<Country>(ownerCreate));
            A.CallTo(() => _ownerRepository.CreateOwner(ownerMap)).Returns(true);//bool
            var controller = new OwnerController(_ownerRepository,_countryRepository, _mapper);
            //Act
            var result = controller.CreateOwner(countryId,ownerCreate);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
