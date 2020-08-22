public class PotionRecipe
{
    public int KingsRoot;
    public int SootheWeed;
    public int ArrowRoot;
    public int KoboldsTooth;

    public override string ToString()
    {
        string recipe = "";
        if (KingsRoot > 0) recipe += $"- {KingsRoot} king's root\n";
        if (SootheWeed > 0) recipe += $"- {SootheWeed} soothe weed\n";
        if (ArrowRoot > 0) recipe += $"- {ArrowRoot} arrow root\n";
        if (KoboldsTooth > 0) recipe += $"- {KoboldsTooth} kobolds tooth\n";

        return recipe;
    }
}
