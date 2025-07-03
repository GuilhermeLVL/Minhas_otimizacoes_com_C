using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class RegistryLatencyTweaker
    {
        public static void Optimize()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\" /v LargeSystemCache /t REG_DWORD /d 1 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\" /v TcpAckFrequency /t REG_DWORD /d 1 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Tweaks de latência aplicados ao registro.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao otimizar registro para latência: " + ex.Message);
            }
        }
    }
}
