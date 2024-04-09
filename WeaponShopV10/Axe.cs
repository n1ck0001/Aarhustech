
/// <summary>
/// This class represents a Axe. An Axe is 
/// considered to be a weapon.
/// </summary>
public class Axe : Weapon
{
    public const int InitialAxeMinDamage = 20;
    public const int InitialAxeMaxDamage = 50;

    public bool isSharpend { get; set; }

    #region Constructor
    public Axe(string description)
        : base(description, InitialAxeMinDamage, InitialAxeMaxDamage)
    {
        isSharpend = false;
    }
    #endregion

    public void Sharpen()
    {
        isSharpend = true;
    }

    public void DSharpen()
    {
        isSharpend = false;
    }

    public int DamageFromAxe()
    {
        var damg = CalculateDamage();
        if(isSharpend)
        {
            return damg*2;
        }

        return damg;
    }
}
