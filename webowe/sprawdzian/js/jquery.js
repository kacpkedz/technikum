$(document).ready(function() {
    let liczbaWierszy = 0;
    $('#dodaj_wiersz').click(function() {
        liczbaWierszy++;
        let kolorWiersza = (liczbaWierszy % 2 === 0) ? 'yellow' : '';
        $('#tabela').append(`
            <tr class="${kolorWiersza}">
                <td>${liczbaWierszy}</td>
                <td>Wiersz ${liczbaWierszy}</td>
            </tr>
        `);
    });

    $('#zmiana_koloru').click(function() {
        $('#tabela tr.yellow').removeClass('yellow').addClass('green');
    });
});