using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Quest[] questQueue;
    public bool isOnQuest { get; private set; }
    public Quest currentQuest { get; private set; }
    public GameObject questButton;
    public Texture2D cursorTexture;
    private int questCounter = 0;
    private PotController pot;
    private CrowController crow;
    private int questsFulfilled = 0;

    private void Start()
    {
        CursorMode cursorMode = CursorMode.Auto;
        Cursor.SetCursor(cursorTexture, new Vector2(0,0), cursorMode);
        pot = FindObjectOfType<PotController>();
        crow = FindObjectOfType<CrowController>();
        questButton.SetActive(false);
    }

    public void NextQuest()
    {
        if (!(questCounter == questQueue.Length))
        {
            currentQuest = questQueue[questCounter];
            questCounter++;
        }
        else
        {
            crow.SayEndGame();
            questCounter = 0;
            questsFulfilled = 0;
            return;
        }

        crow.Say(currentQuest);
        questButton.SetActive(false);
        isOnQuest = true;
    }

    public void MakeNextQuestAvailable()
    {
        if (!isOnQuest)
        {
            questButton.SetActive(true);
        }
    }

    public void CompleteBrew()
    {
        if (!isOnQuest)
        {
            pot.EmptyPot();
            return;
        }

        var questResult = new QuestResult();
        questResult.CalculateResult(currentQuest, pot.brew);

        if (questResult.positiveResult)
        {
            crow.Say(questResult.resultHeader, questResult.resultText);
            isOnQuest = false;
            questsFulfilled++;
        }
        else
        {
            crow.Say("What is this!?", "This potion does nothing! \n\n Try again!");
        }
        pot.EmptyPot();
    }
}
