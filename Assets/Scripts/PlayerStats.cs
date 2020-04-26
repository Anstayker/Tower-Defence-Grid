using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] int lifePoints = 10;
    [SerializeField] Text healthText;

    private void Start() {
        healthText.text = ("Health: " + lifePoints.ToString());
    }

    public void loseLifePoints(int amountToLose) {
        lifePoints -= amountToLose;
        healthText.text = ("Health: " + lifePoints);
    }

}
