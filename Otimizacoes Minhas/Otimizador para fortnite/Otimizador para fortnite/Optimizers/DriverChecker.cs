using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class DriverChecker
    {
        public static void CheckDrivers()
        {
            PerformanceOptimizer.Log("[DriverChecker] Iniciando verificação de drivers");
            try
            {
                Process.Start("devmgmt.msc");
                Console.WriteLine("Verifique se todos os drivers estão atualizados.");
                PerformanceOptimizer.Log("[DriverChecker] Verificação de drivers concluída");
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[DriverChecker] Erro: {ex.Message}");
                Console.WriteLine("Erro ao abrir Gerenciador de Dispositivos: " + ex.Message);
            }
        }
    }
}
