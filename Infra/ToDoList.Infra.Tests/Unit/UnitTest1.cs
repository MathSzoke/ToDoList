namespace Infra.Tests.Unit;

public class Tests
{
    [TestFixture]
    public class ToDoListDbContextTests
    {
        [Test]
        public void ToDoListDbContext_ShouldBeCreated()
        {
            // Arrange & Act
            var options = new DbContextOptionsBuilder<ToDoListDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ToDoListDbContext(options);
            // Assert
            Assert.That(context, Is.Not.Null);
        }

        [Test]
        public void ToDoListDbContext_CanAddToDoListEntity()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ToDoListDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Act
            using var context = new ToDoListDbContext(options);
            
            var todoEntity = new ToDoListEntity { Title = "Test Title", Description = "Test Description", IsCompleted = false };
            context.ToDoList.Add(todoEntity);
            context.SaveChanges();

            Assert.That(context.ToDoList.Count(), Is.EqualTo(1));
            var savedEntity = context.ToDoList.First();

            Assert.Multiple(() =>
            {
                Assert.That(savedEntity.Title, Is.EqualTo("Test Title"));
                Assert.That(savedEntity.Description, Is.EqualTo("Test Description"));
                Assert.That(savedEntity.IsCompleted, Is.False);
            });
        }
    }
}