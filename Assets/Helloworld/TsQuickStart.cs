using UnityEngine;
using Puerts;
using System;
using System.IO;

namespace PuertsTest
{
    public class TsQuickStart : MonoBehaviour
    {
        JsEnv jsEnv;

        async void Start()
        {
            jsEnv = new JsEnv(new DevelopmentLoader(), 8080);
            await jsEnv.WaitDebuggerAsync();
            jsEnv.Eval("require('QuickStart')");
        }

        private void Update()
        {
            jsEnv.Tick();
        }

        void OnDestroy()
        {
            jsEnv.Dispose();
        }
    }
}
