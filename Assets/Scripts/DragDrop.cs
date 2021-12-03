using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private SpriteRenderer sprite;

    private Vector2 originalPosition;
    private string originalSortingLayer;
    private bool IsOverDroppable = false;
    private GameObject colliderObject;
   

	public void OnBeginDrag(PointerEventData eventData)
	{
        Debug.Log("OnBeginDrag");

    }

    public void OnDrag(PointerEventData eventData)
	{
        sprite.sortingLayerName = "DragDrop";
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out pos);
        rectTransform.position = Vector3.Lerp(rectTransform.transform.position, canvas.transform.TransformPoint(pos), Time.deltaTime * 30f);
    }

	public void OnDrop(PointerEventData eventData)
	{
        Debug.Log("Drop");
		if (IsOverDroppable)
		{
            colliderObject.GetComponent<AudioSource>().Play();
            var pot = colliderObject.GetComponentInParent<PotController>();
            var substance = GetComponent<Substance>();

            pot.AddIngredient(substance);
            SetOriginalPosition();
        } else
		{
            SetOriginalPosition();
        }
        

    }
    private void SetOriginalPosition()
	{
        rectTransform.position = originalPosition;
        sprite.sortingLayerName = originalSortingLayer;
    }

	public void OnEndDrag(PointerEventData eventData)
	{
        Debug.Log("OffDrag");

    }

    public void OnPointerDown(PointerEventData eventData)
	{
       
        Debug.Log("Click");
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Droppable droppable = collision.GetComponent<Droppable>();
        if (droppable && droppable.IsDroppable)
        {
            if (collision.name == "Bubbles")
            {
                IsOverDroppable = true;
                colliderObject = collision.gameObject;
            }
        }

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        IsOverDroppable = false;
        colliderObject = null;
	}

	// Start is called before the first frame update
	void Start()
    {
        rectTransform = GetComponentInChildren<RectTransform>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        originalPosition = rectTransform.position;
        originalSortingLayer = sprite.sortingLayerName;
    }
        

    // Update is called once per frame
    void Update()
    {
    }
}
