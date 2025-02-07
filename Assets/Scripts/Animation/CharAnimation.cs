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
        c.Anim.SetBool("IsIdle", false);
        c.Anim.SetBool("Iswalk", false);

        switch (c.State)
        {
            case CharState.Idle:
                c.Anim.SetBool("IsIdle",true);
                break;
            case CharState.Walk:
                c.Anim.SetBool("IsWalk",true);
                break;
        }
    }
    void Update()
    {
        ChooseAnimation(character);
    }
}
