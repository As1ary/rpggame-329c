using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> monsters;
    public List<Enemy> Monsters{ get{ return monsters;}}
    public static EnemyManager instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Character m in monsters)
        {
            m.charInit(VFXManager.instance, UIManager.instance, InventoryManager.Instance);
        }

        InventoryManager.Instance.AddItem(monsters[0], 0);//Health Potion
        InventoryManager.Instance.AddItem(monsters[0], 1);//Sword
        InventoryManager.Instance.AddItem(monsters[0], 2);//Shield
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
