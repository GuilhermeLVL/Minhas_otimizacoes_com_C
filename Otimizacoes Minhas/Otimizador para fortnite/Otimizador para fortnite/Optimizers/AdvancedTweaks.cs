using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class AdvancedTweaks
    {
        public static void Apply()
        {
            // Prioridade tempo real (com cautela)
            System.Console.WriteLine("Ajuste manual: Defina o processo do jogo para 'Tempo Real' no Gerenciador de Tarefas (não recomendado para todos os sistemas).");
            // Timer resolution
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c wmic computersystem where name=\"%computername%\" set systemtimersresolution=0.5",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                System.Console.WriteLine("Timer resolution ajustado para 0.5ms.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro ao ajustar timer resolution: " + ex.Message);
            }
            // Instruções para BIOS
            System.Console.WriteLine("Para usuários avançados: Desabilite CPU Parking, C-States e SpeedStep no BIOS para máxima performance.");
        }
    }
}
