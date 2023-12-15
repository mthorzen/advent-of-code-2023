namespace Day_15;

public class Box
{
    public Dictionary<string, int> LabelToIndex = new Dictionary<string, int>();
    public List<Lens> Lenses = new List<Lens>();
    
    public void LensOperation(string label, int operation, string value)
    {
        if (operation == 0)
        {
            if (LabelToIndex.TryGetValue(label, out int index))
            {
                Lenses.RemoveAt(index);
                RebuildIndex();
            }
        }
        else
        {
            int focalLength = int.Parse(value);
            if (LabelToIndex.TryGetValue(label, out int index))
            {
                Lenses[index].FocalLength = focalLength;
            }
            else
            {
                Lens newLens = new Lens() { Label = label, FocalLength = focalLength};
                Lenses.Add(newLens);
                LabelToIndex[label] = Lenses.Count - 1;
            }
        }
    }

    private void RebuildIndex()
    {
        LabelToIndex.Clear();
        for (var i = 0; i < Lenses.Count; i++)
        {
            LabelToIndex[Lenses[i].Label] = i;
        }
    }

    public void Print(int i)
    {
        string s = " ";
        for (var i1 = 0; i1 < Lenses.Count; i1++)
        {
            s += ("[" + Lenses[i1].Label + " " + Lenses[i1].FocalLength + "]");
        }

        Console.WriteLine($"Box {i} {s}");
    }
}