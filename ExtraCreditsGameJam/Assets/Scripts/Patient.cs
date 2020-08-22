public class Patient
{
    public OrganState Heart = OrganState.Healthy;
    public OrganState Intestines = OrganState.Healthy;
    public OrganState Mind = OrganState.Healthy;
    public OrganState Lungs = OrganState.Healthy;
    public OrganState Skin = OrganState.Healthy;
}

public enum OrganState
{ 
    Healthy,
    ExcessFire,
    ExcessWater,
    ExcessAir,
    ExcessEarth
}