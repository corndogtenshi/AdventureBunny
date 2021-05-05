using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator player;
    private void Start()
    {
        player = GetComponent<Animator>();
    }
    public void SetIdle()
    {
        player.SetTrigger("Idle");
    }
    public void SetWalk()
    {
        player.SetTrigger("Walk");
    }
    public void SetUp()
    {
        player.SetTrigger("Up");
    }
    public void SetDown()
    {
        player.SetTrigger("Down");
    }
}
