using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class LaptopPowerOptimizer
    {
        public static void Optimize()
        {
            try
            {
                if (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery)
                {
                    Process.Start("powercfg", "/setactive SCHEME_MIN");
                    Console.WriteLine("Plano de energia otimizado para laptop.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao otimizar energia do laptop: " + ex.Message);
            }
        }
    }
}
