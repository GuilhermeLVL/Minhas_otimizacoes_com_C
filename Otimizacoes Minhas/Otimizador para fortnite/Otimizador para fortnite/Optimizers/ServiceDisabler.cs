using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class ServiceDisabler
    {
        public static void DisableMoreServices()
        {
            try
            {
                string[] moreServices = new string[]
                {
                    "Spooler", // Print Spooler
                    "bthserv", // Bluetooth
                    "WerSvc",  // Relatório de Erros
                    "W32Time"   // Windows Time
                };
                foreach (var service in moreServices)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "sc",
                        Arguments = $"config {service} start= disabled",
                        Verb = "runas",
                        CreateNoWindow = true,
                        UseShellExecute = true
                    });
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "sc",
                        Arguments = $"stop {service}",
                        Verb = "runas",
                        CreateNoWindow = true,
                        UseShellExecute = true
                    });
                }
                Console.WriteLine("Serviços adicionais desativados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desativar serviços adicionais: " + ex.Message);
            }
        }
    }
}
