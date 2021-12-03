using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Substance substance;

    void Start()
    {
        var texts = GetComponentsInChildren<TextMeshProUGUI>();
        var image = GetComponentInChildren<Image>();

        texts[0].text = substance.substanceName;
        texts[1].text = substance.description;

        image.sprite = substance.GetComponent<SpriteRenderer>().sprite;
    }
}
