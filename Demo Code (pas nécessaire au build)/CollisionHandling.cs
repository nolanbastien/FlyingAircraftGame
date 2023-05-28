using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionHandling : MonoBehaviour
{
    
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] AudioSource crashSFX;
    [SerializeField] AudioSource coinSFX;
    [SerializeField] float loadPanelDelay = 2f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI moneyInfoText;

    public int coins = 0;
    private bool hasCrashed = false;
    [SerializeField] GameObject marketPlacePanel;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasCrashed) {
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<TileMovementManager>().hasCrashed = true;
            }
            this.gameObject.GetComponent<ControlPlayer>().canMove = false;
            smokeEffect.Play();
            crashSFX.Play();
            StartCoroutine(LoadPanel());
            hasCrashed = true;
        }
    }

    IEnumerator LoadPanel() 
    {
        yield return new WaitForSeconds(loadPanelDelay);
        moneyInfoText.text = "Your Money: $" + coins;
        marketPlacePanel.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin") {
            coins++;
            scoreText.text = "$" + coins.ToString();
            coinSFX.Play();
            Destroy(other.gameObject);
        }

    }

}
