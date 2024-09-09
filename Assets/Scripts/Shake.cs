using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1f;

    void Update()
    {
        if (start) {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    public void ShakeScreen()
    {
        StartCoroutine(Shaking());
    }

    public IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + (Random.insideUnitSphere * 0.2f);
            yield return null;
        }
        start = false;
        transform.position = startPosition;
    }
}
