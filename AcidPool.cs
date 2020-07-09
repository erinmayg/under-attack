using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour {

    [SerializeField] private int dps = 5;
    [SerializeField] private AudioSource acidSound;
    private float currTime = 0;

    private void Update() {
        currTime -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (currTime <= 0 && other.gameObject.CompareTag("Player")) {
            currTime = 1f;
            other.GetComponent<PlayerStats>().TakeDamage(dps);
            if (acidSound != null) acidSound.Play();
        }
    }
}
