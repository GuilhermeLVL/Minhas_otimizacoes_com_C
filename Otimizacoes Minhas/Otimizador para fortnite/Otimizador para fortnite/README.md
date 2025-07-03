# Otimizador Para Fortnite

## Visão Geral

Este projeto é um otimizador avançado para Windows, focado em extrair o máximo desempenho do sistema para jogos, especialmente Fortnite. Ele automatiza ajustes de sistema, rede, GPU, áudio, disco e aplica tweaks avançados para reduzir input lag, latência e maximizar FPS.

---

## Funcionalidades Principais

- **Menu Interativo:** Escolha entre otimização completa, rotina de manutenção, otimização pré-jogo, rollback (desfazer) e otimizações avançadas.
- **Backup e Rollback:** Faz backup do registro e status dos serviços antes de alterações críticas. Permite desfazer alterações via menu.
- **Rotina de Manutenção:** Limpa arquivos temporários, cache de navegadores e realiza manutenção básica.
- **Otimização Pré-Jogo:** Fecha programas em segundo plano, ajusta prioridade do jogo, desabilita notificações, otimiza rede, energia e serviços.
- **Otimizações Avançadas:** Ajustes de Game DVR, Windows Update, Cortana, MTU, TCP, Offloads, GPU, áudio, disco, timer resolution, instruções para BIOS e mais.
- **Log de Atividades:** Todas as ações e erros são registrados em `otimizador_log.txt`.

---

## Como Usar

1. **Execute o programa como Administrador.**
2. Escolha a opção desejada no menu:
   - `[1] Otimização Completa`: Aplica todas as rotinas, pré-jogo e ajustes extras.
   - `[2] Apenas Rotina de Manutenção`: Limpeza e manutenção básica.
   - `[3] Apenas Otimização Pré-Jogo`: Ajustes para jogar com máximo desempenho.
   - `[4] Desfazer Alterações (Rollback)`: Restaura registro e exibe instruções para restaurar serviços.
   - `[5] Otimizações Avançadas para Jogos`: Tweaks extras para gamers avançados.
   - `[0] Sair`: Encerra o programa.

---

## O que cada opção faz?

### Otimização Completa
- Faz backup do registro e status dos serviços.
- Executa limpeza de arquivos temporários e cache de navegadores.
- Fecha programas em segundo plano, ajusta prioridade do Fortnite, desabilita efeitos visuais, indexação, notificações, etc.
- Otimiza rede, energia, serviços, input lag, conexão, drivers, startup, QoS, e mais.
- Aplica tweaks avançados de sistema, rede, GPU, áudio, disco e configurações avançadas.

### Rotina de Manutenção
- Limpa arquivos temporários e cache de navegadores.
- (Pode ser expandida para incluir limpeza de logs, sugestões de atualização de drivers, etc.)

### Otimização Pré-Jogo
- Fecha programas em segundo plano.
- Ajusta prioridade do jogo.
- Desabilita notificações, otimiza energia, rede, serviços e input lag.
- Aplica tweaks temporários para máxima performance durante o jogo.

### Otimizações Avançadas
- Desabilita Game DVR, Windows Update, Cortana, hibernação, animações.
- Ajusta MTU, TCP, Offloads, configurações de GPU, áudio, disco.
- Sugere ajustes manuais para BIOS e prioridade tempo real.

### Rollback (Desfazer Alterações)
- Restaura o backup do registro.
- Exibe instruções para restaurar manualmente o status dos serviços (consultar `services_backup.txt`).
- Observação: arquivos deletados e algumas configurações não podem ser desfeitas automaticamente.

---

## Como Validar se a Alteração foi Feita

- **Registro:** Verifique as chaves alteradas usando o `regedit`.
- **Serviços:** Use `services.msc` para checar se serviços estão desativados.
- **Rede:** Use `netsh interface tcp show global` para validar ajustes de TCP/MTU.
- **GPU:** Verifique configurações no painel da NVIDIA/AMD.
- **Áudio:** Veja as propriedades do dispositivo de reprodução.
- **Disco:** Use o desfragmentador e propriedades das pastas.
- **Log:** Consulte `otimizador_log.txt` para ver todas as ações executadas e erros.

---

## Como Desfazer (Rollback)

1. No menu, escolha `[4] Desfazer Alterações (Rollback)`.
2. O registro será restaurado automaticamente.
3. Consulte o arquivo `services_backup.txt` para restaurar manualmente o status dos serviços, se necessário.
4. Para configurações manuais (painel da GPU, BIOS, overlays), reverta manualmente conforme instruções exibidas.

---

## Observações Importantes

- **Execute sempre como Administrador.**
- Algumas otimizações são irreversíveis (ex: arquivos deletados, cache limpo).
- Tweaks avançados podem causar instabilidade em alguns sistemas. Use com cautela.
- Sempre faça backup de arquivos importantes antes de usar o otimizador.

---

## Expansão

O projeto é modular. Para adicionar novos ajustes, crie um novo arquivo em `Optimizers/` e adicione ao menu principal.

---

## Suporte

Para dúvidas ou sugestões, abra uma issue no repositório ou consulte o log para troubleshooting.
