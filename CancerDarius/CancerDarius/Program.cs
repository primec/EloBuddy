using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System.Net;

namespace CancerDarius
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Darius";

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            //Version Check
            string currentVersion = "1.0.0";
            Chat.Print("CancerDarius Version: " + currentVersion + " - LOADED.");
            Chat.Print("Checking online version..");
            if (new WebClient().DownloadString("https://raw.githubusercontent.com/incaner/CancerBuddy/master/CancerDarius/Version.txt") != currentVersion)
                Chat.Print("Old CancerDarius version!");
            else
                Chat.Print("You have the last version of CancerDarius addon.");

            // Initialize the classes that we need
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }
        private static void OnDraw(EventArgs args)
        {
            if (Config.Modes.Drawings.DrawQ)
                Circle.Draw(Color.Red, SpellManager.Q.Range, Player.Instance.Position);
            if (Config.Modes.Drawings.DrawE)
                Circle.Draw(Color.DarkGreen, SpellManager.E.Range, Player.Instance.Position);
            if (Config.Modes.Drawings.DrawR)
                Circle.Draw(Color.DarkOrange, SpellManager.R.Range, Player.Instance.Position);
        }
    }
}
