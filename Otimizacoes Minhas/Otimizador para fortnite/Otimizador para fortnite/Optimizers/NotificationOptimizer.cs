using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class NotificationOptimizer
    {
        public static void DisableNotificationsAndFocusAssist()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\" /v NOC_GLOBAL_SETTING_TOASTS_ENABLED /t REG_DWORD /d 0 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings\" /v FocusAssist /t REG_DWORD /d 0 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Notificações e Focus Assist desabilitados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar notificações: " + ex.Message);
            }
        }
    }
}
