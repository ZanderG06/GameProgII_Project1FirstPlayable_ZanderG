using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_Project1FirstPlayable_ZanderG
{
    internal class Hud
    {
        public void PrintHUD(string hudText, Player player, List<Enemy> enemy, Map map)
        {
            //+3 is so there's spacing
            Console.SetCursorPosition(0, map.mapLength + 3);
            Console.Write("HUD:");
            Console.WriteLine($"\n{hudText}          ");
            Console.WriteLine($"\nPlayer Health: {player._health.health}          ");
            Console.WriteLine($"\nPlayer Damage: {player._damage}          ");
            Console.WriteLine($"\nEnemy{player._lastEncounteredEnemy + 1}'s Health: {enemy[player._lastEncounteredEnemy]._health.health}          ");
            Console.WriteLine($"\nEnemy{player._lastEncounteredEnemy + 1}'s Damage: {enemy[player._lastEncounteredEnemy]._damage}          ");
        }

        public void ChangeEventLog(string eventLogText, Map map)
        {
            Console.SetCursorPosition(0, map.mapLength + 14);
            Console.Write($"Last Event: {eventLogText}                                                                                            ");
        }
    }
}
