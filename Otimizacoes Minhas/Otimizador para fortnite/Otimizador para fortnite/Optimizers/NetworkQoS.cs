using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class NetworkQoS
    {
        public static void SetQoS(string processName = "FortniteClient-Win64-Shipping.exe")
        {
            try
            {
                Console.WriteLine($"Para priorizar o tráfego de {processName}, configure QoS no Editor de Política de Grupo (gpedit.msc).");
                Process.Start("gpedit.msc");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir gpedit: " + ex.Message);
            }
        }
    }
}
