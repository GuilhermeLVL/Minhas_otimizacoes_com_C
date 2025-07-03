using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class StartupOptimizer
    {
        public static void OptimizeStartup()
        {
            try
            {
                Process.Start("explorer.exe", "shell:startup");
                Console.WriteLine("Revise e remova atalhos desnecessários da inicialização.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir pasta de inicialização: " + ex.Message);
            }
        }
    }
}
