using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = CancerDarius.Config.Modes.Harass;

namespace CancerDarius.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            if (Settings.UseE && E.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (E.IsReady() && E.IsInRange(target) && target != null)
                {
                    E.Cast(target);
                }
            }
            if (Settings.UseW && W.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (W.IsReady() && target != null)
                {
                    W.Cast();
                }
            }
            if (Settings.UseQ && Q.IsReady() && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (Q.IsReady() && Q.IsInRange(target) && target != null)
                {
                    Q.Cast();
                }
            }
        }
    }
}
