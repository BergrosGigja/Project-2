using System;
using System.Linq;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Dtos;
using Models.Exceptions;
using Models.Input;
using Moq;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace UnitTest.ServiceTest
{
    [TestClass]
    public class TapeReviewServiceTest
    {
        private Mock<ITapeReviewRepository> _tapeReviewRepositoryMock;
        private ITapeReviewService _tapeReviewService;

        [TestInitialize]
        public void Initialize()
        {
            _tapeReviewRepositoryMock = new Mock<ITapeReviewRepository>();
            _tapeReviewService = new TapeReviewService(_tapeReviewRepositoryMock.Object);
        }

        [TestMethod]
        public void GetReviewsForAllTapes()
        {
            // arrange
            _tapeReviewRepositoryMock.Setup(method => method.GetReviewForAllTapes()).Returns(
                FizzWare.NBuilder.Builder<ReviewDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.FriendId = 1).With(x => x.TapeId = 1)
                    .With(x => x.ReviewInput = "This was awesome").With(x => x.Rating = 5)
                    .TheNext(1).With(x => x.Id = 2).With(x => x.FriendId = 1).With(x => x.TapeId = 2)
                    .With(x => x.ReviewInput = "This was terrible").With(x => x.Rating = 1)
                    .Build());
            
            // act
            var reviews = _tapeReviewService.GetReviewsForAllTapes();
            // assert
            Assert.IsNotNull(reviews);
            Assert.AreEqual(2,reviews.Count());
            Assert.AreNotEqual(3, reviews.Count());
        }

        [TestMethod]
        public void GetReviewForTape()
        {
            // arrange
            int tapeId = 1;
            _tapeReviewRepositoryMock.Setup(method => method.GetReviewForTape(tapeId)).Returns(
                FizzWare.NBuilder.Builder<ReviewDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.FriendId = 1).With(x => x.TapeId = tapeId)
                    .With(x => x.ReviewInput = "This was awesome").With(x => x.Rating = 5)
                    .TheNext(1).With(x => x.Id = 2).With(x => x.FriendId = 1).With(x => x.TapeId = tapeId)
                    .With(x => x.ReviewInput = "This was terrible").With(x => x.Rating = 1)
                    .Build());
            
            // act
            var reviews = _tapeReviewService.GetReviewForTape(tapeId);
            
            // assert
            Assert.IsNotNull(reviews);
            Assert.AreEqual(2,reviews.Count());
            Assert.AreNotEqual(3, reviews.Count());
        }

        [TestMethod]
        public void GetReviewForFriend()
        {
            // arrange
            int friendId = 1;
            int tapeId = 1;
            _tapeReviewRepositoryMock.Setup(method => method.GetReviewForFriend(tapeId, friendId)).Returns(
                FizzWare.NBuilder.Builder<ReviewDto>
                    .CreateNew()
                    .With(x => x.Id = 1).With(x => x.FriendId = friendId).With(x => x.TapeId = tapeId)
                    .With(x => x.ReviewInput = "This was awesome").With(x => x.Rating = 5)
                    .Build());            
            
            // act
            var review = _tapeReviewService.GetReviewForFriend(tapeId, friendId);
            
            // assert
            Assert.IsNotNull(review);
            Assert.AreEqual(1, review.FriendId);
            Assert.AreEqual(1, review.TapeId);
        }

        [TestMethod]
        public void DeleteReviewForFriend()
        {
            // arrange
            int tapeId = 1;
            int friendId = 1;
            _tapeReviewRepositoryMock.Setup(method => method.DeleteReviewForFriend(tapeId, friendId));
            
            // act
            _tapeReviewService.DeleteReviewForFriend(tapeId, friendId);
            
            // assert
            _tapeReviewRepositoryMock.Verify(x => x.DeleteReviewForFriend(tapeId, friendId), Times.Once);
        }

    }
}