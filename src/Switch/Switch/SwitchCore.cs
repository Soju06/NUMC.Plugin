﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Switch {
    public class SwitchCore : IDisposable {
        private readonly Dictionary<Keys, bool> KeyInfos = new Dictionary<Keys, bool>();
        private readonly CancellationTokenSource TokenSource;
        private CancellationToken Token;

        public SwitchCore() {
            foreach (var item in Enum.GetValues(typeof(Keys)))
                if (!KeyInfos.ContainsKey((Keys)item))
                    KeyInfos.Add((Keys)item, false);
            NUMC.Keyboard.KeyboardHook.NonStopKeyDown += KeyboardKeyDown;
            NUMC.Keyboard.KeyboardHook.NonStopKeyUp += KeyboardKeyUp;
            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
            Task.Run(Loop, Token);
        }

        private void KeyboardKeyUp(Keys key) => KeyInfos[key] = false;

        private void KeyboardKeyDown(Keys key) => KeyInfos[key] = true;

        private async Task Loop() {
            var reload_count = 0;
            const int reload = 75;
            var Options = SwitchOptions.LoadOptions();
            Options.TryGetValue("0", out Keys[] M1);
            Options.TryGetValue("1", out Keys[] M2);
            Options.TryGetValue("2", out Keys[] M3);
            while (!Token.IsCancellationRequested) {
                if(reload_count >= reload) {
                    reload_count = 0;
                    Options = SwitchOptions.LoadOptions();
                    Options.TryGetValue("0", out M1);
                    Options.TryGetValue("1", out M2);
                    Options.TryGetValue("2", out M3);
                }

                if (IsKeysDown(M1)) {
                    NUMC.Service.GetService()?.Start();
                    await Task.Delay(100);
                } else if (IsKeysDown(M2)) {
                    NUMC.Service.GetService()?.Pause();
                    await Task.Delay(100);
                }
                else if (IsKeysDown(M3)) {
                    var setvice = NUMC.Service.GetService();
                    var state = setvice?.State;
                    Debug.WriteLine(state);
                    if (state == NUMC.Service.StateCode.Paused)
                        setvice?.Start();
                    else if (state == NUMC.Service.StateCode.Running)
                        setvice?.Pause();
                    await Task.Delay(100);
                }

                reload_count++;
                await Task.Delay(20);
            }
        }

        private bool IsKeysDown(Keys[] keys) {
            if (keys != null) {
                int l = 0;
                for (int i = 0; i < keys.Length; i++) {
                    if (keys[i] == Keys.None) continue;
                    if (!KeyInfos[keys[i]])
                        return false;
                    else l++;
                } if (l > 0) return true;
            } return false;
        }

        public void Dispose() {
            TokenSource.Cancel();
        }
    }
}
