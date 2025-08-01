using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInShop : MonoBehaviour
{
    [SerializeField]
    private int id;
    public int ID { get { return id; } set { id = value; } }
    [SerializeField]
    private Item item;
    public Item Item { get { return item; } set { item = value; } }
    [SerializeField]
    private Toggle iconToggle;
    public Toggle IconToggle { get { return iconToggle; } set { iconToggle = value; } }
    [SerializeField]
    private TMP_Text itemText;
    [SerializeField]
    private TMP_Text priceText;
    [SerializeField]
    private UIManager uiMgr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetupItemInShop(UIManager uiManager, float discount)
    {
        uiMgr = uiManager;
        iconToggle.targetGraphic.GetComponent<Image>().sprite = item.Icon;
        itemText.text = item.ItemName;
        priceText.text = ((int)(item.NormalPrice * discount)).ToString();
    }
}
