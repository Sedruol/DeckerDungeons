using System.Collections.Generic;
using UnityEngine;
public class Globals
{
    public static float volume = 1f;
    [Header("Player 1 - Knight")]
    public static float p1Life; //script: life bar-> function: awake
    public static int p1Mana = 3;
    public static int p1CantMana;
    public static bool p1NoMana = false;
    public static float p1ManaPosX; //script: create mana-> function: awake
    public static float p1ManaPosY = 2.5f;
    public static bool p1CanAttack = true;
    public static bool p1BasicAttack = false;
    public static float p1Strength = 15f;
    public static float p1Intelligence = 5f;
    public static float p1Bloodlust = 10f;
    public static float p1Agility = 10f;
    public static float p1MaxLife = 75f;
    public static int p1Initiative = 10;
    public static bool evade = false;
    public static bool critico = false;

    [Header("Enemy 1")]
    public static float e1MaxLife = 100f;
    //public static bool e1Stats = false;
    public static float e1Life; //script: life bar-> function: start
    //public static bool e1CanAttack = false;
    public static float e1Strength = 5f;
    public static float e1Intelligence = 0f;
    public static float e1Bloodlust = 5f;
    public static int e1Initiative = 5;
    public static float e1Agility = 5f;//script: player -> OnTriggerEnter2D
    //public static bool e1Evade = false;//script: player -> OnTriggerEnter2D
    //public static bool e1Critico = false;
    public static bool e1Died = false;

    [Header("Enemy 2")]
    public static float e2MaxLife = 75f;
    //public static bool e1Stats = false;
    public static float e2Life; //script: life bar-> function: start
    //public static bool e1CanAttack = false;
    public static float e2Strength = 10f;
    public static float e2Intelligence = 0f;
    public static float e2Bloodlust = 10f;
    public static int e2Initiative = 5;
    public static float e2Agility = 10f;//script: player -> OnTriggerEnter2D
    //public static bool e1Evade = false;//script: player -> OnTriggerEnter2D
    //public static bool e1Critico = false;
    public static bool e2Died = false;

    [Header("Enemy temporal")]//agarra los valores del enemigo del nivel
    public static float eTMaxLife;
    public static float eTLife; //script: life bar-> function: start
    public static bool eTCanAttack = false;
    public static float eTStrength;
    public static float eTIntelligence;
    public static float eTBloodlust;
    public static int eTInitiative;
    public static float eTAgility;//script: player -> OnTriggerEnter2D
    public static bool eTEvade = false;//script: player -> OnTriggerEnter2D
    public static bool eTCritico = false;

    [Header("Cards Effects")]
    public static int posibleDamage;
    public static int posibleInit;
    public static bool seeText = false;
    public static bool cIceJaveling = false;
    public static bool cFireBall = false;
    public static bool cNetArrow = false;
    public static bool cShockingTouch = false;
    public static bool cEartquake = false;
    public static bool cBlessingRestoration = false;
    public static bool cFireNova = false;
    public static bool cFrostNova = false;
    public static bool cArrowBarrage = false;
    public static bool cKnifeSlash = false;
    public static bool cWhirldwind = false;

    [Header("Result Menu")]
    public static bool p1Win = false;
    public static bool menuResult = false;

    public static bool newTurn = false;
    public static List<Card> PosibleDeckList = new List<Card>();
    public static List<Card> decklist = new List<Card>();
    public static bool changeCards = false;
    public static int cont = 2;
    public static bool saveDeck = false;
    public static string lastRoom = " ";
    public static bool firstLevel = true;
    public static bool selectYourDeck = false;
    public static bool changeVolume = false;
    public static bool pauseActive = false;
    public static bool changeStats = false;
}
/*public class CardMark
{
    public static string name;
    public static bool selected;
}*/
