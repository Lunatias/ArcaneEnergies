using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthBarImage;
    public PlatformerController player;
    public float length;

    // update the health bar
    public void UpdateHealthBar() {
        healthBarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
        Color newColor = Color.green;
        if (player.health < player.maxHealth * 0.25f) {
            newColor = Color.red;
        } else if (player.health < player.maxHealth * 0.66f) {
            newColor = new Color(1f, 0.6f, 0f, 1f);
        }

        healthBarImage.GetComponent<Image>().color = newColor;
    }
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
