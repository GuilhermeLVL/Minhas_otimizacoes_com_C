using System;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class RoutineOptimizer
    {
        public static void Run()
        {
            // Limpeza de arquivos temporários
            PerformanceOptimizer.CleanTempFiles();
            // Limpeza de cache de navegadores
            BrowserCleaner.CleanCache();
            // (Opcional) Limpeza de logs do Windows, sugestões de atualização de drivers, etc.
            // DriverChecker.CheckDrivers();
            // Outras rotinas de manutenção podem ser adicionadas aqui
            System.Console.WriteLine("Rotina de manutenção concluída.");
        }
    }
}
