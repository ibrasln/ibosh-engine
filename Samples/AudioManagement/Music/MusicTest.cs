using System.Collections;
using System.Collections.Generic;
using IboshEngine.Runtime.AudioManagement;
using UnityEngine;

namespace IboshSama.IboshEngine.Samples
{
    public class MusicTest : MonoBehaviour
    {
        [SerializeField] private MusicData firstMusic;
        [SerializeField] private MusicData secondMusic;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) MusicManager.Instance.Play(firstMusic);
            else if (Input.GetKeyDown(KeyCode.W)) MusicManager.Instance.Play(secondMusic); 
        }
    }
}
