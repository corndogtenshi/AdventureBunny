using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestManager : MonoBehaviour
{
    private bool hasBeenOpened = false;
    private bool allKeysCollected = false;
    private AudioSource chestOpen;
    private SpriteRenderer chestSpriteRenderer;
    public Sprite chestOpened;
    public CollectibleManager collectibleManager;
    public ParticleSystem fireworks;
    public ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        chestSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        chestOpen = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (allKeysCollected == true && hasBeenOpened == false)
        {
            chestSpriteRenderer.sprite = chestOpened;
            chestOpen.Play();
            hasBeenOpened = true;
            score.IncreaseScore(1000);
            collectibleManager.setChestOpened();
            PlayFireworks();
            //Debug.Log("Chest opened!");
            StartCoroutine(LoadNextLevel());

        }
    }

    public void setCanOpen()
    {
        allKeysCollected = true;
    }
    
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PlayFireworks()
    {
        fireworks.Play();
        fireworks.gameObject.GetComponent<AudioSource>().Play();
    }
}
