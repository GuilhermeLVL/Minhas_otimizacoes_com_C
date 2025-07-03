using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class StartupOptimizer
    {
        public static void OptimizeStartup()
        {
            PerformanceOptimizer.Log("[StartupOptimizer] Iniciando otimização de inicialização");
            try
            {
                Process.Start("explorer.exe", "shell:startup");
                Console.WriteLine("Revise e remova atalhos desnecessários da inicialização.");
                PerformanceOptimizer.Log("[StartupOptimizer] Otimização de inicialização concluída");
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[StartupOptimizer] Erro: {ex.Message}");
                Console.WriteLine("Erro ao abrir pasta de inicialização: " + ex.Message);
            }
        }
    }
}
