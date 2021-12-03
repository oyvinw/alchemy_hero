using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredients/Add New", order = 1)]
public class Substance : MonoBehaviour
{
    public string substanceName = "New ingredient";
    [TextArea]
    public string description = "desc";
    public Stats stats;

    public Substance()
    {
        stats = new Stats();
    }

    public void Add(Substance sub)
    {
        stats.Add(sub.stats);
    }
}
