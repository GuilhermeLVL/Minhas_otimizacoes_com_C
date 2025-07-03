using System;
using System.Diagnostics;
using System.IO;

namespace OtimizadorParaFortnite.Optimizers
{
    public static class RollbackManager
    {
        private static string registryBackupPath = "reg_backup.reg";
        private static string servicesBackupPath = "services_backup.txt";

        public static void BackupAll()
        {
            // Backup do registro
            RegistryBackup.Backup(registryBackupPath);
            // Backup do status dos serviços
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c sc query state= all > {servicesBackupPath}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();
                Console.WriteLine($"Backup do status dos serviços salvo em {servicesBackupPath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer backup dos serviços: " + ex.Message);
            }
        }

        public static void RestoreAll()
        {
            // Restaurar registro
            RegistryBackup.Restore(registryBackupPath);
            // Restaurar serviços: instrução manual
            if (File.Exists(servicesBackupPath))
            {
                Console.WriteLine($"Consulte {servicesBackupPath} para restaurar manualmente o status dos serviços.");
            }
            else
            {
                Console.WriteLine("Backup dos serviços não encontrado. Restauração manual necessária.");
            }
            Console.WriteLine("Atenção: arquivos deletados e algumas configurações não podem ser desfeitas automaticamente.");
        }
    }
}
