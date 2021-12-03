using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrowController : MonoBehaviour
{
    private SpriteRenderer crowRenderer;
    private AudioSource crowAudioSource;
    private GameManager gameManager;
    private int pageNum = 0;

    public float greetingTime = 3f;

    public GameObject _dialogueBox;
    [TextArea]
    public string crowGreeting;
    [TextArea]
    public string crowEndGame;
    public TextMeshProUGUI dialogueHeader;
    public TextMeshProUGUI dialogueText;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject crowButton;
    public Sprite crowIdle;
    public Sprite crowGesture;
    public Sprite crowSpeak;
    public AudioClip[] crowSquaks;

    void Awake()
    {
        crowRenderer = GetComponentInChildren<SpriteRenderer>();
        crowAudioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        CrowAppear();
        crowButton.SetActive(false);
    }

    public void ToggleDialogueBox()
    {
        _dialogueBox.SetActive(!_dialogueBox.activeSelf);
        if (_dialogueBox.activeSelf == false)
        {
            crowRenderer.sprite = crowIdle;
            if (!gameManager.isOnQuest)
            {
                StartCoroutine(CrowQuestDelay());
            }
        }
        else
        {
            crowRenderer.sprite = crowSpeak;
            SayQuest();
            Squak();
        }
    }

    public void CrowAppear()
    {
        StartCoroutine(CrowGreeting());
    }
    private IEnumerator CrowQuestDelay()
    {
        //crowRenderer.sprite = crowGone;
        crowRenderer.enabled = true;
        var t = 0f;
        while (t < greetingTime)
        {
            t += Time.deltaTime;
            yield return null;
        }

        crowRenderer.sprite = crowGesture;
        gameManager.MakeNextQuestAvailable();
    }

    private IEnumerator CrowGreeting()
    {
        crowRenderer.sprite = crowIdle;
        crowRenderer.enabled = true;
        var t = 0f;
        while (t < greetingTime)
        {
            t += Time.deltaTime;
            yield return null;
        }

        crowButton.SetActive(true);
        Say("Greetings!", crowGreeting);
    }

    public void SayEndGame()
    {
        crowButton.SetActive(true);
        Say("You've done it", crowEndGame);
    }

    private void SayQuest()
    {
        Say(gameManager.currentQuest.questTitle, gameManager.currentQuest.questText);
    }

    public void Say(string header, string text)
    {
        Squak();
        crowRenderer.sprite = crowSpeak;
        dialogueHeader.text = header;
        dialogueText.text = text;
        dialogueText.pageToDisplay = 1;
        _dialogueBox.SetActive(true);
        nextButton.SetActive(true);
        prevButton.SetActive(false);
    }

    public void Say(Quest quest)
    {
        Say(quest.questGiver + " needs your aid!", quest.questText);
    }

    public void Next()
    {
        dialogueText.pageToDisplay++;
        prevButton.SetActive(true);
        pageNum++;
        //Should have added check to see if there is another page but i dont know how and it takes too long to implement.
    }

    public void Previous()
    {
        dialogueText.pageToDisplay--;
        nextButton.SetActive(true);
        pageNum--;
        if (pageNum <= 0)
        {
            prevButton.SetActive(false);
        }
    }

    private void Squak()
    {
        crowAudioSource.clip = crowSquaks[Random.Range(0, crowSquaks.Length)];
        crowAudioSource.Play();
    }

}
