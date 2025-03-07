using UnityEngine;

public class RightClick : MonoBehaviour
{
    public static RightClick instance;
    private Camera cam;
    public LayerMask layerMask;
    private LeftClick leftClick;

    void Awake()
    {
        leftClick = GetComponent<LeftClick>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        cam = Camera.main;
        layerMask = LayerMask.GetMask("Ground","Character","Building");    
    }
    
    private void CommandToWalk (RaycastHit hit, Character c) 
    {
        if(c != null)
        {
            c.WalkToPosition(hit.point);
        }
    }
    private void TryCommand (Vector2 screenPos) 
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch(hit.collider.tag)
            {
                case"Ground":
                    CommandToWalk(hit, leftClick.CurChar);
                    break;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            TryCommand(Input.mousePosition);
        }
    }
}
