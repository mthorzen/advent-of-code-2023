namespace Day_20;

public abstract class Module
{
    public string id;
    public List<string> Destinations = new List<string>();
    protected PulseType? pulseToSend;
    public int highPulses = 0;
    public int lowPulses = 0;

    public abstract string Prefix();
    public abstract void ReceivePulse(Dictionary<string, Module> modules, Module sender, PulseType pulseType);

    protected void FillDestinations(string line)
    {
        var strings = line.Split("->")[1].Split(",");
        foreach (var s in strings)
        {
            Destinations.Add(s.Trim());
        }
    }
    
    public virtual List<Module> Activate(Dictionary<string, Module> modules)
    {
        List<Module> currentLevel = new List<Module>();
        foreach (var destination in Destinations)
        {
            if (pulseToSend.HasValue)
            {
                if (pulseToSend.Value == PulseType.High)
                {
                    highPulses++;
                }
                else
                {
                    lowPulses++;
                }
                Console.WriteLine(id + " -" + pulseToSend.Value + " -> " + destination);
                if (modules.TryGetValue(destination, out Module module))
                {
                    module.ReceivePulse(modules, this, pulseToSend.Value);
                    currentLevel.Add(module);                    
                }
            }
            else
            {
                //Console.WriteLine(id + " no pulse -> " + destination);
            }
        }

        return currentLevel;
    }

    public abstract void UpdateState();

    public static Module CreateModule(string line)
    {
        if (line.StartsWith("broadcaster"))
        {
            return new BroadcasterModule(line);
        } 
        if (line.StartsWith("%"))
        {
            return new FlipFlopModule(line);
        }
        if (line.StartsWith("&"))
        {
            return new ConjunctionModule(line);
        }

        throw new Exception("Unknown module: " + line);
    }

    public virtual void Initialize(Dictionary<string,Module> modules)
    {
        
    }
}