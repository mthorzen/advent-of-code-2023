namespace Day_20;

public class BroadcasterModule : Module
{
    public BroadcasterModule(string line)
    {
        id = "broadcaster";
        pulseToSend = PulseType.Low;
        FillDestinations(line);
    }

    public override string Prefix()
    {
        return "broadcaster";
    }

    public override void ReceivePulse(Dictionary<string, Module> modules, Module sender, PulseType pulseType)
    {
        Activate(modules);
    }

    public override void UpdateState()
    {
        
    }
}