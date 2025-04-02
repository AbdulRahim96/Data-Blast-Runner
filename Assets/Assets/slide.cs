using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide : MonoBehaviour
{
    private Slider slider;
    public static bool first = true;
    public static int count = 2;
    public Button button;
    void Start()
    {
        slider = GetComponent<Slider>();
        
    }
    private void OnEnable()
    {
        if (count <= 0)
        {
            first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = first;
        if(first == true)
        {
            slider.value -= Time.deltaTime;
            if (slider.value <= 0)
            {
                GetComponentInParent<Button>().interactable = false;
                Destroy(gameObject, 1f);
            }
        }
        else
            Destroy(gameObject);
    }
}
