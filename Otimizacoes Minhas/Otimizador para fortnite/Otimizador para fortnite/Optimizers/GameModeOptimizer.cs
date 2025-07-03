using System;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class GameModeOptimizer
    {
        public static void Run()
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
        }
    }
}
