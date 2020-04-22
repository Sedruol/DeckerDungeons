using System.Collections.Generic;
using UnityEngine;
public class Globals
{
    public static float volume = 1f;
    [Header("Player 1")]
    public static bool p1Stats = true;
    public static float p1Life; //script: life bar-> function: start
    public static int p1Mana = 5;
    public static int p1CantMana;
    public static bool p1NoMana = false;
    public static float p1ManaPosX; //script: create mana-> function: start
    public static float p1ManaPosY = 2.5f;
    public static bool p1CanAttack = true;
    public static float p1Strength = 50f;
    public static float p1Intelligence = 50f;
    public static float p1Bloodlust = 50f;
    public static float p1Agility = 50f;

    public static bool p2Stats = false;
    public static bool p3Stats = false;

    [Header("Enemy 1")]
    public static bool e1Stats = false;
    public static float e1Life; //script: life bar-> function: start
    public static bool e1CanAttack = false;
    public static float e1Strength = 40f;
    public static float e1Intelligence = 40f;
    public static float e1Bloodlust = 40f;
    public static float e1Agility = 40f;

    public static bool e2Stats = false;
    public static bool e3Stats = false;

    [Header("Result Menu")]
    public static bool p1Win = false;
    public static bool menuResult = false;

    public static bool newTurn = false;
}
