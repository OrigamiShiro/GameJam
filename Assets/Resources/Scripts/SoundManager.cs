using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace GameJam
{
    public static class SoundPath
    {
    }

    public class SoundInstance
    {
        public AudioClip Sound { get; }
        public float Volume { get; private set; } = 0.5f;

        private SoundInstance(AudioClip sound)
        {
            Sound = sound;
        }

        public static async Task<SoundInstance> GetSoundInstance(string filePath, AudioType fileType = AudioType.WAV)
        {
            using (var www = UnityWebRequestMultimedia.GetAudioClip(filePath, fileType))
            {
                var result = www.SendWebRequest();

                while (!result.isDone)
                {
                    await Task.Delay(100);
                }

                if (www.result != UnityWebRequest.Result.ConnectionError)
                    return new SoundInstance(DownloadHandlerAudioClip.GetContent(www));

                Debug.Log(www.error);
                return null;
            }
        }
    }

    public static class SoundManager
    {
        private static AudioSource _music;
        private static AudioSource _sound;

        public static async void PlayOneShoot(string path)
        {
            var sound = await SoundInstance.GetSoundInstance(path);
            _sound.volume = sound.Volume;
            _sound.PlayOneShot(sound.Sound);
        }

        public static async void PlayMusic(string path)
        {
            var sound = await SoundInstance.GetSoundInstance(path);
            _music.clip = sound.Sound;
            _music.volume = sound.Volume;
            Play();
        }

        public static void Play() =>
            _music.Play();
        
        public static void Pause() =>
            _music.Pause();

        public static void Mute() =>
            _music.mute = true;

        public static void UnMute() =>
            _music.mute = false;
    }
}