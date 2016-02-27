$(window).onload(start());
function start()
{
    wydarzenia();
}
function wydarzenia()
{
    var wyd = document.getElementById("listaWydarzen");
    for(var i = 0; i < 5; i ++)
    {
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
}