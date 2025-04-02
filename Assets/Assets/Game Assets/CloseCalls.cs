using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCalls : MonoBehaviour
{
    public bool jump, side;
    public static int JumpCount;
    void Start()
    {
        JumpCount = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (SwipeManager.swipeRight || SwipeManager.swipeLeft)
                sideCloase();
            if (SwipeManager.swipeUp || SwipeManager.swipeDown)
                JumpingCount();
        }
    }
    


    void sideCloase()
    {
        Score.addPoints += 100;
        Player user = FindObjectOfType<Player>();
        user.closeCall("So Close\n100");
    }

    void JumpingCount()
    {
        JumpCount++;
        Score.addPoints += 100 * JumpCount;
        Player user = FindObjectOfType<Player>();
        user.closeCall("Jump Count: " + JumpCount + "\n" + 100*JumpCount);
    }
}
