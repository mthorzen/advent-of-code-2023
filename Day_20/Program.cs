using Day_20;
using Tools;

bool example = false;
var lines = FileReader.ReadLines(example ? "Input_example_1.txt" : "Input.txt");

Dictionary<string, Module> ParseInput(List<string> lines)
{
    Dictionary<string, Module> modules = new Dictionary<string, Module>();
    for (var i = 0; i < lines.Count; i++)
    {
        Module module = Module.CreateModule(lines[i]);
        modules[module.id] = module;
    }
    foreach (var (key, value) in modules)
    {
        value.Initialize(modules);
    }

    return modules;
}

Dictionary<string, Module> modules = ParseInput(lines);
foreach (var (key, value) in modules)
{
    Console.WriteLine(value.Prefix() + key + " -> " + value.Destinations.Aggregate((s, s1) => s + ", " + s1));
}

void OneIteration(Dictionary<string, Module> dictionary)
{
    {
        BroadcasterModule broadcasterModule = (BroadcasterModule)dictionary["broadcaster"];
        var currentList = broadcasterModule.Activate(dictionary);
        foreach (var module in currentList)
        {
            module.UpdateState();
        }
        do
        {
            //Console.WriteLine("   -------------------");
            List<Module> newList = ExecuteList(currentList);
            foreach (var module in currentList)
            {
                module.UpdateState();
            }
            foreach (var module in newList)
            {
                module.UpdateState();
            }

            currentList = newList;
        } while (currentList.Count > 0);
    }

    List<Module> ExecuteList(List<Module> m)
    {
        List<Module> l = new List<Module>();
        foreach (var module in m)
        {
            l.AddRange(module.Activate(dictionary));
        }

        return l;
    }
}

int clicks = 0;
for (int i = 0; i < 1000; i++)
{
    Console.WriteLine((i+1)+"-----------------------");
    OneIteration(modules);
    clicks++;
}

int high = 0;
int low = clicks;
foreach (var (key, value) in modules)
{
    high += value.highPulses;
    low += value.lowPulses;
}

Console.WriteLine($"{high} * {low} = {high*low}");

// 11687500


/*
 * button -low-> broadcaster
   broadcaster -low-> a
   broadcaster -low-> b
   broadcaster -low-> c
   a -high-> b
   b -high-> c
   c -high-> inv
   inv -low-> a
   a -low-> b
   b -low-> c
   c -low-> inv
   inv -high-> a
 */

/* 1: press
 * button -low-> broadcaster
   broadcaster -low-> a
   a -high-> inv
   a -high-> con
   inv -low-> b
   con -high-> output
   b -high-> con
   con -low-> output
   
   2: press
   button -low-> broadcaster
   broadcaster -low-> a
   a -low-> inv
   a -low-> con
   inv -high-> b
   con -high-> output
   
   3: press
   button -low-> broadcaster
   broadcaster -low-> a
   a -high-> inv
   a -high-> con
   inv -low-> b
   con -low-> output
   b -low-> con
   con -high-> output
   
   4: press
   button -low-> broadcaster
   broadcaster -low-> a
   a -low-> inv
   a -low-> con
   inv -high-> b
   con -high-> output
*/