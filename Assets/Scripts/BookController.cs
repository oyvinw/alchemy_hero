using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public Canvas bookCanvas;
    public AudioClip openBook;
    public AudioClip closeBook;
    public GameObject bookButton;

    private AudioSource bookAudio;

    private void Start()
    {
        bookAudio = GetComponent<AudioSource>();
    }
    public void ToggleBook()
    {
        bookCanvas.enabled = !bookCanvas.enabled;

		if (bookCanvas.enabled)
		{
            bookAudio.clip = openBook;
            bookButton.SetActive(false);
        } else
		{
            bookAudio.clip = closeBook;
            bookButton.SetActive(true);
        }

        bookAudio.Play();
    }
}
