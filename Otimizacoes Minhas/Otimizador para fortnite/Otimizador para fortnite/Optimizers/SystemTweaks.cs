using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class SystemTweaks
    {
        public static void Apply()
        {
            // Desabilitar Game DVR e Barra de Jogos
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR\" /v AppCaptureEnabled /t REG_DWORD /d 0 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKCU\\System\\GameConfigStore\" /v GameDVR_Enabled /t REG_DWORD /d 0 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Game DVR e Barra de Jogos desabilitados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar Game DVR: " + ex.Message);
            }
            // Desabilitar atualizações automáticas temporariamente
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = "config wuauserv start= disabled",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Process.Start(new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = "stop wuauserv",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Windows Update desabilitado temporariamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar Windows Update: " + ex.Message);
            }
            // Desabilitar animações e transparências
            try
            {
                Process.Start("SystemPropertiesPerformance.exe", "/pagefile");
                Console.WriteLine("Abra a aba Efeitos Visuais e selecione 'Ajustar para obter um melhor desempenho'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao abrir propriedades de desempenho: " + ex.Message);
            }
            // Desabilitar Cortana
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "reg",
                    Arguments = "add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search\" /v AllowCortana /t REG_DWORD /d 0 /f",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Cortana desabilitada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar Cortana: " + ex.Message);
            }
            // Desabilitar hibernação
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powercfg",
                    Arguments = "/hibernate off",
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                });
                Console.WriteLine("Hibernação desabilitada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao desabilitar hibernação: " + ex.Message);
            }
        }
    }
}
