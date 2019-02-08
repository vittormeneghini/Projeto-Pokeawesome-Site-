function AddPlayer() {

    $.ajax({
        type: "POST",
        url: "/Account/AddPlayer",
        success: function (partialView) {
            $("#div-players").hide();
            $("#div-btn-adicionar-personagem").hide();
            $("#div-register-players").append(partialView);
        },
        error: function (error) {
            alert("Problemas ao carregar registro do player");
        }
    });
}


function RegisterPlayer() {

    var name = $("#txt-name-player").val();
    var gender = $("input[name='gender-radio']:checked").val();


    if (!name || !gender) {
        swal("Problemas!", "Preencha a ficha completa para criar um personagem.", "error");        
        return;
    }

    if (name.length < 8) {
        swal("Problemas!", "O campo nome precisa ter no mínimo 8 caractéres.", "error");        
        return;
    }

    var params = {
        "Name": name,
        "Gender": gender 
    };

    $.ajax({
        type: "POST",
        url: "/Account/RegisterPlayer",
        data: {player: params},
        dataType: "json",
        success: function (data) {
            if (data.data) {
                $("#txt-name-player").val("");                

                swal("Parabéns!", data.response, "success");
                window.location.reload();
            }
            else {
                swal("Problemas!", data.response, "error");
            }
            
        },
        error: function (error) {
            alert("Problemas ao cadastrar player");
        }
    });

}


function AddAlterPassword() {
    $.ajax({
        type: "POST",
        url: "/Account/AddAlterPassword",
        success: function (partialView) {
            $("#div-form-account").hide();   
            $("#div-form-email-senha").show();
            $("#div-form-email-senha").append(partialView);
        },
        error: function (error) {
            alert("Problemas ao carregar registro do player");
        }
    });
}

function AlterPassword() {
    var senhaNova = $('#txt-senha-nova-player').val();
    var confirmSenhaNova = $('#txt-confirm-senha-nova-player').val();
    var senhaAntiga = $('#txt-senha-antiga-player').val();


    if (!senhaNova || !confirmSenhaNova || !senhaAntiga) {
        swal("Problemas!", "Preencha a ficha completa para prosseguir com a alteração da senha.", "error");
        return;
    }

    if (senhaNova != confirmSenhaNova) {
        swal("Problemas!", "Os campos nova senha e confirma nova senha não são iguais.", "error");        
        return;
    }

    var params = {
        "SenhaNova": senhaNova,
        "SenhaAntiga": senhaAntiga
    };
   
    $.ajax({
        type: "POST",
        url: "/Account/AlterPassword",
        data: { player: params },
        dataType: "json",
        success: function (data) {
            if (data.data) {
                $("#div-form-account").show(); 
                $("#div-form-email-senha").hide();
                swal("Parabéns!", data.response, "success");
            }
            else {
                swal("Problemas!", data.response, "error");
            }
        },
        error: function (error) {
            alert("Problemas ao alterar senha");
        }
    });
    
}


function deletePlayer(id) {
    $.ajax({
        type: "POST",
        url: "/Account/DeletePlayer",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            if (data.data) {
                swal("Parabéns!", data.response, "success");
                window.location.reload();
            }
            else {
                swal("Problemas!", data.response, "error");
            }
        },
        error: function (error) {
            alert("Problemas ao deletar player");
        }
    });
}