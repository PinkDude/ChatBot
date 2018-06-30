$(document).ready(function () {
    addIds('Users', 'label', 'lab');
    addIds('Users', 'input', 'inplab');
})

function addIds(container, elName, prefix) {
    var container = document.getElementById(container);
    var tables = container.getElementsByTagName(elName);

    for (var i = 0; i < tables.length; i++) {
        tables[i].id = prefix + (i + 1);

    }

}

function Func1(id = "Выберите пользователя", mes, a1, a2, a3, agl1, agl2, agl3, cl) {
    if (document.getElementById(cl).style.background != 'brown') {
        document.getElementById(cl).style.color = 'blue';
        document.getElementById("nowLab").innerHTML = cl;
        document.getElementById("topbar").innerHTML = id;
        document.getElementById("messages").innerHTML = mes;
        document.getElementById("label1").innerHTML = a1;
        document.getElementById("label2").innerHTML = a2;
        document.getElementById("label3").innerHTML = a3;
        document.getElementById('label1').style.visibility = "visible";
        document.getElementById('label2').style.visibility = "visible";
        document.getElementById('label3').style.visibility = "visible";
        document.getElementById("agil1").innerHTML = agl1;
        document.getElementById("agil2").innerHTML = agl2;
        document.getElementById("agil3").innerHTML = agl3;
        document.getElementById("nowLab").innerHTML = cl;
    }
}