# WeekendPlanner

## Beschreibung der Software

Der WeekendPlanner soll Benutzern ein einfache Möglichkeit bieten, sich über verschiedene Veranstaltungen wie Festivals, Bierzelte, Bälle, Partys und vieles mehr zu informieren und somit ihre kommenden Wochenenden zu planen. Die Events können von Usern hinzugefügt und von Admins bearbeitet, gelöscht oder veröffentlicht werden.

## Beschreibung der API
Das Rückgrat dieses Projektes stellt die ASP.Net API sowie die im Hintergrund laufende MongoDB Datenbank dar. Die API besteht grundsätzlich aus 3 Controllern inklusive Services, Schemas und MongoDB Collections sowie sämtlicher Server Middleware für die CORS-Regelung, Session Handling und Health Checks, was nun alles folgend näher beschrieben wird.

### Controller inkl. Services und Modelle

Grundsätzlich setzt sich jeder Zweig der API wie folgt zusammen: 
- Ein Controller in welchem die benötigten Endpoints spezifiziert werden
- Ein Service der die Verbindung zur Datenbank verwaltet und die damit verbundenen Aufgaben übernimmt
- Ein Schema bzw. Modell welches in der Collection gespeichert werden soll

Für dieses Projekt wurden wie bereits erwähnt 3 dieser Zweige implementiert, wobei der Zweig für die User- und für die Event-Verwaltung eine höhere Priorität haben und der dritte eher als Zwischenlager für noch nicht veröffentlichte Events gilt.

#### User-Verwaltung





