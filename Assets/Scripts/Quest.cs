using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class Quest : ScriptableObject
{
    public string questTitle;
    [TextArea(15,10)]
    public string questText;
    public string questGiver;

    public Stats targetStat;
}
