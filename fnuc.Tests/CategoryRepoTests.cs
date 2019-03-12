using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using DAL.Context;
using DAL.Repository;

namespace fnuc.Tests
{
    /// <summary>
    /// Summary description for CategoryRepo
    /// </summary>
    [TestClass]
    public class CategoryRepoTests
    {
        public CategoryRepoTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private DatabaseContext context = new DatabaseContext();
        //[TestMethod]
        //public void Create()
        //{
        //    Category category = new Category
        //    {
        //        Name = "Meuble"
        //    };

        //    CategoryRepo repo = new CategoryRepo(context);
        //    repo.Create(category);
        //    repo.
        //    Assert.AreEqual(category.Name, repo.Retrieve(1).Name);


        //}

        //[TestMethod]
        //public void update()
        //{

        //    categor


        //    CategoryRepo repo = new CategoryRepo(context);
        //    repo.Create(category);
        //    Assert.AreEqual(category.Name, repo.Retrieve(1).Name);


        //}

    }
}

    

