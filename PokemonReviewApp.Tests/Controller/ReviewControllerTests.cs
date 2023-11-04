using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
    public class ReviewControllerTests
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewerRepository _reviewerRepository;
        public ReviewControllerTests()
        {
            _reviewRepository = A.Fake<IReviewRepository>();
            _reviewerRepository = A.Fake<IReviewerRepository>();
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void ReviewController_GetReviews_ReturnOK()
        {
            //Arrange
            var reviews = A.Fake<ICollection<ReviewDto>>();
            var reviewsList = A.Fake<List<ReviewDto>>();
            A.CallTo(() => _mapper.Map<List<ReviewDto>>(reviews)).Returns(reviewsList);
            var controller = new ReviewController(_reviewRepository, _mapper,_pokemonRepository, _reviewerRepository );
            //Act
            var result = controller.GetReviews();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void ReviewController_CreateOwner_ReturnOk()
        {
            //Arrange
            var reviewId = 1;
            var pokemonId = 1;
            var reviewMap = A.Fake<Review>();
            var review = A.Fake<Review>();
            var reviewCreate = A.Fake<ReviewDto>();
            var reviews = A.Fake<ICollection<ReviewDto>>();
            var reviewsList = A.Fake<List<ReviewDto>>();
            A.CallTo(() => _reviewRepository.GetReviewTrimToUpper(reviewCreate)).Returns(review);
            A.CallTo(() => _mapper.Map<Review>(reviewCreate));
            A.CallTo(() => _reviewRepository.CreateReview(reviewMap)).Returns(true);//bool
            var controller = new ReviewController(_reviewRepository, _mapper, _pokemonRepository, _reviewerRepository);
            //Act
            var result = controller.CreateReview(reviewId,pokemonId, reviewCreate);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
 