using IboshEngine.Runtime.AudioManagement;
using UnityEngine;

public class SoundEffectTest : MonoBehaviour
{
    [SerializeField] private SoundEffectData testSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SoundEffectManager.Instance.Play(testSound);
    }
}
