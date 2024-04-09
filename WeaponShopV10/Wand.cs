
using System.Security;


/// <summary>
/// This class represents a Wand. A Wand is 
/// considered to be a weapon.
/// </summary>
public class Wand : Weapon
{
    public const int InitialWandMinDamage = 10;
    public const int InitialWandMaxDamage = 30;
    public bool isEnchanted  { get; set; }

    #region Constructor
    public Wand(string description)
        : base(description, InitialWandMinDamage, InitialWandMaxDamage)
    {
        isEnchanted = false;
    }
    #endregion

    public void EnchantWand()
    {
        isEnchanted = true;
    }
    public void DisEnchantWand()
    {
        isEnchanted = false;
    }

    public int DamageFromWand()
    {
        var dmg =  CalculateDamage();
        if(isEnchanted)
        {
            return dmg*2;
        }
        return dmg;
    }
}
