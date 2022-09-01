"use strict";

var noticeConnection = new signalR.HubConnectionBuilder().withUrl("/NoticeHub").build();

noticeConnection.on("ReceiveNotice", function (notice) {

    let totalNotificationCount = 0;
    let noticeString = `<h6 class="mt-3 mb-1 text-dark">`;
    let noticeJson = JSON.parse(notice);
    $.each(noticeJson, function (i, v) {      
        noticeString += `<i class="fas fa-bullhorn text-primary mr-2 ml-2"></i><span class="text-danger pl-1 pr-1">${++i}. ${v.NoticeTitle}</span>`;
    });
    noticeString += `</h6 >`;
    if (noticeJson.length > 0) {
        $('#currentNotice').html(noticeString); 
        $("#divNotice").show();
        var showMarque = document.getElementById('divNotice');
        showMarque.getElementsByTagName('marquee')[0].start();
        
        //$("#divNotice").removeClass('d-none');
    } else {
        $('#currentNotice').html('');
        $("#divNotice").hide();
        //$("#divNotice").addClass('d-none');
    }
});


function noticeConnectionStart() {

    noticeConnection.start().then(function () {
        SendNotice();
    }).catch(function (err) {
        return console.error(err.toString());
    });
}

noticeConnection.onclose(connectionStart);

noticeConnectionStart();

function SendNotice() {
    noticeConnection.invoke("SendNotice", "").catch(function (err) {
        return console.error(err.toString());
    });
}