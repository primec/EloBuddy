using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace CancerDarius
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Active Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Targeted R { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Active(SpellSlot.Q, 425);
            W = new Spell.Active(SpellSlot.W, 200);
            E = new Spell.Skillshot(SpellSlot.E, 550, SkillShotType.Cone, 250, 100, 120);
            R = new Spell.Targeted(SpellSlot.R, 460);
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }

        public static float RDmg(Obj_AI_Base unit, int stackcount)
        {
            var bonus =
                stackcount *
                    (new[] { 20, 20, 40, 60 }[R.Level] + (0.20 * ObjectManager.Player.FlatPhysicalDamageMod));

            return
                (float)(bonus + (ObjectManager.Player.CalculateDamageOnUnit(unit, DamageType.True,
                        new[] { 100, 100, 200, 300 }[R.Level] + (float)(0.75 * ObjectManager.Player.FlatPhysicalDamageMod))));
        }
        public static float PassiveDmg(Obj_AI_Base unit, int stackcount)
        {
            if (stackcount <= 0)
                stackcount = 1;

            return
                (float)
                    ObjectManager.Player.CalculateDamageOnUnit(unit, DamageType.Physical,
                        (9 + ObjectManager.Player.Level) + (float)(0.3 * ObjectManager.Player.FlatPhysicalDamageMod)) * stackcount;
        }

    }
}
