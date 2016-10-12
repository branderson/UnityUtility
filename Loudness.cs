using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class Loudness 
    {
        // A 20 dB increase sounds about 4x louder.
        // A signal needs an amplitude that is 10^(dB/20) greater, 
        // to be increased by 'dB' decibels.
        class Exponents 
        {
            public static readonly float Set = Mathf.Log(10, 4);
            public static readonly float Get = 1 / Set;
        }
 
        public static float GetLoudness(this AudioSource audioSource) 
        {
            return Mathf.Pow(audioSource.volume, Exponents.Get);
        }
 
        public static float SetLoudness(this AudioSource audioSource, float value) 
        {
            return audioSource.volume = Mathf.Pow(Mathf.Clamp01(value), Exponents.Set);
        }
 
        public static float OfListener 
        {
            get 
            {
                return Mathf.Pow(AudioListener.volume, Exponents.Get);
            }
            set 
            {
                AudioListener.volume = Mathf.Pow(Mathf.Clamp01(value), Exponents.Set);
            }
        }
    }
}