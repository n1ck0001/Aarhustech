using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RolePlayV23
{
    public class Defender : Character
    {
        public Defender(string name, int hitPoints, int minDamage, int maxDamage) : base(name, hitPoints, minDamage, maxDamage)
        { 
             
        }

        protected override int ReceiveDamageModifyChance
        {
            get { return 45; }
        }

        protected override int CalculateModifiedReceivedDamage(int receivedDamage)
        {
            var originalDamage = base.CalculateModifiedReceivedDamage(receivedDamage);
            var damageTaken = base.CalculateModifiedReceivedDamage(receivedDamage)/2;
            //Console.WriteLine(originalDamage+"Original damage");
            //Console.WriteLine(damageTaken+"damage taken as defender");
            return damageTaken;

        }
    }
}
