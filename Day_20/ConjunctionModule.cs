namespace Day_20;

/// <summary>
/// Conjunction modules (prefix &) remember the type of the most recent pulse received from each of their
/// connected input modules; they initially default to remembering a low pulse for each input.
/// When a pulse is received, the conjunction module first updates its memory for that input.
/// Then, if it remembers high pulses for all inputs, it sends a low pulse; otherwise, it sends a high pulse.
/// </summary>
public class ConjunctionModule : Module
{
    private Dictionary<string, PulseType> lastReceivedImpulse = new Dictionary<string, PulseType>();
    private string lastId;
    private PulseType nextPulseType;
    
    public ConjunctionModule(string line)
    {
        id = line.Split("->")[0].Substring(1).Trim();
        FillDestinations(line);
    }

    public override void Initialize(Dictionary<string, Module> modules)
    {
        base.Initialize(modules);
        foreach (var (key, value) in modules)
        {
            if (!key.Equals(id))
            {
                foreach (var valueDestination in value.Destinations)
                {
                    if (valueDestination.Equals(id))
                    {
                        lastReceivedImpulse[key] = PulseType.Low;
                    }
                }
            }
        }
    }

    public override string Prefix()
    {
        return "&";
    }

    public override void ReceivePulse(Dictionary<string, Module> modules, Module sender, PulseType pulseType)
    {
        //Console.WriteLine($"  &{id} received from {sender.id} pulse {pulseType}");
        lastId = sender.id;
        nextPulseType = pulseType;
        
    }

    public override void UpdateState()
    {
        //Console.WriteLine($"  &{id} updating state to {lastId} pulse {nextPulseType}");
        lastReceivedImpulse[lastId] = nextPulseType;
        foreach (var (key, value) in lastReceivedImpulse)
        {
            //Console.WriteLine("     - " + key + " = " + value);
        }
        if (lastReceivedImpulse.Values.All(type => type == PulseType.High))
        {
            pulseToSend = PulseType.Low;
            //Activate(modules, PulseType.Low);
        }
        else
        {
            pulseToSend = PulseType.High;
            //Activate(modules, PulseType.High);
        }
    }
}