using System;
using System.CommandLine;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Tests.DataGenerators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileManagementSystemTests
{
    [Theory]
    [ClassData(typeof(ConnectTestDataGenerator))]
    public void ConnectTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);

        // Act
        root.Invoke(request);

        // Assert
        Assert.Equal(result, logger.LastResult);
    }

    [Theory]
    [ClassData(typeof(TreeListDataGenerator))]
    public void TreeListTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);
        string[] connectReq = { "connect", Environment.CurrentDirectory, "-m", "local" };
        root.Invoke(connectReq);

        // Act
        root.Invoke(request);

        // Assert
        if (result != null) Assert.IsType(result.GetType(), logger.LastResult);
    }

    [Theory]
    [ClassData(typeof(FileShowDataGenerator))]
    public void FileShowTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);
        string[] connectReq = { "connect", Path.Join(Environment.CurrentDirectory, "..", "..", "..", "TestDirectory"), "-m", "local" };
        root.Invoke(connectReq);

        // Act
        root.Invoke(request);

        // Assert
        Assert.Equal(result, logger.LastResult);
    }

    [Theory]
    [ClassData(typeof(FileMoveDataGenerator))]
    public void FileMoveTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);
        string[] connectReq = { "connect", Path.Join(Environment.CurrentDirectory, "..", "..", "..", "TestDirectory"), "-m", "local" };
        root.Invoke(connectReq);

        // Act
        root.Invoke(request);

        // Assert
        Assert.Equal(result, logger.LastResult);
    }

    [Theory]
    [ClassData(typeof(FileCopyDataGenerator))]
    public void FileCopyTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);
        string[] connectReq = { "connect", Path.Join(Environment.CurrentDirectory, "..", "..", "..", "TestDirectory"), "-m", "local" };
        root.Invoke(connectReq);

        // Act
        root.Invoke(request);

        // Assert
        Assert.Equal(result, logger.LastResult);
    }

    [Theory]
    [ClassData(typeof(FileDeleteDataGenerator))]
    public void FileDeleteTest(string[] request, ExecutionResult result)
    {
        // Arrange
        var logger = new TestLogger();
        var application = new FMS(logger);
        var root = new TestRootCommand(application);
        string[] connectReq = { "connect", Path.Join(Environment.CurrentDirectory, "..", "..", "..", "TestDirectory"), "-m", "local" };
        root.Invoke(connectReq);

        // Act
        root.Invoke(request);

        // Assert
        Assert.Equal(result, logger.LastResult);
    }
}