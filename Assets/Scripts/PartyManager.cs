using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> members = new List<Character>();
    public List<Character> Members { get { return members; } }

    [SerializeField]
    private List<Character> selectChars = new List<Character>();
    public List<Character> SelectChars { get { return selectChars; } }

    [SerializeField]
    private List<Quest> questList = new List<Quest>();
    public List<Quest> QuestList { get { return questList; } }

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Character c in members)
        {
            c.charInit(VFXManager.instance, UIManager.instance, InventoryManager.Instance);
        }
        SelectSingleHero(0);
        members[0].MagicSkills.Add(new Magic(VFXManager.instance.MagicDatas[0]));
        members[1].MagicSkills.Add(new Magic(VFXManager.instance.MagicDatas[1]));

        InventoryManager.Instance.AddItem(members[0], 0);//Health Potion
        InventoryManager.Instance.AddItem(members[0], 1);// Sword

        InventoryManager.Instance.AddItem(members[1], 0);//Health Potion
        InventoryManager.Instance.AddItem(members[1], 1);//Sword
        InventoryManager.Instance.AddItem(members[1], 2);//ShieldA
        InventoryManager.Instance.AddItem(members[1], 3);//ShieldB

        UIManager.instance.ShowMagicToggles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (selectChars.Count > 0)
            {
                selectChars[0].IsMagicMode = true;
                selectChars[0].CurMagicCast = selectChars[0].MagicSkills[0];
            }
        }
    }
    public void SelectSingleHero(int i)
    {
        foreach (Character c in selectChars)
            c.ToggleRingSelection(false);

        selectChars.Clear();

        selectChars.Add(members[i]);
        selectChars[0].ToggleRingSelection(true);
    }
    public void HeroSelectMagicSkill(int i)
    {
        if (selectChars.Count <= 0)
            return;

        selectChars[0].IsMagicMode = true;
        selectChars[0].CurMagicCast = selectChars[0].MagicSkills[i];
    }
    public int FindIndexFromClass(Character hero)
    {
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i] == hero)
                return i;
        }
        return 0;
    }
    public void SelectSingleHeroByToggle(int i)
    {
        if (selectChars.Contains(members[i]))
        {
            members[i].ToggleRingSelection(true);
            UIManager.instance.ShowMagicToggles();
        }
        else
        {
            selectChars.Add(members[i]);
            members[i].ToggleRingSelection(true);
            UIManager.instance.ShowMagicToggles();
        }
    }
    public void UnSelectSingleHeroByToggle(int i)
    {
        if (selectChars.Count <= i)
        {
            UIManager.instance.ToggleAvatar[i].isOn = true;
            return;
        }
        if (selectChars.Contains(members[i]))
        {
            selectChars.Remove(members[i]);
            members[i].ToggleRingSelection(false);
        }
    }
    public void RemoveHeroFromParty(int id)
    {
        if (id == -1 || id == 0)
            return;

        if (selectChars.Contains(members[id]))
            selectChars.Remove(members[id]);

        members.Remove(members[id]);
    }
}
