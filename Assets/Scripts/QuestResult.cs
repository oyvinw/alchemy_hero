using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//Generate result text
public class QuestResult : MonoBehaviour
{
    public string resultHeader { get; private set; }
    public string resultText { get; private set; }
    public bool positiveResult { get; private set; }
    private StringBuilder goodNews;
    private StringBuilder badNews;
    public Quest resultQuest { get; private set; }
    private EffectTexts effects;
    private float effectLimit = 10;

    public void CalculateResult(Quest quest, Substance substance)
    {
        positiveResult = false;
        effects = FindObjectOfType<EffectTexts>();
        var stats = (quest.targetStat + substance.stats).ToDictionary();

        resultQuest = quest;
        resultHeader = "Potion Administered!";

        goodNews = new StringBuilder();
        badNews = new StringBuilder();

        /*
        if (stats.Values.Any(x => x > effectLimit))
        {
            bufferLineCounter++;
            badNews.Append(effects.goodNews[Random.Range(0, effects.goodNews.Length)]);
        }

        if (stats.Values.Any(x => x < -effectLimit))
        {
            bufferLineCounter++;
            badNews.Append(effects.badNews[Random.Range(0, effects.badNews.Length)]);
        }*/

        if (stats["toxic"] < -effectLimit)
            badNews.Append(effects.badToxic[Random.Range(0, effects.badToxic.Length)]);
        else if (stats["toxic"] > effectLimit)
            goodNews.Append(effects.goodToxic[Random.Range(0, effects.goodToxic.Length)]);

        if (stats["energy"] < -effectLimit)
            badNews.Append(effects.badEnergy[Random.Range(0, effects.goodEnergy.Length)]);
        else if (stats["energy"] > effectLimit)
            goodNews.Append(effects.goodEnergy[Random.Range(0, effects.goodEnergy.Length)]);

        if (stats["strength"] < -effectLimit)
            badNews.Append(effects.badStrength[Random.Range(0, effects.badStrength.Length)]);
        else if (stats["strength"] > effectLimit)
            goodNews.Append(effects.goodStrength[Random.Range(0, effects.goodStrength.Length)]);

        if (stats["invisibility"] > effectLimit)
            goodNews.Append(effects.goodInvisibility[Random.Range(0, effects.goodInvisibility.Length)]);

        if (stats["invincibility"] > effectLimit)
            goodNews.Append(effects.goodInvincibility[Random.Range(0, effects.goodInvincibility.Length)]);

        if (stats["ferocity"] < -effectLimit)
            badNews.Append(effects.badFerocity[Random.Range(0, effects.badFerocity.Length)]);
        else if (stats["ferocity"] > effectLimit)
            goodNews.Append(effects.goodFerocity[Random.Range(0, effects.badFerocity.Length)]);

        if (stats["respiratory"] < -effectLimit)
            badNews.Append(effects.badRespiratory[Random.Range(0, effects.badRespiratory.Length)]);
        else if (stats["respiratory"] > effectLimit)
            goodNews.Append(effects.goodRespatory[Random.Range(0, effects.goodRespatory.Length)]);

        if (stats["hallucinogenic"] > effectLimit)
            goodNews.Append(effects.goodHallucinogenic[Random.Range(0, effects.goodHallucinogenic.Length)]);

        if (stats["flavour"] < -effectLimit)
            badNews.Append(effects.badFlavour[Random.Range(0, effects.badFlavour.Length)]);
        else if (stats["flavour"] > effectLimit)
            goodNews.Append(effects.goodFlavour[Random.Range(0, effects.goodFlavour.Length)]);

        if (stats["aphrodisiac"] < -effectLimit)
            badNews.Append(effects.badAphrodisiac[Random.Range(0, effects.badAphrodisiac.Length)]);
        else if (stats["aphrodisiac"] > effectLimit)
            goodNews.Append(effects.goodAphrodisiac[Random.Range(0, effects.goodAphrodisiac.Length)]);

        if (stats["charisma"] < -effectLimit)
            badNews.Append(effects.badCharisma[Random.Range(0, effects.badCharisma.Length)]);
        else if (stats["charisma"] > effectLimit)
            goodNews.Append(effects.goodCharisma[Random.Range(0, effects.goodCharisma.Length)]);

        if (stats["dexterity"] < -effectLimit)
            badNews.Append(effects.badDexterity[Random.Range(0, effects.badDexterity.Length)]);
        else if (stats["dexterity"] > effectLimit)
            goodNews.Append(effects.goodDexterity[Random.Range(0, effects.goodDexterity.Length)]);

        if (stats["stamina"] < -effectLimit)
            badNews.Append(effects.badStamina[Random.Range(0, effects.badStamina.Length)]);
        else if (stats["stamina"] > effectLimit)
            goodNews.Append(effects.goodStamina[Random.Range(0, effects.goodStamina.Length)]);

        if (stats["mentalFortitude"] < -effectLimit)
            badNews.Append(effects.badMentalFortitude[Random.Range(0, effects.badMentalFortitude.Length)]);
        else if (stats["mentalFortitude"] > effectLimit)
            goodNews.Append(effects.goodMentalFortitude[Random.Range(0, effects.goodMentalFortitude.Length)]);

        if (stats["intelligence"] < -effectLimit)
            badNews.Append(effects.badIntelligence[Random.Range(0, effects.badIntelligence.Length)]);
        else if (stats["intelligence"] > effectLimit)
            goodNews.Append(effects.goodIntelligence[Random.Range(0, effects.goodIntelligence.Length)]);

        resultText = goodNews.ToString() + "\n\n" + badNews.ToString();
        if (goodNews.ToString().Any() || badNews.ToString().Any())
        {
            positiveResult = true;
        }
    }
}

