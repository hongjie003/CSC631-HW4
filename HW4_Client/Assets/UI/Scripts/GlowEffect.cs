using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlowEffect : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float Low;
    [Range(0, 1)]
    [SerializeField] float High;
    [SerializeField] float Speed;

    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            float glowAmount = Mathf.PingPong(Time.time * Speed, High) + Low; // Oscalate between low and high
            text.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, glowAmount);
        }
    }
}
