using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class UpgradeablePart
    {
        protected byte level;
        public byte Level { get => level; }

        public UpgradeablePart() : this(0)
        {
        }

        public UpgradeablePart(byte level)
        {
            this.level = level;
        }

        public abstract float GetModifier();

        public abstract ulong GetUpgradeCost();

        public abstract ulong GetUpgradePremiumCost();

#nullable enable
        public event Event<UpgradeablePart>? Upgraded;
#nullable disable

        public void Upgrade()
        {
            GameModel.Get().TakeMoney(GetUpgradeCost());
            level++;
            Upgraded?.Invoke(this);
        }

        public void UpgradePremium()
        {
            GameModel.Get().TakePremiumMoney(GetUpgradePremiumCost());
            level++;
            Upgraded?.Invoke(this);
        }
    }
}
