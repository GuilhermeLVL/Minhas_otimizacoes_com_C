using System;

using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class LaptopPowerOptimizer
    {
        public static void Optimize()
        {
            PerformanceOptimizer.Log("[LaptopPowerOptimizer] Iniciando otimização de energia para laptop");
            try
            {
                // Otimização apenas se for laptop (Windows)
                // Como alternativa ao System.Windows.Forms, use Environment.OSVersion e WMI para detectar bateria
                bool hasBattery = HasBattery();
                if (hasBattery)
                {
                    Process.Start("powercfg", "/setactive SCHEME_MIN");
                    Console.WriteLine("Plano de energia otimizado para laptop.");
                    PerformanceOptimizer.Log("[LaptopPowerOptimizer] Otimização de energia para laptop aplicada");
                }
                else
                {
                    PerformanceOptimizer.Log("[LaptopPowerOptimizer] Não é laptop ou não foi detectada bateria");
                }
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[LaptopPowerOptimizer] Erro: {ex.Message}");
                Console.WriteLine("Erro ao otimizar energia do laptop: " + ex.Message);
            }
        }

        // Alternativa simples para detectar bateria sem System.Windows.Forms
        private static bool HasBattery()
        {
            try
            {
                var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_Battery");
                var batteries = searcher.Get();
                // Corrigir: Count é um método, não uma propriedade, e pode não estar disponível diretamente
                // Usar LINQ para verificar se há algum item
                return batteries.Cast<object>().Any();
            }
            catch
            {
                return false;
            }
        }
    }
}
