using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class NetworkQoS
    {
        public static void SetQoS(string processName = "FortniteClient-Win64-Shipping.exe")
        {
            PerformanceOptimizer.Log($"[NetworkQoS] Sugerindo configuração de QoS para {processName}");
            try
            {
                Console.WriteLine($"Para priorizar o tráfego de {processName}, configure QoS no Editor de Política de Grupo (gpedit.msc).");
                Process.Start("gpedit.msc");
                PerformanceOptimizer.Log("[NetworkQoS] Sugestão de QoS exibida");
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[NetworkQoS] Erro: {ex.Message}");
                Console.WriteLine("Erro ao abrir gpedit: " + ex.Message);
            }
        }
    }
}
