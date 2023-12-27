using UnityEngine;

namespace IboshEngine.Runtime.AudioManagement
{
    [CreateAssetMenu(fileName = "MusicData_", menuName = "Data/Audio/Music Data")]
    public class MusicData : ScriptableObject
    {
        public string Name;
        public AudioClip Clip;
        [Range(0, 1)] public float Volume = 1;
    }
}