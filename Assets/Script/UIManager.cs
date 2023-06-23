using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameManager {
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [Header("Button UI")]
        public GameObject loginUI;
        public GameObject registerUI;
        public GameObject barController;
        
        public GameObject canvasForAllScene;

        private void Awake()
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvasForAllScene);
            SetupScreenInit();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SetupScreenInit()
        {
            //DontDestroyOnLoad(loginUI);
            //loginUI.transform.SetParent(canvasForAllScene.transform, false);
            //DontDestroyOnLoad(registerUI);
            //registerUI.transform.SetParent(canvasForAllScene.transform, false);
            registerUI.SetActive(false);
        }
        public void DoneLogin() {
            StartCoroutine(DoneLoginScene());
        }
        public IEnumerator DoneLoginScene() {
            Destroy(loginUI,0.5f);
            Destroy(registerUI, 0.5f);
            yield return new WaitForSeconds(0.5f);
            InitUpgradeScene();
        }

        
        public void clickEventHandler(string cmdNum) {
            switch (cmdNum) {
                case "login":
                    LoginScreen();
                    break;
                case "register":
                    RegisterScreen();
                    break;
            }
        }
        private void RegisterScreen(){
            registerUI.SetActive(true);
            loginUI.SetActive(false);
        }
        private void LoginScreen() {
            loginUI.SetActive(true);
            registerUI.SetActive(false);
        }

        //_________________________________________________________________
        //_________________________________________________________________
        /// Check if GameObject in parameter was exist on parent
        bool ObjectInParent(GameObject objCheck, Transform Parent)
        {
            return objCheck.transform.IsChildOf(Parent);
        }
        
        private void InitUpgradeScene()
        {
            InitUIConcept(barController, "BarController");
        }


        // UIConceptInit
        public void InitUIConcept(GameObject Prefabs, string nameObj)
        {
            GameObject obj = Instantiate(Prefabs);
            obj.name = nameObj;
            obj.transform.SetParent(canvasForAllScene.transform, false);
        }


        // UpgradeLevel Screen Init
        public void UpgradeMenuSceneInit()
        {
            InitUpgradeScene();
        }
        void OnDestroy()
        {
            Instance = null;
        }
    }
}
