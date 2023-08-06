using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;

namespace GameJam
{
    public static class SoundPath
    {
        public const string SFX_DEATH_1 = "Sounds/SFX/Death1";
        public const string SFX_DEATH_2 = "Sounds/SFX/Death2";
        public const string SFX_DEATH_3 = "Sounds/SFX/Death3";
        public const string SFX_FOOT_STEP_1 = "Sounds/SFX/footstep1";
        public const string SFX_FOOT_STEP_2 = "Sounds/SFX/footstep2";
        public const string SFX_GUN_1 = "Sounds/SFX/gun1";
        public const string SFX_GUN_2 = "Sounds/SFX/gun2";
        public const string SFX_GUN_3 = "Sounds/SFX/gun3";
        public const string SFX_MENU_BUTTON = "Sounds/SFX/menuButtonSound";
        public const string SFX_MENU_CLICK = "Sounds/SFX/menuClick";
        public const string SFX_PAIN_HUMAN = "Sounds/SFX/painHuman";
        public const string SFX_PAIN_HUMAN_2 = "Sounds/SFX/painHuman2";
        public const string SFX_PAIN_HUMAN_3 = "Sounds/SFX/painHuman3";
        public const string SFX_PAIN_MONSTER_1 = "Sounds/SFX/painMonster1";
        public const string SFX_PAIN_MONSTER_2 = "Sounds/SFX/painMonster2";
        public const string SFX_PISTOL_1 = "Sounds/SFX/pistol1";
        public const string SFX_PISTOL_2 = "Sounds/SFX/pistol2";
        public const string SFX_PISTOL_3 = "Sounds/SFX/pistol3";
        public const string SFX_PUNCH_1 = "Sounds/SFX/punch1";
        public const string SFX_PUNCH_2 = "Sounds/SFX/punch2";
        public const string SFX_PUNCH_3 = "Sounds/SFX/punch3";
        public const string SFX_PUNCH_SMASH = "Sounds/SFX/punchSmash";
        public const string SFX_ROCKET = "Sounds/SFX/rocket";
        public const string SFX_ROCKET_BOOM = "Sounds/SFX/rocketBoom";
        public const string SFX_SWORD_1 = "Sounds/SFX/sword1";
        public const string SFX_SWORD_2 = "Sounds/SFX/sword2";
        public const string SFX_SWORD_SMASH = "Sounds/SFX/swordSmash";
        public const string SFX_WEAPON_EQUIP_1 = "Sounds/SFX/weaponEquip1";
        public const string SFX_WEAPON_EQUIP_2 = "Sounds/SFX/weaponEquip2";
        public const string SFX_WEAPON_EQUIP_3 = "Sounds/SFX/weaponEquip3";

        public const string BGM_MUSIC_1 = "Sounds/Music/music1";
        public const string BGM_MUSIC_2 = "Sounds/Music/music2";
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