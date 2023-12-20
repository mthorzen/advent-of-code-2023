namespace Day_20;

public class FlipFlopModule : Module
{
    private bool state = false;
    private bool nextState = false;
    private PulseType? nextPulseType;

    public FlipFlopModule(string line)
    {
        id = line.Split("->")[0].Substring(1).Trim();
        FillDestinations(line);
    }
    
    public override string Prefix()
    {
        return "%";
    }

    public override void ReceivePulse(Dictionary<string, Module> modules, Module sender, PulseType pulseType)
    {
        //Console.WriteLine($"   FlipFlop: {id}, received {pulseType}");
        
        if (pulseType == PulseType.High)
        {
            nextPulseType = null;
            return;
        }

        if (pulseType == PulseType.Low)
        {
            nextState = !state;
            if (nextState)
            {
                nextPulseType = PulseType.High;
                //Activate(modules, PulseType.High);
            }
            else
            {
                nextPulseType = PulseType.Low;
                //Activate(modules, PulseType.Low);
            }

            return;
        }

        throw new Exception("Unknown pulse type: " + pulseType);
    }

    public override void UpdateState()
    {
        //Console.WriteLine("      FlipFlop updating state " + id);
        state = nextState;
        pulseToSend = nextPulseType;
    }
}