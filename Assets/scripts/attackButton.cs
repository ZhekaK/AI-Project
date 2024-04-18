using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class attackButton : MonoBehaviour
{
    public Button startat;
    public int test = 0;
    public Animator anim;

    public void StartAttack()
    {
        Invoke(nameof(EndAttack), 0.5f);
        anim.SetTrigger("attack");
    }

    void EndAttack()
    {
        test = 0;
    }
}
