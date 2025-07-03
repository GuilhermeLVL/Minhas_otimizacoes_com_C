using System;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class GameModeOptimizer
    {
        public static void Run()
        {
            PerformanceOptimizer.Log("[GameModeOptimizer] Iniciando otimizações pré-jogo");
            try
            {
                PerformanceOptimizer.CloseBackgroundPrograms();
                PerformanceOptimizer.SetFortniteHighPriority();
                PerformanceOptimizer.DisableWindowsVisualEffects();
                PerformanceOptimizer.DisableFileIndexing();
                PerformanceOptimizer.EnableGameMode();
                PerformanceOptimizer.OptimizeNetworkSettings();
                PerformanceOptimizer.OptimizeAMDGraphics();
                PerformanceOptimizer.SetHighPerformancePowerPlan();
                PerformanceOptimizer.OptimizeInputLag();
                PerformanceOptimizer.OptimizeConnection();
                NotificationOptimizer.DisableNotificationsAndFocusAssist();
                ServiceDisabler.DisableMoreServices();
                RegistryLatencyTweaker.Optimize();
                System.Console.WriteLine("Otimizações pré-jogo aplicadas.");
                PerformanceOptimizer.Log("[GameModeOptimizer] Otimizações pré-jogo aplicadas");
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[GameModeOptimizer] Erro: {ex.Message}");
                throw;
            }
        }
    }
}
