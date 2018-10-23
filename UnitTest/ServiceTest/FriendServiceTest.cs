using System;
using System.Linq;
using AutoMapper;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Dtos;
using Models.Entity;
using Models.Input;
using Moq;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace UnitTest.ServiceTest
{
    public class FriendServiceTest
    {
        private Mock<IFriendRepository> _friendRepositoryMock;
        private IFriendService _friendService;

        [TestInitialize]
        public void Initialize()
        {
            _friendRepositoryMock = new Mock<IFriendRepository>();
            _friendService = new FriendService(_friendRepositoryMock.Object);
        }

        [TestMethod]
        public void GetAllFriends_TestingLength()
        {
            // arrange
            _friendRepositoryMock.Setup(method => method.GetAllFriends()).Returns(
                FizzWare.NBuilder.Builder<FriendDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.Name = "Aaron Jackson")
                    .With(x => x.Email = "aaron@jackson.com")
                    .With(x => x.Phone = "800 544 4856")
                    .With(x => x.Address = "Torrance")
                    .TheNext(1).With(x => x.Id = 2).With(x => x.Name = "Jim Petersen")
                    .With(x => x.Email = "jim@petersen.com")
                    .With(x => x.Phone = "854 680 4888")
                    .With(x => x.Address = "Surrey")
                    .Build());
            // act
            var friends = _friendService.GetAllFriends();
            
            // assert
            Assert.AreEqual(2, friends.Count());
            Assert.AreNotEqual(100, friends.Count());
            Assert.IsNotNull(friends);
        }

        [TestMethod]
        public void GetFriendById_TestingNotNull()
        {
            // arrange
            _friendRepositoryMock.Setup(method => method.GetFriendById(1)).Returns(
                FizzWare.NBuilder.Builder<FriendDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Name = "Aaron Jackson")
                    .With(x => x.Email = "aaron@jackson.com")
                    .With(x => x.Phone = "800 544 4856")
                    .With(x => x.Address = "Torrance").Build());
            // act
            var friend = _friendService.GetFriendById(1);
            
            // assert
            Assert.IsNotNull(friend);
            Assert.AreEqual("Aaron Jackson", friend.Name);
            Assert.AreEqual("aaron@jackson.com", friend.Email);
        }

        [TestMethod]
        public void AddNewFriend_TestIfFriendIsAdded()
        {
            // arrange
            var friendInput = new FriendInputModel
            {
                Name = "Aaron Jackson",
                Email = "aaron@jackson.com",
                Phone = "800 544 4856",
                Address = "Torrance"
            };

            _friendRepositoryMock.Setup(method => method.AddNewFriend(friendInput)).Returns(
                FizzWare.NBuilder.Builder<FriendDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Name = "Aaron Jackson")
                    .With(x => x.Email = "aaron@jackson.com")
                    .With(x => x.Phone = "800 544 4856")
                    .With(x => x.Address = "Torrance").Build());
            
            // act
            var newfriend = _friendService.AddNewFriend(friendInput);
            
            // assert
            Assert.AreEqual("Aaron Jackson",newfriend.Name);
            Assert.IsNotNull(newfriend);
        }

        [TestMethod]
        public void DeleteFriend_TestIfFriendIsDeleted()
        {
            // arrange
            int friendId = 1;
            _friendRepositoryMock.Setup(method => method.DeleteFriend(friendId));
            
            // act
            _friendService.DeleteFriend(friendId);
            
            // assert
            _friendRepositoryMock.Verify(x => x.DeleteFriend(friendId), Times.Once);
        }

        [TestMethod]
        public void UpdateTape_TestIfFriendIsUpdated()
        {
            // arrange
            int friendId = 1;
            var friendInput = new FriendInputModel
            {
                Name = "Aaron Jackson",
                Email = "aaron@jackson.com",
                Phone = "800 544 4856",
                Address = "Torrance"
            };
            
            _friendRepositoryMock.Setup(method => method.UpdateFriend(friendInput, friendId));
            _friendRepositoryMock.Setup(method => method.GetFriendById(friendId)).Returns(
                FizzWare.NBuilder.Builder<FriendDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Name = "Aaron Jackson")
                    .With(x => x.Email = "aaron@jackson.com")
                    .With(x => x.Phone = "800 544 4856")
                    .With(x => x.Address = "Torrance").Build());
            // act
            _friendService.UpdateFriend(friendInput, friendId);
            
            // assert
            _friendRepositoryMock.Verify(x => x.UpdateFriend(friendInput, friendId), Times.Once);

        }

        [TestMethod]
        public void RecommendationForFriend_TestingRecommendation() 
        {
            // arrange
            // act
            // assert
        }

    }
}