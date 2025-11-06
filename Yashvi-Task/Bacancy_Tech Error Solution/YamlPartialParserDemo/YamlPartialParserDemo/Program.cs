using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class ConfigOne
{
    public string Name { get; set; }
    public string Stuff { get; set; }
}

class Program
{
    static void Main()
    {
        var yaml = @"
config_one:
  name: foo
  stuff: value
config_two:
  name: bar
  random: value";

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var yamlObject = deserializer.Deserialize<Dictionary<string, object>>(yaml);

        var configOneObject = yamlObject["config_one"];

        var serializer = new SerializerBuilder().Build();
        var configOneYaml = serializer.Serialize(configOneObject);

        var configOneDeserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var configOne = configOneDeserializer.Deserialize<ConfigOne>(configOneYaml);

        Console.WriteLine("✅ Partial YAML parsed successfully!");
        Console.WriteLine($"Name: {configOne.Name}");
        Console.WriteLine($"Stuff: {configOne.Stuff}");
    }
}
