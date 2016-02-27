window.onload(onstart());

function onstart()
{
    //var pole_imie = document.getElementById("imie");
   // var pole_nazwisko = document.getElementById("nazwisko");
   // var wiek = document.getElementById("wiek");
  //  var starehaslo = document.getElementById("stare_haslo");
   // var nowehaslo1 = document.getElementById("nowe_haslo1");
   // var nowehaslo2 = document.getElementById("nowe_haslo2");
   // wczytaj_dane_profilowe();
   // var przycisk = document.getElementById("potwierdz_zmiany_profilu_button");
  //  przycisk.onclick(klikniecie());

}



function wczytaj_dane_profilowe()
{
    

    // teraz wczytam to do moich pól
    return $.ajax({
        url: 'Map/GetTrees', // jakies uri lel
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function () {
            pole_imie.textContent = "meine imie";
            pole_nazwisko.textContent = "meine nazwisko";
            wiek.textContent = 22;
            starehaslo.textContent = "poprzednie haslo 123";
        },
        error: function () {
            alert('Błąd wczytywania użytkownika');
        }
    });
}

function klikniecie()
{
    alert('lel kliknąłem');
}