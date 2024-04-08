using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image healthbarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private float target = 1;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void UpdateHealthBar (int maxHealth, int currentHealth) {
        target = (float) currentHealth / maxHealth;
        print(target);
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        healthbarSprite.fillAmount =
            Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);

    }
            
    
    
}
