using System.Collections.Generic;
using UnityEngine;

public class LeftClick : MonoBehaviour
{
    public static LeftClick instance;
    private Camera cam;
    [SerializeField]
    private LayerMask layerMask; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Ground","Character","Building","Item");
    }

    private void SelectCharactor(RaycastHit hit)
    {
        Character hero = hit.collider.GetComponent<Character>();
        Debug.Log("Selected Char: "+ hit.collider.gameObject);

        PartyManager.instance.SelectChars.Add(hero);
        hero.ToggleRingSelection(true);
    }
    private void TrySelect(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch(hit.collider.tag)
            {
                case "Player":
                case "Hero":
                    SelectCharactor(hit);
                    break;
            }
        }
    }
    private void ClearRingSelection () 
    {
        foreach (Character h in PartyManager.instance.SelectChars)
            h.ToggleRingSelection(false);   
    }
    private void ClearEverything () 
    {
        ClearRingSelection();
        PartyManager.instance.SelectChars.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClearEverything();
        }
        if(Input.GetMouseButtonUp(0))
        {
            TrySelect(Input.mousePosition);
        }
    }
}
