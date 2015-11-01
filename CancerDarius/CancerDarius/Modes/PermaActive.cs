using EloBuddy;
using EloBuddy.SDK;

using Settings = CancerDarius.Config.Modes.Killsteal;

namespace CancerDarius.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }
        public override void Execute()
        {
            if (Settings.UseR && R.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);

                if (target.IsValidTarget(R.Range) && !target.IsZombie)
                {
                    int PassiveCounter = target.GetBuffCount("dariushemo") <= 0 ? 0 : target.GetBuffCount("dariushemo");
                    if (!target.HasBuffOfType(BuffType.Invulnerability) && !target.HasBuffOfType(BuffType.SpellShield))
                    {
                        if (SpellManager.RDmg(target, PassiveCounter) >= target.Health + SpellManager.PassiveDmg(target, 1))
                        {
                            if (!target.HasBuffOfType(BuffType.Invulnerability)
                                && !target.HasBuffOfType(BuffType.SpellShield))
                            {
                                R.Cast(target);
                            }
                        }
                    }
                }
            }
        }
    }
}
