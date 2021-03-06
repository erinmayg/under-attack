﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleTile : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[2];
    [SerializeField] private AudioSource brokenSound;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private int strength = 100;
    private int currStrength;

    private void Start() {
        currStrength = strength;
        spriteRenderer = GetComponent<SpriteRenderer>();
        brokenSound = GetComponent<AudioSource>();
    }

    private void Update() {
        if (.5 * strength < currStrength) {
            spriteRenderer.sprite = sprites[0];
        } else if (0 < currStrength) {
            spriteRenderer.sprite = sprites[1];
        } else {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        if (brokenSound != null) brokenSound.Play();
        currStrength -= damage;
    }
}
