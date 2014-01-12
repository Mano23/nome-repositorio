function Falha() {
    $('.alerta').remove();
    $('.alerta-error').remove();
    $("body").append("<div class='alerta-error'><strong>Ocorreu um erro inesperado!</strong> Sistema indisponível no momento por favor, tente novamente mais tarde.</div>");
    CenterItem(".alerta-error");
    setTimeout(function () {
        $('.alerta-error').fadeOut(1000);
    }, 10000);
}
function Carregando() {
    $('.alerta').remove();
    $("body").append("<div class='alerta'>Carregando...</div>");
    $("input").attr("disabled", "disabled");
    $("select").attr("disabled", "disabled");
    $("textarea").attr("disabled", "disabled");
    $(".btn").attr("disabled", "disabled");
    CenterItem(".alerta");
}
function Sucesso(data) {
    $('.alerta').remove();
    if (!data.Erro) {
        if (!data.NaoLimpa) {
            $("input:text").val("");
            $("input:password").val("");
            $("select").val("");
            $("textarea").val("");
        }
        if (data.Msg) {
            $("body").append("<div class='alerta'>" + data.Msg + "</div>");
        }
        else if (data.Ajax) {
            $.ajax({
                type: "POST",
                url: data.Ajax,
                success: function (data) {
                    Sucesso(data);
                },
                complete: function () {
                    Completo();
                },
                beforeSend: function () {
                    Carregando();
                },
                error: function () {
                    Falha();
                }
            });
        }
        else {
            $("body").append("<div class='alerta'>Redirecionando...</div>");
            window.location = data.Url;
        }
    }
    else {
        if (data.Msg) {
            $("body").append("<div class='alerta alerta-error'>" + data.Msg + "</div>");
        }
        else {
            $("body").append("<div class='alerta-error'><strong>Ocorreu um erro inesperado!</strong> Sistema indisponível no momento por favor, tente novamente mais tarde.</div>");
        }
    }
    CenterItem(".alerta");
}
function Completo() {
    $("input").removeAttr("disabled");
    $("select").removeAttr("disabled");
    $("textarea").removeAttr("disabled");
    $(".btn").removeAttr("disabled");
    $(".disabled").attr("disabled", "disabled");
    fechaalerta();
}
function SucessoFim() {
    $('.alerta').remove();
}
function fechaalerta() {
    setTimeout(function () {
        $('.alerta').fadeOut(1000);
    }, 10000);
}
function CenterItem(theItem) {
    var w = $(window);
    $(theItem).css("left", (w.width() - $(theItem).width()) / 2 + w.scrollLeft() + "px");
    $(theItem).attr("onclick", "$('" + theItem + "').fadeOut(500)");
}
function CompletoSemMensagem() {
    $("input").removeAttr("disabled");
    $("select").removeAttr("disabled");
    $("textarea").removeAttr("disabled");
    $(".alternativa").removeAttr("disabled");
    $(".btn").removeAttr("disabled");
    $('.alerta').remove();
}

$(function () {
    $(".date").mask("99/99/9999");
    $(".tel").mask("(99)9999-9999?9");
    $(".cpf").mask("999.999.999-99");
    $(".cnpj").mask("99.999.999/9999-99");
    $(".placa").mask("aaa - 9999");
    $(".cep").mask("99999-999");
    $(".hora").mask("99:99");
});
$(".datepicker").datepicker();

$(document).ready(function () {
    $.ajaxSetup({
        cache: false
    });
});