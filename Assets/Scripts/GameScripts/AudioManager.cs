using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public enum AudioSelect
    {
        Success, fail, EndAudio, BGM, GetScore
    }
    public class AudioManager : MonoBehaviour
    {
        public AudioClip Success;
        public AudioClip fail;
        public AudioClip EndAudio;
        public AudioClip BGM;
        public AudioClip GetScore;
        private bool gameOver = false;
        // Start is called before the first frame update
        void Awake()
        {
            GameEventCenter.AddEvent<AudioSelect>("PlayAudio", PlayAudio);
            GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.BGM);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.Success);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.GetScore);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.EndAudio);
            }
        }

        public void PlayAudio(AudioSelect s)
        {
            switch (s)
            {
                case AudioSelect.Success: GameAudioController.Instance.PlayOneShot(Success); break;
                case AudioSelect.fail: GameAudioController.Instance.PlayOneShot(fail); break;
                case AudioSelect.EndAudio: GameOver(); break;
                case AudioSelect.BGM: GameAudioController.Instance.LoopPlay(BGM); break;
                case AudioSelect.GetScore: GameAudioController.Instance.PlayOneShot(GetScore); break;
            }
        }

        private void GameOver()
        {
            if (!gameOver)
            {
                GameAudioController.Instance.LoopPlay(EndAudio);
                gameOver = true;
            }
        }
    }
}


