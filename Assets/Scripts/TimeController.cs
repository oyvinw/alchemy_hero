using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [SerializeField][Range(0f, 5f)] float lerptime;
    [SerializeField][Range(0f, 5f)] float rate;
    // Use this for initialization    
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    // Update is called once per frame    
    void Update()
    {
        spriteRenderer.transform.rotation = Quaternion.Slerp(spriteRenderer.transform.rotation, Quaternion.Euler(0, 0, spriteRenderer.transform.eulerAngles.z + rate), lerptime * Time.deltaTime);
    }
}
