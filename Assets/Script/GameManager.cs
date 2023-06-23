using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

namespace GameManager {
    public class GameManager : MonoBehaviour
    {
        
        public static GameManager Instance;
        
        public GameObject AllManager; // GameObject UIManager
        
        

        void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(AllManager);
            //DontDestroyOnLoad(GO_AuthManager);
            //DontDestroyOnLoad(gameObject);
        }
        void Start()
        {
            EventHandler.CheckLogin += On_Login_Success;
            EventHandler.CheckRegister += On_Register_Success;
        }
        public void On_Login_Success(bool status) {
            if (status) {
                UIManager.Instance.DoneLogin();
            }
        }
        public void On_Register_Success(bool status){
            if (status) {
                UIManager.Instance.clickEventHandler("login");
            }
        }
        void OnDestroy()
        {
            Instance = null;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        
    }
}