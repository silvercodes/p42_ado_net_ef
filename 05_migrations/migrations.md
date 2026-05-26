## Основные команды миграций

| Действие | dotnet CLI | PMC (NuGet Package Console) |
|----------|------------|------------------------------|
| Создать новую миграцию | `dotnet ef migrations add <ИмяМиграции>` | `Add-Migration <ИмяМиграции>` |
| Применить миграции (обновить БД) | `dotnet ef database update` (или до конкретной: `dotnet ef database update <ИмяМиграции>`) | `Update-Database` (или `Update-Database -Migration <ИмяМиграции>`) |
| Удалить последнюю миграцию (до применения к БД) | `dotnet ef migrations remove` | `Remove-Migration` |
| Сгенерировать SQL-скрипт для миграций | `dotnet ef migrations script` | `Script-Migration` |
| Просмотреть список миграций | `dotnet ef migrations list` | `Get-Migration` (неофициально, лучше `Get-Migrations` из пакета `Microsoft.EntityFrameworkCore.Tools`) |
| Сбросить БД и применить все миграции с нуля | `dotnet ef database drop --force --dry-run` + `dotnet ef database update` | `Update-Database -Migration 0` (откат до нуля) |
| Получить контекст и информацию | `dotnet ef dbcontext info` | `Get-DbContext` |

## Сравнение синтаксиса и особенностей.

### Откат и удаление миграций
- **dotnet CLI**:  
  `dotnet ef migrations remove` удаляет последнюю миграцию **только если она не применена к БД**. Если применена, нужно сначала откатиться:  
  `dotnet ef database update <ПредыдущаяМиграция>`  
  (или `dotnet ef database update 0` для полного отката).
- **PMC**:  
  `Remove-Migration` также удаляет последнюю миграцию (без применения).  
  Откат: `Update-Database -Migration <ПредыдущаяМиграция>` или `Update-Database -Migration 0`.

### Генерация SQL-скрипта
- **dotnet CLI**:  
  `dotnet ef migrations script` – генерирует скрипт от начальной миграции до последней.  
  Можно указать `from` и `to`: `dotnet ef migrations script First Last`.
- **PMC**:  
  `Script-Migration` – работает аналогично, но синтаксис может отличаться (например, `Script-Migration -From First -To Last`).

## Краткая шпаргалка

| Задача | dotnet CLI | PMC |
|--------|------------|-----|
| Установка инструмента | `dotnet tool install --global dotnet-ef` | Установить NuGet пакет `Microsoft.EntityFrameworkCore.Tools` |
| Добавить миграцию | `dotnet ef migrations add Name` | `Add-Migration Name` |
| Обновить БД | `dotnet ef database update` | `Update-Database` |
| Удалить миграцию | `dotnet ef migrations remove` | `Remove-Migration` |
| Показать список | `dotnet ef migrations list` | `Get-Migrations` (если доступна) |
| Сгенерировать SQL | `dotnet ef migrations script` | `Script-Migration` |
