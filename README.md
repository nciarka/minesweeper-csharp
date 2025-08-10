# Minesweeper – gra konsolowa w C#

Projekt gry konsolowej „Minesweeper” w języku C#.  
Plansza o wymiarach 10×10 zawiera 15 bomb rozmieszczonych losowo przy każdym rozpoczęciu gry.  
Zadaniem gracza jest odkrywanie pól oraz oznaczanie podejrzanych miejsc flagą.  
Rozgrywka kończy się odkryciem bomby (przegrana) lub odsłonięciem wszystkich pól bez bomb bądź poprawnym oznaczeniem wszystkich bomb (wygrana).

## Zawartość repozytorium:
- `Minesweeper.sln` – plik projektu Visual Studio
- `Minesweeper.csproj` – plik projektu C#
- `Program.cs` – główny plik z kodem

## Funkcjonalności:
- losowe rozmieszczanie bomb
- liczenie bomb wokół wybranego pola
- odkrywanie pól i oznaczanie flagami
- warunki wygranej i przegranej

## Uruchomienie:
1. Otwórz plik `Minesweeper.sln` w Visual Studio  
2. Uruchom grę  
3. W konsoli:
   - wybierz akcję:
     - `u` – odkrycie pola  
     - `f` – oznaczenie pola flagą  
   - podaj wiersz i kolumnę – liczby z zakresu `0–9`

**Autor**  
Natalia Ciarka  
GitHub: [nciarka](https://github.com/nciarka)

---

## English version

# Minesweeper – Console Game in C#

Console-based “Minesweeper” game written in C#.  
The 10×10 board contains 15 bombs placed randomly at the start of each game.  
The player’s goal is to uncover fields and flag suspicious ones.  
The game ends when a bomb is uncovered (loss) or when all safe fields are uncovered or all bombs are correctly flagged (win).

## Repository contents:
- `Minesweeper.sln` – Visual Studio project file
- `Minesweeper.csproj` – C# project file
- `Program.cs` – main source file

## Features:
- Random bomb placement
- Counting bombs around a selected field
- Uncovering fields and placing flags
- Win and loss conditions

## How to run:
1. Open `Minesweeper.sln` in Visual Studio  
2. Start the game  
3. In the console:
   - choose an action:
     - `u` – uncover a field  
     - `f` – flag a field  
   - enter the row and column – numbers in the range `0–9`

**Author**  
Natalia Ciarka  
GitHub: [nciarka](https://github.com/nciarka)
