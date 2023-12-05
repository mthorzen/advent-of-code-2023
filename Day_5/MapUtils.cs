namespace Day_5;

public static class MapUtils
{
    public static Mapping MappingFromString(string s) {
        switch (s)
        {
            case "seed-to-soil":
                return Mapping.SeedToSoil;
            case "soil-to-fertilizer":
                return Mapping.SoilToFertilizer;
            case "fertilizer-to-water":
                return Mapping.FertilizerToWater;
            case "water-to-light":
                return Mapping.WaterToLight;
            case "light-to-temperature":
                return Mapping.LightToTemperature;
            case "temperature-to-humidity":
                return Mapping.TemperatureToHumidity;
            case "humidity-to-location":
                return Mapping.HumidityToLocation;
            default:
                throw new Exception("No mapping for " + s);
        }
    }
}