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
    [TestClass]
    public class TapeServiceTest
    {
        private Mock<ITapeRepository> _tapeRepositoryMock;
        private ITapeService _tapeService;

        [TestInitialize]
        public void Initialize()
        {
            _tapeRepositoryMock = new Mock<ITapeRepository>();
            _tapeService = new TapeService(_tapeRepositoryMock.Object);
        }

        [TestMethod]
        public void GetAllTapes_TestingLength()
        {
            // arrange
            _tapeRepositoryMock.Setup(method => method.GetAllTapes()).Returns(
                FizzWare.NBuilder.Builder<TapeDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.Eidr = "1").With(x => x.Title = "Pulp Fiction")
                    .With(x => x.Type = "VHS").With(x => x.AverageRating = 2.2)
                    .With(x => x.DirectorName = "Quentin Tarantino")
                    .With(x => x.ReleaseDate = DateTime.Today)
                    .TheNext(1).With(x => x.Id = 2).With(x => x.Eidr = "2").With(x => x.Title = "Brain Dead")
                    .With(x => x.Type = "VHS").With(x => x.AverageRating = 9.9)
                    .With(x => x.DirectorName = "Peter Jackson")
                    .With(x => x.ReleaseDate = DateTime.Now)
                    .Build());
            // act
            var tapes = _tapeService.GetAllTapes();
            
            // assert
            Assert.AreEqual(2, tapes.Count());
            Assert.AreNotEqual(100, tapes.Count());
            Assert.IsNotNull(tapes);
        }

        [TestMethod]
        public void GetTapeById_TestingNotNull()
        {
            // arrange
            _tapeRepositoryMock.Setup(method => method.GetTapeById(1)).Returns(
                FizzWare.NBuilder.Builder<TapeDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Eidr = "1").With(x => x.Title = "Pulp Fiction")
                    .With(x => x.Type = "VHS").With(x => x.AverageRating = 2.2)
                    .With(x => x.DirectorName = "Quentin Tarantino")
                    .With(x => x.ReleaseDate = DateTime.Today).Build());
            // act
            var tape = _tapeService.GetTapeById(1);
            
            // assert
            Assert.IsNotNull(tape);
            Assert.AreEqual("Pulp Fiction", tape.Title);
            Assert.AreEqual("Quentin Tarantino", tape.DirectorName);
        }

        [TestMethod]
        public void AddNewTape_TestIfTapeIsAdded()
        {
            // arrange
            var tapeInput = new TapeInputModel
            {
                Title = "Bad Taste",
                DirectorName = "Peter Jackson",
                Eidr = "2",
                ReleaseDate = new DateTime(1999,10,10),
                Type = "VHS"
            };

            _tapeRepositoryMock.Setup(method => method.AddNewTape(tapeInput)).Returns(
                FizzWare.NBuilder.Builder<TapeDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Eidr = "1").With(x => x.Title = "Pulp Fiction")
                    .With(x => x.Type = "VHS").With(x => x.AverageRating = 2.2)
                    .With(x => x.DirectorName = "Quentin Tarantino")
                    .With(x => x.ReleaseDate = DateTime.Today).Build());
            
            // act
            var newtape = _tapeService.AddNewTape(tapeInput);
            
            // assert
            Assert.AreEqual("VHS",newtape.Type);
            Assert.IsNotNull(newtape);
        }

        [TestMethod]
        public void DeleteTape()
        {
            // arrange
            int tapeId = 1;
            _tapeRepositoryMock.Setup(method => method.DeleteTape(tapeId));
            
            // act
            _tapeService.DeleteTape(tapeId);
            
            // assert
            _tapeRepositoryMock.Verify(x => x.DeleteTape(tapeId), Times.Once);
        }

        [TestMethod]
        public void UpdateTape()
        {
            // arrange
            int tapeId = 1;
            var tapeInput = new TapeInputModel
            {
                Title = "Pulp Fiction",
                DirectorName = "Peter Jackson",
                Eidr = "2",
                ReleaseDate = new DateTime(1999,10,10),
                Type = "VHS"
            };
            
            _tapeRepositoryMock.Setup(method => method.UpdateTape(tapeInput, tapeId));
            _tapeRepositoryMock.Setup(method => method.GetTapeById(tapeId)).Returns(
                FizzWare.NBuilder.Builder<TapeDetailsDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.Eidr = "2").With(x => x.Title = "Pulp Fiction")
                    .With(x => x.Type = "VHS").With(x => x.AverageRating = 2.2)
                    .With(x => x.DirectorName = "Quentin Tarantino")
                    .With(x => x.ReleaseDate = DateTime.Today).Build());
            // act
            _tapeService.UpdateTape(tapeInput, tapeId);
            
            // assert
            //_tapeRepositoryMock.Verify(x => x.GetTapeById(tapeId), Times.Once);
            _tapeRepositoryMock.Verify(x => x.UpdateTape(tapeInput, tapeId), Times.Once);

        }

        [TestMethod]
        public void GetFriendLoans_TestIfNull()
        {
            // arrange
            int friendId = 1;
            _tapeRepositoryMock.Setup(method => method.GetFriendLoans(friendId)).Returns(
                FizzWare.NBuilder.Builder<BorrowDto>
                    .CreateListOfSize(2)
                    .TheFirst(1).With(x => x.Id = 1).With(x => x.FriendId = friendId).With(x => x.ReturnDate = null)
                    .With(x => x.BorrowDate = DateTime.Today)
                    .TheNext(1).With(x => x.Id = 2).With(x => x.FriendId = friendId).With(x => x.ReturnDate = null)
                    .With(x => x.BorrowDate = DateTime.Now)
                    .Build());
                
            // act
            var result = _tapeService.GetFriendLoans(friendId);
            
            // assert
            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result);
            Assert.AreNotEqual(3, result.Count());
        }

        [TestMethod]
        public void RegisterTapeLoan()
        {
            // arrange
            int friendId = 1;
            int tapeId = 1;
            _tapeRepositoryMock.Setup(method => method.RegisterTapeLoan(tapeId,friendId)).Returns(
                FizzWare.NBuilder.Builder<BorrowDto>
                    .CreateNew().With(x => x.Id = 1).With(x => x.FriendId = friendId).With(x => x.ReturnDate = null)
                    .With(x => x.BorrowDate = DateTime.Today).Build());
            
            // act
            var borrow = _tapeService.RegisterTapeLoan(tapeId, friendId);
            
            // assert
            Assert.IsNotNull(borrow);
            Assert.AreEqual(friendId, borrow.FriendId);
            Assert.AreEqual(tapeId, borrow.TapeId);
            Assert.AreEqual(null, borrow.ReturnDate);
        }

        [TestMethod]
        public void ReturnTape()
        {
            // arrange
            int tapeId = 1;
            int friendId = 1;
            _tapeRepositoryMock.Setup(method => method.ReturnTape(tapeId, friendId));
            
            // act
            _tapeService.ReturnTape(tapeId, friendId);
            
            // assert
            _tapeRepositoryMock.Verify(x => x.ReturnTape(tapeId, friendId), Times.Once);
        }

        
    }
}


