using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gestionDeaths : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI champTexte;
    private int deathCount;
    void Start()
    {
        deathCount = GameManager.Instance.deathCmpt;
        champTexte.SetText($"Death count: {deathCount}");
    }
}
