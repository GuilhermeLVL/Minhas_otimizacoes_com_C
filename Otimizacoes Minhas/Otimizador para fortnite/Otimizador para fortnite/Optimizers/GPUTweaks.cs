using System;
using System.Diagnostics;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class GPUTweaks
    {
        public static void Apply()
        {
            // Desabilitar overlays conhecidos
            Console.WriteLine("Feche overlays de Discord, Steam, GeForce Experience, etc. manualmente.");
            // Forçar modo de desempenho máximo (AMD exemplo)
            try
            {
                Process.Start("C:\\Program Files\\AMD\\CNext\\CNext\\RadeonSettings.exe", "-performance");
                Console.WriteLine("Driver AMD configurado para desempenho máximo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao configurar driver AMD: " + ex.Message);
            }
            // Instrução para NVIDIA
            Console.WriteLine("No Painel NVIDIA, defina 'Modo de Gerenciamento de Energia' para 'Preferir desempenho máximo'.");
            // Desabilitar V-Sync
            Console.WriteLine("Desabilite V-Sync e G-Sync/Freesync no painel da GPU para menor input lag.");
        }
    }
}
