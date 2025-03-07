using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    private Character character;
    void Start()
    {
        character = GetComponent<Character>();
    }

    private void ChooseAnimation(Character c)
    {
        c.Anim.SetBool("IsIdel", false);
        c.Anim.SetBool("IsMove", false);

        switch (c.State)
        {
            case CharState.Idle:
                c.Anim.SetBool("IsIdel",true);
                break;
            case CharState.Walk:
            case CharState.WalkToEnemy:
                c.Anim.SetBool("IsMove",true);
                break;
        }
    }
    void Update()
    {
        ChooseAnimation(character);
    }
}
