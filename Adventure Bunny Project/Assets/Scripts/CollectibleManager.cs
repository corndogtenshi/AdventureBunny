using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectibleManager : MonoBehaviour
{
    public Text keyText;
    public int startKeyCount = 5;
    private int keyLeftCount;
    private bool chestOpened = false;

    private AudioSource grabKey;

    public ChestManager chest;

    // Start is called before the first frame update
    void Start()
    {
        grabKey = this.gameObject.GetComponent<AudioSource>();
        keyLeftCount = startKeyCount;
        InitializeKeyCount();

    }

    public void IncreaseKeyCount()
    {
        if (!chestOpened)
        {
            keyLeftCount -= 1;
            if (keyLeftCount == 0)
            {
                keyText.text = "Open the chest!";
                chest.setCanOpen();
            }
            else if (keyLeftCount == 1)
            {
                keyText.text = keyLeftCount + " key remains";
            }
            else
            {
                keyText.text = keyLeftCount + " keys remain";
            }
            grabKey.Play();
        }
    }

    public void InitializeKeyCount()
    {
        if (!chestOpened)
        {
            if (keyLeftCount == 0)
            {
                keyText.text = "Open the chest!";
                chest.setCanOpen();
            }
            else if (keyLeftCount == 1)
            {
                keyText.text = keyLeftCount + " key remains";
            }
            else
            {
                keyText.text = keyLeftCount + " keys remain";
            }
        }
    }

    public void setChestOpened()
    {
        chestOpened = true;
        keyText.text = "Enjoy your treasure!";
    }
}
