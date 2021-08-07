using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GasParticle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum GasType
    {
        Oxygen,
        CarbonDioxide,
        None
    }

    public Vector3 startPosition;
    public float returnSpeed = 1.0f;
    public Minigame3 manager;

    [SerializeField] private GasType gasType;
    private bool clicked = false;
    public bool assigned = false;

    private void Start()
    {
        ResetStartPosition();
    }


    private void Update()
    {
        if (!clicked && !assigned)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * returnSpeed);
        }
    }

    public void ResetStartPosition()
    {
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        clicked = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!assigned)
            transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (manager.IsMouseOverGasPanel() == this.gasType)
        {
            assigned = true;
            manager.AssignedParticle();
            Debug.Log("Assigned Particle");
        }
        else if (manager.IsMouseOverGasPanel() != GasType.None)
        {
            manager.IncreaseVignette();
            clicked = false;
        }
        else
        {
            clicked = false;
        }

    }
}
