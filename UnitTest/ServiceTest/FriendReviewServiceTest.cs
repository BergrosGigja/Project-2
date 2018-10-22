using System.Linq;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Dtos;
using Moq;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace UnitTest.ServiceTest
{
    [TestClass]
    public class FriendReviewTest
    {
        private Mock<IFriendReviewRepository> _friendReviewRepositoryMock;
        private IFriendReviewService _friendReviewService;
        
        [TestInitialize]
        public void Initialize()
        {
            _friendReviewRepositoryMock = new Mock<IFriendReviewRepository>();
            _friendReviewService = new FriendReviewService(_friendReviewRepositoryMock.Object);
        }
        
        [TestMethod]
        public void GetReviewsByUserForAllTapes()
        {
            // arrange
            int friendId = 1;
            _friendReviewRepositoryMock.Setup(method => method.GetReviewByUserForAllTapes(friendId)).Returns(
                FizzWare.NBuilder.Builder<ReviewDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.FriendId = friendId).With(x => x.TapeId = 1)
                    .With(x => x.ReviewInput = "This was awesome").With(x => x.Rating = 5)
                    .TheNext(1).With(x => x.Id = 2).With(x => x.FriendId = friendId).With(x => x.TapeId = 2)
                    .With(x => x.ReviewInput = "This was terrible").With(x => x.Rating = 1)
                    .Build());
            
            // act
            var reviews = _friendReviewService.GetReviewByUserForAllTapes(friendId);
            // assert
            Assert.IsNotNull(reviews);
            Assert.AreEqual(2,reviews.Count());
            Assert.AreNotEqual(3, reviews.Count());
        }
        
        [TestMethod]
        public void GetReviewByUserForTape()
        {
            // arrange
            int tapeId = 1;
            int friendId = 1;
            _friendReviewRepositoryMock.Setup(method => method.GetReviewByUserForTape(friendId,tapeId)).Returns(
                FizzWare.NBuilder.Builder<ReviewDto>
                    .CreateNew()
                    .With(x => x.Id = 1).With(x => x.FriendId = friendId).With(x => x.TapeId = tapeId)
                    .With(x => x.ReviewInput = "This was awesome").With(x => x.Rating = 5)
                    .Build()); 
            
            // act
            var review = _friendReviewService.GetReviewByUserForTape(friendId,tapeId);
            
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
            _friendReviewRepositoryMock.Setup(method => method.DeleteReview(friendId, tapeId));
            
            // act
            _friendReviewService.DeleteReview(friendId, tapeId);
            
            // assert
            _friendReviewRepositoryMock.Verify(x => x.DeleteReview(friendId, tapeId), Times.Once);
        }
    }
}