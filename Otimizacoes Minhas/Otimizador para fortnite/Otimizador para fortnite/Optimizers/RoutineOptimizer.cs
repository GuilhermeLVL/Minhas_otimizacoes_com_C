using System;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class RoutineOptimizer
    {
        public static void Run()
        {
            PerformanceOptimizer.Log("[RoutineOptimizer] Iniciando rotina de manutenção");
            try
            {
                // Limpeza de arquivos temporários
                PerformanceOptimizer.CleanTempFiles();
                // Limpeza de cache de navegadores
                BrowserCleaner.CleanCache();
                // (Opcional) Limpeza de logs do Windows, sugestões de atualização de drivers, etc.
                // DriverChecker.CheckDrivers();
                // Outras rotinas de manutenção podem ser adicionadas aqui
                System.Console.WriteLine("Rotina de manutenção concluída.");
                PerformanceOptimizer.Log("[RoutineOptimizer] Rotina de manutenção concluída");
            }
            catch (Exception ex)
            {
                PerformanceOptimizer.Log($"[RoutineOptimizer] Erro: {ex.Message}");
                throw;
            }
        }
    }
}
