

function goMessage(id) {
    var x = document.getElementById(id).innerHTML;
    var jo = {
        Number: document.getElementById('topbar').innerHTML,
        Request: document.getElementById('messages').innerHTML,
        Response: [[document.getElementById('label1').innerHTML, document.getElementById('agil1').innerHTML], [document.getElementById('label2').innerHTML, document.getElementById('agil2').innerHTML], [document.getElementById('label3').innerHTML, document.getElementById('agil3').innerHTML]],
        OperatorVar: x
    }
    //TODO : доделай чтоб он помечался только после успешной отправки
    var nowLab = document.getElementById('nowLab').innerHTML;
    document.getElementById(nowLab).style.background = 'brown';

    document.getElementById('topbar').innerHTML = "";
    document.getElementById('messages').innerHTML = "";
    document.getElementById('label1').innerHTML = "";
    document.getElementById('label2').innerHTML = "";
    document.getElementById('label3').innerHTML = "";

    $.ajax({
        type: "POST",
        data: { jo },
        url: "/Home/GetAnswer",
        accept: 'application / json',
        success: function (data) {
        },
        error: function (result) {
            alert("Something Went Wrong");

        }

    })
    document.getElementById('label1').style.visibility = "hidden";
    document.getElementById('label2').style.visibility = "hidden";
    document.getElementById('label3').style.visibility = "hidden";
}