using System;
using System.Diagnostics;

namespace SystemOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Função para executar um comando CMD
            void ExecuteCMD(string command)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;

                Process process = Process.Start(processInfo);
                process.WaitForExit();
            }

            // Função para executar um comando PowerShell
            void ExecutePowerShell(string command)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("powershell.exe", command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;

                Process process = Process.Start(processInfo);
                process.WaitForExit();
            }

            // Comandos CMD
            string[] cmdCommands = new string[]
            {
                // Mouse
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseThreshold1 /t REG_SZ /d 0 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseThreshold2 /t REG_SZ /d 0 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseSensitivity /t REG_SZ /d 10 /f",

                // Teclado
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Keyboard"" /v KeyboardSpeed /t REG_SZ /d 31 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Keyboard"" /v InitialKeyboardIndicators /t REG_SZ /d 2 /f",

                // Energia
                @"powercfg -setactive SCHEME_MIN",
                @"powercfg -h off",

                // Rede
                @"ipconfig /release",
                @"ipconfig /renew",
                @"ipconfig /flushdns",

                // Desempenho
                @"reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DirectX\CLSID\{33E6ECC0-32BD-4C57-B207-759C5CA8F316}"" /v ""EnableOverride"" /t REG_DWORD /d 1 /f",
                @"reg add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DirectX\CLSID\{33E6ECC0-32BD-4C57-B207-759C5CA8F316}"" /v ""EnableAutoUpdate"" /t REG_DWORD /d 0 /f",
                @"reg add ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers"" /v TdrLevel /t REG_DWORD /d 0 /f",
                @"sc config ""W32Time"" start=disabled"
            };

            // Comandos CMD para desfazer
            string[] cmdUndoCommands = new string[]
            {
                // Mouse
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseThreshold1 /t REG_SZ /d 6 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseThreshold2 /t REG_SZ /d 10 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Mouse"" /v MouseSensitivity /t REG_SZ /d 10 /f",

                // Teclado
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Keyboard"" /v KeyboardSpeed /t REG_SZ /d 31 /f",
                @"reg add ""HKEY_CURRENT_USER\Control Panel\Keyboard"" /v InitialKeyboardIndicators /t REG_SZ /d 0 /f",

                // Energia
                @"powercfg -setactive SCHEME_BALANCED",
                @"powercfg -h on",

                // Rede
                @"ipconfig /release",
                @"ipconfig /renew",
                @"ipconfig /flushdns",

                // Desempenho
                @"reg delete ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DirectX\CLSID\{33E6ECC0-32BD-4C57-B207-759C5CA8F316}"" /v ""EnableOverride"" /f",
                @"reg delete ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DirectX\CLSID\{33E6ECC0-32BD-4C57-B207-759C5CA8F316}"" /v ""EnableAutoUpdate"" /f",
                @"reg delete ""HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GraphicsDrivers"" /v TdrLevel /f",
                @"sc config ""W32Time"" start=auto"
            };

            // Comandos PowerShell
            string[] powershellCommands = new string[]
            {
                // Rede
                @"netsh interface tcp set global autotuning=disabled",

                // Remoção de Bloatware
                @"Get-AppxPackage -AllUsers | Remove-AppxPackage",

                // Serviços
                @"sc stop ""WerSvc"" && sc config ""WerSvc"" start=disabled",
                @"sc stop ""WSearch"" && sc config ""WSearch"" start=disabled",
                @"sc stop ""Dnscache"" && sc config ""Dnscache"" start=disabled",
                @"sc stop ""lanmanworkstation"" && sc config ""lanmanworkstation"" start=disabled",
                @"sc stop ""NlaSvc"" && sc config ""NlaSvc"" start=disabled",

                // Desativação Temporária do Windows Defender
                @"Set-MpPreference -DisableRealtimeMonitoring $true",

                // Modo de Jogo
                @"reg add ""HKCU\Software\Microsoft\GameBar"" /v AllowAutoGameMode /t REG_DWORD /d 1 /f",

                // Reprodução Automática
                @"reg add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers"" /v DisableAutoplay /t REG_DWORD /d 1 /f"
            };

            // Comandos PowerShell para desfazer
            string[] powershellUndoCommands = new string[]
            {
                // Rede
                @"netsh interface tcp set global autotuning=normal",

                // Adicionar Bloatware Padrão
                // (Este comando pode não reverter todos os aplicativos removidos, pois depende do pacote específico do aplicativo)
                @"Get-AppxPackage -AllUsers -Name *Microsoft.BingWeather* | Add-AppxPackage -Register",

                // Serviços
                @"sc config ""WerSvc"" start=auto && sc start ""WerSvc""",
                @"sc config ""WSearch"" start=auto && sc start ""WSearch""",
                @"sc config ""Dnscache"" start=auto && sc start ""Dnscache""",
                @"sc config ""lanmanworkstation"" start=auto && sc start ""lanmanworkstation""",
                @"sc config ""NlaSvc"" start=auto && sc start ""NlaSvc""",

                // Reativação do Windows Defender
                @"Set-MpPreference -DisableRealtimeMonitoring $false",

                // Modo de Jogo
                @"reg add ""HKCU\Software\Microsoft\GameBar"" /v AllowAutoGameMode /t REG_DWORD /d 0 /f",

                // Reprodução Automática
                @"reg add ""HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers"" /v DisableAutoplay /t REG_DWORD /d 0 /f"
            };

            // Menu de Opções
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Executar otimização");
            Console.WriteLine("2. Desfazer otimização");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Executar comandos CMD
                foreach (string command in cmdCommands)
                {
                    ExecuteCMD(command);
                }

                // Executar comandos PowerShell
                foreach (string command in powershellCommands)
                {
                    ExecutePowerShell(command);
                }

                Console.WriteLine("Otimização concluída com sucesso!");
            }
            else if (choice == 2)
            {
                // Executar comandos CMD para desfazer
                foreach (string command in cmdUndoCommands)
                {
                    ExecuteCMD(command);
                }

                // Executar comandos PowerShell para desfazer
                foreach (string command in powershellUndoCommands)
                {
                    ExecutePowerShell(command);
                }

                Console.WriteLine("Otimização desfeita com sucesso!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}
