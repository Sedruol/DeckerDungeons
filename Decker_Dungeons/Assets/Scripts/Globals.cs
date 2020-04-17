using System.Collections.Generic;
using UnityEngine;
public class Globals
{
    [Header("Player 1")]
    public static bool p1Stats = true;
    public static float p1Life = 100f;
    public static float p1Mana = 100f;
    public static float p1Strength = 50f;
    public static float p1Intelligence = 50f;
    public static float p1Bloodlust = 50f;
    public static float p1Agility = 50f;

    public static bool p2Stats = false;
    public static bool p3Stats = false;
    [Header("Enemy 1")]
    public static bool e1Stats = false;
    public static float e1Life = 100f;
    public static float e1Strength = 40f;
    public static float e1Intelligence = 40f;
    public static float e1Bloodlust = 40f;
    public static float e1Agility = 40f;

    public static bool e2Stats = false;
    public static bool e3Stats = false;
    [Header("Result Menu")]
    public static bool p1Win = false;
    public static bool menuResult = false;
}
