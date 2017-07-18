$(document).ready(function () {

    var Team_id = "0";
    var Team1_id = "0";
    var Team2_id = "0";
    var Tournament_id = "0";


    $("#BtnCreateTeam").click(function () {
        var name = $('#TxtNameTeam').val();
        CreateTeam(name);
    });

    $("#BtnAddPlayer").click(function () {
        var name = $('#TxtNamePlayer').val();
        AddPlayerTeam(name, Team_id);
    });

    $('#SelTeamList').change(function () {
        var e = document.getElementById("SelTeamList");
        Team_id = e.options[e.selectedIndex].index;
    });

    $('#SelTeam1List').change(function () {
        var e = document.getElementById("SelTeam1List");
        Team1_id = e.options[e.selectedIndex].index;
    });

    $('#SelTeam2List').change(function () {
        var e = document.getElementById("SelTeam2List");
        Team2_id = e.options[e.selectedIndex].index;
    });

    $('#SelTournamentList').change(function () {
        var e = document.getElementById("SelTournamentList");
        Tournament_id = e.options[e.selectedIndex].index;
    });

    $("#BtnCreateTournament").click(function () {
        var name = $('#TxtTournament').val();
        var rounds = $('#TxtQtdRounds').val();
        CreateTournament(name, "1", Team1_id, Team2_id);
    });

    $('#SelTeamListPlayers').change(function () {
        var e = document.getElementById("SelTeamListPlayers");
        Team_id = e.options[e.selectedIndex].index;
        LoadPlayers(Team_id);

    });

    $("#BtnPlay").click(function () {
        Play(Tournament_id);
    });


});

function CreateTeam(name) {

    if (name == "") {
        alert("Digite um nome");
        $('#TxtNameTeam').focus();
    }
    else {

        var team = { "name": name };

        $.ajax({
            url: '/api-v1/team',
            type: 'POST',
            data: JSON.stringify(team),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert("Time criado com sucesso");
                window.location.href = "/team";
            },
            error: function (request) {
                alert("Falha");
            }
        });

    }


}

function LoadPlayers(team_id) {

    $.ajax({
        url: '/api-v1/players?id=' + team_id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.stringify(data);
            var Content = JSON.parse(result);
            var Content_tr = "";

            $.each(Content, function (i, item) {
                Content_tr += "<tr><td>" + item.name + "</td></tr>";
            });

            $('#Content_tr').html(Content_tr);

        },
        error: function (request) {

        }
    });


}

function AddPlayerTeam(name, team_id) {

    if (name == "") {
        alert("Digite um nome");
        $('#TxtNamePlayer').focus();
    }
    else if (team_id == "0") {
        alert("Escolha o time para add jogador");
        $('#SelTeamList').focus();
    }
    else {

        var players = { "name": name, "team_id": team_id };

        $.ajax({
            url: '/api-v1/players',
            type: 'POST',
            data: JSON.stringify(players),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert("Jogador adicionado com sucesso");
                window.location.href = "/players";
            },
            error: function (request) {
                alert("Falha");
            }
        });

    }


}

function CreateTournament(name, QtdRounds, team1, team2) {
    if (name == "") {
        alert("Digite um nome para o torneio");
        $('#TxtTournament').focus();
    }

        //else if (QtdRounds == "") {
        //    alert("Digite a quantidade de luta");
        //    $('#QtdRounds').focus();
        //}

    else if (team1 == "0" || team1 == "0") {
        alert("Escolha os times que vão lutar");
        $('#SelectTeam1').focus();
    }
    else {

        var team = { "name": name, "rounds": QtdRounds, "team1": team1, "team2": team2 };
        $.ajax({
            url: '/api-v1/tournament',
            type: 'POST',
            data: JSON.stringify(team),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert("Torneio criado com sucesso");
                window.location.href = "/team";
            },
            error: function (request) {
                alert("Falha");
            }
        });

    }


}

function Play(tournament_id) {
    if (tournament_id == "0") {
        alert("Escolha um torneio para começar a jogar");
        $('#SelTournamentList').focus();
    }
    else {
        $('#winner_team').html("<img src=\"/Content/img/anime.gif\" />");
        $.ajax({
            url: '/api-v1/play?id=' + tournament_id,
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $('#winner_team').html("");
                var result = JSON.stringify(data);
                var Content = JSON.parse(result);

                $.each(Content, function (i, item) {
                    $('#team1').html(item.team1_id_versus);
                    $('#team2').html(item.team2_id_versus);
                    $('#points1').html(item.team1_points);
                    $('#points2').html(item.team2_points);
                    $('#winner_team').html(" <p><img src=\"/Content/img/trophy.png\" /></p><h2 class=\"font-red\">" + item.WinningTeam + "</h2>");
                });
               
            },
            error: function (request) {

            }
        });
    }


}