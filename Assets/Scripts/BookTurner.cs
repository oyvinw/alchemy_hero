using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTurner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] sectionOne;
    public GameObject[] sectionTwo;
    private bool isSectionOne;

    private void Start()
    {
        isSectionOne = true;
        UpdatePage();
    }

    public void TogglePage()
    {
        isSectionOne = !isSectionOne;
        UpdatePage();
    }

    private void UpdatePage()
    {
        if (isSectionOne)
        {
            foreach (var bit in sectionOne)
            {
                bit.SetActive(true);
            }
            foreach (var bit in sectionTwo)
            {
                bit.SetActive(false);
            }
        }
        else
        {
            foreach (var bit in sectionTwo)
            {
                bit.SetActive(true);
            }
            foreach (var bit in sectionOne)
            {
                bit.SetActive(false);
            }
        }
    }

}
