using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Socrates.DataAccess;
using System.Linq;

namespace Socrates.Tests.DataAccess
{
    [TestClass]
    public class SocratesContextTests
    {
        [TestMethod]
        public void GetAllDepartments()
        {
            // Arrange
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            var context = SocratesContextFactory.GetContext(connStr);

            // Act
            var departments = context.GetAllDepartments().ToList();

            // Assert
            Assert.IsNotNull(departments);
        }
    }
}
