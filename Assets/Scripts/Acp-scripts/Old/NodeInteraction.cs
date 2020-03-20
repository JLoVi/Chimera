using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NodeInteraction : MonoBehaviour
{

    public Color hoverColor;
    private Renderer rend;
    public Color startColor;

    BuildManager buildManager;

    [SerializeField] private UnityEvent onInventoryItemsUpdated = null;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
    }

    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

       

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
       rend.material.color = startColor;
    }
}
