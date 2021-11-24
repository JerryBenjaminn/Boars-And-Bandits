using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BAB.SceneManagement
{
    public class ChangeLevel : MonoBehaviour
    {
        [SerializeField]
        int loadScene = 0;

        private void OnTriggerEnter(Collider player)
        {
            if(player.tag == "Player")
            {
                SceneManager.LoadScene(loadScene);
            }
        }
    }
}
