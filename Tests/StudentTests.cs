using NUnit.Framework;
using ClassroomDatabaseManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClassroomDatabaseManager.Tests
{
    public class StudentTests
    {
        private ClassroomContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ClassroomContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ClassroomContext(options);
        }

        [Test]
        public async Task CanCreateStudent()
        {
            var student = new Student { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(2000, 1, 1) };
            _context.Add(student);
            await _context.SaveChangesAsync();

            var retrievedStudent = await _context.Students.FirstOrDefaultAsync(s => s.FirstName == "John");
            Assert.NotNull(retrievedStudent);
            Assert.AreEqual("Doe", retrievedStudent.LastName);
        }

        [Test]
        public async Task CanEditStudent()
        {
            var student = new Student { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", DateOfBirth = new DateTime(2000, 1, 1) };
            _context.Add(student);
            await _context.SaveChangesAsync();

            student.LastName = "Smith";
            _context.Update(student);
            await _context.SaveChangesAsync();

            var updatedStudent = await _context.Students.FirstOrDefaultAsync(s => s.FirstName == "Jane");
            Assert.NotNull(updatedStudent);
            Assert.AreEqual("Smith", updatedStudent.LastName);
        }

        // Add more tests as needed
    }
}
