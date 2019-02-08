$("#form-contact").submit(function (e) {

    var name = $("#name").val();
    var email = $("#email").val();
    var subject = $("#subject").val();
    var message = $("#message").val();


    if (!name || !email || !subject || !message) {
        swal("Problemas!", "Preencha a ficha completa para enviar uma mensagem.", "error");
        e.preventDefault();
    }



});
