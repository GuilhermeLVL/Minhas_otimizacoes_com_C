using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class NetworkTweaks
    {
        public static void Apply()
        {
            // Ajustar MTU e TCP Window Auto-Tuning
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "interface ipv4 set subinterface \"Ethernet\" mtu=1500 store=persistent",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "interface tcp set global autotuninglevel=normal",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("MTU e Auto-Tuning ajustados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ajustar MTU/TCP: " + ex.Message);
            }
            // Desabilitar Offloads
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "interface tcp set global chimney=disabled",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "interface tcp set global rss=disabled",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Offloads desabilitados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar offloads: " + ex.Message);
            }
        }
    }
}
