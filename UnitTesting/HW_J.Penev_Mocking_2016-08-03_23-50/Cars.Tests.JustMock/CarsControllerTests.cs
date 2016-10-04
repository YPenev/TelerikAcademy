/*
 Finish the unit testing for CarsController

Write mocks for the rest of ICarsRepository interface (sorting)
Write missing unit test so that the controller functionality is fully tested
*/

namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    using Moq;
    using Data;
    using System.Linq;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        // : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void CarRepository_Add_ShouldCallMethod()
        {
            var mock = new Mock<ICarsRepository>();                       //избираме кой клас да мокнем
            mock.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();      //Когато извикаме Add метода с която и да е кола, не прави нищо само ми отбележи , че това е извикано

        }

        [TestMethod]
        //  [ExpectedException(typeof(ArgumentException))]
        public void AddingCarShoulBeCalled()
        {
            var carRep = new Mock<ICarsRepository>();

            carRep.Setup(x => x.Add(It.IsAny<Car>())).Verifiable();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GettingDetailsShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var mock = new Mock<ICarsRepository>();
            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns((Car)null);     //Пренаписваме го за да може когато извикаме метода той да връща null

            var testControler = new CarsController(mock.Object);
            testControler.Details(10);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingWithoutParamShoulThrowExeption()
        {
            var mockedRep = new Mock<ICarsRepository>();
            CarsController testControler = new CarsController(mockedRep.Object);

            testControler.Sort(null);
        }

        [TestMethod]
        public void SortByMakeShouldWorkCorrectly()
        {
            var mockDB = new Mock<IDatabase>();
            mockDB.Setup(x => x.Cars).Returns(FakeData.CarList());
            var rep = new CarsRepository(mockDB.Object);

            var sortedCars = rep.SortedByMake().ToList();

            Assert.AreEqual("Audi", sortedCars[0].Make);
            Assert.AreEqual("BMW", sortedCars[1].Make);
            Assert.AreEqual("BMW", sortedCars[2].Make);
            Assert.AreEqual("Opel", sortedCars[3].Make);
        }


        [TestMethod]
        public void SortByYearShouldWorkCorrectly()
        {
            var mockDB = new Mock<IDatabase>();
            mockDB.Setup(x => x.Cars).Returns(FakeData.CarList);
            var rep = new CarsRepository(mockDB.Object);

            var sortedCars = rep.SortedByYear().ToList();

            Assert.AreEqual(2010, sortedCars[0].Year);
            Assert.AreEqual(2008, sortedCars[1].Year);
            Assert.AreEqual(2007, sortedCars[2].Year);
            Assert.AreEqual(2005, sortedCars[3].Year);
        }


        [TestMethod]
        public void SearchBMWShouldReturnFullListOfBMWCars()
        {
            var searchCars = (IList<Car>)this.GetModel(() => this.controller.Search("BMW"));

            Assert.AreEqual(2, searchCars.Count);

            Assert.AreEqual("325i", searchCars[0].Model);
            Assert.AreEqual("330d", searchCars[1].Model);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
