using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteResultTests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void Run_ShouldNotReturnSuccess_InDenseSpace(AbstractSpaceship ship1, AbstractSpaceship ship2)
    {
        // Arrange
        ISpace space = new DenseSpace(Array.Empty<IDenseSpaceObstacle>(), 10000);
        var route = new Route(new[] { space });

        // Act
        FlightResult result1 = FlightManager.Run(route, ship1);
        FlightResult result2 = FlightManager.Run(route, ship2);

        // Assert
        Assert.IsType<ShipDestruction>(result1);
        Assert.IsType<ShipLoss>(result2);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void Run_WaclassWithPhotonicDeflectorShouldReturnSuccess_InDenseSpace(AbstractSpaceship ship1, AbstractSpaceship ship2)
    {
        // Arrange
        ISpace space = new DenseSpace(new[] { new PhotonicFlash() }, 10000);
        var route = new Route(new[] { space });
        ship2?.SetPhotonicDeflector();

        // Act
        FlightResult result1 = FlightManager.Run(route, ship1);
        FlightResult result2 = FlightManager.Run(route, ship2);

        // Assert
        Assert.IsType<CrewDeath>(result1);
        Assert.IsType<Success>(result2);
    }

    [Theory]
    [ClassData(typeof(ThirdTestDataGenerator))]
    public void Run_WaclassShouldReturnDestructionOtherReturnSuccess(AbstractSpaceship ship1, Type expectedType)
    {
        // Arrange
        ISpace space = new NitrineSpace(new[] { new SpaceWhale() }, 10000);
        var route = new Route(new[] { space });

        // Act
        FlightResult result = FlightManager.Run(route, ship1);

        // Assert
        Assert.IsType(expectedType, result);
    }

    [Theory]
    [ClassData(typeof(FourthTestDataGenerator))]
    public void Run_BasicShuttleShouldBeBetter(AbstractSpaceship ship1, AbstractSpaceship ship2)
    {
        // Arrange
        ISpace space = new BasicSpace(new[] { new Asteroid() }, 1000);
        var route = new Route(new[] { space });

        // Act
        FlightResult result1 = FlightManager.Run(route, ship1);
        FlightResult result2 = FlightManager.Run(route, ship2);

        // Assert
        Assert.IsType<Success>(result1);
        Assert.IsType<Success>(result2);

        var success1 = (Success)result1;
        var success2 = (Success)result2;

        Assert.True(success1.Fuel < success2.Fuel);
    }

    [Fact]
    public void Run_AvgurReturnShipLossAndStellaReturnSuccess()
    {
        // Arrange
        var avgur = new Avgur();
        var stella = new Stella();
        ISpace space = new DenseSpace(Array.Empty<IDenseSpaceObstacle>(), 5000);
        var route = new Route(new[] { space });

        // Act
        FlightResult result1 = FlightManager.Run(route, avgur);
        FlightResult result2 = FlightManager.Run(route, stella);

        // Assert
        Assert.IsType<ShipLoss>(result1);
        Assert.IsType<Success>(result2);
    }

    [Fact]
    public void Run_WaclassShouldBeSetter()
    {
        // Arrange
        var basicShuttle = new BasicShuttle();
        var waclass = new Waclass();
        ISpace space = new NitrineSpace(Array.Empty<INitrineSpaceObstacle>(), 1000);
        var route = new Route(new[] { space });

        // Act`
        FlightResult result1 = FlightManager.Run(route, basicShuttle);
        FlightResult result2 = FlightManager.Run(route, waclass);

        // Assert
        Assert.IsType<Success>(result1);
        Assert.IsType<Success>(result2);

        var success1 = (Success)result1;
        var success2 = (Success)result2;

        Assert.True(success1.Fuel > success2.Fuel);
    }

    [Fact]
    public void Run_ReturnSuccess()
    {
        // Arrange
        var ship = new Waclass();
        ship.SetPhotonicDeflector();
        ship.SetAntiNitrineEmitter();
        ISpace basicSpace = new BasicSpace(new IBasicSpaceObstacle[] { new Asteroid(), new Meteor(), new Meteor() }, 1000);
        ISpace nitrineSpace = new NitrineSpace(new[] { new SpaceWhale(), new SpaceWhale() }, 100);
        ISpace denseSpace = new DenseSpace(new[] { new PhotonicFlash(), new PhotonicFlash() }, 5000);
        var route = new Route(new[] { basicSpace, nitrineSpace, denseSpace });

        // Act
        FlightResult result = FlightManager.Run(route, ship);

        // Assert
        Assert.IsType<Success>(result);
    }
}