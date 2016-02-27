$(window).onload(start());
function start()
{
    getEvents();
}
function getEvents() {
    var wyd = document.getElementById("listaWydarzen");
    return $.ajax({
        url: 'Map/GetTrees',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (results) {
            for (var i = 0; i < results.length; i++) {
                var divik = document.createElement("div");
                var obrazek = document.createElement("img");
                obrazek.src = "~/Images/biegacz.png";
                var data = document.createElement("span");
                var miejsce = document.createElement("span");
                divik.appendChild(obrazek);
                divik.appendChild(data);
                divik.appendChild(miejsce);
                wyd.appendChild(divik)
            }
        },
        error: function () {
            alert('Error occured');
        }
    });
}
