using System;
using System.Diagnostics;
using System.Security.Principal;

class WindowsOptimization
{
    static void Main(string[] args)
    {
        // Verificar se o programa está sendo executado como administrador
        if (!IsAdministrator())
        {
            Console.WriteLine("Este programa precisa ser executado como administrador. Reiniciando com permissões elevadas...");
            RestartAsAdministrator();
            return;
        }

        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Executar otimizações únicas");
        Console.WriteLine("2. Executar otimizações de rotina");
        Console.WriteLine("3. Executar otimizações da GPU AMD");
        Console.WriteLine("4. Desfazer alterações");
        Console.Write("Opção: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ExecuteUniqueOptimizations();
                break;
            case "2":
                ExecuteRoutineOptimizations();
                break;
            case "3":
                ExecuteAMDOptimizations();
                break;
            case "4":
                UndoChanges();
                break;
            default:
                Console.WriteLine("Opção inválida. Saindo...");
                break;
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static void ExecuteUniqueOptimizations()
    {
        Console.WriteLine("Iniciando otimizações únicas...");

        // Lista de comandos para otimizações únicas
        string[] uniqueCommands = {
            "powercfg -setactive SCHEME_MIN",
            "wmic computersystem where name=\"%computername%\" set AutomaticManagedPagefile=False",
            "sc stop WSearch & sc config WSearch start= disabled",
            "powercfg -h off",
            "sc stop SysMain & sc config SysMain start= disabled",
            "gpupdate /force",
            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Psched\" /v NonBestEffortLimit /t REG_DWORD /d 0 /f",
            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" /v DisableAntiSpyware /t REG_DWORD /d 1 /f",
            "sc stop wuauserv & sc config wuauserv start= disabled",
            "sc stop Spooler & sc config Spooler start= disabled",
            "sc stop Fax & sc config Fax start= disabled",
            "sc stop FontCache & sc config FontCache start= disabled",
            "sc stop WMPNetworkSvc & sc config WMPNetworkSvc start= disabled",
            "sc stop WerSvc & sc config WerSvc start= disabled",
            "sc stop bthserv & sc config bthserv start= disabled",
            "sc stop WbioSrvc & sc config WbioSrvc start= disabled"
        };

        ExecuteCommands("Executando otimizações únicas...", uniqueCommands);
        Console.WriteLine("\nOtimizações únicas concluídas. Será necessário reiniciar o sistema para aplicar todas as mudanças.");
    }

    static void ExecuteRoutineOptimizations()
    {
        Console.WriteLine("Iniciando otimizações de rotina...");

        // Lista de comandos para otimizações de rotina
        string[] routineCommands = {
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\" /v NoDriveTypeAutoRun /t REG_DWORD /d 255 /f",
            "fsutil behavior set disablelastaccess 1",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR\" /v AllowGameDVR /t REG_DWORD /d 0 /f",
            "reg add \"HKCU\\System\\GameConfigStore\" /v GameDVR_Enabled /t REG_DWORD /d 0 /f",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\PushNotifications\" /v ToastEnabled /t REG_DWORD /d 0 /f",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager\" /v SystemPaneSuggestionsEnabled /t REG_DWORD /d 0 /f",
            "reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config\" /v DODownloadMode /t REG_DWORD /d 0 /f",
            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d 0 /f",
            "reg add \"HKCU\\Control Panel\\Desktop\" /v UserPreferencesMask /t REG_BINARY /d 9012038010000000 /f",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 0 /f",
            "reg add \"HKCU\\Control Panel\\Desktop\\WindowMetrics\" /v MinAnimate /t REG_SZ /d 0 /f",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v DisablePreviewDesktop /t REG_DWORD /d 1 /f",
            "reg add \"HKCU\\Software\\Microsoft\\Windows\\DWM\" /v DisableShadow /t REG_DWORD /d 1 /f",
            "powershell -Command \"Stop-Service WSearch\"",
            "powershell -Command \"Set-Service WSearch -StartupType Disabled\"",
            "powershell -Command \"powercfg -attributes SUB_PROCESSOR 893dee8e-2bef-41e0-89c6-b55d0929964c -ATTRIB_HIDE\"",
            "powershell -Command \"powercfg -setacvalueindex SCHEME_MIN SUB_PROCESSOR 893dee8e-2bef-41e0-89c6-b55d0929964c 100\"",
            "powershell -Command \"powercfg -setdcvalueindex SCHEME_MIN SUB_PROCESSOR 893dee8e-2bef-41e0-89c6-b55d0929964c 100\"",
            "powershell -Command \"powercfg -setactive SCHEME_MIN\"",
            "powershell -Command \"Get-ScheduledTask | Where-Object {$_.State -eq 'Ready'} | Disable-ScheduledTask\"",
            "powershell -Command \"Set-Service -Name 'DiagTrack' -StartupType Disabled\"",
            "powershell -Command \"Set-Service -Name 'dmwappushservice' -StartupType Disabled\"",
            "powershell -Command \"Stop-Service wuauserv\"",
            "powershell -Command \"Set-Service wuauserv -StartupType Disabled\"",
            "powershell -Command \"Set-NetAdapterAdvancedProperty -Name '*' -DisplayName 'Interrupt Moderation' -DisplayValue 'Disabled'\"",
            "powershell -Command \"Set-NetAdapterAdvancedProperty -Name '*' -DisplayName 'Receive Side Scaling' -DisplayValue 'Enabled'\"",
            "powershell -Command \"Set-NetAdapterAdvancedProperty -Name '*' -DisplayName 'Speed & Duplex' -DisplayValue '1.0 Gbps Full Duplex'\""
        };

        ExecuteCommands("Executando otimizações de rotina...", routineCommands);
        Console.WriteLine("\nOtimizações de rotina concluídas. Será necessário reiniciar o sistema para aplicar todas as mudanças.");
    }

    static void ExecuteAMDOptimizations()
    {
        Console.WriteLine("Iniciando otimização da GPU AMD...");

        string[] commands = {
            "del /s /q \"%LOCALAPPDATA%\\AMD\\DxCache\\*\"",
            "del /s /q \"%APPDATA%\\AMD\\DxCache\\*\"",
            "del /s /q \"%LOCALAPPDATA%\\AMD\\GLCache\\*\"",
            "reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\amdkmdag\\UMD\" /v PP_DisablePowerSaver /t REG_DWORD /d 1 /f",
            "powercfg -setactive SCHEME_MIN",
            "reg add \"HKLM\\SOFTWARE\\AMD\\Performance\" /v GPU_Performance /t REG_DWORD /d 1 /f",
            "start /wait \"C:\\Caminho\\Para\\AMD_Cleanup_Utility.exe\" -silent",
            "reg add \"HKCU\\System\\GameConfigStore\" /v GameDVR_FSEBehaviorMode /t REG_DWORD /d 2 /f",
            "sc stop amdkmdag",
            "sc start amdkmdag"
        };

        ExecuteCommands("Executando otimizações da GPU AMD...", commands);
        Console.WriteLine("Otimização da GPU AMD concluída.");
    }

    static void UndoChanges()
    {
        Console.WriteLine("Desfazendo alterações...");

        // Lista de comandos para reverter as alterações
        string[] undoCommands = {
            "sc config WSearch start= demand & sc start WSearch",
            "sc config SysMain start= demand & sc start SysMain",
            "sc config DiagTrack start= demand & sc start DiagTrack",
            "sc config DPS start= demand & sc start DPS",
            "sc config WerSvc start= demand & sc start WerSvc",
            "sc config TermService start= demand & sc start TermService",
            "sc config bthserv start= demand & sc start bthserv",
            "sc config WbioSrvc start= demand & sc start WbioSrvc"
        };

        ExecuteCommands("Executando comandos para desfazer alterações...", undoCommands);
        Console.WriteLine("\nAlterações desfeitas. Será necessário reiniciar o sistema para aplicar todas as mudanças.");
    }

    static void ExecuteCommands(string message, string[] commands)
    {
        Console.WriteLine($"\n{message}");
        foreach (string command in commands)
        {
            ExecuteCommand(command);
        }
    }

    static void ExecuteCommand(string command)
    {
        try
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine($"Saída: {output}");
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"Erro: {error}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar comando: {command}");
            Console.WriteLine(ex.Message);
        }
    }

    static bool IsAdministrator()
    {
        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
        {
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }

    static void RestartAsAdministrator()
    {
        ProcessStartInfo processInfo = new ProcessStartInfo
        {
            FileName = Process.GetCurrentProcess().MainModule.FileName,
            UseShellExecute = true,
            Verb = "runas" // Executa como administrador
        };

        try
        {
            Process.Start(processInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Falha ao reiniciar o programa como administrador.");
            Console.WriteLine(ex.Message);
        }
    }
}
