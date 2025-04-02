using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsManager : MonoBehaviour
{
    public static bool powerUp, fastRun, magnet, superJump;
    public static Player player;
    public float fastRunTime, jumpTime, magnetTime;
    public Slider magnetSlider, fastRunSlider, jumpSlider;

    public static float maxRunTime, maxJumpTime, maxMagnetTime;

    private void Awake()
    {
        hit();
    }
    public static void Condition()
    {
        player = FindObjectOfType<Player>();
        if(powerUp == false)
        {
            fastRun = false;
            magnet = false;
            superJump = false;
        }
        player.powerSpeed = fastRun == true ? 5 : 0;
        player.jumpHeight = superJump == true ? 5 : 2;
    }
    private void Update()
    {
        magnetSlider.gameObject.SetActive(magnet);
        jumpSlider.gameObject.SetActive(superJump);
        fastRunSlider.gameObject.SetActive(fastRun);

        magnetSlider.value = magnetTime;
        jumpSlider.value = jumpTime;
        fastRunSlider.value = fastRunTime;


        if(fastRun == true)
        {
            fastRunTime -= Time.deltaTime;
            if(fastRunTime <= 0)
            {
                fastRun = false;
                fastRunTime = maxRunTime;
                Condition();
            }
        }
        if (superJump == true)
        {
            jumpTime -= Time.deltaTime;
            if (jumpTime <= 0)
            {
                superJump = false;
                jumpTime = maxJumpTime;
                Condition();
            }
        }
        if (magnet == true)
        {
            magnetTime -= Time.deltaTime;
            if (magnetTime <= 0)
            {
                magnet = false;
                magnetTime = maxMagnetTime;
                Condition();
            }
        }
    }

    public static void hit()
    {
        powerUp = false;
        Condition();
    }

}
