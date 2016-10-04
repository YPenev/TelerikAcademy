using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using School.Tests2;

namespace School.Tests
{
    [TestClass]
    public class BankTest
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_CreateStudentWithNullName_ShouldThrowNullExeption()
        {
            var student = new Student("");
        }

        [TestMethod]
        public void Student_TestCreatedStudentName_IsNameCorrect()
        {
            string name = "Pesho";
            var student = new Student(name);

            Assert.AreEqual(name, student.Name);
        }

        [TestMethod]
        public void Student_TestCreatedStudentNumber_IsStudentNumbersInCorrectOrder()
        {
            Assert.AreEqual(UnitTestSourse.studentOne.UniqueNumber + 2, UnitTestSourse.studentThree.UniqueNumber);
        }

        [TestMethod]
        public void Student_TestCreatedStudentNumber_IsStudentNumbersUnique()
        {
            Assert.AreNotEqual(UnitTestSourse.studentOne.UniqueNumber, UnitTestSourse.studentTwo.UniqueNumber);
            Assert.AreNotEqual(UnitTestSourse.studentTwo.UniqueNumber, UnitTestSourse.studentThree.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_CreateStudentWithGreaterThanInvalidNumbers_ShouldThrowExeption()
        {

            for (int i = 0; i < 90000; i++)
            {
                new Student("Name");
            }
        }

      

        [TestMethod]
        public void Course_Add_IsAddingThreeStudents()
        {
            var TestCourse = new Course();
            TestCourse.Join(UnitTestSourse.studentOne);
            TestCourse.Join(UnitTestSourse.studentTwo);
            TestCourse.Join(UnitTestSourse.studentThree);

            Assert.AreEqual(3, TestCourse.Count());
        }

        [TestMethod]
        public void Course_TakeListOfStudents_IsListCorrect()
        {
            var TestCourse = new Course();
            var listOfStudent = new List<Student>();

            TestCourse.Join(UnitTestSourse.studentOne);
            TestCourse.Join(UnitTestSourse.studentTwo);
            listOfStudent.Add(UnitTestSourse.studentOne);
            listOfStudent.Add(UnitTestSourse.studentTwo);

            Assert.AreEqual(listOfStudent[0], TestCourse.Students[0]);
            Assert.AreEqual(listOfStudent[1], TestCourse.Students[1]);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_AddMoreThan30Students_ShouldThrowExeption()
        {
                var TestCourse = new Course();

                for (int i = 0; i < 31; i++)
                {
                    TestCourse.Join(new Student("SomeName"));
                }
        }

        [TestMethod]
        public void Course_Remove_DoesRemoveTheStudent()
        {
            var TestCourse = new Course();

            TestCourse.Join(UnitTestSourse.studentOne);
            TestCourse.Leave(UnitTestSourse.studentOne);

            Assert.AreEqual(0, TestCourse.Count());
        }
    }
}