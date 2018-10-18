using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSimplyMoving : SavableObject {

    Vector3 position;
    Quaternion rotation;
    Vector2 velocity;
    bool active;

    public override void Save()
    {
        position = transform.position;
        rotation = transform.rotation;
        active = gameObject.activeSelf;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) velocity = rb.velocity;
    }

    public override void Load()
    {
        transform.position = position;
        transform.rotation = rotation;
        gameObject.SetActive(active);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = velocity;
    }
}
