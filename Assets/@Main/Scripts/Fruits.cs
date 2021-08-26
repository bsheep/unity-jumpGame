using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject m_collectedPrefab;
    public AudioClip collectedClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
        {
            var collected = Instantiate
            (
                m_collectedPrefab,
                transform.position,
                Quaternion.identity
            );
            var animator = collected.GetComponent<Animator>();
            var info = animator.GetCurrentAnimatorStateInfo(0);
            var time = info.length;
            Destroy(collected, time);

            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(collectedClip);

            Destroy(gameObject);
        }
    }
}
