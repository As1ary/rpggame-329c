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
    [SerializeField]
    private int partyMoney = 1000;
    public int PartyMoney { get { return partyMoney; } set { partyMoney = value; } }
    [SerializeField]
    private int totalExp;

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
            c.CharInit(VFXManager.instance, UIManager.instance, InventoryManager.instance, this);
        }
        SelectSingleHero(0);
        /*members[0].MagicSkills.Add(new Magic(VFXManager.instance.MagicDatas[0]));
        members[1].MagicSkills.Add(new Magic(VFXManager.instance.MagicDatas[1]));

        InventoryManager.instance.AddItem(members[0], 0);//Health Potion
        InventoryManager.instance.AddItem(members[0], 1);// Sword

        InventoryManager.instance.AddItem(members[1], 0);//Health Potion
        InventoryManager.instance.AddItem(members[1], 1);//Sword
        InventoryManager.instance.AddItem(members[1], 2);//ShieldA
        InventoryManager.instance.AddItem(members[1], 3);//ShieldB*/

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
    public void DistributeTotalExp(int n)
    {
        totalExp = n;
        int eachHeroExp = totalExp / members.Count;

        foreach (Hero hero in members)
            hero.ReceiveExp(eachHeroExp);
    }
    public bool HeroJoinParty(Character hero)
    {
        if (members.Count >= 6)
            return false;

        hero.CharInit(VFXManager.instance, UIManager.instance,
                    InventoryManager.instance, this);

        members.Add(hero);
        return true;
    }
}
