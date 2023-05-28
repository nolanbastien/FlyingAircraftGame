using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{   
    private GameObject gameManager;
    [SerializeField] GameObject[] aircraftPanels;
    [SerializeField] CollisionHandling collisionHandling;
    [SerializeField] TextMeshProUGUI moneyInfo;
    private Memory memory;

    private void Start() {
        memory = GameObject.FindWithTag("Memory").GetComponent<Memory>();
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
 
    public void ChooseAircraft(int aircraftIndex)
    {   
        // Update Memory
        memory.chosenAircraft = aircraftIndex;
        
        // Update wallet
        if (!memory.acquiredAircrafts[aircraftIndex]) {
            memory.acquiredAircrafts[aircraftIndex] = true;
            string price = aircraftPanels[aircraftIndex].transform.Find("Price").GetComponent<TextMeshProUGUI>().text.Remove(0, 1);
            collisionHandling.coins = collisionHandling.coins - int.Parse(price);
            moneyInfo.text = "Your Money: $" + collisionHandling.coins;
        }
        UpdateButtons();
    }

    public void UpdateButtons() {

        int i = 0;   
        foreach (GameObject aircraftPanel in aircraftPanels) {

            if (i == memory.chosenAircraft) {
                aircraftPanel.transform.Find("Buy").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Chosen";
                aircraftPanel.transform.Find("Buy").GetComponent<Button>().interactable = false;
                i++;
                continue;
            }

            if (memory.acquiredAircrafts[i]) {
                aircraftPanel.transform.Find("Buy").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Choose";
                aircraftPanel.transform.Find("Buy").GetComponent<Button>().interactable = true;
                i++;
                continue;
            }

            // Get price of aircraft in Price object
            string price = aircraftPanel.transform.Find("Price").GetComponent<TextMeshProUGUI>().text.Remove(0, 1);

            if (int.Parse(price) > collisionHandling.coins) {
                aircraftPanel.transform.Find("Buy").GetComponent<Button>().interactable = false;
            };

            i++;
        }
    }
}
