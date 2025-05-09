using System.Text.Json;
using Darkened.Data;
using Darkened.Data.Interfaces;
using Moq;

namespace UnitTests.Data;

public class JsonParserTests
{
    [SetUp]
    public void Setup()
    {
        data = new Data(
            1,
            "TestData",
            "This data is for testing purposes",
            DateTime.Now
        );
    }
    [Test]
    public void StoreWasSuccessful()
    {
        // Arrange
        string jsonString = JsonSerializer.Serialize(data, JsonSerializerOptions.Default);
        var fileMock = new Mock<IFile>();
        fileMock.Setup(file => file.PathExists()).Returns(true);
        fileMock.Setup(file => file.Write(jsonString));
        // Act
        var parser = new JsonParser<Data>(fileMock.Object, JsonSerializerOptions.Default);
        parser.Store(data);
        // Assert
        fileMock.Verify(file => file.Write(jsonString), Times.Once);
    }

    [Test]
    public void StoreWasNotSuccessful_FileNotFound()
    {
        // Arrange
        var mock = new Mock<IFile>();
        mock.Setup(file => file.PathExists()).Returns(false);
        // Act
        var parser = new JsonParser<Data>(mock.Object, JsonSerializerOptions.Default);
        // Assert
        Assert.Throws<FileNotFoundException>(() => parser.Store(data));
        mock.Verify(file => file.Write(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void LoadWasSuccessful()
    {
        // Arrange
        string jsonString = JsonSerializer.Serialize(data, JsonSerializerOptions.Default);
        var fileMock = new Mock<IFile>();
        fileMock.Setup(file => file.PathExists()).Returns(true);
        fileMock.Setup(file => file.Read()).Returns(jsonString);
        // Act
        var parser = new JsonParser<Data>(fileMock.Object, JsonSerializerOptions.Default);
        var result = parser.Load();
        // Assert
        Assert.NotNull(result);
        fileMock.Verify(file => file.Read(), Times.Once);
    }

    [Test]
    public void LoadWasNotSuccessful()
    {
        // Arrange
        var fileMock = new Mock<IFile>();
        fileMock.Setup(file => file.PathExists()).Returns(false);
        // Act
        var parser = new JsonParser<Data>(fileMock.Object, JsonSerializerOptions.Default);
        // Assert
        Assert.Throws<FileNotFoundException>(() => parser.Load());
        fileMock.Verify(file => file.Read(), Times.Never);
    }

    private struct Data
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Content { get; set; }
        
        public DateTime Created { get; set; }

        public Data(int id, string name, string content, DateTime created)
        {
            Id = id;
            Name = name;
            Content = content;
            Created = created;
        }
    }
    private Data data;
}