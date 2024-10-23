$(document).ready(function() {
    $('#btnWyslij').hide()
    $('#imie').hide()

    $('#btnPodaj').click(function(){
        $('#imie').show()
        $('#btnWyslij').show()
    })

    $('#btnWyslij').click(function() {
        $('#btnWyslij').hide()
        $('#imie').hide()
        if ($('#imie').val() == "") {
            alert('Proszę podać imię!')
        } else {
            alert('Witaj ' + $('#imie').val())
        }
        $('#imie').val("")
    })
})