using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    public float toxic;
    public float energy;
    public float strength;
    public float invisibility;
    public float invincibility;
    public float ferocity;
    public float respiratory;
    public float hallucinogenic;
    public float flavour;
    public float aphrodisiac;
    public float charisma;
    public float dexterity;
    public float stamina;
    public float mentalFortitude;
    public float intelligence;

    private Dictionary<string, float> properties;

    private float r = 0f;
    private float g = 0f;
    private float b = 0f;
    private int ingredientCount = 1;
    public Color color;

    public void Add(Stats stats)
    {
        r += stats.color.r;
        g += stats.color.g;
        b += stats.color.b;

        toxic += stats.toxic;
        strength += stats.strength;
        invisibility += stats.invisibility;
        invincibility += stats.invincibility;
        ferocity += stats.ferocity;
        respiratory += stats.respiratory;
        hallucinogenic += stats.hallucinogenic;
        flavour += stats.flavour;
        aphrodisiac += stats.aphrodisiac;
        charisma += stats.charisma;
        dexterity += stats.dexterity;
        stamina += stats.stamina;
        mentalFortitude += stats.mentalFortitude;
        intelligence += stats.intelligence;

        ingredientCount++;
        color = new Color(r / ingredientCount, g / ingredientCount, b / ingredientCount);
    }

    public Dictionary<string, float> ToDictionary ()
    {
        var returnDict = new Dictionary<string, float>();
        returnDict.Add("toxic", toxic);
        returnDict.Add("energy", energy);
        returnDict.Add("strength", strength);
        returnDict.Add("invisibility", invisibility);
        returnDict.Add("invincibility", invincibility);
        returnDict.Add("ferocity", ferocity);
        returnDict.Add("respiratory", respiratory);
        returnDict.Add("hallucinogenic", hallucinogenic);
        returnDict.Add("flavour", flavour);
        returnDict.Add("aphrodisiac", aphrodisiac);
        returnDict.Add("charisma", charisma);
        returnDict.Add("dexterity", dexterity);
        returnDict.Add("stamina", stamina);
        returnDict.Add("mentalFortitude", mentalFortitude);
        returnDict.Add("intelligence", intelligence);

        return returnDict;
    }

    public static Stats operator -(Stats a, Stats b)
    {
        var returnStats = new Stats();

        returnStats.toxic = a.toxic - Mathf.Abs(b.toxic);
        returnStats.strength = a.strength - Mathf.Abs(b.strength);
        returnStats.invisibility = a.invisibility - Mathf.Abs(b.invisibility);
        returnStats.invincibility = a.invincibility - Mathf.Abs(b.invincibility);
        returnStats.ferocity = a.ferocity - Mathf.Abs(b.ferocity);
        returnStats.respiratory = a.respiratory - Mathf.Abs(b.respiratory);
        returnStats.hallucinogenic = a.hallucinogenic - Mathf.Abs(b.hallucinogenic);
        returnStats.flavour = a.flavour - Mathf.Abs(a.flavour);
        returnStats.aphrodisiac = a.aphrodisiac - Mathf.Abs(a.aphrodisiac);
        returnStats.charisma = a.charisma - Mathf.Abs(b.charisma);
        returnStats.dexterity = a.dexterity - Mathf.Abs(b.dexterity);
        returnStats.stamina = a.stamina - Mathf.Abs(a.stamina);
        returnStats.mentalFortitude = a.mentalFortitude - Mathf.Abs(b.mentalFortitude);
        returnStats.intelligence = a.intelligence - Mathf.Abs(b.mentalFortitude);

        return returnStats;
    }

    public static Stats operator +(Stats a, Stats b)
    {
        var returnStats = new Stats();

        returnStats.toxic = a.toxic + b.toxic;
        returnStats.strength = a.strength + b.strength;
        returnStats.invisibility = a.invisibility + b.invisibility;
        returnStats.invincibility = a.invincibility + b.invincibility;
        returnStats.ferocity = a.ferocity + b.ferocity;
        returnStats.respiratory = a.respiratory + b.respiratory;
        returnStats.hallucinogenic = a.hallucinogenic + b.hallucinogenic;
        returnStats.flavour = a.flavour + a.flavour;
        returnStats.aphrodisiac = a.aphrodisiac + a.aphrodisiac;
        returnStats.charisma = a.charisma + b.charisma;
        returnStats.dexterity = a.dexterity + b.dexterity;
        returnStats.stamina = a.stamina + a.stamina;
        returnStats.mentalFortitude = a.mentalFortitude + b.mentalFortitude;
        returnStats.intelligence = a.intelligence + b.mentalFortitude;

        return returnStats;
    }
}
