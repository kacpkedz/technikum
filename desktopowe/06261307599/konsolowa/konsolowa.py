import itertools

# /********************************************************
#  * nazwa funkcji: dane
#  * parametry wejściowe: sciezka_pliku - ścieżka do pliku z danymi
#  * wartość zwracana: lista krotek zawierających liczby i słowa
#  * autor: PESEL
#  ********************************************************/

def wczytaj(sciezka_pliku):
    """Wczytuje dane z podanego pliku i zwraca listę krotek."""
    try:
        # Otwieranie pliku w trybie odczytu. Przy błędzie (np. brak pliku) program przejdzie do bloku except.
        with open(sciezka_pliku, 'r') as plik:
            dane = [linia.strip().split() for linia in plik]
            # Przetwarza wczytane linie na listę krotek, gdzie pierwszym elementem jest liczba, a drugim słowo.
            return [(int(liczba), slowo) for liczba, slowo in dane]
    except Exception as e:
        # Obsługa błędu podczas otwierania lub przetwarzania pliku.
        print(f"Błąd podczas wczytywania pliku: {e}")
        return []

# /********************************************************
#  * nazwa funkcji: pary
#  * parametry wejściowe: dane - lista krotek liczba-słowo
#  * wartość zwracana: brak
#  * autor: PESEL
#  ********************************************************/

def pary(dane):
    """Znajduje i wypisuje pary, gdzie długość słowa odpowiada podanej liczbie."""
    print("\nPary, gdzie długość słowa odpowiada liczbie:")
    # Iteruje przez wszystkie krotki w danych, aby znaleźć pary, gdzie długość słowa odpowiada liczbie.
    for liczba, slowo in dane:
        # Sprawdza, czy długość słowa jest równa podanej liczbie.
        if len(slowo) == liczba:
            print(f"{slowo} (Długość: {len(slowo)})")

# /********************************************************
#  * nazwa funkcji: blizniaki
#  * parametry wejściowe: dane - lista krotek liczba-słowo
#  * wartość zwracana: brak
#  * autor: PESEL
#  ********************************************************/

def blizniaki(dane):
    """Znajduje i wypisuje słowa będące anagramami (bliźniakami)."""
    print("\nSłowa bliźniacze (anagramy):")
    # Grupowanie danych według posortowanych liter w słowach, co umożliwia znalezienie anagramów.
    pogrupowane = itertools.groupby(sorted(dane, key=lambda x: sorted(x[1])), key=lambda x: sorted(x[1]))
    for _, grupa in pogrupowane:
        blizniaki = list(grupa)
        # Sprawdza, czy grupa zawiera więcej niż jedno słowo, co oznacza, że są to anagramy.
        if len(blizniaki) > 1:
            slowa = [slowo for _, slowo in blizniaki]
            print(f"{' , '.join(slowa)}")

if __name__ == "__main__":
    # Ścieżka do pliku zawierającego dane.
    sciezka_pliku = "C:\\Users\\t4\\Desktop\\PESEL\\konsola\\pliki\\dane.txt"
    # Wczytywanie danych z pliku.
    dane = wczytaj(sciezka_pliku)
    if dane:
        # Wywołanie funkcji pary.
        pary(dane)
        # Wywołanie funkcji blizniaki.
        blizniaki(dane)