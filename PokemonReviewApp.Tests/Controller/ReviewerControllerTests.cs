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
    public class ReviewerControllerTests
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerControllerTests()
        {
            _reviewerRepository = A.Fake<IReviewerRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void ReviewerController_GetReviews_ReturnOK()
        {
            //Arrange
            var reviewers = A.Fake<ICollection<ReviewerDto>>();
            var reviewersList = A.Fake<List<ReviewerDto>>();
            A.CallTo(() => _mapper.Map<List<ReviewerDto>>(reviewers)).Returns(reviewersList);
            var controller = new ReviewerController(_reviewerRepository, _mapper);
            //Act
            var result = controller.GetReviewers();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void ReviewController_CreateOwner_ReturnOk()
        {
            //Arrange
            var reviewerMap = A.Fake<Reviewer>();
            var reviewer = A.Fake<Reviewer>();
            var reviewerCreate = A.Fake<ReviewerDto>();
            var reviewers = A.Fake<ICollection<ReviewerDto>>();
            var reviewersList = A.Fake<List<ReviewerDto>>();
            A.CallTo(() => _reviewerRepository.GetReviewerTrimToUpper(reviewerCreate)).Returns(reviewer);
            A.CallTo(() => _mapper.Map<Review>(reviewerCreate));
            A.CallTo(() => _reviewerRepository.CreateReviewer(reviewerMap)).Returns(true);//bool
            var controller = new ReviewerController(_reviewerRepository, _mapper);
            //Act
            var result = controller.CreateReviewer(reviewerCreate);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
