using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    [SerializeField]
    private string toMapName;
    [SerializeField]
    private int enterPointId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MapManager.instance.GoToMap(toMapName, enterPointId);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
