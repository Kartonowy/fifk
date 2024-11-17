using Library;

namespace KartkowkaTesty;

public class CarTest
{
    [Fact]
    public static void CarGetterTest()
    {
        var maluch = new Car(25);
        Assert.Equal(0, maluch.GetNumberOfPassengers());
        
        
        maluch.AddPassengers(14);
        Assert.Equal(14, maluch.GetNumberOfPassengers());
    }

    [Fact]
    public static void CarAddTests()
    {
        var maluch = new Car(25);
        
        Assert.False(maluch.AddPassengers(-3));
        Assert.False(maluch.AddPassengers(39));
        Assert.True(maluch.AddPassengers(6));
    }
}