﻿using FixEverything.Commands;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FixEverything.ViewModels
{
    internal class FixitsViewModel : ParentViewModel
    {
        public FixitsViewModel()
        {
            FixitsCommand = new FixitsCommand(this);
        }

        public bool CanExecute
        {
            get
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    return false;
                }
                return true;
            }
        }
        
        public ICommand FixitsCommand
        {
            get;
            private set;
        }

        public void WinUpdateFix()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "WinUpdateFix-06.11.14.bat", "winupdate.bat");
            Utils.UpdateDbClickCount("Windows Update Fix");
        }

        public void ScansPopup()
        {
            Messenger.Default.Send(new NotificationMessage("Scans"));
            Utils.UpdateDbClickCount("Misc Scans");
        }

        public void DvdFix()
        {
            Utils.downloadProgram("http://callme.cloudapp.net/download.php?file=CDDVDWin8.meta.diagcab", "DVD Drive Fix");
            Utils.UpdateDbClickCount("DVD Fix");
        }

        public void ClearPrintQueue()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "Printer fix.bat", "printerfix.bat");
            Utils.UpdateDbClickCount("Printer Fix");
        }

        public void SoundFix()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "soundfix.bat", "soundfix.bat");
            Utils.UpdateDbClickCount("Sound Fix");
        }

        public void AdminFix()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "win81adminfix.bat", "win81adminfix.bat");
            Utils.UpdateDbClickCount("8.1 Update Fix");
        }

        public void AppsFix()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "apps.diagcab", "apps.diagcab");
            Utils.UpdateDbClickCount("Apps Troubleshooter");
        }

        public void RemoveSentinelDrivers()
        {
            Utils.downloadProgram("http://callme.cloudapp.net/download.php?file=haspdinst.exe", "Sentinel Driver Removal");
            Utils.UpdateDbClickCount("Haspdinst");
        }

        public void FixPcSettings()
        {
            Utils.runProgramFromResource(Utils.RESOURCE_DIR + "fix_pcsettings.bat", "fix_pcsettings.bat");
            Utils.UpdateDbClickCount("Fix PC Settings");
        }

    }
}
