using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayV23
{
    public class Damager : Character
    {
        public Damager(string name, int maxHitPoints, int minDamage, int maxDamage) 
            : base(name, maxHitPoints, minDamage, maxDamage)
        {
            

        }

        protected override int DealDamageModifyChance => 40;


        protected override int CalculateModifiedDealDamage(int dealtDamage)
        {
            var normalDamage = base.CalculateModifiedDealDamage(dealtDamage);
            var doubleDamage = base.CalculateModifiedDealDamage(dealtDamage);
            return doubleDamage;
            
        }
    }
}
