using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class HandleStartPlaying : MonoBehaviour
{
    public float disappearTextsDelay = 1.0f;
    [SerializeField] Rigidbody2D rb;
    private GameObject[] startTexts;
    private GameObject tileManager;
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        tileManager = GameObject.FindWithTag("TileManager");
        startTexts = GameObject.FindGameObjectsWithTag("StartText");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rb.constraints = RigidbodyConstraints2D.None;
            tileManager.GetComponent<TileManager>().spawnIndex0 = false;
            StartCoroutine(DeleteTextWithDelay(disappearTextsDelay));
            this.enabled = false;
        }
    }

    IEnumerator DeleteTextWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject startText in startTexts)
        {
            Destroy(startText); 
        }
        scoreText.text = "$0";
    }

}
